using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.FavoriteAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate;
using Equinor.Lighthouse.Api.Domain.Audit;
using Equinor.Lighthouse.Api.Domain.Events;
using Equinor.Lighthouse.Api.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Infrastructure;

public class ApplicationContext : DbContext, IUnitOfWork, IReadOnlyContext, IWriteContext 
{
    private readonly IPlantProvider _plantProvider;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly ICurrentUserProvider _currentUserProvider;

    public ApplicationContext(
        DbContextOptions<ApplicationContext> options,
        IPlantProvider plantProvider,
        IEventDispatcher eventDispatcher,
        ICurrentUserProvider currentUserProvider)
        : base(options)
    {
        _plantProvider = plantProvider;
        _eventDispatcher = eventDispatcher;
        _currentUserProvider = currentUserProvider;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SetGlobalPlantFilter(modelBuilder);
    }

    public static DateTimeKindConverter DateTimeKindConverter { get; } = new DateTimeKindConverter();
    public virtual DbSet<Responsible> Responsibles { get; set; }
    public virtual DbSet<Person> Persons { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<SavedFilter> SavedFilters { get; set; }
    public virtual DbSet<Setting> Settings { get; set; }
    public virtual DbSet<Activity> Activities { get; set; }
    //public virtual DbSet<WorkOrder> WorkOrders { get; set; }
    public virtual DbSet<LciObject> LciObjects { get; set; }

    public virtual DbSet<PortalSetting> PortalSettings { get; set; }
    public virtual DbSet<Favorite> Favorites { get; set; }

    private void SetGlobalPlantFilter(ModelBuilder modelBuilder)
    {
        // Set global query filter on entities inheriting from PlantEntityBase
        // https://gunnarpeipman.com/ef-core-global-query-filters/
        foreach (var type in TypeProvider.GetEntityTypes(typeof(IDomainMarker).GetTypeInfo().Assembly, typeof(PlantEntityBase)))
        {
            typeof(ApplicationContext)
                .GetMethod(nameof(ApplicationContext.SetGlobalQueryFilter))
                ?.MakeGenericMethod(type)
                .Invoke(this, new object[] { modelBuilder });
        }
    }

    public void SetGlobalQueryFilter<T>(ModelBuilder builder) where T : PlantEntityBase =>
        builder
            .Entity<T>()
            .HasQueryFilter(e => e.Plant == _plantProvider.Plant || _plantProvider.IsCrossPlantQuery);

    public IQueryable<TEntity> QuerySet<TEntity>() where TEntity : class => Set<TEntity>().AsNoTracking();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await DispatchEventsAsync(cancellationToken);
        await SetAuditDataAsync();
        try
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException concurrencyException)
        {
            throw new ConcurrencyException("Data store operation failed. Data may have been modified or deleted since entities were loaded.", concurrencyException);
        }
    }

    private async Task DispatchEventsAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker
            .Entries<EntityBase>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(x => x.Entity);
        await _eventDispatcher.DispatchAsync(entities, cancellationToken);
    }

    private async Task SetAuditDataAsync()
    {
        var addedEntries = ChangeTracker
            .Entries<ICreationAuditable>()
            .Where(x => x.State == EntityState.Added)
            .ToList();
        var modifiedEntries = ChangeTracker
            .Entries<IModificationAuditable>()
            .Where(x => x.State == EntityState.Modified)
            .ToList();

        if (addedEntries.Any() || modifiedEntries.Any())
        {
            var currentUserOid = _currentUserProvider.GetCurrentUserOid();
            var currentUser = await Persons.SingleOrDefaultAsync(p => p.Oid == currentUserOid);

            foreach (var entry in addedEntries)
            {
                entry.Entity.SetCreated(currentUser);
            }

            foreach (var entry in modifiedEntries)
            {
                entry.Entity.SetModified(currentUser);
            }
        }
    }
}

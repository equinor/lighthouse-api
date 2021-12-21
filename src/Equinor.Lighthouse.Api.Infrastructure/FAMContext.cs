using System.Reflection;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.Events;
using Equinor.Lighthouse.Api.Domain.FAMModels;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Infrastructure;

public class FAMContext : DbContext
{

    private readonly IPlantProvider _plantProvider;
    private readonly IEventDispatcher _eventDispatcher;
    private readonly ICurrentUserProvider _currentUserProvider;

    public FAMContext(
        DbContextOptions<FAMContext> options,
        IPlantProvider plantProvider,
        IEventDispatcher eventDispatcher,
        ICurrentUserProvider currentUserProvider)
        : base(options)
    {
        _plantProvider = plantProvider;
        _eventDispatcher = eventDispatcher;
        _currentUserProvider = currentUserProvider;
    }



    public virtual DbSet<McPkg> McPkgs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //SetGlobalPlantFilter(modelBuilder);
        modelBuilder
            .Entity<McPkg>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("Procosys_McPkg","Castberg");
            });


    }

}

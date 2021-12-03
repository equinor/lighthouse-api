using Equinor.Lighthouse.Api.BlobStorage;
using Equinor.Lighthouse.Api.Command.EventHandlers;
using Equinor.Lighthouse.Api.Command.Validators;
using Equinor.Lighthouse.Api.Command.Validators.ProjectValidators;
using Equinor.Lighthouse.Api.Command.Validators.ResponsibleValidators;
using Equinor.Lighthouse.Api.Command.Validators.SavedFilterValidators;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ResponsibleAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate;
using Equinor.Lighthouse.Api.Domain.Events;
using Equinor.Lighthouse.Api.Domain.Time;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Infrastructure.Caching;
using Equinor.Lighthouse.Api.Infrastructure.Repositories;
using Equinor.Lighthouse.Api.MainApi;
using Equinor.Lighthouse.Api.MainApi.Area;
using Equinor.Lighthouse.Api.MainApi.Certificate;
using Equinor.Lighthouse.Api.MainApi.Client;
using Equinor.Lighthouse.Api.MainApi.Discipline;
using Equinor.Lighthouse.Api.MainApi.Permission;
using Equinor.Lighthouse.Api.MainApi.Person;
using Equinor.Lighthouse.Api.MainApi.Plant;
using Equinor.Lighthouse.Api.MainApi.Project;
using Equinor.Lighthouse.Api.MainApi.Responsible;
using Equinor.Lighthouse.Api.WebApi.Misc;
using Equinor.Lighthouse.Api.WebApi.Authorizations;
using Equinor.Lighthouse.Api.WebApi.Caches;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Equinor.Lighthouse.Api.WebApi.Authentication;
using Equinor.Lighthouse.Api.WebApi.Telemetry;
using Microsoft.Extensions.DependencyInjection;

namespace Equinor.Lighthouse.Api.WebApi.DIModules;

public static class ApplicationModule
{
    public static void AddApplicationModules(this IServiceCollection services, IConfiguration configuration)
    {
        TimeService.SetProvider(new SystemTimeProvider());

        services.Configure<MainApiOptions>(configuration.GetSection("MainApi"));
        services.Configure<CacheOptions>(configuration.GetSection("CacheOptions"));
        services.Configure<BlobStorageOptions>(configuration.GetSection("BlobStorage"));
        services.Configure<AuthenticatorOptions>(configuration.GetSection("Authenticator"));

        services.AddDbContext<ApplicationContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection"); //TODO
            options.UseSqlServer(connectionString);
        });

        services.AddHttpContextAccessor();
        services.AddHttpClient();
        // Transient - Created each time it is requested from the service container

        // Scoped - Created once per client request (connection)
        services.AddScoped<ITelemetryClient, ApplicationInsightsTelemetryClient>();
        services.AddScoped<IPersonCache, PersonCache>();
        services.AddScoped<IPlantCache, PlantCache>();
        services.AddScoped<IPermissionCache, PermissionCache>();
        services.AddScoped<IClaimsTransformation, ClaimsTransformation>();
        services.AddScoped<IClaimsProvider, ClaimsProvider>();
        services.AddScoped<CurrentUserProvider>();
        services.AddScoped<ICurrentUserProvider>(x => x.GetRequiredService<CurrentUserProvider>());
        services.AddScoped<ICurrentUserSetter>(x => x.GetRequiredService<CurrentUserProvider>());
        services.AddScoped<PlantProvider>();
        services.AddScoped<IPlantProvider>(x => x.GetRequiredService<PlantProvider>());
        services.AddScoped<IPlantSetter>(x => x.GetRequiredService<PlantProvider>());
        services.AddScoped<IAccessValidator, AccessValidator>();
        services.AddScoped<IProjectChecker, ProjectChecker>();
        services.AddScoped<IProjectAccessChecker, ProjectAccessChecker>();
        services.AddScoped<IContentRestrictionsChecker, ContentRestrictionsChecker>();
        services.AddScoped<IEventDispatcher, EventDispatcher>();
        services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationContext>());
        services.AddScoped<IReadOnlyContext, ApplicationContext>();

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IResponsibleRepository, ResponsibleRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ISettingRepository, SettingRepository>();

        services.AddScoped<Authenticator>();
        services.AddScoped<IBearerTokenProvider>(x => x.GetRequiredService<Authenticator>());
        services.AddScoped<IBearerTokenSetter>(x => x.GetRequiredService<Authenticator>());
        services.AddScoped<IAuthenticator>(x => x.GetRequiredService<Authenticator>());
        services.AddScoped<IBearerTokenApiClient, BearerTokenApiClient>();
        services.AddScoped<IPlantApiService, MainApiPlantService>();
        services.AddScoped<IPersonApiService, MainApiPersonService>();
        services.AddScoped<IProjectApiService, MainApiProjectService>();
        services.AddScoped<IAreaApiService, MainApiAreaService>();
        services.AddScoped<IDisciplineApiService, MainApiDisciplineService>();
        services.AddScoped<IResponsibleApiService, MainApiResponsibleService>();
        services.AddScoped<IPermissionApiService, MainApiPermissionService>();
        services.AddScoped<ICertificateApiService, MainApiCertificateService>();
        services.AddScoped<IBlobStorage, AzureBlobService>();

        services.AddScoped<IProjectValidator, ProjectValidator>();
        services.AddScoped<IResponsibleValidator, ResponsibleValidator>();
        services.AddScoped<IRowVersionValidator, RowVersionValidator>();
        services.AddScoped<ISavedFilterValidator, SavedFilterValidator>();

        // Singleton - Created the first time they are requested
        services.AddSingleton<ICacheManager, CacheManager>();
    }
}

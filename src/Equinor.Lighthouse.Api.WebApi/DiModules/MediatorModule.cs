using System.Reflection;
using Equinor.Lighthouse.Api.Command;
using Equinor.Lighthouse.Api.Query;
using Equinor.Lighthouse.Api.WebApi.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Equinor.Lighthouse.Api.WebApi.DIModules
{
    public static class MediatorModule
    {
        public static void AddMediatrModules(this IServiceCollection services)
        {
            services.AddMediatR(
                typeof(MediatorModule).GetTypeInfo().Assembly,
                typeof(ICommandMarker).GetTypeInfo().Assembly,
                typeof(IQueryMarker).GetTypeInfo().Assembly
            );
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CheckValidProjectBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CheckAccessBehavior<,>));
        }
    }
}

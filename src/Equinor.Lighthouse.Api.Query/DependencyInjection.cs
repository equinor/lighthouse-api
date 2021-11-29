using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Equinor.Lighthouse.Api.Query;

public static class DependencyInjection
{
    public static IServiceCollection AddQueryApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}

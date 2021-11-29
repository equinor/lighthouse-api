using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.MainApi.Person;
using Equinor.Lighthouse.Api.WebApi.Misc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Equinor.Lighthouse.Api.WebApi.Middleware;

public class PersonValidatorMiddleware
{
    private readonly RequestDelegate _next;

    public PersonValidatorMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(
        HttpContext context,
        ICurrentUserProvider currentUserProvider,
        IPersonCache personCache,
        ILogger<PersonValidatorMiddleware> logger)
    {
        logger.LogInformation($"----- {GetType().Name} start");
        if (currentUserProvider.HasCurrentUser())
        {
            var oid = currentUserProvider.GetCurrentUserOid();
            if (!await personCache.ExistsAsync(oid))
            {
                await context.WriteForbidden(logger);
                return;
            }
        }

        logger.LogInformation($"----- {GetType().Name} complete");
        // Call the next delegate/middleware in the pipeline
        await _next(context);
    }
}

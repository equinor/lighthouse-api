using System.Threading.Tasks;
using Equinor.Lighthouse.Api.WebApi.Misc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Equinor.Lighthouse.Api.WebApi.Middleware;

public class CurrentBearerTokenMiddleware
{
    private readonly RequestDelegate _next;

    public CurrentBearerTokenMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(
        HttpContext context,
        IHttpContextAccessor httpContextAccessor,
        IBearerTokenSetter bearerTokenSetter,
        ILogger<CurrentBearerTokenMiddleware> logger)
    {
        logger.LogInformation($"----- {GetType().Name} start");
        var authorizationHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        var tokens = authorizationHeader.ToString()?.Split(' ');

        if (tokens is { Length: > 1 })
        {
            var token = tokens[1];
            bearerTokenSetter.SetBearerToken(token);
        }

        logger.LogInformation($"----- {GetType().Name} complete");
        // Call the next delegate/middleware in the pipeline
        await _next(context);
    }
}

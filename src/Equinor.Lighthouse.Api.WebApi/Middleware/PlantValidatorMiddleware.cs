using System.Collections.Generic;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.MainApi.Plant;
using Equinor.Lighthouse.Api.WebApi.Misc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Equinor.Lighthouse.Api.WebApi.Middleware
{
    public class PlantValidatorMiddleware
    {
        private readonly RequestDelegate _next;

        public PlantValidatorMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(
            HttpContext context,
            IPlantProvider plantProvider,
            IPlantCache plantCache,
            ILogger<PlantValidatorMiddleware> logger)
        {
            logger.LogInformation($"----- {GetType().Name} start");
            var plantId = plantProvider.Plant;
            if (context.User.Identity.IsAuthenticated && plantId != null)
            {
                if (!await plantCache.IsAValidPlantAsync(plantId))
                {
                    var errors = new Dictionary<string, string[]>
                    {
                        {CurrentPlantMiddleware.PlantHeader, new[] {$"Plant '{plantId}' is not a valid plant"}}
                    };
                    await context.WriteBadRequestAsync(errors, logger);
                    return;
                }
            }

            logger.LogInformation($"----- {GetType().Name} complete");
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}

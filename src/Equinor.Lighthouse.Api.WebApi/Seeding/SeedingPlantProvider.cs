using Equinor.Lighthouse.Api.Domain;

namespace Equinor.Lighthouse.Api.WebApi.Seeding;

public class SeedingPlantProvider : IPlantProvider
{
    public SeedingPlantProvider(string plant) => Plant = plant;

    public string Plant { get; }
    public bool IsCrossPlantQuery => false;
}

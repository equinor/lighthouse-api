using Equinor.Lighthouse.Api.Domain;

namespace Equinor.Lighthouse.Api.Test.Common
{
    public class PlantProvider : IPlantProvider, IPlantSetter
    {
        public PlantProvider(string plant) => Plant = plant;

        public string Plant { get; private set; }
        public bool IsCrossPlantQuery { get; private set; }

        public void SetPlant(string plant) => Plant = plant;
        public void SetCrossPlantQuery() => IsCrossPlantQuery = true;
        public void ClearCrossPlantQuery() => IsCrossPlantQuery = false;
    }
}

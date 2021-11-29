namespace Equinor.Lighthouse.Api.Domain
{
    public interface IPlantSetter
    {
        void SetPlant(string plant);
        void SetCrossPlantQuery();
        void ClearCrossPlantQuery();
    }
}

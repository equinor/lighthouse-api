namespace Equinor.Lighthouse.Api.Domain;

public interface IPlantProvider
{
    string Plant { get; }
    bool IsCrossPlantQuery { get; }
}
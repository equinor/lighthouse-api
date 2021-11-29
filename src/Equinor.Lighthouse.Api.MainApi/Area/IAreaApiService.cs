using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Area
{
    public interface IAreaApiService
    {
        Task<PCSArea> TryGetAreaAsync(string plant, string code);
    }
}

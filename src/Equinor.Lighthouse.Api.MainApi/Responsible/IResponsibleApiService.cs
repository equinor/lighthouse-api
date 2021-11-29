using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Responsible
{
    public interface IResponsibleApiService
    {
        Task<PCSResponsible> TryGetResponsibleAsync(string plant, string code);
    }
}

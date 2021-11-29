using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.TagFunction;

public interface ITagFunctionApiService
{
    Task<PCSTagFunction> TryGetTagFunctionAsync(string plant, string tagFunctionCode, string registerCode);
}
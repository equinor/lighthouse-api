using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Client;

public interface IBearerTokenProvider
{
    ValueTask<string> GetBearerTokenAsync();
}
using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.MainApi.Project;

public interface IProjectApiService
{
    Task<PCSProject> TryGetProjectAsync(string plant, string name);
}
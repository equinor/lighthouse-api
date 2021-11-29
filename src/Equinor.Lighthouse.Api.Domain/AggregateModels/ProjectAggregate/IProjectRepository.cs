using System.Threading.Tasks;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.ProjectAggregate;

public interface IProjectRepository : IRepository<Project>
{
    Task<Project> GetProjectOnlyByNameAsync(string projectName);
}
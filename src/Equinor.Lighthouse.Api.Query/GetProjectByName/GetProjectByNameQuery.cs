using Equinor.Lighthouse.Api.Domain;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.GetProjectByName;

public class GetProjectByNameQuery : IRequest<Result<ProjectDetailsDto>>, IProjectRequest
{
    public GetProjectByNameQuery(string projectName) => ProjectName = projectName;

    public string ProjectName { get; }
}
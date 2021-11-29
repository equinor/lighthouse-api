namespace Equinor.Lighthouse.Api.WebApi.Authorizations;

public interface IProjectAccessChecker
{
    bool HasCurrentUserAccessToProject(string projectName);
}
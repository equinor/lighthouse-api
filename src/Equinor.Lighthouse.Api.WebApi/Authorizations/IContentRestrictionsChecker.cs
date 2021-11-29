namespace Equinor.Lighthouse.Api.WebApi.Authorizations;

public interface IContentRestrictionsChecker
{
    bool HasCurrentUserExplicitNoRestrictions();
    bool HasCurrentUserExplicitAccessToContent(string responsibleCode);
}
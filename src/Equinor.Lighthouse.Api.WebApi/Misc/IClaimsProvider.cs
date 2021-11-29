using System.Security.Claims;

namespace Equinor.Lighthouse.Api.WebApi.Misc;

public interface IClaimsProvider
{
    ClaimsPrincipal GetCurrentUser();
}
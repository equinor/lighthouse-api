using Microsoft.AspNetCore.Authorization;

namespace Equinor.Lighthouse.Api.WebApi;

public class AuthorizeAnyAttribute : AuthorizeAttribute
{
    public AuthorizeAnyAttribute()
    {
    }

    public AuthorizeAnyAttribute(params string[] permissions) => Roles = string.Join(",", permissions);
}
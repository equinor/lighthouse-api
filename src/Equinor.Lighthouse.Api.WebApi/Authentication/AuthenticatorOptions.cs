using System;

namespace Equinor.Lighthouse.Api.WebApi.Authentication;

public class AuthenticatorOptions
{
    public string? Instance { get; set; }

    public string? LighthouseApiClientId { get; set; } //TODO rename
    public Guid LighthouseApiObjectId { get; set; }
    public string? LighthouseApiSecret { get; set; }

    public string? MainApiScope { get; set; }
        
    public string? GlobalSetting { get; set; }
    public string? ScopedSetting { get; set; }
}

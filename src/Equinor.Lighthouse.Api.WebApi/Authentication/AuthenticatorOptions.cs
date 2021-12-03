﻿using System;

namespace Equinor.Lighthouse.Api.WebApi.Authentication;

public class AuthenticatorOptions
{
    public string? Instance { get; set; }

    public string? PreservationApiClientId { get; set; } //TODO rename
    public Guid PreservationApiObjectId { get; set; }
    public string? PreservationApiSecret { get; set; }

    public string? MainApiScope { get; set; }
        
    public string? GlobalSetting { get; set; }
    public string? ScopedSetting { get; set; }
}

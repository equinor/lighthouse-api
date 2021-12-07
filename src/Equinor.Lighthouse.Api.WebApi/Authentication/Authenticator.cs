using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.MainApi.Client;
using Equinor.Lighthouse.Api.WebApi.Misc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace Equinor.Lighthouse.Api.WebApi.Authentication;

public class Authenticator : IBearerTokenProvider, IBearerTokenSetter, IAuthenticator
{
    private readonly IOptions<AuthenticatorOptions> _options;
    private readonly ILogger<Authenticator> _logger;
    private string _requestToken;
    private string? _onBehalfOfUserToken;
    private string? _applicationToken;
    private readonly string _secretInfo;

    public Authenticator(IOptions<AuthenticatorOptions> options, ILogger<Authenticator> logger)
    {
        _options = options;
        _logger = logger;
        var apiSecret = _options.Value.LighthouseApiSecret;
        _secretInfo = $"{apiSecret?[..2]}***{apiSecret?.Substring(apiSecret.Length - 1, 1)}";
        AuthenticationType = AuthenticationType.OnBehalfOf;
    }
        
    public AuthenticationType AuthenticationType { get; set; }

    public void SetBearerToken(string token) => _requestToken = token;

    public async ValueTask<string> GetBearerTokenAsync()
    {
        _logger.LogInformation($"Global setting=[{_options.Value.GlobalSetting}]");
        _logger.LogInformation($"Scoped setting=[{_options.Value.ScopedSetting}]");

        return AuthenticationType switch
        {
            AuthenticationType.OnBehalfOf => await GetBearerTokenOnBehalfOfCurrentUserAsync(),
            AuthenticationType.AsApplication => await GetBearerTokenForApplicationAsync(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private async ValueTask<string> GetBearerTokenOnBehalfOfCurrentUserAsync()
    {
        if (_onBehalfOfUserToken != null)
        {
            return _onBehalfOfUserToken;
        }

        if (string.IsNullOrEmpty(_requestToken))
        {
            throw new ArgumentNullException(nameof(_requestToken));
        }

        var app = CreateConfidentialPreservationClient();

        var tokenResult = await app
            .AcquireTokenOnBehalfOf(new List<string?> { _options.Value.MainApiScope }, new UserAssertion(_requestToken))
            .ExecuteAsync();
        _logger.LogInformation("Got token on behalf of");

        _onBehalfOfUserToken = tokenResult.AccessToken;
        return _onBehalfOfUserToken;

    }

    private async ValueTask<string> GetBearerTokenForApplicationAsync()
    {
        if (_applicationToken != null)
        {
            return _applicationToken;
        }

        var app = CreateConfidentialPreservationClient();

        var tokenResult = await app
            .AcquireTokenForClient(new List<string> { _options.Value.MainApiScope })
            .ExecuteAsync();
        _logger.LogInformation("Got token for application");

        _applicationToken = tokenResult.AccessToken;
        return _applicationToken;
    }

    private IConfidentialClientApplication CreateConfidentialPreservationClient()
    {
        _logger.LogInformation($"Getting client using {_secretInfo} for {_options.Value.LighthouseApiClientId}");
        return ConfidentialClientApplicationBuilder
            .Create(_options.Value.LighthouseApiClientId)
            .WithClientSecret(_options.Value.LighthouseApiSecret)
            .WithAuthority(new Uri(_options.Value.Instance))
            .Build();
    }
}

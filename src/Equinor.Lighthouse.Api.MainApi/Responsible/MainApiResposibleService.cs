using System;
using System.Net;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.MainApi.Client;
using Microsoft.Extensions.Options;

namespace Equinor.Lighthouse.Api.MainApi.Responsible;

public class MainApiResponsibleService : IResponsibleApiService
{
    private readonly string _apiVersion;
    private readonly Uri _baseAddress;
    private readonly IBearerTokenApiClient _mainApiClient;

    public MainApiResponsibleService(IBearerTokenApiClient mainApiClient,
        IOptionsMonitor<MainApiOptions> options)
    {
        _mainApiClient = mainApiClient;
        _apiVersion = options.CurrentValue.ApiVersion;
        _baseAddress = new Uri(options.CurrentValue.BaseAddress);
    }

    public async Task<PCSResponsible> TryGetResponsibleAsync(string plant, string code)
    {
        var url = $"{_baseAddress}Library/Responsible" +
                  $"?plantId={plant}" +
                  $"&code={WebUtility.UrlEncode(code)}" +
                  $"&api-version={_apiVersion}";

        return await _mainApiClient.TryQueryAndDeserializeAsync<PCSResponsible>(url);
    }
}
﻿using System;
using System.Net;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.MainApi.Client;
using Microsoft.Extensions.Options;

namespace Equinor.Lighthouse.Api.MainApi.Area
{
    public class MainApiAreaService : IAreaApiService
    {
        private readonly string _apiVersion;
        private readonly Uri _baseAddress;
        private readonly IBearerTokenApiClient _mainApiClient;

        public MainApiAreaService(IBearerTokenApiClient mainApiClient,
            IOptionsMonitor<MainApiOptions> options)
        {
            _mainApiClient = mainApiClient;
            _apiVersion = options.CurrentValue.ApiVersion;
            _baseAddress = new Uri(options.CurrentValue.BaseAddress);
        }

        public async Task<PCSArea> TryGetAreaAsync(string plant, string code)
        {
            var url = $"{_baseAddress}Library/Area" +
                      $"?plantId={plant}" +
                      $"&code={WebUtility.UrlEncode(code)}" +
                      $"&api-version={_apiVersion}";

            return await _mainApiClient.TryQueryAndDeserializeAsync<PCSArea>(url);
        }
    }
}

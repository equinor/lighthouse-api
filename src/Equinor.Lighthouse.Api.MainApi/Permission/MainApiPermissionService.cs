﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.MainApi.Client;
using Microsoft.Extensions.Options;

namespace Equinor.Lighthouse.Api.MainApi.Permission;

public class MainApiPermissionService : IPermissionApiService
{
    private readonly string _apiVersion;
    private readonly Uri _baseAddress;
    private readonly IBearerTokenApiClient _mainApiClient;

    public MainApiPermissionService(IBearerTokenApiClient mainApiClient,
        IOptionsMonitor<MainApiOptions> options)
    {
        _mainApiClient = mainApiClient;
        _apiVersion = options.CurrentValue.ApiVersion;
        _baseAddress = new Uri(options.CurrentValue.BaseAddress);
    }
        
    public async Task<IList<PCSProject>> GetAllOpenProjectsAsync(string plantId)
    {
        var url = $"{_baseAddress}Projects" +
                  $"?plantId={plantId}" +
                  "&withCommPkgsOnly=false" +
                  "&includeProjectsWithoutAccess=true" +
                  $"&api-version={_apiVersion}";

        return await _mainApiClient.QueryAndDeserializeAsync<List<PCSProject>>(url) ?? new List<PCSProject>();
    }

    public async Task<IList<string>> GetPermissionsAsync(string plantId)
    {
        var url = $"{_baseAddress}Permissions" +
                  $"?plantId={plantId}" +
                  $"&api-version={_apiVersion}";

        return await _mainApiClient.QueryAndDeserializeAsync<List<string>>(url) ?? new List<string>();
    }

    public async Task<IList<string>> GetContentRestrictionsAsync(string plantId)
    {
        var url = $"{_baseAddress}ContentRestrictions" +
                  $"?plantId={plantId}" +
                  $"&api-version={_apiVersion}";

        return await _mainApiClient.QueryAndDeserializeAsync<List<string>>(url) ?? new List<string>();
    }
}
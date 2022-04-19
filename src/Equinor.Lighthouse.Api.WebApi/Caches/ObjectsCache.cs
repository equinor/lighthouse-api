using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Infrastructure.Caching;
using Equinor.Lighthouse.Api.Query;
using Equinor.Lighthouse.Api.Query.LciObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Equinor.Lighthouse.Api.WebApi.Caches;

public class ObjectsCache : IObjectsCache
{
    private readonly ICacheManager _cacheManager;
    private readonly IOptionsMonitor<CacheOptions> _options;


    public ObjectsCache(ICacheManager cacheManager, IOptionsMonitor<CacheOptions> options)
    {
        _cacheManager = cacheManager;
        _options = options;
    }


    public async Task<ActionResult<PaginatedList<LciObjectDto>>> GetObjects(
        Func<Task<PaginatedList<LciObjectDto>>> query)
    {
        var paginatedList = await _cacheManager.GetOrCreate(
            ObjectsCacheKey(),
            async () =>
            {
                var objects = await query.Invoke();
                return objects;
            },
            CacheDuration.Minutes,
            _options.CurrentValue.PlantCacheMinutes);
        return paginatedList;
    }

    private static string ObjectsCacheKey()
        => $"OBJECTS_123";
}

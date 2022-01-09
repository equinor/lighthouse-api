using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Infrastructure.Caching;
using Equinor.Lighthouse.Api.Query;
using Equinor.Lighthouse.Api.Query.WorkOrders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Equinor.Lighthouse.Api.WebApi.Caches;

public class WorkOrderCache : IWorkOrderCache
{
    private readonly ICacheManager _cacheManager;
    private readonly IOptionsMonitor<CacheOptions> _options;
    public WorkOrderCache(ICacheManager cacheManager, IOptionsMonitor<CacheOptions> options)
    {
        _cacheManager = cacheManager;
        _options = options;
    }
    public async Task<ActionResult<PaginatedList<WorkOrderDto>>> GetWorkOrders(Func<Task<PaginatedList<WorkOrderDto>>> query)
    {
        var paginatedList = await _cacheManager.GetOrCreate(
            "WorkOrders123",
            async () =>
            {
                var objects = await query.Invoke();
                return objects;
            },
            CacheDuration.Minutes,
            _options.CurrentValue.PlantCacheMinutes);
        return paginatedList;
    }
}

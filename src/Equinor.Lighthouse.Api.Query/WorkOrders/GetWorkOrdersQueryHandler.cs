using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Infrastructure.Caching;
using Equinor.Lighthouse.Api.WebApi.Caches;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Equinor.Lighthouse.Api.Query.WorkOrders;

public class GetWorkOrdersQueryHandler : IRequestHandler<GetWorkOrdersQuery, PaginatedList<WorkOrderDto>>
{
    private readonly FAMContext _context;
    private readonly IMapper _mapper;
    private readonly ICacheManager _cacheManager;
    private readonly IOptionsMonitor<CacheOptions> _options;

    public GetWorkOrdersQueryHandler(FAMContext ctx, IMapper mapper, ICacheManager cacheManager, 
        IOptionsMonitor<CacheOptions> options)
    {
        _context = ctx;
        _mapper = mapper;
        _cacheManager = cacheManager;
        _options = options;
    }

    public async Task<PaginatedList<WorkOrderDto>> Handle(GetWorkOrdersQuery request,
        CancellationToken cancellationToken)
    {

        var list = await _cacheManager.GetOrCreate(
            "WorkOrders123",
            async () =>
            {
                var objects = await Fetch(cancellationToken,request);
                return objects;
            },
            CacheDuration.Minutes,
            _options.CurrentValue.PlantCacheMinutes);//TODO

        if (request.PageSize == 0 || request.PageSize > list.Count)
        {
            return new PaginatedList<WorkOrderDto>(list, list.Count, 1, list.Count);
        }

        var pagedList = list.Skip(request.PageSize * request.PageNumber).Take(request.PageSize).ToList();
        return new PaginatedList<WorkOrderDto>(pagedList, list.Count, request.PageNumber, request.PageSize);

    }

    private async Task<List<WorkOrderDto>> Fetch(CancellationToken cancellationToken,GetWorkOrdersQuery request )
    {
        var contextWorkOrders = _context.WorkOrders.AsQueryable();

        return await contextWorkOrders.ProjectTo<WorkOrderDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);


    }
}

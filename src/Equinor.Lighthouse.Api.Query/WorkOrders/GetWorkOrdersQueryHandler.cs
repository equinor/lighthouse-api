using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Equinor.Lighthouse.Api.Infrastructure;
using Equinor.Lighthouse.Api.Query.Mappings;
using Equinor.Lighthouse.Api.Query.McPkg;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Query.WorkOrders;

public class GetWorkOrdersQueryHandler : IRequestHandler<GetWorkOrdersQuery, PaginatedList<WorkOrderDto>>
{
    private readonly FAMContext _context;
    private readonly IMapper _mapper;

    public GetWorkOrdersQueryHandler(FAMContext ctx, IMapper mapper)
    {
        _context = ctx;
        _mapper = mapper;
    }

    public async Task<PaginatedList<WorkOrderDto>> Handle(GetWorkOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var contextMscMcPkgs = _context.WorkOrders.AsQueryable();

        //TODO synaps paging
        var list = await contextMscMcPkgs.ProjectTo<WorkOrderDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

        if (request.PageSize == 0 || request.PageSize > list.Count)
        {
            return new PaginatedList<WorkOrderDto>(list, list.Count,1 ,list.Count);
        }

        var pagedList = list.Skip(request.PageSize * request.PageNumber).Take(request.PageSize).ToList();
        return new PaginatedList<WorkOrderDto>(pagedList, list.Count, request.PageNumber, request.PageSize);
    }
}

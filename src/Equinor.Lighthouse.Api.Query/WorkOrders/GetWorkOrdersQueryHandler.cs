using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Equinor.Lighthouse.Api.Query.Mappings;
using MediatR;

namespace Equinor.Lighthouse.Api.Query.WorkOrders;

public class GetWorkOrdersQueryHandler : IRequestHandler<GetWorkOrdersQuery, PaginatedList<WorkOrderDto>>
{
    private readonly IReadOnlyContext _context;
    private readonly IMapper _mapper;

    public GetWorkOrdersQueryHandler(IReadOnlyContext ctx, IMapper mapper)
    {
        _context = ctx;
        _mapper = mapper;
    }

    public async Task<PaginatedList<WorkOrderDto>> Handle(GetWorkOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var contextWorkOrders = _context.QuerySet<WorkOrder>();
        if (request.ActivityNo != null)
        {
            contextWorkOrders = contextWorkOrders.Where(wo => wo.ActivityNo == request.ActivityNo);
        }

        return await contextWorkOrders.ProjectTo<WorkOrderDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

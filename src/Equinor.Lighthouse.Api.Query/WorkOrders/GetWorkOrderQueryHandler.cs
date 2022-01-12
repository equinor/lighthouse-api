using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Equinor.Lighthouse.Api.Query.WorkOrders;

public class GetWorkOrderQueryHandler : IRequestHandler<GetWorkOrderQuery, WorkOrderDto>
{
    private readonly IReadOnlyContext _context;
    private readonly IMapper _mapper;

    public GetWorkOrderQueryHandler(IReadOnlyContext ctx, IMapper mapper)
    {
        _context = ctx;
        _mapper = mapper;
    }

    public async Task<WorkOrderDto> Handle(GetWorkOrderQuery request, CancellationToken cancellationToken)
    {
        var workOrder = await _context.QuerySet<WorkOrder>()
            .SingleOrDefaultAsync(wo => wo.WoNo == request.Id.ToString(), cancellationToken); //TODO ore remove
        return _mapper.Map<WorkOrderDto>(workOrder);
    }
}

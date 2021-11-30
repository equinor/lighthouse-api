using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Equinor.Lighthouse.Api.Query.Mappings;
using MediatR;

namespace Equinor.Lighthouse.Api.Query.LciObjects;

public class LciObjectsQueryHandler : IRequestHandler<LciObjectsQuery, PaginatedList<LciObjectDto>>
{
    private readonly IReadOnlyContext _context;
    private readonly IMapper _mapper;

    public LciObjectsQueryHandler(IMapper mapper, IReadOnlyContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PaginatedList<LciObjectDto>> Handle(LciObjectsQuery request, CancellationToken cancellationToken)
    {
        var contextLciObjects = _context.QuerySet<LciObject>();
        if (request.ActivityNo != null)
        {
            contextLciObjects = contextLciObjects.Where(ob => ob.ActivityNo == request.ActivityNo);
        }

        if (request.WorkOrderNo != null)
        {
            contextLciObjects = contextLciObjects.Where(ob => ob.WorkOrderNo == request.WorkOrderNo);
        }

        return await contextLciObjects.ProjectTo<LciObjectDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

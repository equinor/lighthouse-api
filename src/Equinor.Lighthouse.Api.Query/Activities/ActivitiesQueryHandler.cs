using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Equinor.Lighthouse.Api.Domain;
using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Equinor.Lighthouse.Api.Query.Mappings;
using MediatR;

namespace Equinor.Lighthouse.Api.Query.Activities;

public class ActivitiesQueryHandler : IRequestHandler<ActivitiesQuery, PaginatedList<ActivityDto>>
{
    private readonly IReadOnlyContext _context;
    private readonly IMapper _mapper;

    public ActivitiesQueryHandler(IMapper mapper, IReadOnlyContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PaginatedList<ActivityDto>> Handle(ActivitiesQuery request, CancellationToken cancellationToken)
    {
        var contextActivities = _context.QuerySet<Activity>();
        if (request.ActivityNo != null)
        {
            contextActivities = contextActivities.Where(a => a.ActivityNo == request.ActivityNo);
        }

        return await contextActivities.ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

using MediatR;

namespace Equinor.Lighthouse.Api.Query.Activities;

public class ActivitiesQuery : IRequest<PaginatedList<ActivityDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 0;
    public string? ActivityNo { get; set; }
}

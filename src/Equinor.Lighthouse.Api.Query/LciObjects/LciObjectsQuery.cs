using MediatR;

namespace Equinor.Lighthouse.Api.Query.LciObjects;

public class LciObjectsQuery : IRequest<PaginatedList<LciObjectDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 0;
    public string? ActivityNo { get; set; }
    public string? WorkOrderNo { get; set; }
}

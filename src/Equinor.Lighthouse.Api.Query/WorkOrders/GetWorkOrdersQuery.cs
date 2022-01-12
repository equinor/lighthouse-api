using MediatR;

namespace Equinor.Lighthouse.Api.Query.WorkOrders;

public class GetWorkOrdersQuery : IRequest<PaginatedList<WorkOrderDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 0;
}

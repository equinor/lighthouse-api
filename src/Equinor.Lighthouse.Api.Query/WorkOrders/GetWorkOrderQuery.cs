using System;
using MediatR;

namespace Equinor.Lighthouse.Api.Query.WorkOrders;

public class GetWorkOrderQuery : IRequest<WorkOrderDto>
{
    public Guid Id { get; set; }
}

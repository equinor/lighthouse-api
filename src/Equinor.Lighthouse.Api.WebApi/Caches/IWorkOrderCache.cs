using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Query;
using Equinor.Lighthouse.Api.Query.WorkOrders;
using Microsoft.AspNetCore.Mvc;

namespace Equinor.Lighthouse.Api.WebApi.Caches;

public interface IWorkOrderCache
{

    Task<ActionResult<PaginatedList<WorkOrderDto>>> GetWorkOrders(Func<Task<PaginatedList<WorkOrderDto>>> query);
}

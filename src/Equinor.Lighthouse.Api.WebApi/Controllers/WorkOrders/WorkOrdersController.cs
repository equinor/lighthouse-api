//using System;
//using System.Threading.Tasks;
//using Equinor.Lighthouse.Api.Query;
//using Equinor.Lighthouse.Api.Query.WorkOrders;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace Equinor.Lighthouse.Api.WebApi.Controllers.WorkOrders;

//[Route("[controller]")]
//[ApiController]
//public class WorkOrdersController : ApiControllerBase
//{
//    // GET: <WorkOrdersController>
//    [Authorize]
//    [HttpGet]
//    public async Task<ActionResult<PaginatedList<WorkOrderDto>>> Get([FromQuery] GetWorkOrdersQuery query)
//    {
//        return await Mediator.Send(query);
//    }


//    // GET <WorkOrdersController>/5
//    [HttpGet("{id}")]
//    public Task<WorkOrderDto> Get(Guid id) 
//        => Mediator.Send(new GetWorkOrderQuery{Id = id});
//}

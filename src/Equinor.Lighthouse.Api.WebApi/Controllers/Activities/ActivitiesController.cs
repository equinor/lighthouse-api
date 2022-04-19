//using System.Threading.Tasks;
//using Equinor.Lighthouse.Api.Query;
//using Equinor.Lighthouse.Api.Query.Activities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Equinor.Lighthouse.Api.WebApi.Controllers.Activities;
//[Route("[controller]")]
//[ApiController]

//public class ActivitiesController : ApiControllerBase
//{
//    // GET: api/<ActivitiesController>
//    [Authorize]
//    [HttpGet]
//    public async Task<ActionResult<PaginatedList<ActivityDto>>> Get([FromQuery] ActivitiesQuery query)
//    {
//        return await Mediator.Send(query);
      
//    }

//    //// GET api/<ActivitiesController>/5
//    //[HttpGet("{id}")]
//    //public Task<ActivityDto> Get(Guid id)
//    //{
    
//    //}

//}

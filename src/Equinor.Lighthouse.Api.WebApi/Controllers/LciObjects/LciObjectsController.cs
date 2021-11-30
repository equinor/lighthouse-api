using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Query;
using Equinor.Lighthouse.Api.Query.LciObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Equinor.Lighthouse.Api.WebApi.Controllers.LciObjects;

[Route("[controller]")]
[ApiController]
public class LciObjectsController : ApiControllerBase
{
    // GET: api/<LciObjectController>
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<PaginatedList<LciObjectDto>>> Get([FromQuery] LciObjectsQuery query)
    {
        return await Mediator.Send(query);
      
    }

    //// GET api/<LciObjectsController>/5
    //[HttpGet("{id}")]
    //public Task<LciObjectDto> Get(Guid id)
    //{
    
    //}

}

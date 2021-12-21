using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Query;
using Equinor.Lighthouse.Api.Query.LciObjects;
using Equinor.Lighthouse.Api.Query.McPkg;
using Equinor.Lighthouse.Api.WebApi.Caches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Equinor.Lighthouse.Api.WebApi.Controllers.McPkg;

[Route("[controller]")]
[ApiController]
public class McPkgController : ApiControllerBase
{

    private readonly IObjectsCache _objectsCache;

    public McPkgController(IObjectsCache objectsCache)
    {
        _objectsCache = objectsCache;
    }

    // GET: api/<LciObjectController>
    [Authorize]
    //[AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<PaginatedList<McPkgDto>>> Get([FromQuery] McPkgQuery query)
    {
        var objects = await  Mediator.Send(query);
        return objects;
    }

    //// GET api/<LciObjectsController>/5
    //[HttpGet("{id}")]
    //public Task<LciObjectDto> Get(Guid id)
    //{
    
    //}

}

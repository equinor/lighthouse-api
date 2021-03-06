using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Query.ResponsibleAggregate;
using Equinor.Lighthouse.Api.WebApi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceResult.ApiExtensions;

namespace Equinor.Lighthouse.Api.WebApi.Controllers.Responsibles;

[ApiController]
[Route("Responsibles")]
public class ResponsiblesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResponsiblesController(IMediator mediator) => _mediator = mediator;

    [Authorize(Roles = Permissions.LIBRARY_PRESERVATION_READ)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponsibleDto>>> GetAllResponsibles(
        [FromHeader(Name = CurrentPlantMiddleware.PlantHeader)]
        [Required]
        string plant)
    {
        var result = await _mediator.Send(new GetAllResponsiblesQuery());
        return this.FromResult(result);
    }
}

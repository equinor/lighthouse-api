using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.PersonCommands.CreateSavedFilter;
using Equinor.Lighthouse.Api.Command.PersonCommands.DeleteSavedFilter;
using Equinor.Lighthouse.Api.Command.PersonCommands.UpdateSavedFilter;
using Equinor.Lighthouse.Api.Query.GetSavedFiltersInProject;
using Equinor.Lighthouse.Api.WebApi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceResult.ApiExtensions;

namespace Equinor.Lighthouse.Api.WebApi.Controllers.Persons;

[ApiController]
[Route("Persons")]
public class PersonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonsController(IMediator mediator) => _mediator = mediator;

    [Authorize(Roles = Permissions.PRESERVATION_READ)]
    [HttpPost("SavedFilter")]
    public async Task<ActionResult<int>> CreateSavedFilter(
        [FromHeader(Name = CurrentPlantMiddleware.PlantHeader)]
        [Required]
        string plant,
        [FromBody] CreateSavedFilterDto dto)
    {
        var result = await _mediator.Send(new CreateSavedFilterCommand(dto.ProjectName, dto.Title, dto.Criteria, dto.DefaultFilter));
        return this.FromResult(result);
    }
         
    [Authorize(Roles = Permissions.PRESERVATION_READ)]
    [HttpGet("SavedFilters")]
    public async Task<ActionResult<List<SavedFilterDto>>> GetSavedFiltersInProject(
        [FromHeader(Name = CurrentPlantMiddleware.PlantHeader)]
        [Required]
        string plant,
        [FromQuery] string projectName)
    {
        var result = await _mediator.Send(new GetSavedFiltersInProjectQuery(projectName));
        return this.FromResult(result);
    }

    [Authorize(Roles = Permissions.PRESERVATION_READ)]
    [HttpDelete("SavedFilters/{id}")]
    public async Task<ActionResult> DeleteSavedFilter(
        [FromHeader(Name = CurrentPlantMiddleware.PlantHeader)]
        [Required] string plant,
        [FromRoute] Guid id,
        [FromBody] DeleteSavedFilterDto dto)
    {
        var result = await _mediator.Send(new DeleteSavedFilterCommand(id, dto.RowVersion));
        return this.FromResult(result);
    }

    [Authorize(Roles = Permissions.PRESERVATION_READ)]
    [HttpPut("SavedFilters/{id}")]
    public async Task<ActionResult> UpdateSavedFilter(
        [FromHeader(Name = CurrentPlantMiddleware.PlantHeader)]
        [Required] string plant,
        [FromRoute] Guid id,
        [FromBody] UpdateSavedFilterDto dto)
    {
        var command = new UpdateSavedFilterCommand(
            id,
            dto.Title,
            dto.Criteria,
            dto.DefaultFilter,
            dto.RowVersion);

        var result = await _mediator.Send(command);
        return this.FromResult(result);
    }
}
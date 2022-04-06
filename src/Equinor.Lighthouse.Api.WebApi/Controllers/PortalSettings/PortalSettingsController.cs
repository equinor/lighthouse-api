using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Query;
using Equinor.Lighthouse.Api.Query.PortalSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinor.Lighthouse.Api.WebApi.Controllers.PortalSettings;

[Route("[controller]")]
[ApiController]
public class PortalSettingsController : ApiControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<PaginatedList<PortalSettingSimpleDto>>> Get([FromQuery] GetPortalSettingsQuery query) 
        => await Mediator.Send(query);


    [HttpGet("{id}")]
    public Task<PortalSettingDto> Get(Guid azureOid) 
        => Mediator.Send(new GetPortalSettingQuery{AzureOid = azureOid});
}



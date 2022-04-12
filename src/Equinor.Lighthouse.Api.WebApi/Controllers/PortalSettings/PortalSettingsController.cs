using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.PortalSettingCommands;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using Equinor.Lighthouse.Api.Query.PortalSettings;
using Equinor.Lighthouse.Api.WebApi.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceResult;
using ServiceResult.ApiExtensions;

namespace Equinor.Lighthouse.Api.WebApi.Controllers.PortalSettings;

[Route("[controller]")]
[ApiController]
public class PortalSettingsController : ApiControllerBase
{
    [Authorize]
    [HttpGet("GetSimple")]
    public async Task<ActionResult<PortalSettingSimpleDto>> GetSimple()
    {
        var oid = User.Claims.TryGetOid();
        if (oid == null)
        {
            return BadRequest("Could not get Oid from signed in user");
        }
        var result = await Mediator.Send(new GetSimplePortalSettingQuery{AzureOid = (Guid)oid});

        if (result.ResultType == ResultType.NotFound)
        { 
            var r = await Mediator.Send(new CreatePortalSettingCommand((Guid)oid));
            var dto = r.Data;
            result = new SuccessResult<PortalSettingSimpleDto>(new PortalSettingSimpleDto { AzureOid = dto.AzureOid });
        }

        return this.FromResult(result);
    }


    [HttpGet]
    public async Task<ActionResult<PortalSettingDto>> Get()
    {
        var oid = User.Claims.TryGetOid();
        if (oid == null)
        {
            return BadRequest("Could not get Oid from signed in user");
        }

        var result = await Mediator.Send(new GetPortalSettingQuery() { AzureOid = (Guid)oid });


        if (result.ResultType == ResultType.NotFound)
        { 
            result = await Mediator.Send(new CreatePortalSettingCommand((Guid)oid));
        }

        return this.FromResult(result);
    }


}



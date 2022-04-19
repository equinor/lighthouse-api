using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.FavoriteCommands.CreateFavorite;
using Equinor.Lighthouse.Api.Domain.AggregateModels.FavoriteAggregate;
using Equinor.Lighthouse.Api.Query.Favorites;
using Equinor.Lighthouse.Api.WebApi.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceResult.ApiExtensions;

namespace Equinor.Lighthouse.Api.WebApi.Controllers.Favorites;

[Route("[controller]")]
[ApiController]
public class FavoriteController : ApiControllerBase
{

    [HttpGet("{id}")]
    public async Task<ActionResult<FavoriteDto>> Get(Guid id)
    {
        var result = await Mediator.Send(new GetFavoriteQuery() { FavoriteId = id });
        return this.FromResult(result);
    }

    [HttpPost()]
    public async Task<ActionResult<FavoriteDto>> Create([FromBody] CreateFavoriteCommand command)
    {
        var result = await Mediator.Send(command);
        return this.FromResult(result);
    }

    [Authorize]
    [HttpGet("GetFavoriteIdsForLoggedInUser")]
    public async Task<ActionResult<ICollection<Guid>>> GetSimple()
    {
        var oid = User.Claims.TryGetOid();
        if (oid == null)
        {
            return BadRequest("Could not get Oid from signed in user");
        }

        var result = await Mediator.Send(new GetFavoriteIdsByAzureOidQuery() { AzureOid = (Guid)oid });

        return this.FromResult(result);
    }

}

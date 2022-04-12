using System;
using System.Threading.Tasks;
using Equinor.Lighthouse.Api.Command.PortalSettingCommands;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate.Favorite;
using Equinor.Lighthouse.Api.Query.Favorite;
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
    public async Task<ActionResult<FavoriteDto>> Create([FromBody] FavoriteDto dto)
    {

        var result = await Mediator.Send(new CreateFavoriteCommand(dto));
    }



}

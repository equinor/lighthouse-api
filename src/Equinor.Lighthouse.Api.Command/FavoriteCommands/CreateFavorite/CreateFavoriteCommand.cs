using System;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.FavoriteCommands.CreateFavorite;

public class CreateFavoriteCommand : IRequest<Result<Guid>>
{
    public Guid AzureOid { get; set; }

    public string? AppId { get; set; }

    public string? AppPreset { get; set; }

    public string? FavoriteName { get; set; }
    
    public CreateFavoriteCommand(Guid azureOid,string? favoriteName, string? appPreset, string? appId)
    {
        FavoriteName = favoriteName;
        AppPreset = appPreset;
        AppId = appId;
        AzureOid = azureOid;
    }
}

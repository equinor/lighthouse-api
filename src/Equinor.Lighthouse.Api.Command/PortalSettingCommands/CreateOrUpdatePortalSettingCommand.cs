using System;
using System.Collections.Generic;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.PortalSettingCommands;

public class CreateOrUpdatePortalSettingCommand : IRequest<Result<Guid>>
{
    public CreateOrUpdatePortalSettingCommand(Guid azureOid, ICollection<Guid> favoriteIds)
    {
        AzureOid = azureOid;
        FavoriteIds = favoriteIds;
    }

    public Guid AzureOid { get; }

    public ICollection<Guid> FavoriteIds { get; }
}

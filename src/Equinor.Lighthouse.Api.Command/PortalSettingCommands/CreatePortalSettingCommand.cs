using System;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Command.PortalSettingCommands;

public class CreatePortalSettingCommand : IRequest<Result<PortalSettingDto>>
{
    public CreatePortalSettingCommand(Guid azureOid) => AzureOid = azureOid;

    public Guid AzureOid { get; }

}

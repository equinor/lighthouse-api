using System;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.PortalSettings;

public class GetPortalSettingQuery : IRequest<Result<PortalSettingDto>>
{
    public Guid AzureOid { get; set; }
}

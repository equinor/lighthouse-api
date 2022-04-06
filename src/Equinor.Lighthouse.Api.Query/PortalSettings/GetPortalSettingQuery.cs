using System;
using MediatR;

namespace Equinor.Lighthouse.Api.Query.PortalSettings;

public class GetPortalSettingQuery : IRequest<PortalSettingDto>
{
    public Guid AzureOid { get; set; }
}

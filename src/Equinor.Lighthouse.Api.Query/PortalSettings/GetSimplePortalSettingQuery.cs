using System;
using MediatR;
using ServiceResult;

namespace Equinor.Lighthouse.Api.Query.PortalSettings;

public class GetSimplePortalSettingQuery : IRequest<Result<PortalSettingSimpleDto>>
{
    public Guid AzureOid { get; set; }
}

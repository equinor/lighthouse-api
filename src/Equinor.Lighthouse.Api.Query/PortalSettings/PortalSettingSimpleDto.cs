using System;
using System.Collections.Generic;
using MediatR;

namespace Equinor.Lighthouse.Api.Query.PortalSettings;

public class PortalSettingSimpleDto : IRequest
{
    public Guid AzureOid { get; set; }

    public ICollection<Guid> FilterIds { get; set; } = new List<Guid>();

    public ICollection<Guid> FavoriteIds { get; set; } = new List<Guid>();
}

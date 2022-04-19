using System;
using System.Collections.Generic;
using MediatR;

namespace Equinor.Lighthouse.Api.Query.PortalSettings;

public class PortalSettingSimpleDto : IRequest
{
    public ICollection<Guid> FavoriteIds { get; set; } = new List<Guid>();
}

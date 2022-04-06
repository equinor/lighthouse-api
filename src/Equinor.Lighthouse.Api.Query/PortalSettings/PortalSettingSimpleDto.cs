using System;
using System.Collections.Generic;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;

namespace Equinor.Lighthouse.Api.Query.PortalSettings;

public class PortalSettingSimpleDto
{
    public Guid AzureOid { get; set; }

    public ICollection<Guid> FilterIds { get; set; } = new List<Guid>();

    public ICollection<Guid> FavoriteIds { get; set; } = new List<Guid>();
}

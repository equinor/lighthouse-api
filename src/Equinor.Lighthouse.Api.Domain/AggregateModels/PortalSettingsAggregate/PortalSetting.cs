using System;
using System.Collections.Generic;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;

public class PortalSetting
{
    public Guid AzureOid { get; set; }

    public ICollection<Filter> Filters { get; set; } = new List<Filter>();

    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();


}

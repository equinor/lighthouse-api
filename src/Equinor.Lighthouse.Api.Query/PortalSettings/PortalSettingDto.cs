using System;
using System.Collections.Generic;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;

namespace Equinor.Lighthouse.Api.Query.PortalSettings;

public class PortalSettingDto
{
    public Guid AzureOid { get; set; }

    public ICollection<Filter> Filters { get; set; } = new List<Filter>();

    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();


}

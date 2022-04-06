using System;

namespace Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;

public class Favorite
{
    public Guid FavoriteId { get; set; }

    public Guid AzureOid { get; set; }

    public string? AppId { get; set; }

    public string? AppPreset { get; set; }

    public string? FavoriteName { get; set; }

    //public Guid FilterId { get; set; }  

}

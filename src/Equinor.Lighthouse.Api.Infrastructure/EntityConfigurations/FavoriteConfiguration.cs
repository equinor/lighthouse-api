
using Equinor.Lighthouse.Api.Domain.AggregateModels.FavoriteAggregate;
using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinor.Lighthouse.Api.Infrastructure.EntityConfigurations;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        builder.HasKey(f => f.FavoriteId);
    }
}

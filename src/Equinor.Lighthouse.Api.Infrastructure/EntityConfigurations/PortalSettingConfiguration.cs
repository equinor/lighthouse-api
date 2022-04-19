using Equinor.Lighthouse.Api.Domain.AggregateModels.PortalSettingsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinor.Lighthouse.Api.Infrastructure.EntityConfigurations
{
    public class PortalSettingConfiguration : IEntityTypeConfiguration<PortalSetting>
    {
        public void Configure(EntityTypeBuilder<PortalSetting> builder)
        {
            builder.HasKey(ps => ps.AzureOid);

            //builder.HasMany(ps => ps.Favorites)
            //    .WithOne()
            //    .HasForeignKey(f => f.AzureOid);
        }
    }
}

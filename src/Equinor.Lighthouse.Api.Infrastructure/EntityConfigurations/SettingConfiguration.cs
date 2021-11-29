using Equinor.Lighthouse.Api.Domain.AggregateModels.SettingAggregate;
using Equinor.Lighthouse.Api.Infrastructure.EntityConfigurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinor.Lighthouse.Api.Infrastructure.EntityConfigurations;

internal class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.ConfigurePlant();
        builder.ConfigureConcurrencyToken();

        builder.Property(x => x.Code)
            .HasMaxLength(Setting.CodeLengthMax)
            .IsRequired();
    }
}
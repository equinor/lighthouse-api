using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinor.Lighthouse.Api.Infrastructure.EntityConfigurations;

public class LciObjectConfiguration : IEntityTypeConfiguration<LciObject>
{
    public void Configure(EntityTypeBuilder<LciObject> builder)
    {
        builder.HasIndex(entity => entity.Id)
            .IsUnique();
    }
}

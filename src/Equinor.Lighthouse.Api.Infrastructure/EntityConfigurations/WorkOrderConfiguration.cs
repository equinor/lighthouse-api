using Equinor.Lighthouse.Api.Domain.AggregateModels.ActivityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinor.Lighthouse.Api.Infrastructure.EntityConfigurations;

public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
{
    public void Configure(EntityTypeBuilder<WorkOrder> builder) =>
        builder.HasIndex(entity => entity.Id)
            .IsUnique();
}

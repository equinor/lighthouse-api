using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Domain.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinor.Lighthouse.Api.Infrastructure.EntityConfigurations.Extensions
{
    public static class AuditableConfigurationExtensions
    {
        public static void ConfigureCreationAudit<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, ICreationAuditable
        {
            builder
                .Property(x => x.CreatedAtUtc)
                .HasConversion(ApplicationContext.DateTimeKindConverter);

            builder
                .HasOne<Person>()
                .WithMany()
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static void ConfigureModificationAudit<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IModificationAuditable
        {
            builder
                .Property(x => x.ModifiedAtUtc)
                .HasConversion(ApplicationContext.DateTimeKindConverter);

            builder
                .HasOne<Person>()
                .WithMany()
                .HasForeignKey(x => x.ModifiedById)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

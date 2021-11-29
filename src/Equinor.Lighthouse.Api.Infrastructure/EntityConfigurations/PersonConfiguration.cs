using Equinor.Lighthouse.Api.Domain.AggregateModels.PersonAggregate;
using Equinor.Lighthouse.Api.Infrastructure.EntityConfigurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinor.Lighthouse.Api.Infrastructure.EntityConfigurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ConfigureModificationAudit();
            builder.ConfigureConcurrencyToken();

            builder.HasIndex(x => x.Oid)
                .IsUnique();

            builder.Property(x => x.FirstName)
                .HasMaxLength(Person.FirstNameLengthMax)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(Person.LastNameLengthMax)
                .IsRequired();

            builder
                .HasMany(x => x.SavedFilters)
                .WithOne()
                .IsRequired();
        }
    }
}

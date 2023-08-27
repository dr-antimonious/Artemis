using Artemis.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Data.Db.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Cities)
                .WithMany(y => y.Countries);

            builder.HasMany(x => x.Locations)
                .WithOne(y => y.Country)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}

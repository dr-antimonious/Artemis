using Artemis.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Data.Db.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.City)
                .WithMany(y => y.Locations);

            builder.HasOne(x => x.Country)
                .WithMany(y => y.Locations);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}

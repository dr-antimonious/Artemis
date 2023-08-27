using Artemis.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Data.Db.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Countries)
                .WithMany(y => y.Cities);

            builder.HasMany(x => x.Locations)
                .WithOne(y => y.City)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasIndex(x => x.Name).IsUnique();

            
        }
    }
}

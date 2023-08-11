using Artemis.Contracts.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Data.Db.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<IMatch>
    {
        public void Configure(EntityTypeBuilder<IMatch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Shooter)
                .WithMany(y => y.Matches);

            builder.HasOne(x => x.StartTimestamp)
                .WithMany();

            builder.HasOne(x => x.EndTimestamp)
                .WithMany();

            builder.HasOne(x => x.Location)
                .WithMany();

            builder.Property(x => x.AirTemperature);

            builder.Property(x => x.AirPressure);

            builder.Property(x => x.WindSpeed);

            builder.Property(x => x.WindDirection);

            builder.Property(x => x.EnvironmentNotes);

            builder.Property(x => x.EquipmentNotes);

            builder.Property(x => x.ShooterNotes);
        }
    }
}

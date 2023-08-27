using Artemis.Contracts.Entities.Matches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Data.Db.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Shots)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(x => x.Shooter)
                .WithMany(y => y.Matches)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.StartTimestamp)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.EndTimestamp)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Location)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

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

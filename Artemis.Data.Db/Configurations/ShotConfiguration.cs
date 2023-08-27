using Artemis.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Data.Db.Configurations
{
    public class ShotConfiguration : IEntityTypeConfiguration<Shot>
    {
        public void Configure(EntityTypeBuilder<Shot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.TimeStamp)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(x => x.Value).IsRequired();

            builder.Property(x => x.Position).IsRequired();

            builder.Property(x => x.HorizontalDisplacement);

            builder.Property(x => x.VerticalDisplacement);
        }
    }
}

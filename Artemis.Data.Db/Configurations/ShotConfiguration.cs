using Artemis.Contracts.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Data.Db.Configurations
{
    public class ShotConfiguration : IEntityTypeConfiguration<IShot>
    {
        public void Configure(EntityTypeBuilder<IShot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.TimeStamp)
                .WithMany();

            builder.Property(x => x.Value).IsRequired();

            builder.Property(x => x.HorizontalDisplacement);

            builder.Property(x => x.VerticalDisplacement);
        }
    }
}

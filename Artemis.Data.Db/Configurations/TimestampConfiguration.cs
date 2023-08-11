using Artemis.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Data.Db.Configurations
{
    public class TimestampConfiguration : IEntityTypeConfiguration<Timestamp>
    {
        public void Configure(EntityTypeBuilder<Timestamp> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TimeStamp).IsRequired();

            builder.HasIndex(x => x.TimeStamp).IsUnique();
        }
    }
}

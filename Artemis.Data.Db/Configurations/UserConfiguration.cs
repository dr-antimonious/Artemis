using Artemis.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artemis.Data.Db.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName);

            builder.Property(x => x.AdditionalNames);

            builder.Property(x => x.LastName);

            builder.Property(x => x.DateOfBirth);

            builder.Property(x => x.Gender);

            builder.Property(x => x.Email);

            builder.Property(x => x.PhoneNumber);

            builder.HasMany(x => x.Matches).WithOne(y => y.Shooter);

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}

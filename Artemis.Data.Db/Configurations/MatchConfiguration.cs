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
        }
    }
}

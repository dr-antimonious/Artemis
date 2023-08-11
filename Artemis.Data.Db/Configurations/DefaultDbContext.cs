using System.Reflection;
using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Matches;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Configurations
{
    public class DefaultDbContext : IdentityDbContext<User, IdentityRole<string>, string>
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<_3P50Match> _3P50Matches { get; set; }

        public DbSet<AP10Match> AP10Matches { get; set; }

        public DbSet<AR10Match> AR10Matches { get; set; }

        public DbSet<P25Match> P25Matches { get; set; }

        public DbSet<RFP25Match> RFP25Matches { get; set; }

        public DbSet<TSMatch> TSMatches { get; set; }

        public DbSet<Shot> Shots { get; set; }

        public DbSet<Timestamp> Timestamps { get; set; }

        public DbSet<User> UserSet { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Match>().ToTable("Matches");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DefaultDbContext()
        {
        }
    }
}

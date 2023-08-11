using System.Reflection;
using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Interfaces;
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

        public DbSet<IMatch> Matches { get; set; }

        public DbSet<IShot> Shots { get; set; }

        public DbSet<Timestamp> Timestamps { get; set; }

        public DbSet<User> UserSet { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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

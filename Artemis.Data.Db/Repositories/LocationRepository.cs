using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class LocationRepository : ILocationRepository<Location>
    {
        private readonly DbSet<Location> _locations;

        public async Task Create(Location entity)
        {
            await _locations.AddAsync(entity);
        }

        public async Task<List<Location>> GetAllAsync()
        {
            return await _locations.ToListAsync();
        }

        public async Task<Location> GetAsync(string id)
        {
            return await _locations.FindAsync(id);
        }

        public async Task<List<Location>> GetByCityAsync(string city)
        {
            return await _locations.Where(x => x.City.Equals(city)).ToListAsync();
        }

        public async Task<List<Location>> GetByCountryAsync(string country)
        {
            return await _locations.Where(x => x.Country.Equals(country)).ToListAsync();
        }

        public async Task<List<Location>> GetByNameAsync(string name)
        {
            return await _locations.Where(x => x.Name.Equals(name)).ToListAsync();
        }

        public async Task Update(Location entity)
        {
            await Task.Run(() => _locations.Update(entity));
        }

        public LocationRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
        {
            _locations = dbContext.Set<Location>();
        }
    }
}

using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository<Location>
    {
        private readonly DbSet<Location> _locations;

        public async Task Create(Location entity)
        {
            await HandleCancelTask(_locations.AddAsync(entity));
        }

        public async Task<List<Location>> GetAllAsync()
        {
            return await HandleNullCancelTask(_locations.ToListAsync());
        }

        public async Task<Location?> GetAsync(string id)
        {
            return await _locations.FindAsync(id);
        }

        public async Task<List<Location>> GetByCityNameAsync(string city)
        {
            return await HandleNullCancelTask(_locations.Where(
                x => x.City.Name.Equals(city)).ToListAsync());
        }

        public async Task<List<Location>> GetByCountryNameAsync(string country)
        {
            return await HandleNullCancelTask(_locations.Where(
                x => x.Country.Name.Equals(country)).ToListAsync());
        }

        public async Task<List<Location>> GetByNameAsync(string name)
        {
            return await HandleNullCancelTask(_locations.Where(
                x => x.Name.Equals(name)).ToListAsync());
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

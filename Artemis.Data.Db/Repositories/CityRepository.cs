using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository<City>
    {
        private readonly DbSet<City> _cities;

        public async Task Create(City entity)
            => await HandleCancelTask(_cities.AddAsync(entity));

        public async Task<List<City>> GetAllAsync()
            => await HandleNullCancelTask(_cities
                .Include(x => x.Countries)
                .Include(x => x.Locations)
                .ToListAsync());

        public async Task<City?> GetAsync(string id)
            => await _cities
                .Include(x => x.Countries)
                .Include(x => x.Locations)
                .FirstOrDefaultAsync(y => y.Id.Equals(id));

        public async Task<List<City>> GetByCountryNameAsync(string country)
            => await HandleNullCancelTask(_cities
                .Include(x => x.Countries)
                .Include(x => x.Locations)
                .Where(x => x.Countries
                    .FirstOrDefault(y => y.Name.Equals(country)) != null)
                .ToListAsync());

        public async Task<List<City>> GetByPartialNameMatchAsync(string name)
            => await HandleNullCancelTask(_cities
                .Include(x => x.Countries)
                .Include(x => x.Locations)
                .Where(x => x.Name.Contains(name))
                .ToListAsync());

        public async Task<City?> GetByExactNameMatchAsync(string name)
            => await HandleNullCancelTask(_cities
                .Include(x => x.Countries)
                .Include(x => x.Locations)
                .FirstOrDefaultAsync(x => x.Name.Equals(name)));

        public async Task Update(City entity)
            => await Task.Run(() => _cities.Update(entity));

        public CityRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
            => _cities = dbContext.Set<City>();
    }
}

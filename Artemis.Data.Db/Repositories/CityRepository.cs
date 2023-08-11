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
        {
            await HandleCancelTask(_cities.AddAsync(entity));
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await HandleNullCancelTask(_cities.ToListAsync());
        }

        public async Task<City?> GetAsync(string id)
        {
            return await _cities.FindAsync(id);
        }

        public async Task<List<City>> GetByCountryNameAsync(string country)
        {
            return await HandleNullCancelTask(_cities.Where(
                x => x.Countries.Exists(
                        y => y.Name.Equals(country))
                    .Equals(true)).ToListAsync());
        }

        public async Task<List<City>> GetByNameAsync(string name)
        {
            return await HandleNullCancelTask(_cities.Where(
                x => x.Name.Equals(name)).ToListAsync());
        }
        
        public async Task Update(City entity)
        {
            await Task.Run(() => _cities.Update(entity));
        }

        public CityRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
        {
            _cities = dbContext.Set<City>();
        }
    }
}

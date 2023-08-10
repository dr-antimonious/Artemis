using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository<Country>
    {
        private readonly DbSet<Country> _countries;

        public async Task Create(Country entity)
        {
            await HandleCancelTask(_countries.AddAsync(entity));
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await HandleNullCancelTask(_countries.ToListAsync());
        }

        public async Task<Country> GetAsync(string id)
        {
            return await _countries.FindAsync(id);
        }

        public async Task<List<Country>> GetByCityNameAsync(string city)
        {
            return await HandleNullCancelTask(_countries.Where(
                x => x.Cities.Exists(
                        y => y.Name.Equals(city))
                    .Equals(true)).ToListAsync());
        }

        public async Task<List<Country>> GetByNameAsync(string name)
        {
            return await HandleNullCancelTask(_countries.Where(
                x => x.Name.Equals(name)).ToListAsync());
        }

        public async Task Update(Country entity)
        {
            await Task.Run(() => _countries.Update(entity));
        }

        public CountryRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
        {
            _countries = dbContext.Set<Country>();
        }
    }
}

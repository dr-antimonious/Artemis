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
            => await HandleCancelTask(_countries.AddAsync(entity));

        public async Task<List<Country>> GetAllAsync()
            => await HandleNullCancelTask(_countries
                .Include(x => x.Cities)
                .Include(x => x.Locations)
                .ToListAsync());

        public async Task<Country?> GetAsync(string id)
            => await _countries
                .Include(x => x.Cities)
                .Include(x => x.Locations)
                .FirstOrDefaultAsync(y => y.Id.Equals(id));

        public async Task<List<Country>> GetByCityNameAsync(string city)
            => await HandleNullCancelTask(_countries
                .Include(x => x.Cities)
                .Include(x => x.Locations)
                .Where(x => x.Cities
                    .FirstOrDefault(y => y.Name.Equals(city)) != null)
                .ToListAsync());

        public async Task<List<Country>> GetByPartialNameMatchAsync(string name)
            => await HandleNullCancelTask(_countries
                .Include(x => x.Cities)
                .Include(x => x.Locations)
                .Where(x => x.Name.Contains(name))
                .ToListAsync());

        public async Task<Country?> GetByExactNameMatchAsync(string name)
            => await HandleNullCancelTask(_countries
                .Include(x => x.Cities)
                .Include(x => x.Locations)
                .FirstOrDefaultAsync(x => x.Name.Equals(name)));

        public async Task Update(Country entity)
            => await Task.Run(() => _countries.Update(entity));

        public CountryRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
            => _countries = dbContext.Set<Country>();
    }
}

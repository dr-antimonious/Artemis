using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class CityRepository : INameRepository<City>
    {
        private readonly DbSet<City> _cities;

        public async Task Create(City entity)
        {
            await _cities.AddAsync(entity);
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _cities.ToListAsync();
        }

        public async Task<City> GetAsync(string id)
        {
            return await _cities.FindAsync(id);
        }

        public async Task<List<City>> GetByNameAsync(string name)
        {
            //TODO: reformat into single entity, list not possible
            return await _cities.Where(x => x.Name.Equals(name)).ToListAsync();
        }
        
        public Task Update(City entity)
        {
            throw new NotImplementedException();
        }
    }
}

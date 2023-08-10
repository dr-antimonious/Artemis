using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Interfaces;
using Artemis.Contracts.Repositories;

namespace Artemis.Data.Db.Repositories
{
    public class ShotRepository : Repository<IShot>, IRemovableRepository<IShot>
    {
        public Task Create(IShot entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(IShot entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<IShot>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IShot> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(IShot entity)
        {
            throw new NotImplementedException();
        }
    }
}

using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Interfaces;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class ShotRepository : Repository<IShot>, IRemovableRepository<IShot>
    {
        private readonly DbSet<IShot> _shots;

        public async Task Create(IShot entity)
        {
            await HandleCancelTask(_shots.AddAsync(entity));
        }

        public async Task Delete(IShot entity)
        {
            await Task.Run(() => _shots.Remove(entity));
        }

        public async Task<List<IShot>> GetAllAsync()
        {
            return await HandleNullCancelTask(_shots.ToListAsync());
        }

        public async Task<IShot> GetAsync(string id)
        {
            return await _shots.FindAsync(id);
        }

        public async Task Update(IShot entity)
        {
            await Task.Run(() => _shots.Update(entity));
        }

        public ShotRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
        {
            _shots = dbContext.Set<IShot>();
        }
    }
}

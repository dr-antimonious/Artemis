using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class ShotRepository : Repository<Shot>, IRemovableRepository<Shot>
    {
        private readonly DbSet<Shot> _shots;

        public async Task Create(Shot entity)
            => await HandleCancelTask(_shots.AddAsync(entity));

        public async Task Delete(Shot entity)
            => await Task.Run(() => _shots.Remove(entity));

        public async Task<List<Shot>> GetAllAsync()
            => await HandleNullCancelTask(_shots.ToListAsync());

        public async Task<Shot?> GetAsync(string id)
            => await _shots.FindAsync(id);

        public async Task Update(Shot entity)
            => await Task.Run(() => _shots.Update(entity));

        public ShotRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
            => _shots = dbContext.Set<Shot>();
    }
}

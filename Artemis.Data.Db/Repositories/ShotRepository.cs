using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class ShotRepository : Repository<Shot>, IMultiRepository<Shot>
    {
        private readonly DbSet<Shot> _shots;

        public async Task Create(Shot entity)
            => await HandleCancelTask(_shots.AddAsync(entity));

        public async Task CreateMulti(List<Shot> shots)
            => await HandleCancelTask(_shots.AddRangeAsync(shots));

        public async Task Delete(Shot entity)
            => await Task.Run(() => _shots.Remove(entity));

        public async Task<List<Shot>> GetAllAsync()
            => await HandleNullCancelTask(_shots
                .Include(x => x.TimeStamp)
                .ToListAsync());

        public async Task<Shot?> GetAsync(string id)
            => await HandleNullCancelTask(_shots
                .Include(x => x.TimeStamp)
                .FirstOrDefaultAsync(x => x.Id.Equals(id)));

        public async Task<List<Shot>> GetMulti(List<string> ids)
            => await HandleNullCancelTask(
                _shots.Include(x => x.TimeStamp)
                    .Where(x => ids.Contains(x.Id))
                    .ToListAsync());

        public async Task Update(Shot entity)
            => await Task.Run(() => _shots.Update(entity));

        public async Task UpdateMulti(List<Shot> shots)
            => await Task.Run(() => _shots.UpdateRange(shots));

        public ShotRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
            => _shots = dbContext.Set<Shot>();
    }
}

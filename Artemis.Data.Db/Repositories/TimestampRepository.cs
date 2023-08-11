using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class TimestampRepository : Repository<Timestamp>, ITimestampRepository<Timestamp>
    {
        private readonly DbSet<Timestamp> _timestamps;

        public async Task Create(Timestamp entity)
        {
            await HandleCancelTask(_timestamps.AddAsync(entity));
        }

        public async Task<List<Timestamp>> GetAllAsync()
        {
            return await HandleNullCancelTask(_timestamps.ToListAsync());
        }

        public async Task<Timestamp> GetAsync(string id)
        {
            return await _timestamps.FindAsync(id);
        }

        public async Task<Timestamp?> GetByTimestamp(DateTime timestamp)
        {
            return await HandleNullCancelTask(
                _timestamps.FirstOrDefaultAsync(
                    x => x.TimeStamp.Equals(timestamp)));
        }

        public async Task Update(Timestamp entity)
        {
            await Task.Run(() => _timestamps.Update(entity));
        }

        public TimestampRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
        {
            _timestamps = dbContext.Set<Timestamp>();
        }
    }
}

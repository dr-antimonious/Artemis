using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Matches;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class MatchRepository : Repository<Match>, IMatchRepository<Match>
    {
        private readonly DbSet<Match> _matches;

        public async Task Create(Match entity)
            => await HandleCancelTask(_matches.AddAsync(entity));

        public async Task Delete(Match entity)
            => await Task.Run(() => _matches.Remove(entity));

        public async Task DeleteMulti(List<Match> entities)
            => await Task.Run(() => _matches.RemoveRange(entities));

        public async Task<List<Match>> GetAllAsync()
            => await HandleNullCancelTask(_matches
                .Include(x => x.Shooter)
                .Include(x => x.Location)
                .Include(x => x.StartTimestamp)
                .Include(x => x.EndTimestamp)
                .Include(x => x.Shots)
                .ToListAsync());

        public async Task<Match?> GetAsync(string id)
            => await HandleNullCancelTask(_matches
                .Include(x => x.Shooter)
                .Include(x => x.Location)
                .Include(x => x.StartTimestamp)
                .Include(x => x.EndTimestamp)
                .Include(x => x.Shots)
                .FirstOrDefaultAsync(x => x.Id.Equals(id)));

        public async Task<List<Match>> GetMulti(List<string> ids)
            => await HandleNullCancelTask(_matches
                .Include(x => x.Shooter)
                .Include(x => x.Location)
                .Include(x => x.StartTimestamp)
                .Include(x => x.EndTimestamp)
                .Include(x => x.Shots)
                .Where(x => ids.Contains(x.Id))
                .ToListAsync());

        public async Task<List<Match>> GetByUserIdAsync(string userId)
            => await HandleNullCancelTask(_matches
                .Include(x => x.Shooter)
                .Include(x => x.Location)
                .Include(x => x.StartTimestamp)
                .Include(x => x.EndTimestamp)
                .Where(x => x.Shooter.Id.Equals(userId))
                .ToListAsync());

        public async Task Update(Match entity)
            => await Task.Run(() => _matches.Update(entity));

        public MatchRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
            => _matches = dbContext.Set<Match>();
    }
}

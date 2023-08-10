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
        {
            await HandleCancelTask(_matches.AddAsync(entity));
        }

        public async Task Delete(Match entity)
        {
            await Task.Run(() => _matches.Remove(entity));
        }

        public async Task<List<Match>> GetAllAsync()
        {
            return await HandleNullCancelTask(_matches.ToListAsync());
        }

        public async Task<Match> GetAsync(string id)
        {
            return await _matches.FindAsync(id);
        }

        public async Task<List<Match>> GetByUserIdAsync(string userId)
        {
            return await HandleNullCancelTask(_matches.Where(
                x => x.Shooter.Id.Equals(userId)).ToListAsync());
        }

        public async Task Update(Match entity)
        {
            await Task.Run(() => _matches.Update(entity));
        }

        public MatchRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
        {
            _matches = dbContext.Set<Match>();
        }
    }
}

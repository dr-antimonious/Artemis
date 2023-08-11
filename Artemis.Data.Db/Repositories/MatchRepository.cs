using Artemis.Contracts.Entities;
using Artemis.Contracts.Entities.Interfaces;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class MatchRepository : Repository<IMatch>, IMatchRepository<IMatch>
    {
        private readonly DbSet<IMatch> _matches;

        public async Task Create(IMatch entity)
        {
            await HandleCancelTask(_matches.AddAsync(entity));
        }

        public async Task Delete(IMatch entity)
        {
            await Task.Run(() => _matches.Remove(entity));
        }

        public async Task<List<IMatch>> GetAllAsync()
        {
            return await HandleNullCancelTask(_matches.ToListAsync());
        }

        public async Task<IMatch> GetAsync(string id)
        {
            return await _matches.FindAsync(id);
        }

        public async Task<List<IMatch>> GetByUserIdAsync(string userId)
        {
            return await HandleNullCancelTask(_matches.Where(
                x => x.Shooter.Id.Equals(userId)).ToListAsync());
        }

        public async Task Update(IMatch entity)
        {
            await Task.Run(() => _matches.Update(entity));
        }

        public MatchRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
        {
            _matches = dbContext.Set<IMatch>();
        }
    }
}

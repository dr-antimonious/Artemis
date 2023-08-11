using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artemis.Data.Db.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository<User>
    {
        private readonly DbSet<User> _users;

        public async Task Create(User entity)
        {
            await HandleCancelTask(_users.AddAsync(entity));
        }

        public async Task Delete(User entity)
        {
            await Task.Run(() => _users.Remove(entity));
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await HandleNullCancelTask(_users.ToListAsync());
        }

        public async Task<User?> GetAsync(string id)
        {
            return await _users.FindAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await HandleNullCancelTask(
                _users.FirstOrDefaultAsync(
                    x => x.Email.Equals(email)));
        }

        public async Task Update(User entity)
        {
            await Task.Run(() => _users.Update(entity));
        }

        public UserRepository(IdentityDbContext<User, IdentityRole<string>, string> dbContext)
        {
            _users = dbContext.Set<User>();
        }
    }
}

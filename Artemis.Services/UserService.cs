using System.Security.Claims;
using Artemis.Contracts.DTOs;
using Artemis.Contracts.Entities;
using Artemis.Contracts.Repositories;

namespace Artemis.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ITokenGenerator _tokenGenerator;

        public async Task<TokenDto> Login(User user)
        {
            List<Claim> claims = new()
            {
                new(ClaimTypes.Email, user.Email),
                new("Full name", user.FullName),
                new("Id", user.Id),
            };

            return await _tokenGenerator.GenerateToken(claims);
        }

        public async Task<User?> GetByIdAsync(string id)
            => await _unitOfWork.Users.GetAsync(id);

        public async Task<User?> GetByEmailAsync(string email)
            => await _unitOfWork.Users.GetByEmailAsync(email);

        public async Task CreateUserAsync(User user)
        {
            await _unitOfWork.Users.Create(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            await _unitOfWork.Users.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public UserService(IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator)
        {
            this._unitOfWork = unitOfWork;
            this._tokenGenerator = tokenGenerator;
        }
    }
}

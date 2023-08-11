using System.Security.Claims;
using Artemis.Contracts.DTOs;

namespace Artemis.Services
{
    public interface ITokenGenerator
    {
        TokenDto GenerateToken(List<Claim> claims);
    }
}

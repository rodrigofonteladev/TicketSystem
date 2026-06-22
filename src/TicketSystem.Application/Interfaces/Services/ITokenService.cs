using TicketSystem.Application.DTOs.Auth;

namespace TicketSystem.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(UserTokenDataDTO userData);
    }
}
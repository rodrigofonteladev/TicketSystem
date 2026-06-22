using TicketSystem.Application.DTOs;
using TicketSystem.Application.DTOs.Auth;

namespace TicketSystem.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Result<LoginResponse>> LoginAsync(LoginRequest request);
        Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest request);
    }
}
using Microsoft.AspNetCore.Identity;
using TicketSystem.Application.DTOs;
using TicketSystem.Application.DTOs.Auth;
using TicketSystem.Application.Interfaces.Services;
using TicketSystem.Domain.Enum;
using TicketSystem.Infrastructure.Identity;

namespace TicketSystem.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return new Result<LoginResponse>(false, "The email or password is empty", null, ErrorType.Validation);

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return new Result<LoginResponse>(false, "Invalid credentials", null, ErrorType.Unauthorized);

            if (await _userManager.IsLockedOutAsync(user))
                return new Result<LoginResponse>(false, "Your account is temporarily blocked", null, ErrorType.Forbidden);

            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                await _userManager.AccessFailedAsync(user);
                if (await _userManager.IsLockedOutAsync(user))
                    return new Result<LoginResponse>(false, "Your account is temporarily blocked", null, ErrorType.Forbidden);

                return new Result<LoginResponse>(false, "Invalid credentials", null, ErrorType.Unauthorized);
            }
            await _userManager.ResetAccessFailedCountAsync(user);

            var roles = await _userManager.GetRolesAsync(user);
            var userData = new UserTokenDataDTO
            {
                UserId = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                Roles = roles
            };

            var token = _tokenService.GenerateToken(userData);
            var loginData = new LoginResponse(token);
            return new Result<LoginResponse>(true, "Successful login", loginData);
        }

        public async Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest request)
        {
            if (request.Password != request.ConfirmPassword)
                return new Result<RegisterResponse>(false, "Passwords do not match", null);

            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email
            };

            var createResult = await _userManager.CreateAsync(user, request.Password);
            if (!createResult.Succeeded)
            {
                var error = string.Join(", ", createResult.Errors.Select(e => e.Description));
                return new Result<RegisterResponse>(false, error, null);
            }

            var assignResult = await _userManager.AddToRoleAsync(user, UserRole.User.ToString());
            if (!assignResult.Succeeded)
            {
                var error = string.Join(",", assignResult.Errors.Select(e => e.Description));
                await _userManager.DeleteAsync(user);
                return new Result<RegisterResponse>(false, error, null);
            }

            var registerData = new RegisterResponse(user.Email);
            return new Result<RegisterResponse>(true, "Successfully registered user", registerData);
        }
    }
}
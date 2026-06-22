using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.DTOs.Auth;
using TicketSystem.Application.Interfaces.Services;
using TicketSystem.Domain.Enum;

namespace TicketSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result.IsSuccess) return BadRequest(new { message = result.Message });
            return Ok(result.Data);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.Validation => BadRequest(new { message = result.Message }),
                    ErrorType.Unauthorized => Unauthorized(new { message = result.Message }),
                    ErrorType.Forbidden => Forbid(),
                    _ => StatusCode(500, new { result.Message })
                };
            }
            return Ok(result.Data);
        }
    }
}
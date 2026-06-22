namespace TicketSystem.Application.DTOs.Auth
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string UserName,
        string Email,
        string Password,
        string ConfirmPassword
    );
}
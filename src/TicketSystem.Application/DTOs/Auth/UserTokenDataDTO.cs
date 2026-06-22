namespace TicketSystem.Application.DTOs.Auth
{
    public class UserTokenDataDTO
    {
        public required string UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }

        public ICollection<string> Roles { get; set; } = new List<string>();
    }
}

using TicketSystem.Domain.Common;

namespace TicketSystem.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public required string Content { get; set; }

        public required string UserId { get; set; }
        public Guid TicketId { get; set; }

        public Ticket Ticket { get; set; } = null!;
    }
}
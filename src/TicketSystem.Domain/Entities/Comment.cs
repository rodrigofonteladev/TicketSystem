using TicketSystem.Domain.Common;

namespace TicketSystem.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public required string Content { get; set; }

        public Guid UserId { get; set; }
        public Guid TicketId { get; set; }

        public Ticket Ticket { get; set; } = null!;
    }
}
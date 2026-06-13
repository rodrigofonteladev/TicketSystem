using TicketSystem.Domain.Common;

namespace TicketSystem.Domain.Entities
{
    public class TicketHistory : BaseEntity
    {
        public Guid UserId { get; set; }
        public required string FieldName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public required string ActionDescription { get; set; }

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}
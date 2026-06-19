using TicketSystem.Domain.Common;
using TicketSystem.Domain.Enum;

namespace TicketSystem.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TicketStatus Status { get; set; } = TicketStatus.Open;
        public TicketPriority Priority { get; set; }
        public required string CreatedByUserId { get; set; }
        public string? AssignedByUserId { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<TicketAttachment> Attachments { get; set; } = new List<TicketAttachment>();
        public ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
    }
}
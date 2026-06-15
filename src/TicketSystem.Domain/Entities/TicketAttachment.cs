using TicketSystem.Domain.Common;

namespace TicketSystem.Domain.Entities
{
    public class TicketAttachment : BaseEntity
    {
        public required string FileName { get; set; }
        public string CloudinaryPublicId { get; set; } = null!;
        public string SecureUrl { get; set; } = null!;
        public required string MimeType { get; set; }
        public long FileSize { get; set; }
        public required string UploadedByUserId { get; set; }

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}
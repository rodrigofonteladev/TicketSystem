using TicketSystem.Domain.Common;

namespace TicketSystem.Domain.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
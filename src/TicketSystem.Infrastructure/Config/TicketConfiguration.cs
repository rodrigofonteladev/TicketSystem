using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Infrastructure.Config
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(col => col.Title).HasMaxLength(150);
            builder.Property(col => col.Description).HasMaxLength(500);
            builder.Property(col => col.Status).HasConversion<string>();
            builder.Property(col => col.Priority).HasConversion<string>();
            builder.Property(col => col.CreatedByUserId).HasMaxLength(16);
            builder.Property(col => col.AssignedByUserId).HasMaxLength(16);
            builder
            .HasOne(t => t.Category)
            .WithMany(c => c.Tickets)
            .HasForeignKey(t => t.CategoryId);
        }
    }
}
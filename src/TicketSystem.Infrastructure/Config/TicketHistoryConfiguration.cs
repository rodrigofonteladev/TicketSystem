using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Infrastructure.Config
{
    public class TicketHistoryConfiguration : IEntityTypeConfiguration<TicketHistory>
    {
        public void Configure(EntityTypeBuilder<TicketHistory> builder)
        {
            builder.Property(col => col.UserId).HasMaxLength(450).IsRequired();
            builder.Property(col => col.FieldName).HasMaxLength(50);
            builder.Property(col => col.OldValue).HasMaxLength(500);
            builder.Property(col => col.NewValue).HasMaxLength(500);
            builder.Property(col => col.ActionDescription).HasMaxLength(500);
            builder
            .HasOne(th => th.Ticket)
            .WithMany(t => t.TicketHistories)
            .HasForeignKey(th => th.TicketId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
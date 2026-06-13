using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Infrastructure.Config
{
    public class TicketAttachmentConfiguration : IEntityTypeConfiguration<TicketAttachment>
    {
        public void Configure(EntityTypeBuilder<TicketAttachment> builder)
        {
            builder.Property(col => col.FileName).HasMaxLength(50);
            builder.Property(col => col.CloudinaryPublicId).IsRequired();
            builder.Property(col => col.SecureUrl).IsRequired();
            builder.Property(col => col.MimeType).HasMaxLength(50);
            builder.Property(col => col.UploadedByUserId).HasMaxLength(16);
            builder
            .HasOne(ta => ta.Ticket)
            .WithMany(t => t.Attachments)
            .HasForeignKey(ta => ta.TicketId);
        }
    }
}
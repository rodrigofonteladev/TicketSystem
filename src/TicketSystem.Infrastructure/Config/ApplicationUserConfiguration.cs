using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Infrastructure.Identity;

namespace TicketSystem.Infrastructure.Config
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(col => col.FirstName).HasMaxLength(100);
            builder.Property(col => col.LastName).HasMaxLength(100);
        }
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Domain.Entities;
using TicketSystem.Infrastructure.Config;
using TicketSystem.Infrastructure.Identity;

namespace TicketSystem.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(CommentConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(TicketAttachmentConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(TicketConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(TicketHistoryConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserConfiguration).Assembly);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketAttachment> Attachments { get; set; }
        public DbSet<TicketHistory> Histories { get; set; }

    }
}
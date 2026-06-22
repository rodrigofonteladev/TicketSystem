using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Domain.Enum;
using TicketSystem.Infrastructure.Identity;

namespace TicketSystem.Infrastructure.Seed
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await RoleSeeder.SeedAsync(roleManager);
            await AdminSeeder.SeedAsync(userManager);
        }
    }
}
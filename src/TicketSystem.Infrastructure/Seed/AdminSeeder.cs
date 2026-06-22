using Microsoft.AspNetCore.Identity;
using TicketSystem.Domain.Enum;
using TicketSystem.Infrastructure.Identity;

namespace TicketSystem.Infrastructure.Seed
{
    public static class AdminSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var adminEmail = "admin@correo.com";
            var adminPassword = "Admin123!";

            var adminUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
                Email = adminEmail
            };

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, UserRole.Admin.ToString());
            }
        }
    }
}
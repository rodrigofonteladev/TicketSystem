using Microsoft.AspNetCore.Identity;
using TicketSystem.Domain.Enum;

namespace TicketSystem.Infrastructure.Seed
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles =
            [
                UserRole.User.ToString(),
                UserRole.Agent.ToString(),
                UserRole.Admin.ToString()
            ];

            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
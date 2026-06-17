using Microsoft.AspNetCore.Identity;
using Tawreed.BLL.Constants;

namespace Tawreed.API.Extensions
{
    public static class RoleSeedExtensions
    {
        /// <summary>
        /// Seeds the three application roles into the database if they don't exist.
        /// Call this from Program.cs: await app.SeedRolesAsync();
        /// </summary>
        public static async Task SeedRolesAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            string[] roles = [AppRoles.Admin, AppRoles.Buyer, AppRoles.Supplier];

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
            }
        }
    }
}

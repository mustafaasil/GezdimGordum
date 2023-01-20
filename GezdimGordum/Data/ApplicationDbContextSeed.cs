using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GezdimGordum.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (!await userManager.Users.AnyAsync(x => x.UserName == "admin@example.com"))
            {
                var adminUser = new IdentityUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                };

                await userManager.CreateAsync(adminUser, "P@ssword1");
                await userManager.AddToRoleAsync(adminUser, "admin");
            }
        }

    }
}

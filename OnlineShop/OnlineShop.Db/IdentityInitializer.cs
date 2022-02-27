using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class IdentityInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminUser = "Admin";
            var adminEmail = "admin@admin.com";
            var password = "Admin12345";
            if (await roleManager.FindByNameAsync(Constants.AdminRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName));
            }
            if (await roleManager.FindByNameAsync(Constants.UserRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName));
            }
            if (await userManager.FindByNameAsync(adminUser) == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminUser };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Constants.AdminRoleName);
                }
            }
        }
    }
}

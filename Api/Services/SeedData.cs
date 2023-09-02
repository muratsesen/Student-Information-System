using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace Api.Services;

public static class SeedData
{
    public static void SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole
            {
                Name = "Admin"
            };

            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
        }
    }

    public static void SeedUsers(UserManager<IdentityUser> userManager)
    {
        if (userManager.FindByNameAsync("admin").Result == null)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@example.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "Admin123!").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }

    public static void Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        SeedRoles(roleManager);
        SeedUsers(userManager);
    }
}


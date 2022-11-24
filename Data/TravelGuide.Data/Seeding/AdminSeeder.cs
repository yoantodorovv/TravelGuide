﻿namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using TravelGuide.Data.Models;

    using static TravelGuide.Common.GlobalConstants;

    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedAdminAsync(userManager, "admin@admin.com");
        }

        private static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, string email)
        {
            var admin = new ApplicationUser()
            {
                FirstName = "Yoan",
                LastName = "Todorov",
                UserName = "admin",
                Email = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var result = await userManager.CreateAsync(admin, "admin123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, AdministratorRoleName);
            }
        }
    }
}

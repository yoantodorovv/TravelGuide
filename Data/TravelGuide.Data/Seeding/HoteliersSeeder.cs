namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using TravelGuide.Data.Models;

    using static TravelGuide.Common.GlobalConstants;

    /// <summary>
    /// A class to seed a user with role 'hotelier'.
    /// </summary>
    public class HoteliersSeeder : ISeeder
    {
        /// <summary>
        /// Seeds the hotelier.
        /// </summary>
        /// <param name="dbContext">The applicationDbContext.</param>
        /// <param name="serviceProvider">Injection of desired service.</param>
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedHotelierAsync(userManager, "hotelier@hostelier.com");
        }

        private static async Task SeedHotelierAsync(UserManager<ApplicationUser> userManager, string email)
        {
            var user = new ApplicationUser()
            {
                FirstName = "dummyName",
                LastName = "dummyName",
                UserName = "hotelier",
                Email = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, "hotelier123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, HotelierRoleName);
            }
        }
    }
}

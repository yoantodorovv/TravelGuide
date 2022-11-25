namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using TravelGuide.Data.Models;

    using static TravelGuide.Common.GlobalConstants;

    /// <summary>
    /// A class to seed a user with a 'restauranteur' role.
    /// </summary>
    public class RestauranteursSeeder : ISeeder
    {
        /// <summary>
        /// Seeds all restaurants into the restaurants table.
        /// </summary>
        /// <param name="dbContext">The applicationDbContext.</param>
        /// <param name="serviceProvider">Injection of desired service.</param>
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedRestauranteurAsync(userManager, "restauranteur@restauranteur.com");
        }

        private static async Task SeedRestauranteurAsync(UserManager<ApplicationUser> userManager, string email)
        {
            var user = new ApplicationUser()
            {
                FirstName = "dummyName",
                LastName = "dummyName",
                UserName = "restauranteur",
                Email = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var result = await userManager.CreateAsync(user, "restauranteur123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, RestauranteurRoleName);
            }
        }
    }
}

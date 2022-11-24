namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using TravelGuide.Data.Models;

    using static TravelGuide.Common.GlobalConstants;

    public class RestauranteursSeeder : ISeeder
    {
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

            var result = await userManager.CreateAsync(user, "restauranteur");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, RestauranteurRoleName);
            }
        }
    }
}

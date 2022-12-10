namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Central seeder.
    /// </summary>
    public class ApplicationDbContextSeeder : ISeeder
    {
        /// <summary>
        /// Seeds all data that is used.
        /// </summary>
        /// <param name="dbContext">The applicationDbContext.</param>
        /// <param name="serviceProvider">Injection of desired service.</param>
        /// <exception cref="ArgumentNullException">Throws an exception if eigther the dbContext or the serviceProvider is null.</exception>
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                              new AdminSeeder(),
                              new HoteliersSeeder(),
                              new RestauranteursSeeder(),
                              new DiscountsSeeder(),
                              new AmenitiesSeeder(),
                              //new TownsSeeder(),
                              //new AddressSeeder(),
                              //new HotelsSeeder(),
                              //new RestaurantsSeeder(),
                              //new ReviewSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}

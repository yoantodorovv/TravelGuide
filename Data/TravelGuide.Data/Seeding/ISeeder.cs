namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Seeder interface.
    /// </summary>
    public interface ISeeder
    {
        /// <summary>
        /// An asynchronious method to seed all data.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}

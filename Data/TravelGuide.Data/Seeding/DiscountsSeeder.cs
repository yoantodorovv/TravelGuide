namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    /// <summary>
    /// Discounts seeder class.
    /// </summary>
    public class DiscountsSeeder : ISeeder
    {
        /// <summary>
        /// Seeds all discounts into the discounts table.
        /// </summary>
        /// <param name="dbContext">The applicationDbContext.</param>
        /// <param name="serviceProvider">Injection of desired service.</param>
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Discounts.Any())
            {
                return;
            }

            var discounts = new List<Tuple<string, decimal>>
            {
                new Tuple<string, decimal>("Students", 5),
                new Tuple<string, decimal>("Students", 10),
                new Tuple<string, decimal>("Students", 20),
                new Tuple<string, decimal>("Students", 30),
                new Tuple<string, decimal>("Students", 40),
                new Tuple<string, decimal>("Students", 50),
                new Tuple<string, decimal>("Students", 70),
                new Tuple<string, decimal>("Children", 5),
                new Tuple<string, decimal>("Children", 10),
                new Tuple<string, decimal>("Children", 20),
                new Tuple<string, decimal>("Children", 30),
                new Tuple<string, decimal>("Children", 40),
                new Tuple<string, decimal>("Children", 50),
                new Tuple<string, decimal>("Children", 70),
                new Tuple<string, decimal>("Elder People", 5),
                new Tuple<string, decimal>("Elder People", 10),
                new Tuple<string, decimal>("Elder People", 20),
                new Tuple<string, decimal>("Elder People", 30),
                new Tuple<string, decimal>("Elder People", 40),
                new Tuple<string, decimal>("Elder People", 50),
                new Tuple<string, decimal>("Elder People", 70),
            };

            foreach (var discount in discounts)
            {
                await dbContext.Discounts.AddAsync(new Discount() { Title = discount.Item1, DiscountPercentage = discount.Item2 });
            }
        }
    }
}

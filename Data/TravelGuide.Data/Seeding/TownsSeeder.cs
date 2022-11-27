namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    public class TownsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Towns.Any())
            {
                return;
            }

            var towns = new List<Town>()
            {
                new Town()
                {
                    Name = "Pattaya",
                },
            };

            await dbContext.Towns.AddRangeAsync(towns);
        }
    }
}

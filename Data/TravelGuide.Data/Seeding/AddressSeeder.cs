namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    public class AddressSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Addresses.Any())
            {
                return;
            }

            var addresses = new List<Address>()
            {
                new Address()
                {
                    AddressText = "211 Moo 1 Na Jomtien Soi 4, Jomtien Beach",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
                new Address
                {
                    AddressText = "255/5 Moo 9, Pattaya Sai 2 Road, Na Kluea",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
                new Address
                {
                    AddressText = "10, Moo 9, North Pattaya Beach Road",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
                new Address
                {
                    AddressText = "37/2-11, Moo 2, Sukhumvit Road, Soi 8, Jomtien Beach",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
                new Address
                {
                    AddressText = "277 Moo 5 Naklua, Banglamung",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
                new Address
                {
                    AddressText = "399/9 Moo 10 Second Rd",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
                new Address
                {
                    AddressText = "333/101 Moo 9",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
                new Address
                {
                    AddressText = "333/101 Moo 9 Hilton Pattaya, 34th Floor",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
                new Address
                {
                    AddressText = "Thappraya road Soi 11, 391/6, Moo 10",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
                new Address
                {
                    AddressText = "353 Phra Tamnuk Road (part of the Royal Cliff Hotels Group)",
                    Country = "Thailand",
                    Town = dbContext.Towns.FirstOrDefault(),
                },
            };

            await dbContext.Addresses.AddRangeAsync(addresses);
        }
    }
}

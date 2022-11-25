namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Models;

    /// <summary>
    /// Amenities table seeder.
    /// </summary>
    public class AmenitiesSeeder : ISeeder
    {
        /// <summary>
        /// Seeds the amenities asynchroniously (if there are none in the database currently).
        /// </summary>
        /// <param name="dbContext">The applicationDbContext.</param>
        /// <param name="serviceProvider">Injection of desired service.</param>
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Amenities.Any())
            {
                return;
            }

            var amenities = new List<Tuple<string>>
            {
                new Tuple<string>("Free parking"),
                new Tuple<string>("Pool"),
                new Tuple<string>("Fitness center"),
                new Tuple<string>("Beachfront"),
                new Tuple<string>("Internet"),
                new Tuple<string>("Suites"),
                new Tuple<string>("Free Wifi"),
                new Tuple<string>("Kids Activities"),
                new Tuple<string>("Room Service"),
                new Tuple<string>("Wheelchair access"),
                new Tuple<string>("Restaurant"),
                new Tuple<string>("Spa"),
                new Tuple<string>("Airport transportation"),
                new Tuple<string>("Wifi"),
                new Tuple<string>("Public Wifi"),
                new Tuple<string>("Dry Cleaning"),
                new Tuple<string>("Meeting Rooms"),
                new Tuple<string>("Bar/Lounge"),
                new Tuple<string>("Non-smoking rooms"),
                new Tuple<string>("Business center"),
                new Tuple<string>("Laundry Service"),
                new Tuple<string>("Concierge"),
                new Tuple<string>("Banquet Room"),
                new Tuple<string>("Air Conditioning"),
                new Tuple<string>("Family Rooms"),
                new Tuple<string>("Multilingual Staff"),
                new Tuple<string>("Refrigerator in room"),
                new Tuple<string>("Babysitting"),
                new Tuple<string>("Breakfast Buffet"),
                new Tuple<string>("Poolside Bar"),
                new Tuple<string>("Private Balcony"),
                new Tuple<string>("Outdoor pool"),
                new Tuple<string>("Parking"),
                new Tuple<string>("Facilities for Disabled Guests"),
                new Tuple<string>("Housekeeping"),
                new Tuple<string>("Car Hire"),
                new Tuple<string>("Doorperson"),
                new Tuple<string>("Firness"),
                new Tuple<string>("Sauna"),
                new Tuple<string>("Baggage Storage"),
                new Tuple<string>("Couples massage"),
                new Tuple<string>("Fireplace"),
                new Tuple<string>("First Aid Kit"),
                new Tuple<string>("Foot Massage"),
                new Tuple<string>("Full Body Massage"),
                new Tuple<string>("Game Room"),
                new Tuple<string>("Hair Dryer"),
                new Tuple<string>("Pool view"),
                new Tuple<string>("Shops"),
                new Tuple<string>("Telephone"),
                new Tuple<string>("Umbrella"),
            };

            foreach (var amenity in amenities)
            {
                await dbContext.Amenities.AddAsync(new Amenity() { Title = amenity.Item1 });
            }
        }
    }
}

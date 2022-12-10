namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    /// <summary>
    /// A class which seeds all hotels (if there is no data in the table).
    /// </summary>
    public class HotelsSeeder : ISeeder
    {
        /// <summary>
        /// Seeds all hotels into the hotels table.
        /// </summary>
        /// <param name="dbContext">The applicationDbContext.</param>
        /// <param name="serviceProvider">Injection of desired service.</param>
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Hotels.Any())
            {
                return;
            }

            var amenities = new List<Amenity>()
            {
                new Amenity()
                {
                    Title = "Parking",
                },
                new Amenity()
                {
                    Title = "Free Internet",
                },
                new Amenity()
                {
                    Title = "Pool",
                },
                new Amenity()
                {
                    Title = "Fitness Center",
                },
                new Amenity()
                {
                    Title = "Free Wifi",
                },
                new Amenity()
                {
                    Title = "Spa",
                },
                new Amenity()
                {
                    Title = "Meeting Rooms",
                },
                new Amenity()
                {
                    Title = "Poolside Bar",
                },
                new Amenity()
                {
                    Title = "Full Body Massage",
                },
            };

            var workingHours = new List<WorkingHours>()
            {
                new WorkingHours()
                {
                    Text = "Monday",
                    RegistrationTime = 420,
                    LeaveTime = 1320,
                },
                new WorkingHours()
                {
                    Text = "Tuesday",
                    RegistrationTime = 420,
                    LeaveTime = 1320,
                },
                new WorkingHours()
                {
                    Text = "Wednesday",
                    RegistrationTime = 420,
                    LeaveTime = 1320,
                },
                new WorkingHours()
                {
                    Text = "Thursday",
                    RegistrationTime = 420,
                    LeaveTime = 1320,
                },
                new WorkingHours()
                {
                    Text = "Friday",
                    RegistrationTime = 420,
                    LeaveTime = 1320,
                },
                new WorkingHours()
                {
                    Text = "Saturday",
                    RegistrationTime = 420,
                    LeaveTime = 1320,
                },
                new WorkingHours()
                {
                    Text = "Sunday",
                    RegistrationTime = 420,
                    LeaveTime = 1320,
                },
            };

            //var hotels = new List<Hotel>
            //{
            //    new Hotel()
            //    {
            //        OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "EA85E689-3D43-4016-165E-08DAD7506F72").Id,
            //        Name = "Centara Grand Mirage Beach Resort Pattaya",
            //        Location = "Pattaya, Chonburi Province",
            //        Price = 150,
            //        Details = "Centara Grand Mirage Beach Resort Pattaya is an exciting Lost World themed resort on Wong Amat Beach. You will enjoy 555 sea-facing rooms, suites and family residences (from 42 to 326 sqm.), eight dining venues, an award-winning spa, and a gigantic water park. The Lost World features a freeform pool, a meandering lazy river, waterslides, an adult’s pool, Jacuzzis, cliff jumping platforms, and Monsoon Island children’s water playground. Children can also enjoy two kids clubs, a club lounge dedicated to families, and a plethora of activities. The 230-metre beach is perfect for water sports. A PADI dive centre is also available. Spa Cenvaree is a true refuge for the senses and has 24 treatment rooms and a yoga and meditation pavilion. Other facilities include a fitness centre, two tennis courts and rock climbing facilities. A shuttle service connects to Central Festival Pattaya shopping and lifestyle centre. Bangkok’s Suvarnabhumi International Airport is approximately 90 minutes away.",
            //        Rating = 4.5,
            //        Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "ED5A38E7-78F5-43FB-5E6F-08DAD750F9C9"),
            //        PhoneNumber = "+66 81 863 3010",
            //        WebsiteUrl = "http://www.centarahotelsresorts.com/centaragrand/cmbr/",
            //        Email = "cmbr@chr.co.th",
            //        //Amenities = amenities,
            //        Reviews = null,
            //        WorkingHours = workingHours,
            //        Images = null, // TODO: Finish Images
            //    },
            //    new Hotel()
            //    {
            //        OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "EA85E689-3D43-4016-165E-08DAD7506F72").Id,
            //        Name = "Pinnacle Grand Jomtien Resort",
            //        Location = "Jomtien Beach, Pattaya, Chonburi Province",
            //        Price = 75,
            //        Details = "The PINNACLE Grand Jomtien Resort & Spa is located on its own private beach separated from the Jomtien/Pattaya beaches, and is about 9 km from South Pattaya. The hotel low rise buildings are set amidst a tropical landscape of lawns, pools and tropical trees. The 345 hotel rooms and suites are located in 8 low rise buildings (ground floor + 2 floors) which are grouped around a free size swimming pool with a children's paddle pool, the Pool Bar and a large pond amidst a tropical garden with palm trees flowering shrubs and orchids. Beyond this area lays the second swimming pool, a large lawn with palm trees and sunshades, the Beach Restaurant and Bar and the wide sandy beach. Two more pools can be found spread around the property, close to the guest accommodations. The PINNACLE Grand Jomtien Resort & Spa is specially suited for families and guests who want a private, peaceful and relaxing holiday on a private beach while shopping, entertainment, and festivities of Pattaya are awaiting.",
            //        Rating = 4.0,
            //        Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "ED5A38E7-78F5-43FB-5E6F-08DAD750F9C9"),
            //        PhoneNumber = "+66 38 259 100",
            //        WebsiteUrl = "https://pattaya.pinnaclehotels.com/",
            //        Email = "prjreserv@gmail.com",
            //        //Amenities = amenities,
            //        Reviews = null,
            //        WorkingHours = workingHours,
            //        Images = null, // TODO: Finish Images
            //    },
            //    new Hotel()
            //    {
            //        OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "EA85E689-3D43-4016-165E-08DAD7506F72").Id,
            //        Name = "Mytt Beach Hotel",
            //        Location = "Pattaya, Chonburi Province",
            //        Price = 100,
            //        Details = "The Mytt Beach Hotel in Pattaya is a modern, Set in the heart of North Pattaya, just a few steps away from the beach, our luxury 5-star Pattaya hotel provides exceptional facilities at surprisingly affordable rates, making it truly outstanding value for money.",
            //        Rating = 5.0,
            //        Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "ED5A38E7-78F5-43FB-5E6F-08DAD750F9C9"),
            //        PhoneNumber = "+66 91 735 8169",
            //        WebsiteUrl = "http://www.mytthotel.com/?partner=2751&gclid=EAIaIQobChMI-JeW9vWn5QIViIqPCh2LxwLoEAAYASAAEgJ-SPD_BwE",
            //        Email = "info@mytthotel.com",
            //        //Amenities = amenities,
            //        Reviews = null,
            //        WorkingHours = workingHours,
            //        Images = null, // TODO: Finish Images
            //    },
            //    new Hotel()
            //    {
            //        OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "EA85E689-3D43-4016-165E-08DAD7506F72").Id,
            //        Name = "Red Planet Pattaya",
            //        Location = "Na Kluea, Pattaya, Chonburi Province",
            //        Price = 20,
            //        Details = "The 192-room Red Planet Pattaya is the lift guests need to tap into this dynamic destination for all its worth. Designed for both business and leisure travellers, Red Planet Pattaya is situated in North Pattaya on Second Road, providing guests with easily access to Pattaya Beach, the Royal Garden Plaza, the Pattaya Avenue Shopping Mall, excellent restaurants serving local and international food and a pulsating nightlife. The Red Planet Pattaya has redefined the value-hotel sector by offering an all-inclusive rate for every room, every night. All rooms have free high-speed Wi-Fi (up to three devices), soothing power showers, quality custom-made beds with upscale linen and many other features including air conditioning, in-room safes, hair dryers, ceiling fans and a 32-inch flat screen TV. There are no hidden costs in the room rates or the amenities we provide.",
            //        Rating = 4.0,
            //        Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "ED5A38E7-78F5-43FB-5E6F-08DAD750F9C9"),
            //        PhoneNumber = "+66 2 613 5888",
            //        WebsiteUrl = "http://www.redplanethotels.com/hotel/pattaya",
            //        Email = "thailand@redplanethotels.com",
            //        //Amenities = amenities,
            //        Reviews = null,
            //        WorkingHours = workingHours,
            //        Images = null, // TODO: Finish Images
            //    },
            //    new Hotel()
            //    {
            //        OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "EA85E689-3D43-4016-165E-08DAD7506F72").Id,
            //        Name = "Centre Point Hotel Pattaya",
            //        Location = "Pattaya, Chonburi Province",
            //        Price = 50,
            //        Details = "VERANDA RESORT PATTAYA MGallery by Sofitel ON NA JOMTIEN BEACH WHICH IS CLOSE ENOUGH TO PATTAYA CITY'S BUZZING NEIGHBOURHOODS, YET SECLUDED ENOUGH TO ENSURE A PEACEFUL AND RELAXING STAY WITH FRIENDS, FAMILY OR LOVED ONES.EXCLUSIVE BEACHFRONT LOCATION ENSURES A PERFECT VIEW OVER THE OCEAN AND NEARBY ISLANDS.",
            //        Rating = 4.0,
            //        Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "ED5A38E7-78F5-43FB-5E6F-08DAD750F9C9"),
            //        PhoneNumber = "+66 81 944 5571",
            //        WebsiteUrl = "http://www.verandaresort.com",
            //        Email = "HA0E9-RE@accor.com",
            //        //Amenities = amenities,
            //        Reviews = null,
            //        WorkingHours = workingHours,
            //        Images = null, // TODO: Finish Images
            //    },
            //};

            //foreach (var hotel in hotels)
            //{
            //    await dbContext.Hotels.AddAsync(new Hotel()
            //    {
            //        OwnerId = hotel.OwnerId,
            //        Name = hotel.Name,
            //        Location = hotel.Location,
            //        Price = hotel.Price,
            //        Details = hotel.Details,
            //        Rating = hotel.Rating,
            //        Address = hotel.Address,
            //        PhoneNumber = hotel.PhoneNumber,
            //        WebsiteUrl = hotel.WebsiteUrl,
            //        Email = hotel.Email,
            //        //Amenities = hotel.Amenities,
            //        Reviews = hotel.Reviews,
            //        WorkingHours = hotel.WorkingHours,
            //        Images = hotel.Images,
            //    });
            //}
        }
    }
}

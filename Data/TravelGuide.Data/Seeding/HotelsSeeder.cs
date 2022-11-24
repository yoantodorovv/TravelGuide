namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    public class HotelsSeeder : ISeeder
    {
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
                },new Amenity()
                {
                    Title = "Spa",
                },new Amenity()
                {
                    Title = "Meeting Rooms",
                },new Amenity()
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
                    WeekDay = "Monday",
                    OpenTime = 420,
                    CloseTime = 1320,
                },
                new WorkingHours()
                {
                    WeekDay = "Tuesday",
                    OpenTime = 420,
                    CloseTime = 1320,
                },
                new WorkingHours()
                {
                    WeekDay = "Wednesday",
                    OpenTime = 420,
                    CloseTime = 1320,
                },
                new WorkingHours()
                {
                    WeekDay = "Thursday",
                    OpenTime = 420,
                    CloseTime = 1320,
                },
                new WorkingHours()
                {
                    WeekDay = "Friday",
                    OpenTime = 420,
                    CloseTime = 1320,
                },
                new WorkingHours()
                {
                    WeekDay = "Saturday",
                    OpenTime = 420,
                    CloseTime = 1320,
                },
                new WorkingHours()
                {
                    WeekDay = "Sunday",
                    OpenTime = 420,
                    CloseTime = 1320,
                },
            };

            var hotels = new List<Hotel>
            {
                new Hotel()
                {
                    Name = "Centara Grand Mirage Beach Resort Pattaya",
                    Location = "Pattaya, Chonburi Province",
                    Price = 150,
                    Details = "Centara Grand Mirage Beach Resort Pattaya is an exciting Lost World themed resort on Wong Amat Beach. You will enjoy 555 sea-facing rooms, suites and family residences (from 42 to 326 sqm.), eight dining venues, an award-winning spa, and a gigantic water park. The Lost World features a freeform pool, a meandering lazy river, waterslides, an adult’s pool, Jacuzzis, cliff jumping platforms, and Monsoon Island children’s water playground. Children can also enjoy two kids clubs, a club lounge dedicated to families, and a plethora of activities. The 230-metre beach is perfect for water sports. A PADI dive centre is also available. Spa Cenvaree is a true refuge for the senses and has 24 treatment rooms and a yoga and meditation pavilion. Other facilities include a fitness centre, two tennis courts and rock climbing facilities. A shuttle service connects to Central Festival Pattaya shopping and lifestyle centre. Bangkok’s Suvarnabhumi International Airport is approximately 90 minutes away.",
                    Rating = 4.5,
                    Adress = "277 Moo 5 Naklua, Banglamung, Pattaya 20150 Thailand",
                    PhoneNumber = "+66 81 863 3010",
                    WebsiteUrl = "http://www.centarahotelsresorts.com/centaragrand/cmbr/",
                    Email = "cmbr@chr.co.th",
                    Amenities = amenities,
                    Reviews = new List<Review>()
                    {
                        new Review()
                        {
                            Title = "A very delightful experience",
                            Rating = 8.0,
                            Description = "The rooms were clean, very comfortable, and the staff was amazing. They went over and beyond to help make our stay enjoyable. I highly recommend this hotel for anyone visiting downtown.",
                        },
                        new Review()
                        {
                            Title = "Perfect weekend getaway hotel",
                            Rating = 10.0,
                            Description = "This is the perfect hotel for a weekend getaway. The downtown area on Main Street is a best kept secret and the hotel offers everything you need if you don’t feel like venturing out.",
                        },
                        new Review()
                        {
                            Title = "A pleasent stay",
                            Rating = 6.5,
                            Description = "Overall, I had a great experience with the hotel; staff was incredibly helpful, and the amenities were great. The room was wonderful, clean, and perfect to celebrate a birthday weekend.",
                        },
                    },
                    WorkingHours = workingHours,
                    Images = null, // TODO: Finish Images
                },
                new Hotel()
                {
                    Name = "Pinnacle Grand Jomtien Resort",
                    Location = "Jomtien Beach, Pattaya, Chonburi Province",
                    Price = 75,
                    Details = "The PINNACLE Grand Jomtien Resort & Spa is located on its own private beach separated from the Jomtien/Pattaya beaches, and is about 9 km from South Pattaya. The hotel low rise buildings are set amidst a tropical landscape of lawns, pools and tropical trees. The 345 hotel rooms and suites are located in 8 low rise buildings (ground floor + 2 floors) which are grouped around a free size swimming pool with a children's paddle pool, the Pool Bar and a large pond amidst a tropical garden with palm trees flowering shrubs and orchids. Beyond this area lays the second swimming pool, a large lawn with palm trees and sunshades, the Beach Restaurant and Bar and the wide sandy beach. Two more pools can be found spread around the property, close to the guest accommodations. The PINNACLE Grand Jomtien Resort & Spa is specially suited for families and guests who want a private, peaceful and relaxing holiday on a private beach while shopping, entertainment, and festivities of Pattaya are awaiting.",
                    Rating = 4.0,
                    Adress = "37/2-11, Moo 2, Sukhumvit Road, Soi 8, Jomtien Beach, Pattaya 20250 Thailand",
                    PhoneNumber = "+66 38 259 100",
                    WebsiteUrl = "https://pattaya.pinnaclehotels.com/",
                    Email = "prjreserv@gmail.com",
                    Amenities = amenities,
                    Reviews = new List<Review>()
                    {
                        new Review()
                        {
                            Title = "A very delightful experience",
                            Rating = 8.0,
                            Description = "The rooms were clean, very comfortable, and the staff was amazing. They went over and beyond to help make our stay enjoyable. I highly recommend this hotel for anyone visiting downtown.",
                        },
                        new Review()
                        {
                            Title = "Perfect weekend getaway hotel",
                            Rating = 10.0,
                            Description = "This is the perfect hotel for a weekend getaway. The downtown area on Main Street is a best kept secret and the hotel offers everything you need if you don’t feel like venturing out.",
                        },
                        new Review()
                        {
                            Title = "The Best Hotel",
                            Rating = 10.0,
                            Description = "The best hotel I’ve ever been privileged enough to stay at. Gorgeous building, and it only gets more breathtaking when you walk in. High quality rooms (there was even a tv by the shower), and high quality service. Also, they are one of few hotels that allow people under 21 to book a reservation.",
                        },
                    },
                    WorkingHours = workingHours,
                    Images = null, // TODO: Finish Images
                },
                new Hotel()
                {
                    Name = "Mytt Beach Hotel",
                    Location = "Pattaya, Chonburi Province",
                    Price = 100,
                    Details = "The Mytt Beach Hotel in Pattaya is a modern, Set in the heart of North Pattaya, just a few steps away from the beach, our luxury 5-star Pattaya hotel provides exceptional facilities at surprisingly affordable rates, making it truly outstanding value for money.",
                    Rating = 5.0,
                    Adress = "10, Moo 9, North Pattaya Beach Road, Pattaya 20150 Thailand",
                    PhoneNumber = "+66 91 735 8169",
                    WebsiteUrl = "http://www.mytthotel.com/?partner=2751&gclid=EAIaIQobChMI-JeW9vWn5QIViIqPCh2LxwLoEAAYASAAEgJ-SPD_BwE",
                    Email = "info@mytthotel.com",
                    Amenities = amenities,
                    Reviews = new List<Review>()
                    {
                        new Review()
                        {
                            Title = "A very delightful experience",
                            Rating = 8.0,
                            Description = "The rooms were clean, very comfortable, and the staff was amazing. They went over and beyond to help make our stay enjoyable. I highly recommend this hotel for anyone visiting downtown.",
                        },
                        new Review()
                        {
                            Title = "A pleasent stay",
                            Rating = 6.5,
                            Description = "Overall, I had a great experience with the hotel; staff was incredibly helpful, and the amenities were great. The room was wonderful, clean, and perfect to celebrate a birthday weekend.",
                        },
                    },
                    WorkingHours = workingHours,
                    Images = null, // TODO: Finish Images
                },
                new Hotel()
                {
                    Name = "Red Planet Pattaya",
                    Location = "Na Kluea, Pattaya, Chonburi Province",
                    Price = 20,
                    Details = "The 192-room Red Planet Pattaya is the lift guests need to tap into this dynamic destination for all its worth. Designed for both business and leisure travellers, Red Planet Pattaya is situated in North Pattaya on Second Road, providing guests with easily access to Pattaya Beach, the Royal Garden Plaza, the Pattaya Avenue Shopping Mall, excellent restaurants serving local and international food and a pulsating nightlife. The Red Planet Pattaya has redefined the value-hotel sector by offering an all-inclusive rate for every room, every night. All rooms have free high-speed Wi-Fi (up to three devices), soothing power showers, quality custom-made beds with upscale linen and many other features including air conditioning, in-room safes, hair dryers, ceiling fans and a 32-inch flat screen TV. There are no hidden costs in the room rates or the amenities we provide.",
                    Rating = 4.0,
                    Adress = "255/5 Moo 9, Pattaya Sai 2 Road, Na Kluea, Pattaya 20150 Thailand",
                    PhoneNumber = "+66 2 613 5888",
                    WebsiteUrl = "http://www.redplanethotels.com/hotel/pattaya",
                    Email = "thailand@redplanethotels.com",
                    Amenities = amenities,
                    Reviews = new List<Review>()
                    {
                        new Review()
                        {
                            Title = "A very delightful experience",
                            Rating = 8.0,
                            Description = "The rooms were clean, very comfortable, and the staff was amazing. They went over and beyond to help make our stay enjoyable. I highly recommend this hotel for anyone visiting downtown.",
                        },
                        new Review()
                        {
                            Title = "Perfect weekend getaway hotel",
                            Rating = 10.0,
                            Description = "This is the perfect hotel for a weekend getaway. The downtown area on Main Street is a best kept secret and the hotel offers everything you need if you don’t feel like venturing out.",
                        },
                        new Review()
                        {
                            Title = "A pleasent stay",
                            Rating = 6.5,
                            Description = "Overall, I had a great experience with the hotel; staff was incredibly helpful, and the amenities were great. The room was wonderful, clean, and perfect to celebrate a birthday weekend.",
                        },
                    },
                    WorkingHours = workingHours,
                    Images = null, // TODO: Finish Images
                },
                new Hotel()
                {
                    Name = "Centre Point Hotel Pattaya",
                    Location = "Pattaya, Chonburi Province",
                    Price = 50,
                    Details = "VERANDA RESORT PATTAYA MGallery by Sofitel ON NA JOMTIEN BEACH WHICH IS CLOSE ENOUGH TO PATTAYA CITY'S BUZZING NEIGHBOURHOODS, YET SECLUDED ENOUGH TO ENSURE A PEACEFUL AND RELAXING STAY WITH FRIENDS, FAMILY OR LOVED ONES.EXCLUSIVE BEACHFRONT LOCATION ENSURES A PERFECT VIEW OVER THE OCEAN AND NEARBY ISLANDS.",
                    Rating = 4.0,
                    Adress = "211 Moo 1 Na Jomtien Soi 4, Jomtien Beach, Pattaya 20250 Thailand",
                    PhoneNumber = "+66 81 944 5571",
                    WebsiteUrl = "http://www.verandaresort.com",
                    Email = "HA0E9-RE@accor.com",
                    Amenities = amenities,
                    Reviews = new List<Review>()
                    {
                        new Review()
                        {
                            Title = "A very delightful experience",
                            Rating = 8.0,
                            Description = "The rooms were clean, very comfortable, and the staff was amazing. They went over and beyond to help make our stay enjoyable. I highly recommend this hotel for anyone visiting downtown.",
                        },
                        new Review()
                        {
                            Title = "A pleasent stay",
                            Rating = 6.5,
                            Description = "Overall, I had a great experience with the hotel; staff was incredibly helpful, and the amenities were great. The room was wonderful, clean, and perfect to celebrate a birthday weekend.",
                        },
                    },
                    WorkingHours = workingHours,
                    Images = null, // TODO: Finish Images
                },
            };

            foreach (var hotel in hotels)
            {
                await dbContext.Hotels.AddAsync(new Hotel() { Name = hotel.Name, Location = hotel.Location, Price = hotel.Price, Details = hotel.Details, Rating = hotel.Rating, Adress = hotel.Adress, PhoneNumber = hotel.PhoneNumber, WebsiteUrl = hotel.WebsiteUrl, Email = hotel.Email });
            }
        }

    }
}

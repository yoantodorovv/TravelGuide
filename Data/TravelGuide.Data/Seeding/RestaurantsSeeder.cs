namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    /// <summary>
    /// A class to seed all restaurants into the restaurants table.
    /// </summary>
    public class RestaurantsSeeder : ISeeder
    {
        /// <summary>
        /// Seeds all restaurants into the restaurants table.
        /// </summary>
        /// <param name="dbContext">The applicationDbContext.</param>
        /// <param name="serviceProvider">Injection of desired service.</param>
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Restaurants.Any())
            {
                return;
            }

            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "4324B389-2CE0-47B2-0359-08DACE3E769D").Id,
                    Name = "Robin Hood Tavern",
                    Rating = 5.0,
                    Location = "Pattaya, Chonburi Province",
                    PriceRange = "$99 - $2,500",
                    Description = "Gastro pub A Family Orientated, Air Conditioned, Clean and Very Spacious Restaurant Serving both Western & Thai Food with a modern flare",
                    PhoneNumber = "+66 38 410 511",
                    Address = "399/9 Moo 10 Second Rd, Pattaya 20150 Thailand",
                    WebsiteUrl = "http://www.rhpattaya.com/",
                    Email = "www.robinhoodtavernavenue@gmail.com",
                    MenuUrl = "https://www.facebook.com/Therobinhoodpattaya/",
                    Reviews = null,
                    WorkingHours = new List<WorkingHours>()
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
                    },
                    Images = null, // TODO: Finish Images
                },
                new Restaurant()
                {
                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "4324B389-2CE0-47B2-0359-08DACE3E769D").Id,
                    Name = "Edge",
                    Rating = 4.5,
                    Location = "Pattaya, Chonburi Province",
                    PriceRange = "$520 - $1,400",
                    Description = "Discover the ever changing, pan Asian dinning concept at Edge where contemporary open kitchens present a dazzling range of cuisine from around the globe.",
                    PhoneNumber = "+66 38 253 000",
                    Address = "333/101 Moo 9, Pattaya 20260 Thailand",
                    WebsiteUrl = "http://pattaya.hilton.com",
                    Email = "BKKHP.Pattaya.Info@hilton.com",
                    MenuUrl = "http://pattaya.hilton.com",
                    Reviews = null,
                    WorkingHours = new List<WorkingHours>()
                    {
                        new WorkingHours()
                        {
                            WeekDay = "Monday",
                            OpenTime = 360,
                            CloseTime = 660,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Tuesday",
                            OpenTime = 720,
                            CloseTime = 900,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Wednesday",
                            OpenTime = 1020,
                            CloseTime = 1320,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Thursday",
                            OpenTime = 360,
                            CloseTime = 630,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Friday",
                            OpenTime = 1020,
                            CloseTime = 1320,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Saturday",
                            OpenTime = 360,
                            CloseTime = 630,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Sunday",
                            OpenTime = 1020,
                            CloseTime = 1320,
                        },
                    },
                    Images = null, // TODO: Finish Images
                },
                new Restaurant()
                {
                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "4324B389-2CE0-47B2-0359-08DACE3E769D").Id,
                    Name = "Horizon",
                    Rating = 4.5,
                    Location = "Pattaya, Chonburi Province",
                    PriceRange = "$300 - $4,000",
                    Description = "Located on level 34 of Hilton Pattaya, this unique rooftop venue offers some of the most breathtaking views of Pattaya. Sleek and sophisticated, this Pattaya restaurant and bar is a truly exclusive hideaway from the bustling city below. Indulge in the delicious menu with a twist or simply relax in the Infinity Bar and enjoy the gentle sea breezes in comfort and style. Luxurious and chic, Horizon is also perfect for weddings and special occasions.",
                    PhoneNumber = "+66 38 253 079",
                    Address = "333/101 Moo 9 Hilton Pattaya, 34th Floor, Pattaya 20260 Thailand",
                    WebsiteUrl = "http://pattaya.hilton.com",
                    Email = "BKKHP.Pattaya.Info@hilton.com",
                    MenuUrl = "https://horizon.bar",
                    Reviews = null,
                    WorkingHours = new List<WorkingHours>()
                    {
                        new WorkingHours()
                        {
                            WeekDay = "Monday",
                            OpenTime = 960,
                            CloseTime = 1500,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Tuesday",
                            OpenTime = 960,
                            CloseTime = 1500,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Wednesday",
                            OpenTime = 960,
                            CloseTime = 1500,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Thursday",
                            OpenTime = 960,
                            CloseTime = 1500,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Friday",
                            OpenTime = 960,
                            CloseTime = 1500,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Saturday",
                            OpenTime = 960,
                            CloseTime = 1500,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Sunday",
                            OpenTime = 960,
                            CloseTime = 1500,
                        },
                    },
                    Images = null, // TODO: Finish Images
                },
                new Restaurant()
                {
                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "4324B389-2CE0-47B2-0359-08DACE3E769D").Id,
                    Name = "Cafe des Amis Fine Dining",
                    Rating = 5.0,
                    Location = "Pattaya, Chonburi Province",
                    PriceRange = "$600 - $3,000",
                    Description = "We are family owned independent restaurant since 2008. Fine Dining, French and European cuisine. We offer 5 or 6 course Dégustation Menu’s and the largest selection of imported beef from Aus, USA, Japan. as well as some amazing Fish. Snow fish, oysters lobster scallops, large wine list, fine spirits, cocktails, Largest Gin selection in ASIA 180+ Gins, 30 Vodkas, 60 Whiskeys. Indoor and outdoor air conditioned dining areas, Romantic restaurant. Perfect for a birthday anniversary or family celebration. Cafe des Amis is elegant but relaxed and not stuffy or posh. We aspire to the challenges of keeping every customer happy and providing a high class eatery for the area. Our garden terrace dining area is perfect for children. Please use Grab Taxi app to get to us we are located 1km from walking street. Limited Vegetarian available. We have smartly dressed guests celebrating special occasions such as wedding anniversaries. Please respect our Dress Code: Smart Casual, No Flip Flops or beach",
                    PhoneNumber = "+66 84 026 4989",
                    Address = "Thappraya road Soi 11, 391/6, Moo 10,, Pattaya 20150 Thailand",
                    WebsiteUrl = "http://www.cafe-des-amis.com/",
                    Email = "info@cafedesamispattaya.com",
                    MenuUrl = "https://www.cafe-des-amis.com/menus",
                    Reviews = null,
                    WorkingHours = new List<WorkingHours>()
                    {
                        new WorkingHours()
                        {
                            WeekDay = "Monday",
                            OpenTime = 1020,
                            CloseTime = 1350,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Tuesday",
                            OpenTime = 1020,
                            CloseTime = 1350,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Wednesday",
                            OpenTime = 1020,
                            CloseTime = 1350,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Thursday",
                            OpenTime = 1020,
                            CloseTime = 1350,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Friday",
                            OpenTime = 1020,
                            CloseTime = 1350,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Saturday",
                            OpenTime = 1020,
                            CloseTime = 1350,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Sunday",
                            OpenTime = 1020,
                            CloseTime = 1350,
                        },
                    },
                    Images = null, // TODO: Finish Images
                },
                new Restaurant()
                {
                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "4324B389-2CE0-47B2-0359-08DACE3E769D").Id,
                    Name = "Maharani",
                    Rating = 5.0,
                    Location = "Pattaya, Chonburi Province",
                    PriceRange = "$25",
                    Description = "The jewel in the crown of Indian restaurants. The recently renovated Maharani restaurant offers authentic Indian cuisines from all over the subcontinent. Guests can relish one of the best Indian cuisines in Pattaya whilst enjoying the spectacular view of the gulf of Thailand. Our talented Indian kitchen team creates dishes and menus combining Indian ingredients with creative recipes and for these reasons many locals have hailed this restaurant as one of the best in Pattaya.",
                    PhoneNumber = "+66 38 250 421",
                    Address = "353 Phra Tamnuk Road (part of the Royal Cliff Hotels Group), Pattaya 20150 Thailand",
                    WebsiteUrl = "http://www.royalcliff.com/restaurants-maharani.php",
                    Email = "gro-main@royalcliff.com",
                    MenuUrl = "https://www.royalcliff.com/weekly_menu.php?c=maharani",
                    Reviews = null,
                    WorkingHours = new List<WorkingHours>()
                    {
                        new WorkingHours()
                        {
                            WeekDay = "Monday",
                            OpenTime = 1080,
                            CloseTime = 1380,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Tuesday",
                            OpenTime = 1080,
                            CloseTime = 1380,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Wednesday",
                            OpenTime = 1080,
                            CloseTime = 1380,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Thursday",
                            OpenTime = 1080,
                            CloseTime = 1380,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Friday",
                            OpenTime = 1080,
                            CloseTime = 1380,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Saturday",
                            OpenTime = 1080,
                            CloseTime = 1380,
                        },
                        new WorkingHours()
                        {
                            WeekDay = "Sunday",
                            OpenTime = 1080,
                            CloseTime = 1380,
                        },
                    },
                    Images = null, // TODO: Finish Images
                },
            };

            foreach (var restaurant in restaurants)
            {
                await dbContext.Restaurants.AddAsync(new Restaurant()
                {
                    OwnerId = restaurant.OwnerId,
                    Name = restaurant.Name,
                    Rating = restaurant.Rating,
                    Location = restaurant.Location,
                    PriceRange = restaurant.PriceRange,
                    Description = restaurant.Description,
                    PhoneNumber = restaurant.PhoneNumber,
                    Address = restaurant.Address,
                    WebsiteUrl = restaurant.WebsiteUrl,
                    Email = restaurant.Email,
                    MenuUrl = restaurant.MenuUrl,
                    Reviews = restaurant.Reviews,
                    WorkingHours = restaurant.WorkingHours,
                    Images = restaurant.Images,
                });
            }
        }
    }
}

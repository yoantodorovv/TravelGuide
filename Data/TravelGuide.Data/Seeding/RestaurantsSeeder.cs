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

            //            var restaurants = new List<Restaurant>()
            //            {
            //                new Restaurant()
            //                {
            //                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "0F2EF011-C52C-4380-165F-08DAD7506F72").Id,
            //                    Name = "Robin Hood Tavern",
            //                    Rating = 5.0,
            //                    Location = "Pattaya, Chonburi Province",
            //                    PriceRange = "$99 - $2,500",
            //                    Description = "Gastro pub A Family Orientated, Air Conditioned, Clean and Very Spacious Restaurant Serving both Western & Thai Food with a modern flare",
            //                    PhoneNumber = "+66 38 410 511",
            //                  Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "356F8EE1-95EE-4C94-5E75-08DAD750F9C9"),
            //                    WebsiteUrl = "http://www.rhpattaya.com/",
            //                    Email = "www.robinhoodtavernavenue@gmail.com",
            //                    MenuUrl = "https://www.facebook.com/Therobinhoodpattaya/",
            //                    Reviews = null,
            //                    WorkingHours = new List<WorkingHours>()
            //                    {
            //                        new WorkingHours()
            //                        {
            //                            Text = "Monday",
            //                            RegistrationTime = 420,
            //                            LeaveTime = 1320,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Tuesday",
            //                            RegistrationTime = 420,
            //                            LeaveTime = 1320,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Wednesday",
            //                            RegistrationTime = 420,
            //                            LeaveTime = 1320,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Thursday",
            //                            RegistrationTime = 420,
            //                            LeaveTime = 1320,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Friday",
            //                            RegistrationTime = 420,
            //                            LeaveTime = 1320,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Saturday",
            //                            RegistrationTime = 420,
            //                            LeaveTime = 1320,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Sunday",
            //                            RegistrationTime = 420,
            //                            LeaveTime = 1320,
            //                        },
            //                    },
            //                },
            //                new Restaurant()
            //                {
            //                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "0F2EF011-C52C-4380-165F-08DAD7506F72").Id,
            //                    Name = "Edge",
            //                    Rating = 4.5,
            //                    Location = "Pattaya, Chonburi Province",
            //                    PriceRange = "$520 - $1,400",
            //                    Description = "Discover the ever changing, pan Asian dinning concept at Edge where contemporary open kitchens present a dazzling range of cuisine from around the globe.",
            //                    PhoneNumber = "+66 38 253 000",
            //                    Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "356F8EE1-95EE-4C94-5E75-08DAD750F9C9"),
            //                    WebsiteUrl = "http://pattaya.hilton.com",
            //                    Email = "BKKHP.Pattaya.Info@hilton.com",
            //                    MenuUrl = "http://pattaya.hilton.com",
            //                    Reviews = null,
            //                    WorkingHours = new List<WorkingHours>()
            //                    {
            //                        new WorkingHours()
            //                        {
            //                            Text = "Monday",
            //                            RegistrationTime = 360,
            //                            LeaveTime = 660,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Tuesday",
            //                            RegistrationTime = 720,
            //                            LeaveTime = 900,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Wednesday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1320,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Thursday",
            //                            RegistrationTime = 360,
            //                            LeaveTime = 630,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Friday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1320,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Saturday",
            //                            RegistrationTime = 360,
            //                            LeaveTime = 630,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Sunday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1320,
            //                        },
            //                    },
            //                    Images = null, // TODO: Finish Images
            //                },
            //                new Restaurant()
            //                {
            //                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "0F2EF011-C52C-4380-165F-08DAD7506F72").Id,
            //                    Name = "Horizon",
            //                    Rating = 4.5,
            //                    Location = "Pattaya, Chonburi Province",
            //                    PriceRange = "$300 - $4,000",
            //                    Description = "Located on level 34 of Hilton Pattaya, this unique rooftop venue offers some of the most breathtaking views of Pattaya. Sleek and sophisticated, this Pattaya restaurant and bar is a truly exclusive hideaway from the bustling city below. Indulge in the delicious menu with a twist or simply relax in the Infinity Bar and enjoy the gentle sea breezes in comfort and style. Luxurious and chic, Horizon is also perfect for weddings and special occasions.",
            //                    PhoneNumber = "+66 38 253 079",
            //                    Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "356F8EE1-95EE-4C94-5E75-08DAD750F9C9"),
            //                    WebsiteUrl = "http://pattaya.hilton.com",
            //                    Email = "BKKHP.Pattaya.Info@hilton.com",
            //                    MenuUrl = "https://horizon.bar",
            //                    Reviews = null,
            //                    WorkingHours = new List<WorkingHours>()
            //                    {
            //                        new WorkingHours()
            //                        {
            //                            Text = "Monday",
            //                            RegistrationTime = 960,
            //                            LeaveTime = 1500,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Tuesday",
            //                            RegistrationTime = 960,
            //                            LeaveTime = 1500,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Wednesday",
            //                            RegistrationTime = 960,
            //                            LeaveTime = 1500,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Thursday",
            //                            RegistrationTime = 960,
            //                            LeaveTime = 1500,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Friday",
            //                            RegistrationTime = 960,
            //                            LeaveTime = 1500,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Saturday",
            //                            RegistrationTime = 960,
            //                            LeaveTime = 1500,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Sunday",
            //                            RegistrationTime = 960,
            //                            LeaveTime = 1500,
            //                        },
            //                    },
            //                    Images = null, // TODO: Finish Images
            //                },
            //                new Restaurant()
            //                {
            //                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "0F2EF011-C52C-4380-165F-08DAD7506F72").Id,
            //                    Name = "Cafe des Amis Fine Dining",
            //                    Rating = 5.0,
            //                    Location = "Pattaya, Chonburi Province",
            //                    PriceRange = "$600 - $3,000",
            //                    Description = "We are family owned independent restaurant since 2008. Fine Dining, French and European cuisine. We offer 5 or 6 course Dégustation Menu’s and the largest selection of imported beef from Aus, USA, Japan. as well as some amazing Fish. Snow fish, oysters lobster scallops, large wine list, fine spirits, cocktails, Largest Gin selection in ASIA 180+ Gins, 30 Vodkas, 60 Whiskeys. Indoor and outdoor air conditioned dining areas, Romantic restaurant. Perfect for a birthday anniversary or family celebration. Cafe des Amis is elegant but relaxed and not stuffy or posh. We aspire to the challenges of keeping every customer happy and providing a high class eatery for the area. Our garden terrace dining area is perfect for children. Please use Grab Taxi app to get to us we are located 1km from walking street. Limited Vegetarian available. We have smartly dressed guests celebrating special occasions such as wedding anniversaries. Please respect our Dress Code: Smart Casual, No Flip Flops or beach",
            //                    PhoneNumber = "+66 84 026 4989",
            //                    Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "356F8EE1-95EE-4C94-5E75-08DAD750F9C9"),
            //                    WebsiteUrl = "http://www.cafe-des-amis.com/",
            //                    Email = "info@cafedesamispattaya.com",
            //                    MenuUrl = "https://www.cafe-des-amis.com/menus",
            //                    Reviews = null,
            //                    WorkingHours = new List<WorkingHours>()
            //                    {
            //                        new WorkingHours()
            //                        {
            //                            Text = "Monday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1350,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Tuesday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1350,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Wednesday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1350,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Thursday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1350,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Friday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1350,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Saturday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1350,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Sunday",
            //                            RegistrationTime = 1020,
            //                            LeaveTime = 1350,
            //                        },
            //                    },
            //                    Images = null, // TODO: Finish Images
            //                },
            //                new Restaurant()
            //                {
            //                    OwnerId = dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "0F2EF011-C52C-4380-165F-08DAD7506F72").Id,
            //                    Name = "Maharani",
            //                    Rating = 5.0,
            //                    Location = "Pattaya, Chonburi Province",
            //                    PriceRange = "$25",
            //                    Description = "The jewel in the crown of Indian restaurants. The recently renovated Maharani restaurant offers authentic Indian cuisines from all over the subcontinent. Guests can relish one of the best Indian cuisines in Pattaya whilst enjoying the spectacular view of the gulf of Thailand. Our talented Indian kitchen team creates dishes and menus combining Indian ingredients with creative recipes and for these reasons many locals have hailed this restaurant as one of the best in Pattaya.",
            //                    PhoneNumber = "+66 38 250 421",
            //                    Address = dbContext.Addresses.FirstOrDefault(x => x.Id.ToString() == "356F8EE1-95EE-4C94-5E75-08DAD750F9C9"),
            //                    WebsiteUrl = "http://www.royalcliff.com/restaurants-maharani.php",
            //                    Email = "gro-main@royalcliff.com",
            //                    MenuUrl = "https://www.royalcliff.com/weekly_menu.php?c=maharani",
            //                    Reviews = null,
            //                    WorkingHours = new List<WorkingHours>()
            //                    {
            //                        new WorkingHours()
            //                        {
            //                            Text = "Monday",
            //                            RegistrationTime = 1080,
            //                            LeaveTime = 1380,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Tuesday",
            //                            RegistrationTime = 1080,
            //                            LeaveTime = 1380,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Wednesday",
            //                            RegistrationTime = 1080,
            //                            LeaveTime = 1380,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Thursday",
            //                            RegistrationTime = 1080,
            //                            LeaveTime = 1380,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Friday",
            //                            RegistrationTime = 1080,
            //                            LeaveTime = 1380,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Saturday",
            //                            RegistrationTime = 1080,
            //                            LeaveTime = 1380,
            //                        },
            //                        new WorkingHours()
            //                        {
            //                            Text = "Sunday",
            //                            RegistrationTime = 1080,
            //                            LeaveTime = 1380,
            //                        },
            //                    },
            //                    Images = null, // TODO: Finish Images
            //                },
            //            };

            //            foreach (var restaurant in restaurants)
            //            {
            //                await dbContext.Restaurants.AddAsync(new Restaurant()
            //                {
            //                    OwnerId = restaurant.OwnerId,
            //                    Name = restaurant.Name,
            //                    Rating = restaurant.Rating,
            //                    Location = restaurant.Location,
            //                    PriceRange = restaurant.PriceRange,
            //                    Description = restaurant.Description,
            //                    PhoneNumber = restaurant.PhoneNumber,
            //                    Address = restaurant.Address,
            //                    WebsiteUrl = restaurant.WebsiteUrl,
            //                    Email = restaurant.Email,
            //                    MenuUrl = restaurant.MenuUrl,
            //                    Reviews = restaurant.Reviews,
            //                    WorkingHours = restaurant.WorkingHours,
            //                    Images = restaurant.Images,
            //                });
            //            }
        }
    }
}

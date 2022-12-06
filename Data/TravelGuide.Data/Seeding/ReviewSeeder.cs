namespace TravelGuide.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    /// <summary>
    /// A class to seed all reviews for the hotels or restaurants.
    /// </summary>
    public class ReviewSeeder : ISeeder
    {
        /// <summary>
        /// Seeds all reviews into the reviews table.
        /// </summary>
        /// <param name="dbContext">The applicationDbContext.</param>
        /// <param name="serviceProvider">Injection of desired service.</param>
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Reviews.Any())
            {
                return;
            }
                
            var hotelReviews = new List<Tuple<string, double, string, Guid, Guid>>
            {
                new Tuple<string, double, string, Guid, Guid>("A very delightful experience", 8.0, "The rooms were clean, very comfortable, and the staff was amazing. They went over and beyond to help make our stay enjoyable. I highly recommend this hotel for anyone visiting downtown.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Hotels.FirstOrDefault(x => x.Id.ToString() == "1E39E8B0-71A5-471D-A897-08DAD751CEB8").Id),
                new Tuple<string, double, string, Guid, Guid>("Excelent service", 9.0, "They were extremely accommodating and allowed us to check in early at like 10am. We got to hotel super early and I didn’t wanna wait. So this was a big plus. The sevice was exceptional as well. Would definitely send a friend there.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Hotels.FirstOrDefault(x => x.Id.ToString() == "1E39E8B0-71A5-471D-A897-08DAD751CEB8").Id),
                new Tuple<string, double, string, Guid, Guid>("Perfect weekend getaway hotel", 10.0, "This is the perfect hotel for a weekend getaway. The downtown area on Main Street is a best kept secret and the hotel offers everything you need if you don’t feel like venturing out.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Hotels.FirstOrDefault(x => x.Id.ToString() == "1E39E8B0-71A5-471D-A897-08DAD751CEB8").Id),
                new Tuple<string, double, string, Guid, Guid>("The Best Hotel", 10.0, "The best hotel I’ve ever been privileged enough to stay at. Gorgeous building, and it only gets more breathtaking when you walk in. High quality rooms (there was even a tv by the shower), and high quality service. Also, they are one of few hotels that allow people under 21 to book a reservation.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Hotels.FirstOrDefault(x => x.Id.ToString() == "1E39E8B0-71A5-471D-A897-08DAD751CEB8").Id),
                new Tuple<string, double, string, Guid, Guid>("A pleasent stay", 6.5, "Overall, I had a great experience with the hotel; staff was incredibly helpful, and the amenities were great. The room was wonderful, clean, and perfect to celebrate a birthday weekend.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Hotels.FirstOrDefault(x => x.Id.ToString() == "1E39E8B0-71A5-471D-A897-08DAD751CEB8").Id),
                new Tuple<string, double, string, Guid, Guid>("Worst experience ever!", 0.0, " I didn’t like anything. This place was so disgusting. Bugs everywhere, horrible customer service, worst experience ever. DO NOT EVER WASTE YOUR MONEY", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Hotels.FirstOrDefault(x => x.Id.ToString() == "1E39E8B0-71A5-471D-A897-08DAD751CEB8").Id),
            };

            var restaurantReviews = new List<Tuple<string, double, string, Guid, Guid>>
            {
                new Tuple<string, double, string, Guid, Guid>("A delightful experience", 8.0, "Amaazing food! The whole experience from start to finish is great waitress is always so friendly and kind. The food can’t get better and the prices are fair for the portion size. Always a great spot to get great food.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Restaurants.FirstOrDefault(x => x.Id.ToString() == "120C906A-D309-458C-BABF-08DAD751CEE7").Id),
                new Tuple<string, double, string, Guid, Guid>("The BEST restaurant in the area!", 10.0, "The food is exceptional! Very tasty and well prepared and you can chose among many menu options. I love the service at the place and the chef is so friendly with the guests and always takes care to offer the best quality! I highly recommend this place.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Restaurants.FirstOrDefault(x => x.Id.ToString() == "120C906A-D309-458C-BABF-08DAD751CEE7").Id),
                new Tuple<string, double, string, Guid, Guid>("Extremely positive!", 10.0, "Everything about this restaurant was great. The place was clean and smelled good. The staff and greeter was very nice. Our waiter was awesome, the staff also worked as a team in bringing and cleaning up our food. The food was fresh and awesome. Then we also had dessert and that was really good as well. Great atmosphere with really nice people.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Restaurants.FirstOrDefault(x => x.Id.ToString() == "120C906A-D309-458C-BABF-08DAD751CEE7").Id),
                new Tuple<string, double, string, Guid, Guid>("A pleasent experience", 7.0, "Delicious food, waiters are very attentive, and super nice atmosphere. Plus it’s all at an affordable price. Can totally recommend it and will definitely come back again.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Restaurants.FirstOrDefault(x => x.Id.ToString() == "120C906A-D309-458C-BABF-08DAD751CEE7").Id),
                new Tuple<string, double, string, Guid, Guid>("Extremely unsatisfied", 3.0, " I’m confident the food here poisoned me. It’s the only food I ate in the last 24 hours that I did not eat in the proceeding days. There was also a good amount of pork. It was also half of what came up.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Restaurants.FirstOrDefault(x => x.Id.ToString() == "120C906A-D309-458C-BABF-08DAD751CEE7").Id),
                new Tuple<string, double, string, Guid, Guid>("Utterly poor service quality", 1.0, "Would give it a zero if I could. Hostess stand was rude. Bartender was rude. Come here if you want attitude.", dbContext.Users.FirstOrDefault(x => x.Id.ToString() == "2B2D8C57-7669-47A7-165D-08DAD7506F72").Id, dbContext.Restaurants.FirstOrDefault(x => x.Id.ToString() == "120C906A-D309-458C-BABF-08DAD751CEE7").Id),
            };

            foreach (var review in hotelReviews)
            {
                await dbContext.AddAsync(new Review() { Title = review.Item1, Rating = review.Item2, Description = review.Item3, AuthorId = review.Item4, HotelId = review.Item5 });
            }

            foreach (var review in restaurantReviews)
            {
                await dbContext.AddAsync(new Review() { Title = review.Item1, Rating = review.Item2, Description = review.Item3, AuthorId = review.Item4, RestaurantId = review.Item5 });
            }
        }
    }
}

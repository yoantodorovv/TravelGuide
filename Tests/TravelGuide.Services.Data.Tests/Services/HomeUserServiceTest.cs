namespace TravelGuide.Services.Data.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.Tests.Mocks;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;
    using Xunit;

    public class HomeUserServiceTest
    {
        public HomeUserServiceTest()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(HotelPagingViewModel).GetTypeInfo().Assembly);
            AutoMapperConfig.RegisterMappings(
                typeof(RestaurantPagingViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task GetAllHotelsToRenderShouldReturnACollectionOfHotels()
        {
            // Arrange
            var hotelRepo = HotelRepositoryMock.Instance;
            var restaurantRepo = RestaurantRepositoryMock.Instance;

            var service = await this.GetHomeUserServiceAsync(hotelRepo, restaurantRepo);

            // Act
            var hotels = await service.GetAllHotelsToRender<IEnumerable<HotelPagingViewModel>>();

            // Assert
            Assert.NotNull(hotels);
        }

        private async Task<HomeUserService> GetHomeUserServiceAsync(
            IDeletableEntityRepository<Hotel> hotelRepo,
            IDeletableEntityRepository<Restaurant> restaurantRepo)
        {
            using var data = DatabaseMock.Instance;

            await data.Hotels.AddAsync(new Hotel()
            {
                Id = Guid.Parse("0ba9926d-1059-41ab-9eae-0f7403d38aff"),
            });

            await data.SaveChangesAsync();

            return new HomeUserService(hotelRepo, restaurantRepo);
        }
    }
}

namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.DTOs;

    public class HomeUserService : IHomeUserService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;

        public HomeUserService(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IDeletableEntityRepository<Restaurant> restaurantRepository)
        {
            this.hotelRepository = hotelRepository;
            this.restaurantRepository = restaurantRepository;
        }

        public IEnumerable<HotelIndexDto> GetAllHotelsToRender() => this.hotelRepository.AllAsNoTracking()
            .Where(h => h.Rating == 5)
            .To<HotelIndexDto>()
            .ToList();

        public IEnumerable<RestaurantIndexDto> GetAllRestaurantsToRender() => this.restaurantRepository.AllAsNoTracking()
            .Where(r => r.Rating == 5)
            .To<RestaurantIndexDto>()
            .ToList();
    }
}

namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    /// <summary>
    /// Home service.
    /// </summary>
    public class HomeUserService : IHomeUserService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="hotelRepository">Hotel repository injection.</param>
        /// <param name="restaurantRepository">Restaurant repository injection.</param>
        public HomeUserService(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IDeletableEntityRepository<Restaurant> restaurantRepository)
        {
            this.hotelRepository = hotelRepository;
            this.restaurantRepository = restaurantRepository;
        }

        /// <summary>
        /// Gets all hotels that are to be rendered asynchroniously.
        /// </summary>
        /// <returns>A collection of HotelIndexViewModel.</returns>
        public async Task<IEnumerable<HotelIndexViewModel>> GetAllHotelsToRender() => await this.hotelRepository.AllAsNoTracking()
            .Where(h => h.Rating == 5)
            .To<HotelIndexViewModel>()
            .ToListAsync();

        /// <summary>
        /// Gets all restaurants that are to be rendered asynchroniously.
        /// </summary>
        /// <returns>A collection of RestaurantIndexViewModel.</returns>
        public async Task<IEnumerable<RestaurantIndexViewModel>> GetAllRestaurantsToRender() => await this.restaurantRepository.AllAsNoTracking()
            .Where(r => r.Rating == 5)
            .To<RestaurantIndexViewModel>()
            .ToListAsync();
    }
}

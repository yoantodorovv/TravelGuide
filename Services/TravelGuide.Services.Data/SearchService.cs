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
    /// Search service.
    /// </summary>
    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="hotelRepository">Hotel repository injection.</param>
        /// <param name="restaurantRepository">Restaurant repository injection.</param>
        public SearchService(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IDeletableEntityRepository<Restaurant> restaurantRepository)
        {
            this.hotelRepository = hotelRepository;
            this.restaurantRepository = restaurantRepository;
        }

        /// <summary>
        /// Gets all hotels that answear to the search.
        /// </summary>
        /// <returns>Collection of hotels to be visualised.</returns>
        public async Task<IEnumerable<HotelPagingViewModel>> GetAllHotelsInSearchArea(string searchString) => await this.hotelRepository.AllAsNoTracking()
            .Include(h => h.Address)
            .ThenInclude(a => a.Town)
            .Where(h => h.Address.Country.Contains(searchString)
                || h.Address.Town.Name.Contains(searchString)
                || h.Address.AddressText.Contains(searchString)
                || h.Location.Contains(searchString)
                || h.Name.Contains(searchString))
            .To<HotelPagingViewModel>()
            .ToListAsync();

        /// <summary>
        /// Gets all restaurants that answear to the search.
        /// </summary>
        /// <returns>Collection of restaurants to be visualised.</returns>
        public async Task<IEnumerable<RestaurantIndexViewModel>> GetAllRestaurantsInSearchArea(string searchString) => await this.restaurantRepository.AllAsNoTracking()
            .Include(r => r.Address)
            .ThenInclude(a => a.Town)
            .Where(r => r.Address.Country.Contains(searchString)
                || r.Address.Town.Name.Contains(searchString)
                || r.Address.AddressText.Contains(searchString)
                || r.Location.Contains(searchString)
                || r.Name.Contains(searchString))
            .To<RestaurantIndexViewModel>()
            .ToListAsync();
    }
}

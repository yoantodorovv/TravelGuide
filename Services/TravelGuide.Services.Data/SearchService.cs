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
    using TravelGuide.Web.ViewModels.DTOs;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;

        public SearchService(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IDeletableEntityRepository<Restaurant> restaurantRepository)
        {
            this.hotelRepository = hotelRepository;
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<IEnumerable<HotelIndexDto>> GetAllHotelsInSearchArea(string searchString) => await this.hotelRepository.AllAsNoTracking()
            .Include(h => h.Address)
            .ThenInclude(a => a.Town)
            .Where(h => h.Address.Country.Contains(searchString)
                || h.Address.Town.Name.Contains(searchString)
                || h.Address.AddressText.Contains(searchString)
                || h.Location.Contains(searchString))
            .To<HotelIndexDto>()
            .ToListAsync();

        public async Task<IEnumerable<RestaurantIndexDto>> GetAllRestaurantsInSearchArea(string searchString) => await this.restaurantRepository.AllAsNoTracking()
            .Include(r => r.Address)
            .ThenInclude(a => a.Town)
            .Where(r => r.Address.Country.Contains(searchString)
                || r.Address.Town.Name.Contains(searchString)
                || r.Address.AddressText.Contains(searchString)
                || r.Location.Contains(searchString))
            .To<RestaurantIndexDto>()
            .ToListAsync();
    }
}

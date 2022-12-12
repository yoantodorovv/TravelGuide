namespace TravelGuide.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;

    /// <summary>
    /// Restaurant Service.
    /// </summary>
    public class RestaurantService : IRestaurantService
    {
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;

        public RestaurantService(IDeletableEntityRepository<Restaurant> restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        /// <summary>
        /// Gets all restaurants and maps them to a view model.
        /// </summary>
        public async Task<ICollection<T>> GetAllAsync<T>(int page, int itemsPerPage = 6) => await this.restaurantRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        /// <summary>
        /// Gets all user restaurants and maps them to a view model.
        /// </summary>
        public async Task<IEnumerable<T>> GetAllUserRestaurantsAsync<T>(int page, string userId, int itemsPerPage = 6) => await this.restaurantRepository.AllAsNoTracking()
                .Where(x => x.OwnerId.ToString() == userId)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        /// <summary>
        /// Gets the count of all hotels.
        /// </summary>
        public async Task<int> GetCountAsync() => await this.restaurantRepository.AllAsNoTracking().CountAsync();

        /// <summary>
        /// Gets the count of all user restaurants.
        /// </summary>
        public async Task<int> GetUserRestaurantsCountAsync(string userId) => await this.restaurantRepository.AllAsNoTracking().Where(x => x.OwnerId.ToString() == userId).CountAsync();
    }
}

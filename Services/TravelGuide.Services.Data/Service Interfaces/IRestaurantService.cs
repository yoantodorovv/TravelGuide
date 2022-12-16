namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TravelGuide.Data.Models;
    using TravelGuide.Web.ViewModels.Restaurant;

    /// <summary>
    /// Interface for Restaurant service.
    /// </summary>
    public interface IRestaurantService
    {
        /// <summary>
        /// Adds a restaurant to the DB asynchroniously.
        /// </summary>
        Task AddAsync(CreateRestaurantViewModel model, string userId);

        /// <summary>
        /// Gets all restaurants in the DB and maps them to a view model.
        /// </summary>
        Task<ICollection<T>> GetAllAsync<T>();

        /// <summary>
        /// Gets all restaurants in the DB and maps them to a view model.
        /// </summary>
        Task<ICollection<T>> GetAllAsync<T>(int page, int itemsPerPage);

        /// <summary>
        /// Gets the count of all restaurants in the DB.
        /// </summary>
        Task<int> GetCountAsync();

        /// <summary>
        /// Gets all user restaurants in the DB and maps them to a view model.
        /// </summary>
        Task<IEnumerable<T>> GetAllUserRestaurantsAsync<T>(string userId);

        /// <summary>
        /// Gets all user restaurants in the DB and maps them to a view model.
        /// </summary>
        Task<IEnumerable<T>> GetAllUserRestaurantsAsync<T>(int page, string userId, int itemsPerPage);

        /// <summary>
        /// Gets the count of all user restaurants in the DB.
        /// </summary>
        Task<int> GetUserRestaurantsCountAsync(string userId);

        Task<T> GetById<T>(string restaurantId);

        Task<Restaurant> GetById(string restaurantId);
    }
}

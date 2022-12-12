namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Hotel service.
    /// </summary>
    public interface IRestaurantService
    {
        /// <summary>
        /// Gets all hotels in the DB and maps them to a view model.
        /// </summary>
        Task<ICollection<T>> GetAllAsync<T>(int page, int itemsPerPage);

        /// <summary>
        /// Gets the count of all restaurants in the DB.
        /// </summary>
        Task<int> GetCountAsync();

        /// <summary>
        /// Gets all user restaurants in the DB and maps them to a view model.
        /// </summary>
        Task<IEnumerable<T>> GetAllUserRestaurantsAsync<T>(int page, string userId, int itemsPerPage);

        /// <summary>
        /// Gets the count of all user restaurants in the DB.
        /// </summary>
        Task<int> GetUserRestaurantsCountAsync(string userId);
    }
}

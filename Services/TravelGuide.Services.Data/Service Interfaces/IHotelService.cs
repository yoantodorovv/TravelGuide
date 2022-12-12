namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.Hotel;

    /// <summary>
    /// Interface for Hotel service.
    /// </summary>
    public interface IHotelService
    {
        /// <summary>
        /// Adds a hotel to the DB asynchroniously.
        /// </summary>
        Task AddAsync(CreateHotelViewModel createHotelViewModel, string userId);

        /// <summary>
        /// Gets all hotels in the DB and maps them to a view model.
        /// </summary>
        Task<ICollection<T>> GetAllAsync<T>(int page, int itemsPerPage);

        /// <summary>
        /// Gets the count of all hotels in the DB.
        /// </summary>
        Task<int> GetCountAsync();

        /// <summary>
        /// Gets all user hotels in the DB and maps them to a view model.
        /// </summary>
        Task<IEnumerable<T>> GetAllUserHotelsAsync<T>(int page, string userId, int itemsPerPage);

        /// <summary>
        /// Gets the count of all user hotels in the DB.
        /// </summary>
        Task<int> GetUserHotelsCountAsync(string userId);
    }
}

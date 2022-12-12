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

        Task<ICollection<T>> GetAllAsync<T>(int page, int itemsPerPage = 12);

        Task<int> GetCountAsync();

        Task<IEnumerable<HotelPagingViewModel>> GetAllUserHotelsAsync(int page, string userId, int itemsPerPage = 12);

        Task<int> GetUserHotelsCountAsync(string userId);
    }
}

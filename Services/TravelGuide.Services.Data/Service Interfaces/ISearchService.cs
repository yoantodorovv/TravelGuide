namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    /// <summary>
    /// Interface for Search service.
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Gets all Hotels that are to be searched.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        Task<IEnumerable<HotelPagingViewModel>> GetAllHotelsInSearchArea(string searchString);

        /// <summary>
        /// Gets all restaurants that are to be searched.
        /// </summary>
        Task<IEnumerable<RestaurantPagingViewModel>> GetAllRestaurantsInSearchArea(string searchString);
    }
}

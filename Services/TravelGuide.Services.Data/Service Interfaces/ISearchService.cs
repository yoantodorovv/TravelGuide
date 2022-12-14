namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
        Task<IEnumerable<T>> GetAllHotelsInSearchArea<T>(string searchString);

        /// <summary>
        /// Gets all restaurants that are to be searched.
        /// </summary>
        Task<IEnumerable<T>> GetAllRestaurantsInSearchArea<T>(string searchString);
    }
}

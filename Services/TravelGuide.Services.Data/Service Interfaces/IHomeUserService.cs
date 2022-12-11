namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    /// <summary>
    /// Interface for Home service.
    /// </summary>
    public interface IHomeUserService
    {
        /// <summary>
        /// Gets all hotels to render in home page.
        /// </summary>
        /// <returns>Collection of T.</returns>
        Task<IEnumerable<T>> GetAllHotelsToRender<T>();

        /// <summary>
        /// Gets all restaurants to render in home page.
        /// </summary>
        /// <returns>Collection of T.</returns>
        Task<IEnumerable<T>> GetAllRestaurantsToRender<T>();
    }
}

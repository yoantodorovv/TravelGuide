namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    public interface ISearchService
    {
        Task<IEnumerable<HotelIndexViewModel>> GetAllHotelsInSearchArea(string searchString);

        Task<IEnumerable<RestaurantIndexViewModel>> GetAllRestaurantsInSearchArea(string searchString);
    }
}

namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    public interface IHomeUserService
    {
        Task<IEnumerable<HotelIndexViewModel>> GetAllHotelsToRender();

        Task<IEnumerable<RestaurantIndexViewModel>> GetAllRestaurantsToRender();
    }
}

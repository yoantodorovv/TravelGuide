namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.DTOs;

    public interface IHomeUserService
    {
        IEnumerable<HotelIndexDto> GetAllHotelsToRender();

        IEnumerable<RestaurantIndexDto> GetAllRestaurantsToRender();
    }
}

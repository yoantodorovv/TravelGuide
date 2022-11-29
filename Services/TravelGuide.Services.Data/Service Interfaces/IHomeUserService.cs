namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.DTOs;

    public interface IHomeUserService
    {
        Task<IEnumerable<HotelIndexDto>> GetAllHotelsToRender();

        Task<IEnumerable<RestaurantIndexDto>> GetAllRestaurantsToRender();
    }
}

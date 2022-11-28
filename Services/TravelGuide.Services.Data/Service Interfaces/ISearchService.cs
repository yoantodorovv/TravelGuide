namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;

    using TravelGuide.Web.ViewModels.DTOs;

    public interface ISearchService
    {
        IEnumerable<HotelIndexDto> GetAllHotelsInSearchArea(string searchString);

        IEnumerable<RestaurantIndexDto> GetAllRestaurantsInSearchArea(string searchString);
    }
}

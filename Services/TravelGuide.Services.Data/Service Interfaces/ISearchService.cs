﻿namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.DTOs;

    public interface ISearchService
    {
        Task<IEnumerable<HotelIndexDto>> GetAllHotelsInSearchArea(string searchString);

        Task<IEnumerable<RestaurantIndexDto>> GetAllRestaurantsInSearchArea(string searchString);
    }
}

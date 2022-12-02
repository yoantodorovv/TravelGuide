namespace TravelGuide.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    using TravelGuide.Web.ViewModels.DTOs;
    using TravelGuide.Web.ViewModels.DTOs.Hotel;

    public class CardVisualiseViewModel : PagingViewModel
    {
        public IEnumerable<HotelIndexDto> HotelsToRender { get; set; }

        public IEnumerable<RestaurantIndexDto> RestaurantsToRender { get; set; }
    }
}

namespace TravelGuide.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    using TravelGuide.Web.ViewModels.DTOs;

    public class CardVisualiseViewModel : PagingViewModel
    {
        public IEnumerable<HotelIndexDto> HotelsToRender { get; set; }

        public IEnumerable<RestaurantIndexDto> RestaurantsToRender { get; set; }
    }
}

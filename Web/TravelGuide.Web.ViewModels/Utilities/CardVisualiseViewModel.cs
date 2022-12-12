namespace TravelGuide.Web.ViewModels.Utilities
{
    using System;
    using System.Collections.Generic;

    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    public class CardVisualiseViewModel : PagingViewModel
    {
        public IEnumerable<HotelPagingViewModel> HotelsToRender { get; set; }

        public IEnumerable<RestaurantPagingViewModel> RestaurantsToRender { get; set; }
    }
}

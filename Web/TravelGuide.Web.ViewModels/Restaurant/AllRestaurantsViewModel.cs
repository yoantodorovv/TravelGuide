namespace TravelGuide.Web.ViewModels.Restaurant
{
    using System.Collections.Generic;

    using TravelGuide.Web.ViewModels.Utilities;

    public class AllRestaurantsViewModel : PagingViewModel
    {
        public IEnumerable<RestaurantPagingViewModel> Restaurants { get; set; }
    }
}

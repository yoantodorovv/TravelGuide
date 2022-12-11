namespace TravelGuide.Web.ViewModels.Hotel
{
    using System.Collections.Generic;

    using TravelGuide.Web.ViewModels.Utilities;

    public class AllHotelsViewModel : PagingViewModel
    {
        public IEnumerable<HotelPagingViewModel> Hotels { get; set; }
    }
}

namespace TravelGuide.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Web.ViewModels.DTOs;

    using static TravelGuide.Common.GlobalConstants;

    public class HomeIndexViewModel
    {
        [Required]
        public string SearchString { get; set; }

        public IEnumerable<HotelIndexDto> HotelsToRender { get; set; }

        public IEnumerable<RestaurantIndexDto> RestaurantsToRender { get; set; }
    }
}

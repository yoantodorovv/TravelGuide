namespace TravelGuide.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Web.ViewModels.DTOs;

    using static TravelGuide.Common.GlobalConstants;

    public class HomeIndexViewModel : CardVisualiseViewModel
    {
        public string SearchString { get; set; }
    }
}

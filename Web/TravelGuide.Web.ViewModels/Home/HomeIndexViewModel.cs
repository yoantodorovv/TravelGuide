namespace TravelGuide.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Web.ViewModels.Utilities;

    using static TravelGuide.Common.GlobalConstants;

    public class HomeIndexViewModel : CardVisualiseViewModel
    {
        public string SearchString { get; set; }
    }
}

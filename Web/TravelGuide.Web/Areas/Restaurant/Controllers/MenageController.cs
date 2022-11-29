namespace TravelGuide.Web.Areas.Restaurant.Controllers
{
    using System;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Web.Controllers;

    using static TravelGuide.Common.GlobalConstants;

    [Area("Restaurant")]
    [Authorize(Roles = AdministratorOrRestauranteur)]
    public class MenageController : BaseController
    {
        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        public IActionResult Delete()
        {
            return this.View();
        }
    }
}

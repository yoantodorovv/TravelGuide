namespace TravelGuide.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static TravelGuide.Common.GlobalConstants;

    [Authorize(Roles = AdministratorOrRestauranteur)]
    public class RestaurantController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Reservations()
        {
            return this.View();
        }

        public IActionResult Rating()
        {
            return this.View();
        }
    }
}

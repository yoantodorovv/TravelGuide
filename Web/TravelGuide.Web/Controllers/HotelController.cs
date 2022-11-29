namespace TravelGuide.Web.Controllers
{
    using System;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static TravelGuide.Common.GlobalConstants;

    [Authorize(Roles = AdministratorOrHotelier)]
    public class HotelController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult All()
        {
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult BecomeHotelier()
        {
            return this.View();
        }

        public IActionResult Create()
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

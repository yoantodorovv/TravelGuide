﻿namespace TravelGuide.Web.Areas.Hotel.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Web.Controllers;

    using static TravelGuide.Common.GlobalConstants;

    [Area("Hotel")]
    [Authorize(Roles = AdministratorOrHotelier)]
    public class HomeController : BaseController
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

namespace TravelGuide.Web.Areas.Hotel.Controllers
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

namespace TravelGuide.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Data.Models;
    using TravelGuide.Web.ViewModels;

    using static TravelGuide.Common.GlobalConstants;

    public class HotelController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public HotelController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult All()
        {
            return this.View();
        }

        [Authorize(Roles = UserRoleName)]
        public IActionResult BecomeHotelier() => this.View(new BecomeHotelierViewModel());

        // TODO: Add policy
        [HttpPost]
        [Authorize(Roles = UserRoleName)]
        public async Task<IActionResult> BecomeHotelier(BecomeHotelierViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
                //// TODO: Implement admin approval functionality

            var user = await this.userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                await this.userManager.AddToRoleAsync(user, HotelierRoleName);
            }

            return this.View("BecomeHotelierConfirmation");
        }

        [Authorize(Roles = AdministratorOrHotelier)]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = AdministratorOrHotelier)]
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

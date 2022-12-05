namespace TravelGuide.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels;
    using TravelGuide.Web.ViewModels.Hotel;

    using static TravelGuide.Common.GlobalConstants;

    public class HotelController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHotelService hotelService;

        public HotelController(
            UserManager<ApplicationUser> userManager,
            IHotelService hotelService)
        {
            this.userManager = userManager;
            this.hotelService = hotelService;
        }

        [AllowAnonymous]
        public IActionResult All()
        {
            return this.View();
        }

        [AllowAnonymous]
        public IActionResult Mine()
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
        public IActionResult Create() => this.View(new CreateHotelViewModel());

        [HttpPost]
        [Authorize(Roles = AdministratorOrHotelier)]
        public async Task<IActionResult> Create(CreateHotelViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            model.Amenities = model.AmenityTitle.Split("  ");

            //// TODO: Check if all inputs are correct and none of them are faulty. /injections/

            await this.hotelService.AddAsync(null);

            return this.RedirectToAction(nameof(this.All));
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

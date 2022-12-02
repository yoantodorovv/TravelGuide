namespace TravelGuide.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Web.ViewModels;
    using TravelGuide.Web.ViewModels.Hotel;

    using static TravelGuide.Common.GlobalConstants;

    public class HotelController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;

        public HotelController(
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<Hotel> hotelRepository)
        {
            this.userManager = userManager;
            this.hotelRepository = hotelRepository;
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
        public IActionResult Create() => this.View(new HotelViewModel());

        [HttpPost]
        [Authorize(Roles = AdministratorOrHotelier)]
        public async Task<IActionResult> Create(HotelViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            //// TODO: Check if all inputs are correct and none of them are faulty. /injections/

            await this.hotelRepository.AddAsync(new Hotel());

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

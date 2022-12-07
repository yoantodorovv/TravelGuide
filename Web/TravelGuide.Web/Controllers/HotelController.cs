namespace TravelGuide.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels;
    using TravelGuide.Web.ViewModels.Hotel;

    using static TravelGuide.Common.ErrorMessages.HotelErrorMessages;
    using static TravelGuide.Common.GlobalConstants;

    public class HotelController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHotelService hotelService;
        private readonly IApproveService approveService;

        public HotelController(
            UserManager<ApplicationUser> userManager,
            IHotelService hotelService,
            IApproveService approveService)
        {
            this.userManager = userManager;
            this.hotelService = hotelService;
            this.approveService = approveService;
        }

        [AllowAnonymous]
        public IActionResult All()
        {
            return this.View();
        }

        // TODO: Create Policy (User + Hotelier)
        [Authorize]
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

            if (model.Email != this.User.FindFirst(ClaimTypes.Email).Value)
            {
                this.ModelState.AddModelError("Email", InvalidEmail);

                return this.View(model);
            }

            var success = await this.approveService.AddToApprovalsAsync(model.Email, HotelierPosition);

            if (!success)
            {
                this.ModelState.AddModelError("Email", string.Format(CannotRequestApprovalMoreThanOnce, HotelierPosition, HotelierPosition));

                return this.View(model);
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

            //// TODO: Check if all inputs are correct and none of them are faulty. /injections/

            await this.hotelService.AddAsync(model);

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

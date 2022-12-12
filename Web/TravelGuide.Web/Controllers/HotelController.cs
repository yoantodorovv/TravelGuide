namespace TravelGuide.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels;
    using TravelGuide.Web.ViewModels.Hotel;

    using static TravelGuide.Common.ErrorMessages.BecomeErrorMessages;
    using static TravelGuide.Common.GlobalConstants;

    /// <summary>
    /// Controller responsible for hotel functionality.
    /// </summary>
    public class HotelController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHotelService hotelService;
        private readonly IApproveService approveService;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="userManager">User manager injection.</param>
        /// <param name="hotelService">Hotel service injection.</param>
        /// <param name="approveService">Approve service injection.</param>
        public HotelController(
            UserManager<ApplicationUser> userManager,
            IHotelService hotelService,
            IApproveService approveService)
        {
            this.userManager = userManager;
            this.hotelService = hotelService;
            this.approveService = approveService;
        }

        /// <summary>
        /// Returns the view that visualises all hotels.
        /// </summary>
        [AllowAnonymous]
        public async Task<IActionResult> All(int id = 1)
        {
            const int ItemsPerPage = 6;

            var model = new AllHotelsViewModel()
            {
                ControllerName = "Hotel",
                ActionName = nameof(this.All),
                ItemsPerPage = ItemsPerPage,
                Hotels = await this.hotelService.GetAllAsync<HotelPagingViewModel>(id, ItemsPerPage),
                EntityCount = await this.hotelService.GetCountAsync(),
                PageNumber = id,
            };

            return this.View(model);
        }

        // TODO: Create Policy (User + Hotelier)

        /// <summary>
        /// Returns the view that visualises all hotels owned by the current user.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Mine(int id = 1)
        {
            const int ItemsPerPage = 6;
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = new AllHotelsViewModel()
            {
                ControllerName = "Hotel",
                ActionName = nameof(this.Mine),
                ItemsPerPage = ItemsPerPage,
                Hotels = await this.hotelService.GetAllUserHotelsAsync<HotelPagingViewModel>(id, userId, ItemsPerPage),
                EntityCount = await this.hotelService.GetUserHotelsCountAsync(userId),
                PageNumber = id,
            };

            return this.View(model);
        }

        /// <summary>
        /// Returns the view that visualises the view to submit a request to become a hotelier.
        /// </summary>
        [Authorize(Roles = UserRoleName)]
        public async Task<IActionResult> BecomeHotelier()
        {
            var user = await this.userManager.FindByEmailAsync(this.User.FindFirst(ClaimTypes.Email).Value);

            if (this.approveService.Contains(user, RestauranteurPosition))
            {
                return this.View("BecomeHotelierConfirmation");
            }

            return this.View(new BecomeHotelierViewModel());
        }

        /// <summary>
        /// Sends a request to become a hotelier.
        /// </summary>
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

        /// <summary>
        /// Returns the view that visualises the create hotel form.
        /// </summary>
        [Authorize(Roles = AdministratorOrHotelier)]
        public IActionResult Create() => this.View(new CreateHotelViewModel());

        /// <summary>
        /// Create a hotel.
        /// </summary>
        [HttpPost]
        [Authorize(Roles = AdministratorOrHotelier)]
        public async Task<IActionResult> Create(CreateHotelViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            //// TODO: Check if all inputs are correct and none of them are faulty. /injections/

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.hotelService.AddAsync(model, userId);
            }
            catch (Exception ex)
            {
                //// TODO: Use Alerts not ModelState errors.

                this.ModelState.AddModelError(string.Empty, ex.Message); //SomethingWentWrong);

                return this.View(model);
            }

            return this.RedirectToAction(nameof(this.All));
        }

        //// TODO: Add summary

        [Authorize(Roles = AdministratorOrHotelier)]
        public IActionResult Reservations()
        {
            return this.View();
        }
    }
}

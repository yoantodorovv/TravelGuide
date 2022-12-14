namespace TravelGuide.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Ganss.Xss;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels;
    using TravelGuide.Web.ViewModels.Hotel;

    using static TravelGuide.Common.ErrorMessages.BecomeErrorMessages;
    using static TravelGuide.Common.GlobalConstants;
    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.BecomeSuccessMessages;
    using static TravelGuide.Common.SuccessMessages.CreateSuccessMessages;

    /// <summary>
    /// Controller responsible for hotel functionality.
    /// </summary>
    public class HotelController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHotelService hotelService;
        private readonly IApproveService approveService;
        private readonly IHtmlSanitizer htmlSanitizer;

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
            this.htmlSanitizer = new HtmlSanitizer();
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

            if (this.approveService.Contains(user.Id, HotelierPosition))
            {
                this.TempData[ErrorMessage] = string.Format(CannotRequestApprovalMoreThanOnce, HotelierPosition, HotelierPosition);

                return this.RedirectToAction("Index", "Home");
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
                this.TempData[ErrorMessage] = InvalidEmail;

                return this.View(model);
            }

            var success = await this.approveService.AddToApprovalsAsync(this.htmlSanitizer.Sanitize(model.Email), HotelierPosition);

            if (!success)
            {
                this.TempData[ErrorMessage] = string.Format(CannotRequestApprovalMoreThanOnce, HotelierPosition, HotelierPosition);

                return this.View(model);
            }

            this.TempData[SuccessMessage] = string.Format(SuccessfullyRequested, HotelierPosition);

            return this.RedirectToAction("Index", "Home");
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

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.hotelService.AddAsync(model, userId);
            }
            catch (Exception ex)
            {
                this.TempData[ErrorMessage] = ex.Message;

                return this.View(model);
            }

            this.TempData[SuccessMessage] = string.Format(SuccessfullyCreated, "hotel");

            return this.RedirectToAction(nameof(this.Mine));
        }

        [AllowAnonymous]
        public async Task<IActionResult> ById(string id)
        {
            var hotel = await this.hotelService.GetById<HotelViewModel>(id);

            return this.View(hotel);
        }
    }
}

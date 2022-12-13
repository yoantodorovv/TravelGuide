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
    using TravelGuide.Web.ViewModels.Restaurant;

    using static TravelGuide.Common.ErrorMessages.BecomeErrorMessages;
    using static TravelGuide.Common.GlobalConstants;
    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.BecomeSuccessMessages;
    using static TravelGuide.Common.SuccessMessages.CreateSuccessMessages;

    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService restaurantService;
        private readonly IApproveService approveService;
        private readonly UserManager<ApplicationUser> userManager;

        public RestaurantController(
            IRestaurantService restaurantService,
            IApproveService approveService,
            UserManager<ApplicationUser> userManager)
        {
            this.restaurantService = restaurantService;
            this.approveService = approveService;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int id = 1)
        {
            const int ItemsPerPage = 6;

            var model = new AllRestaurantsViewModel()
            {
                ControllerName = "Restaurant",
                ActionName = nameof(this.All),
                ItemsPerPage = ItemsPerPage,
                Restaurants = await this.restaurantService.GetAllAsync<RestaurantPagingViewModel>(id, ItemsPerPage),
                EntityCount = await this.restaurantService.GetCountAsync(),
                PageNumber = id,
            };

            return this.View(model);
        }

        /// <summary>
        /// Returns the view that visualises all restaurants owned by the current user.
        /// </summary>
        [Authorize(Roles = AdministratorOrRestauranteur)]
        public async Task<IActionResult> Mine(int id = 1)
        {
            const int ItemsPerPage = 6;
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = new AllRestaurantsViewModel()
            {
                ControllerName = "Restaurant",
                ActionName = nameof(this.Mine),
                ItemsPerPage = ItemsPerPage,
                Restaurants = await this.restaurantService.GetAllUserRestaurantsAsync<RestaurantPagingViewModel>(id, userId, ItemsPerPage),
                EntityCount = await this.restaurantService.GetUserRestaurantsCountAsync(userId),
                PageNumber = id,
            };

            return this.View(model);
        }

        [Authorize(Roles = UserRoleName)]
        public async Task<IActionResult> BecomeRestauranteur()
        {
            var user = await this.userManager.FindByEmailAsync(this.User.FindFirst(ClaimTypes.Email).Value);

            if (this.approveService.Contains(user, RestauranteurPosition))
            {
                this.TempData[ErrorMessage] = string.Format(CannotRequestApprovalMoreThanOnce, RestauranteurPosition, RestauranteurPosition);

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(new BecomeRestauranteurViewModel());
        }

        /// <summary>
        /// Sends a request to become a restauranteur.
        /// </summary>
        [HttpPost]
        [Authorize(Roles = UserRoleName)]
        public async Task<IActionResult> BecomeRestauranteur(BecomeRestauranteurViewModel model)
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

            var success = await this.approveService.AddToApprovalsAsync(model.Email, RestauranteurPosition);

            if (!success)
            {
                this.TempData[ErrorMessage] = string.Format(CannotRequestApprovalMoreThanOnce, RestauranteurPosition, RestauranteurPosition);

                return this.View(model);
            }

            this.TempData[SuccessMessage] = string.Format(SuccessfullyRequested, RestauranteurPosition);

            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = AdministratorOrRestauranteur)]
        public IActionResult Create() => this.View(new CreateRestaurantViewModel());

        [HttpPost]
        [Authorize(Roles = AdministratorOrRestauranteur)]
        public async Task<IActionResult> Create(CreateRestaurantViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            //// TODO: Check if all inputs are correct and none of them are faulty. /injections/

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                // TODO: SaveChanges for last!
                await this.restaurantService.AddAsync(model, userId);
            }
            catch (Exception ex)
            {
                this.TempData[ErrorMessage] = ex.Message;

                return this.View(model);
            }

            this.TempData[SuccessMessage] = string.Format(SuccessfullyCreated, "restaurant");

            return this.RedirectToAction(nameof(this.Mine));
        }

        public IActionResult Reservations()
        {
            return this.View();
        }
    }
}

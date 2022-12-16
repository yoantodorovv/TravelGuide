namespace TravelGuide.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Common;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Administration.Restaurant;

    using static TravelGuide.Common.ErrorMessages.RestaurantErrorMessages;
    using static TravelGuide.Common.GlobalConstants;
    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.RestaurantSuccessMessages;

    [Area("Administration")]
    [Authorize(Roles = AdministratorOrRestauranteur)]
    public class RestaurantController : Controller
    {
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;
        private readonly IRestaurantService restaurantService;
        private readonly IImageService imageService;

        public RestaurantController(
            IDeletableEntityRepository<Restaurant> restaurantRepository,
            IRestaurantService restaurantService,
            IImageService imageService)
        {
            this.restaurantRepository = restaurantRepository;
            this.restaurantService = restaurantService;
            this.imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var restaurants = await this.restaurantService.GetAllUserRestaurantsAsync<RestaurantViewModel>(userId);

            if (this.User.IsInRole(AdministratorRoleName))
            {
                restaurants = await this.restaurantService.GetAllAsync<RestaurantViewModel>();
            }

            return this.View(restaurants);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var restaurant = await this.restaurantService.GetById<RestaurantViewModel>(id);

            if (restaurant == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(restaurant);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var restaurant = await this.restaurantService.GetById<RestaurantViewModel>(id);

            if (restaurant == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, RestaurantViewModel model)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            var restaurant = await this.restaurantService.GetById(id);

            if (restaurant == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                restaurant.Name = model.Name;
                restaurant.Email = model.Email;
                restaurant.PriceRange = model.PriceRange;
                restaurant.Location = model.Location;
                restaurant.Address.Town.Name = model.AddressTownName;
                restaurant.Address.Country = model.AddressCountry;
                restaurant.Address.AddressText = model.AddressAddressText;
                restaurant.Rating = model.Rating;
                restaurant.Description = model.Description;
                restaurant.PhoneNumber = model.PhoneNumber;
                restaurant.WebsiteUrl = model.WebsiteUrl;
                restaurant.MenuUrl = model.MenuUrl;

                await this.imageService.UploadAndGetRestaurantImageCollectionAsync(model.AddedImages, restaurant.Id);

                this.restaurantRepository.Update(restaurant);
                await this.restaurantRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.RestaurantExists(id))
                {
                    this.TempData[ErrorMessage] = SomethingWentWrong;

                    return this.RedirectToAction(nameof(this.Edit));
                }
                else
                {
                    this.TempData[ErrorMessage] = SomethingWentWrong;

                    throw;
                }
            }

            this.TempData[SuccessMessage] = SuccessfullyEditedRestaurant;

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var restaurant = await this.restaurantService.GetById<RestaurantViewModel>(id);

            if (restaurant == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(restaurant);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Delete));
            }

            var restaurant = await this.restaurantService.GetById(id);

            if (restaurant == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Delete));
            }

            this.restaurantRepository.Delete(restaurant);
            await this.restaurantRepository.SaveChangesAsync();

            this.TempData[SuccessMessage] = SuccessfullyDeletedRestaurant;

            return this.RedirectToAction(nameof(this.Index));
        }

        private async Task<bool> RestaurantExists(string id) => await this.restaurantRepository.AllAsNoTracking().AnyAsync(x => x.Id.ToString() == id);
    }
}

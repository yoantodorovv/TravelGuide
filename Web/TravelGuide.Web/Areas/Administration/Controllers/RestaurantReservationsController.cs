namespace TravelGuide.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Administration.RestaurantReservations;

    using static TravelGuide.Common.ErrorMessages.ReservationErrorMessages;
    using static TravelGuide.Common.GlobalConstants;
    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.ReservationSuccessMessages;

    [Area("Administration")]
    [Authorize(Roles = AdministratorOrRestauranteur)]
    public class RestaurantReservationsController : Controller
    {
        private readonly IDeletableEntityRepository<RestaurantReservation> restaurantReservationRepository;
        private readonly IReservationService reservationService;

        public RestaurantReservationsController(
            IDeletableEntityRepository<RestaurantReservation> restaurantReservationRepository,
            IReservationService reservationService)
        {
            this.restaurantReservationRepository = restaurantReservationRepository;
            this.reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            var restaurantReservations = await this.reservationService.GetAllRestaurantReservationsAsync<RestaurantReservationViewModel>();

            return this.View(restaurantReservations);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var restaurantReservation = await this.reservationService.GetRestaurantReservationByIdAsync<RestaurantReservationViewModel>(id);

            if (restaurantReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(restaurantReservation);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var restaurantReservation = await this.reservationService.GetRestaurantReservationByIdAsync<RestaurantReservationViewModel>(id);

            if (restaurantReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(restaurantReservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, RestaurantReservationViewModel model)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            var restaurantReservation = await this.reservationService.GetRestaurantReservationByIdAsync(id);

            if (restaurantReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(new RestaurantReservationViewModel()
                {
                    ReservationDate = restaurantReservation.ReservationDate,
                });
            }

            try
            {
                restaurantReservation.ReservationDate = model.ReservationDate;

                this.restaurantReservationRepository.Update(restaurantReservation);
                await this.restaurantReservationRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            this.TempData[SuccessMessage] = SuccessfullyEditedReservation;

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var restaurantReservation = await this.reservationService.GetRestaurantReservationByIdAsync<RestaurantReservationViewModel>(id);

            if (restaurantReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(restaurantReservation);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            var restaurantReservation = await this.reservationService.GetRestaurantReservationByIdAsync(id);

            if (restaurantReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            try
            {
                this.restaurantReservationRepository.Delete(restaurantReservation);
                await this.restaurantReservationRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            this.TempData[SuccessMessage] = SuccessfullyDeletedReservation;

            return this.RedirectToAction(nameof(this.Index));
        }

        private async Task<bool> RestaurantReservationExists(string id) => await this.restaurantReservationRepository.AllAsNoTracking().AnyAsync(x => x.Id.ToString() == id);
    }
}

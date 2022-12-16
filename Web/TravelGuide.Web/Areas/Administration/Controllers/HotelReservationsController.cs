namespace TravelGuide.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.Controllers;
    using TravelGuide.Web.ViewModels.Administration.HotelReservations;

    using static TravelGuide.Common.ErrorMessages.ReservationErrorMessages;
    using static TravelGuide.Common.GlobalConstants;
    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.ReservationSuccessMessages;

    [Authorize(Roles = AdministratorOrHotelier)]
    [Area("Administration")]
    public class HotelReservationsController : BaseController
    {
        private readonly IDeletableEntityRepository<HotelReservation> hotelReservationRepository;
        private readonly IReservationService reservationService;

        public HotelReservationsController(
            IDeletableEntityRepository<HotelReservation> hotelReservationRepository,
            IReservationService reservationService)
        {
            this.hotelReservationRepository = hotelReservationRepository;
            this.reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            var hotelReservations = await this.reservationService.GetAllHotelReservationsAsync<HotelReservationViewModel>();

            return this.View(hotelReservations);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var hotelReservation = await this.reservationService.GetHotelReservationByIdAsync<HotelReservationViewModel>(id);

            if (hotelReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(hotelReservation);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var hotelReservation = await this.reservationService.GetHotelReservationByIdAsync<HotelReservationViewModel>(id);

            if (hotelReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(hotelReservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, HotelReservationViewModel model)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            var hotelReservation = await this.reservationService.GetHotelReservationByIdAsync(id);

            if (hotelReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(hotelReservation);
            }

            try
            {
                hotelReservation.Price = model.Price;
                hotelReservation.StartDay = model.StartDay;
                hotelReservation.EndDay = model.EndDay;

                this.hotelReservationRepository.Update(hotelReservation);
                await this.hotelReservationRepository.SaveChangesAsync();
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

            var hotelReservation = await this.reservationService.GetHotelReservationByIdAsync<HotelReservationViewModel>(id);

            if (hotelReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(hotelReservation);
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

            var hotelReservation = await this.reservationService.GetHotelReservationByIdAsync(id);

            if (hotelReservation == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            try
            {
                this.hotelReservationRepository.Delete(hotelReservation);
                await this.hotelReservationRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.NotFound();
            }

            this.TempData[SuccessMessage] = SuccessfullyDeletedReservation;

            return this.RedirectToAction(nameof(this.Index));
        }

        private async Task<bool> HotelReservationExists(string id) => await this.hotelReservationRepository.AllAsNoTracking().AnyAsync(x => x.Id.ToString() == id);
    }
}

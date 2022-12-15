namespace TravelGuide.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Administration.HotelReservations;

    using static TravelGuide.Common.ErrorMessages.ReservationErrorMessages;
    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.ReservationSuccessMessages;

    public class HotelReservationsController : AdministrationController
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

        public async Task<IActionResult> Index() => this.View(await this.hotelReservationRepository.AllAsNoTracking().ToListAsync());

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var hotelReservation = await this.hotelReservationRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == id);

            if (hotelReservation == null)
            {
                return this.NotFound();
            }

            return this.View(hotelReservation);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.reservationService.AddAsync(model);
            }
            catch (Exception ex)
            {
                this.TempData[ErrorMessage] = ex.Message;

                return this.View(model);
            }

            this.TempData[SuccessMessage] = SuccessfullyCreatedReservation;

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var hotelReservation = await this.hotelReservationRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == id);

            if (hotelReservation == null)
            {
                return this.NotFound();
            }

            return this.View(hotelReservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Price,UserId,HotelId,DiscountId,StartDay,EndDay,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] HotelReservation hotelReservation)
        {
            if (id != hotelReservation.Id.ToString())
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.hotelReservationRepository.Update(hotelReservation);
                    await this.hotelReservationRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.HotelReservationExists(id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(hotelReservation);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var hotelReservation = await this.hotelReservationRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == id);

            if (hotelReservation == null)
            {
                return this.NotFound();
            }

            return this.View(hotelReservation);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hotelReservation = await this.hotelReservationRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == id);

            this.hotelReservationRepository.Delete(hotelReservation);
            await this.hotelReservationRepository.SaveChangesAsync();

            return this.RedirectToAction(nameof(this.Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.hotelReservationRepository.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task<bool> HotelReservationExists(string id) => await this.hotelReservationRepository.AllAsNoTracking().AnyAsync(x => x.Id.ToString() == id);
    }
}

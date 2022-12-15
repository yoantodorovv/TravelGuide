namespace TravelGuide.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Common;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Hotel;

    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.ReservationSuccessMessages;

    public class HotelReservationsController : BaseController
    {
        private readonly IReservationService reservationService;

        public HotelReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        public IActionResult Mine()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HotelViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.reservationService.CreateHotelReservation(model, userId);
            }
            catch (Exception ex)
            {
                this.TempData[ErrorMessage] = ex.Message;

                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SuccessMessage] = SuccessfullyCreatedReservation;

            return this.RedirectToAction(nameof(this.Mine));
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        public IActionResult Delete()
        {
            return this.View();
        }

        public IActionResult History()
        {
            return this.View();
        }
    }
}

namespace TravelGuide.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Administration.Hotel;

    using static TravelGuide.Common.ErrorMessages.HotelErrorMessages;
    using static TravelGuide.Common.GlobalConstants;
    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.HotelSuccessMessages;

    [Area("Administration")]
    public class HotelController : Controller
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IHotelService hotelService;
        private readonly IImageService imageService;

        public HotelController(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IHotelService hotelService,
            IImageService imageService)
        {
            this.hotelRepository = hotelRepository;
            this.hotelService = hotelService;
            this.imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var hotels = await this.hotelService.GetAllUserHotelsAsync<HotelViewModel>(userId);

            if (this.User.IsInRole(AdministratorRoleName))
            {
                hotels = await this.hotelService.GetAllAsync<HotelViewModel>();
            }

            return this.View(hotels);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var hotel = await this.hotelService.GetById<HotelViewModel>(id);

            if (hotel == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(hotel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var hotel = await this.hotelService.GetById<HotelViewModel>(id);

            if (hotel == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, HotelViewModel model)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Edit));
            }

            var hotel = await this.hotelService.GetById(id);

            if (hotel == null)
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
                hotel.Name = model.Name;
                hotel.Email = model.Email;
                hotel.Price = model.Price;
                hotel.Location = model.Location;
                hotel.Address.Town.Name = model.AddressTownName;
                hotel.Address.Country = model.AddressCountry;
                hotel.Address.AddressText = model.AddressAddressText;
                hotel.Rating = model.Rating;
                hotel.Details = model.Details;
                hotel.PhoneNumber = model.PhoneNumber;
                hotel.WebsiteUrl = model.WebsiteUrl;

                await this.imageService.UploadAndGetHotelImageCollectionAsync(model.AddedImages, hotel.Id);

                this.hotelRepository.Update(hotel);
                await this.hotelRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.HotelExists(id))
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

            this.TempData[SuccessMessage] = SuccessfullyEditedHotel;

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            var hotel = await this.hotelService.GetById<HotelViewModel>(id);

            if (hotel == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(hotel);
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

            var hotel = await this.hotelService.GetById(id);

            if (hotel == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Delete));
            }

            this.hotelRepository.Delete(hotel);
            await this.hotelRepository.SaveChangesAsync();

            this.TempData[SuccessMessage] = SuccessfullyDeletedHotel;

            return this.RedirectToAction(nameof(this.Index));
        }

        private async Task<bool> HotelExists(string id) => await this.hotelRepository.AllAsNoTracking().AnyAsync(x => x.Id.ToString() == id);
    }
}

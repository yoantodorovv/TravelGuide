namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Hotel;

    // FIXME: Fix images. (make them work -> 2:00:00)

    /// <summary>
    /// Hotel service.
    /// </summary>
    public class HotelService : IHotelService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IAmenityService amenityService;
        private readonly IAddressService addressService;
        private readonly IWorkingHoursService workingHoursService;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="hotelRepository">Hotel repository injection.</param>
        public HotelService(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IAmenityService amenityService,
            IAddressService addressService,
            IWorkingHoursService workingHoursService)
        {
            this.hotelRepository = hotelRepository;
            this.amenityService = amenityService;
            this.addressService = addressService;
            this.workingHoursService = workingHoursService;
        }

        /// <summary>
        /// Adds hotel to the DB asynchroniously.
        /// </summary>
        public async Task AddAsync(CreateHotelViewModel model, string userId, string imagePath)
        {
            var hotel = new Hotel()
            {
                OwnerId = Guid.Parse(userId),
                Name = model.Name,
                Location = model.Location,
                Price = model.Price,
                Details = model.Details,
                Rating = model.Rating,
                PhoneNumber = model.PhoneNumber,
                WebsiteUrl = model.WebsiteUrl,
                Email = model.Email,
            };

            // await this.AddImagesToHotelAsync(model, userId, hotel, imagePath);

            //// FIXME: Fix multiple addings (add to db only those that do not exist in db but add all to hotel relations (workingHours))

            try
            {
                hotel.Address = await this.addressService.GetAddressAsync(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            await this.hotelRepository.AddAsync(hotel);
            await this.hotelRepository.SaveChangesAsync();

            try
            {
                await this.amenityService.AddAmenitiesToHotelAsync(model, hotel);
                await this.workingHoursService.AddWorkingHoursToHotelAsync(model, hotel.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task AddImagesToHotelAsync(CreateHotelViewModel model, string userId, Hotel hotel, string imagePath)
        {
            foreach (var image in model.Images)
            {
                var extension = Path.GetExtension(image.FileName);

                var dbImage = new Image
                {
                    AuthorId = Guid.Parse(userId),
                    Extension = extension,
                };

                hotel.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/hotels/{dbImage.Id}.{extension}";
            }
        }
    }
}

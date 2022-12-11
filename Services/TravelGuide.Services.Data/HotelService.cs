﻿namespace TravelGuide.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Hotel;

    /// <summary>
    /// Hotel service.
    /// </summary>
    public class HotelService : IHotelService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IAmenityService amenityService;
        private readonly IAddressService addressService;
        private readonly IWorkingHoursService workingHoursService;
        private readonly IImageService imageService;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="hotelRepository">Hotel repository injection.</param>
        /// <param name="amenityService">Amenity service injection.</param>
        /// <param name="addressService">Address service injection.</param>
        /// <param name="workingHoursService">WorkingHours service injection.</param>
        /// <param name="imageService">Image service injection.</param>
        public HotelService(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IAmenityService amenityService,
            IAddressService addressService,
            IWorkingHoursService workingHoursService,
            IImageService imageService)
        {
            this.hotelRepository = hotelRepository;
            this.amenityService = amenityService;
            this.addressService = addressService;
            this.workingHoursService = workingHoursService;
            this.imageService = imageService;
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

            try
            {
                hotel.Address = await this.addressService.GetAddressAsync(model);

                await this.hotelRepository.AddAsync(hotel);

                hotel.Images = await this.imageService.UploadAndGetImageCollectionAsync(model.Images, hotel.Id);

                await this.hotelRepository.SaveChangesAsync();

                await this.amenityService.AddAmenitiesToHotelAsync(model, hotel);
                await this.workingHoursService.AddWorkingHoursToHotelAsync(model, hotel.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

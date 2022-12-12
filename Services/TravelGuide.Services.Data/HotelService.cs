namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;
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
        private readonly IUserService userService;

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
            IImageService imageService,
            IUserService userService)
        {
            this.hotelRepository = hotelRepository;
            this.amenityService = amenityService;
            this.addressService = addressService;
            this.workingHoursService = workingHoursService;
            this.imageService = imageService;
            this.userService = userService;
        }

        /// <summary>
        /// Adds hotel to the DB asynchroniously.
        /// </summary>
        /// TODO: Add hotel to User collection!
        /// TODO: Exception handling (if there is an error dont add hotel.)
        public async Task AddAsync(CreateHotelViewModel model, string userId)
        {
            var foundHotel = this.hotelRepository.All()
                .FirstOrDefault(x => x.Owner.Id.ToString() == userId
                    && x.Name == model.Name
                    && x.Location == model.Location
                    && x.Details == model.Details
                    && x.Rating == model.Rating
                    && x.PhoneNumber == model.PhoneNumber
                    && x.WebsiteUrl == model.WebsiteUrl
                    && x.Email == model.Email);

            if (foundHotel == null)
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

        /// <summary>
        /// Gets all hotels and maps them to a view model.
        /// </summary>
        public async Task<ICollection<T>> GetAllAsync<T>(int page, int itemsPerPage = 6) => await this.hotelRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        /// <summary>
        /// Gets all user hotels and maps them to a view model.
        /// </summary>
        public async Task<IEnumerable<T>> GetAllUserHotelsAsync<T>(int page, string userId, int itemsPerPage = 6) => await this.hotelRepository.AllAsNoTracking()
                .Where(x => x.OwnerId.ToString() == userId)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        /// <summary>
        /// Gets the count of all hotels.
        /// </summary>
        public async Task<int> GetCountAsync() => await this.hotelRepository.AllAsNoTracking().CountAsync();

        /// <summary>
        /// Gets the count of all user hotels.
        /// </summary>
        public async Task<int> GetUserHotelsCountAsync(string userId) => await this.hotelRepository.AllAsNoTracking().Where(x => x.OwnerId.ToString() == userId).CountAsync();
    }
}

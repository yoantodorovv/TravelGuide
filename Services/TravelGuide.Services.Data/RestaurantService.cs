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
    using TravelGuide.Web.ViewModels.Restaurant;

    using static TravelGuide.Common.ErrorMessages.CreateErrorMessages;

    /// <summary>
    /// Restaurant Service.
    /// </summary>
    public class RestaurantService : IRestaurantService
    {
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;
        private readonly IAddressService addressService;
        private readonly IImageService imageService;
        private readonly IWorkingHoursService workingHoursService;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="restaurantRepository">Restaurant repository injection.</param>
        /// <param name="addressService">Address service injection.</param>
        /// <param name="imageService">Image service injection.</param>
        /// <param name="workingHoursService">WorkingHours service injection.</param>
        public RestaurantService(
            IDeletableEntityRepository<Restaurant> restaurantRepository,
            IAddressService addressService,
            IImageService imageService,
            IWorkingHoursService workingHoursService)
        {
            this.restaurantRepository = restaurantRepository;
            this.addressService = addressService;
            this.imageService = imageService;
            this.workingHoursService = workingHoursService;
        }

        /// <summary>
        /// Adds a restaurant to DB asynchroniously.
        /// </summary>
        public async Task AddAsync(CreateRestaurantViewModel model, string userId)
        {
            var foundRestaurant = await this.restaurantRepository.All()
                .FirstOrDefaultAsync(x => x.Name == model.Name
                && x.Rating == model.Rating
                && x.Location == model.Location
                && x.PhoneNumber == model.PhoneNumber
                && x.WebsiteUrl == model.WebsiteUrl
                && x.Email == model.Email);

            if (foundRestaurant == null)
            {
                var restaurant = new Restaurant()
                {
                    OwnerId = Guid.Parse(userId),
                    Name = model.Name,
                    Location = model.Location,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    WebsiteUrl = model.WebsiteUrl,
                    Rating = model.Rating,
                    Description = model.Description,
                    MenuUrl = model.MenuUrl,
                    PriceRange = model.PriceRange,
                };

                try
                {
                    restaurant.Address = await this.addressService.GetAddressAsync<CreateRestaurantViewModel>(model);

                    await this.restaurantRepository.AddAsync(restaurant);

                    restaurant.Images = await this.imageService.UploadAndGetRestaurantImageCollectionAsync(model.Images, restaurant.Id);

                    await this.restaurantRepository.SaveChangesAsync();

                    await this.workingHoursService.AddWorkingHoursToRestaurantAsync(model, restaurant.Id);
                }
                catch (Exception)
                {
                    throw new Exception(SomethingWentWrongException);
                }
            }
            else
            {
                throw new Exception(string.Format(AlreadyExistsException, "restaurant"));
            }
        }

        /// <summary>
        /// Gets all restaurants and maps them to a view model.
        /// </summary>
        public async Task<ICollection<T>> GetAllAsync<T>(int page, int itemsPerPage = 6) => await this.restaurantRepository.AllAsNoTracking()
                .Include(x => x.WorkingHours)
                .ThenInclude(wh => wh.WorkingHours)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        public async Task<ICollection<T>> GetAllAsync<T>() => await this.restaurantRepository.AllAsNoTrackingWithDeleted()
                .Include(x => x.WorkingHours)
                .ThenInclude(wh => wh.WorkingHours)
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToListAsync();

        /// <summary>
        /// Gets all user restaurants and maps them to a view model.
        /// </summary>
        public async Task<IEnumerable<T>> GetAllUserRestaurantsAsync<T>(int page, string userId, int itemsPerPage = 6) => await this.restaurantRepository.AllAsNoTracking()
                .Include(x => x.WorkingHours)
                .ThenInclude(wh => wh.WorkingHours)
                .Where(x => x.OwnerId.ToString() == userId)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToListAsync();

        public async Task<IEnumerable<T>> GetAllUserRestaurantsAsync<T>(string userId) => await this.restaurantRepository.AllAsNoTracking()
                .Include(x => x.WorkingHours)
                .ThenInclude(wh => wh.WorkingHours)
                .Where(x => x.OwnerId.ToString() == userId)
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToListAsync();

        public async Task<T> GetById<T>(string restaurantId) => await this.restaurantRepository.AllAsNoTracking()
            .Include(x => x.Reservations)
            .Include(x => x.Images)
            .Include(x => x.Reviews)
            .Include(x => x.WorkingHours)
            .ThenInclude(wh => wh.WorkingHours)
            .Include(x => x.Address)
            .ThenInclude(a => a.Town)
            .Where(x => x.Id.ToString() == restaurantId)
            .To<T>()
            .FirstOrDefaultAsync();

        public async Task<Restaurant> GetById(string restaurantId) => await this.restaurantRepository.AllAsNoTracking()
            .Include(x => x.Reservations)
            .Include(x => x.Images)
            .Include(x => x.Reviews)
            .Include(x => x.WorkingHours)
            .ThenInclude(wh => wh.WorkingHours)
            .Include(x => x.Address)
            .ThenInclude(a => a.Town)
            .FirstOrDefaultAsync(x => x.Id.ToString() == restaurantId);

        /// <summary>
        /// Gets the count of all hotels.
        /// </summary>
        public async Task<int> GetCountAsync() => await this.restaurantRepository.AllAsNoTracking().CountAsync();

        /// <summary>
        /// Gets the count of all user restaurants.
        /// </summary>
        public async Task<int> GetUserRestaurantsCountAsync(string userId) => await this.restaurantRepository.AllAsNoTracking().Where(x => x.OwnerId.ToString() == userId).CountAsync();
    }
}

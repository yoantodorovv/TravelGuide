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
    using TravelGuide.Web.ViewModels.Administration.HotelReservations;
    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    using static TravelGuide.Common.ErrorMessages.ReservationErrorMessages;

    public class ReservationService : IReservationService
    {
        private readonly IDeletableEntityRepository<RestaurantReservation> restaurantReservationsRepository;
        private readonly IDeletableEntityRepository<HotelReservation> hotelReservationsRepository;
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;

        public ReservationService(
            IDeletableEntityRepository<RestaurantReservation> restaurantReservationsRepository,
            IDeletableEntityRepository<HotelReservation> hotelReservationsRepository,
            IDeletableEntityRepository<Restaurant> restaurantRepository,
            IDeletableEntityRepository<Hotel> hotelRepository)
        {
            this.restaurantReservationsRepository = restaurantReservationsRepository;
            this.hotelReservationsRepository = hotelReservationsRepository;
            this.restaurantRepository = restaurantRepository;
            this.hotelRepository = hotelRepository;
        }

        public async Task AddHotelReservationAsync(HotelReservationViewModel model)
        {
            var reservation = new HotelReservation()
            {
                HotelId = model.HotelId,
                UserId = model.UserId,
                Price = model.Price,
                StartDay = model.StartDay,
                EndDay = model.EndDay,
            };

            await this.hotelReservationsRepository.AddAsync(reservation);
            await this.hotelReservationsRepository.SaveChangesAsync();
        }

        public async Task CreateHotelReservation(HotelViewModel model, string userId)
        {
            var hotel = await this.hotelRepository.All().FirstOrDefaultAsync(x => x.Id == model.Id);

            if (model.ReservationStartDate < DateTime.Now || model.ReservationEndDate < DateTime.Now)
            {
                throw new Exception(DateCannotBeAlreadyPassed);
            }

            var foundReservation = await this.hotelReservationsRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.HotelId == model.Id
            && x.Price == model.Price
            && x.StartDay == model.ReservationStartDate
            && x.EndDay == model.ReservationEndDate);

            if (foundReservation != null)
            {
                throw new Exception(string.Format(AlreadyReserved, "room", "hotel", "rooms", "the hotel has free rooms"));
            }

            hotel.Reservations.Add(new HotelReservation()
            {
                StartDay = model.ReservationStartDate,
                EndDay = model.ReservationEndDate,
                UserId = Guid.Parse(userId),
            });

            await this.hotelRepository.SaveChangesAsync();
        }

        public async Task CreateRestaurantReservation(RestaurantViewModel model, string userId)
        {
            var restaurant = await this.restaurantRepository.All().FirstOrDefaultAsync(x => x.Id == model.Id);

            if (model.ReservationDate < DateTime.Now)
            {
                throw new Exception(DateCannotBeAlreadyPassed);
            }

            var foundReservation = await this.restaurantReservationsRepository.AllAsNoTracking().FirstOrDefaultAsync(x => x.RestaurantId == model.Id
            && x.ReservationDate == model.ReservationDate);

            if (foundReservation != null)
            {
                throw new Exception(string.Format(AlreadyReserved, "table", "restaurant", "tables", await this.restaurantReservationsRepository.AllAsNoTracking().CountAsync() >= 20 ? "tomorrow" : "45 minutes after"));
            }

            restaurant.Reservations.Add(new RestaurantReservation()
            {
                ReservationDate = model.ReservationDate,
                UserId = Guid.Parse(userId),
            });

            await this.restaurantRepository.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllHotelReservationsAsync<T>() => await this.hotelReservationsRepository.AllAsNoTracking()
            .To<T>()
            .ToListAsync();

        public async Task<ICollection<T>> GetAllRestaurantReservationsAsync<T>() => await this.restaurantReservationsRepository.AllAsNoTracking()
            .To<T>()
            .ToListAsync();
    }
}

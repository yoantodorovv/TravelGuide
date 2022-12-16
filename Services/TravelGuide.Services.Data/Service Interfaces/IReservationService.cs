namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;
    using TravelGuide.Web.ViewModels.Administration.HotelReservations;
    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    public interface IReservationService
    {
        Task CreateRestaurantReservation(RestaurantViewModel model, string userId);

        Task CreateHotelReservation(HotelViewModel model, string userId);

        Task<T> GetHotelReservationByIdAsync<T>(string id);

        Task<HotelReservation> GetHotelReservationByIdAsync(string id);

        //// Task<T> GetRestaurantReservationByIdAsync<T>(string id);

        Task<ICollection<T>> GetAllHotelReservationsAsync<T>();

        Task<ICollection<T>> GetAllRestaurantReservationsAsync<T>();
    }
}

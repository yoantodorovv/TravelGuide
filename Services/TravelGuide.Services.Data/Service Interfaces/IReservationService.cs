namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.Administration.HotelReservations;
    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    public interface IReservationService
    {
        Task CreateRestaurantReservation(RestaurantViewModel model, string userId);

        Task CreateHotelReservation(HotelViewModel model, string userId);

        Task AddAsync(CreateViewModel model);
    }
}

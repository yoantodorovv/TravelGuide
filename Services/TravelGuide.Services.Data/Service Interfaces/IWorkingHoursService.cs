namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    public interface IWorkingHoursService
    {
        Task AddWorkingHoursToHotelAsync(CreateHotelViewModel model, Guid hotelId);

        Task AddWorkingHoursToRestaurantAsync(CreateRestaurantViewModel model, Guid restaurantId);
    }
}

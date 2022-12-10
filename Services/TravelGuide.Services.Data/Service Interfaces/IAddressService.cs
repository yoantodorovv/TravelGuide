namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;
    using TravelGuide.Web.ViewModels.Hotel;

    public interface IAddressService
    {
        Task<Address> GetAddressAsync(CreateHotelViewModel model);
    }
}

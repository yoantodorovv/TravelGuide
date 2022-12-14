namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using TravelGuide.Data.Models;

    public interface IImageService
    {
        Task<ICollection<HotelImage>> UploadAndGetHotelImageCollectionAsync(IFormFileCollection images, Guid hotelId);

        Task<ICollection<RestaurantImage>> UploadAndGetRestaurantImageCollectionAsync(IFormFileCollection images, Guid restaurantId);
    }
}

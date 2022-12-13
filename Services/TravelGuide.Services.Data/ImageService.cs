namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;

    public class ImageService : IImageService
    {
        private readonly IDeletableEntityRepository<HotelImage> hotelImagesRepository;
        private readonly IDeletableEntityRepository<RestaurantImage> restaurantImagesRepository;
        private readonly ICloudinaryService cloudinaryService;

        public ImageService(
            IDeletableEntityRepository<HotelImage> hotelImagesRepository,
            IDeletableEntityRepository<RestaurantImage> restaurantImagesRepository,
            ICloudinaryService cloudinaryService)
        {
            this.hotelImagesRepository = hotelImagesRepository;
            this.restaurantImagesRepository = restaurantImagesRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<ICollection<HotelImage>> UploadAndGetHotelImageCollectionAsync(IFormFileCollection images, Guid hotelId)
        {
            var hotelImages = new HashSet<HotelImage>();

            foreach (var image in images)
            {
                var imageUrl = this.cloudinaryService.UploadImage(image);

                var newImage = new HotelImage()
                {
                    ImageUrl = imageUrl,
                    HotelId = hotelId,
                };

                await this.hotelImagesRepository.AddAsync(newImage);

                hotelImages.Add(newImage);
            }

            await this.hotelImagesRepository.SaveChangesAsync();

            return hotelImages;
        }

        public async Task<ICollection<RestaurantImage>> UploadAndGetRestaurantImageCollectionAsync(IFormFileCollection images, Guid restaurantId)
        {
            var restaurantImages = new HashSet<RestaurantImage>();

            foreach (var image in images)
            {
                var imageUrl = this.cloudinaryService.UploadImage(image);

                var newImage = new RestaurantImage()
                {
                    ImageUrl = imageUrl,
                    RestaurantId = restaurantId,
                };

                await this.restaurantImagesRepository.AddAsync(newImage);

                restaurantImages.Add(newImage);
            }

            await this.restaurantImagesRepository.SaveChangesAsync();

            return restaurantImages;
        }
    }
}

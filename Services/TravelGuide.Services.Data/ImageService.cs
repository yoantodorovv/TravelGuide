namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;

    public class ImageService : IImageService
    {
        private readonly IDeletableEntityRepository<HotelImage> hotelImagesRepository;
        private readonly ICloudinaryService cloudinaryService;

        public ImageService(
            IDeletableEntityRepository<HotelImage> hotelImagesRepository,
            ICloudinaryService cloudinaryService)
        {
            this.hotelImagesRepository = hotelImagesRepository;
            this.cloudinaryService = cloudinaryService;
        }

        // TODO: FINISH! Make it work for images.
        public async Task<ICollection<HotelImage>> UploadAndGetImageCollectionAsync(IFormFileCollection images, Guid hotelId)
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
    }
}

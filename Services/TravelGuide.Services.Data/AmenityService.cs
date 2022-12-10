namespace TravelGuide.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Hotel;

    public class AmenityService : IAmenityService
    {
        private readonly IDeletableEntityRepository<Amenity> amenityRepository;
        private readonly IRepository<AmenityHotel> amenityHotelsRepository;

        public AmenityService(
            IDeletableEntityRepository<Amenity> amenityRepository,
            IRepository<AmenityHotel> amenityHotelsRepository)
        {
            this.amenityRepository = amenityRepository;
            this.amenityHotelsRepository = amenityHotelsRepository;
        }

        public async Task AddAmenitiesToHotelAsync(CreateHotelViewModel model, Hotel hotel)
        {
            foreach (var title in model.AmenitiesUtil.Split("  "))
            {
                var foundAmenity = this.amenityRepository.All().ToList().FirstOrDefault(x => x.Title == title);

                if (foundAmenity == null)
                {
                    await this.amenityHotelsRepository.AddAsync(new AmenityHotel()
                    {
                        Amenity = new Amenity()
                        {
                            Title = title,
                        },
                        HotelId = hotel.Id,
                    });
                }
                else
                {
                    await this.amenityHotelsRepository.AddAsync(new AmenityHotel()
                    {
                        AmenityId = foundAmenity.Id,
                        HotelId = hotel.Id,
                    });
                }
            }

            await this.amenityHotelsRepository.SaveChangesAsync();
        }
    }
}

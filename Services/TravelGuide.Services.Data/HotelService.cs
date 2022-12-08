namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Hotel;

    // FIXME: Fix multiple addings (add to db only those that do not exist in db but add all to hotel relations (addresses, workingHours))

    // FIXME: Fix images. (make them work -> 2:00:00)

    /// <summary>
    /// Hotel service.
    /// </summary>
    public class HotelService : IHotelService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IDeletableEntityRepository<Amenity> amenityRepository;
        private readonly IRepository<AmenityHotels> amenityHotelsRepository;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="hotelRepository">Hotel repository injection.</param>
        public HotelService(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IDeletableEntityRepository<Amenity> amenityRepository,
            IRepository<AmenityHotels> amenityHotelsRepository)
        {
            this.hotelRepository = hotelRepository;
            this.amenityRepository = amenityRepository;
            this.amenityHotelsRepository = amenityHotelsRepository;
        }

        /// <summary>
        /// Adds hotel to the DB asynchroniously.
        /// </summary>
        public async Task AddAsync(CreateHotelViewModel model, string userId, string imagePath)
        {
            var hotel = new Hotel()
            {
                OwnerId = Guid.Parse(userId),
                Name = model.Name,
                Location = model.Location,
                Price = model.Price,
                Details = model.Details,
                Rating = model.Rating,
                Address = new Address()
                {
                    AddressText = model.AddressAddressText,
                    Country = model.AddressCountry,
                    Town = new Town()
                    {
                        Name = model.AddressTownName,
                    },
                },
                PhoneNumber = model.PhoneNumber,
                WebsiteUrl = model.WebsiteUrl,
                Email = model.Email,
                WorkingHours = new List<WorkingHours>()
                {
                    new WorkingHours()
                    {
                        WeekDay = model.WorkingHoursWeekDay,
                        RegistrationTime = (int.Parse(model.WorkingHoursRegistrationTime.Split(":")[0]) * 60) + int.Parse(model.WorkingHoursRegistrationTime.Split(":")[1]),
                        LeaveTime = (int.Parse(model.WorkingHoursLeaveTime.Split(":")[0]) * 60) + int.Parse(model.WorkingHoursLeaveTime.Split(":")[1]),
                    },
                },
            };

            foreach (var image in model.Images)
            {
                var extension = Path.GetExtension(image.FileName);

                var dbImage = new Image
                {
                    AuthorId = Guid.Parse(userId),
                    Extension = extension,
                };

                hotel.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/hotels/{dbImage.Id}.{extension}";
            }

            await this.hotelRepository.AddAsync(hotel);
            await this.hotelRepository.SaveChangesAsync();

            await this.AddAmenitiesAsync(model, hotel);
        }

        private async Task AddAmenitiesAsync(CreateHotelViewModel model, Hotel hotel)
        {
            foreach (var title in model.AmenitiesUtil.Split("  "))
            {
                var foundAmenity = this.amenityRepository.All().ToList().FirstOrDefault(x => x.Title == title);

                if (foundAmenity == null)
                {
                    await this.amenityHotelsRepository.AddAsync(new AmenityHotels()
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
                    await this.amenityHotelsRepository.AddAsync(new AmenityHotels()
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

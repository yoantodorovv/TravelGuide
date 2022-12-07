namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Amenity;
    using TravelGuide.Web.ViewModels.Hotel;

    /// <summary>
    /// Hotel service.
    /// </summary>
    public class HotelService : IHotelService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="hotelRepository">Hotel repository injection.</param>
        public HotelService(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IDele)
        {
            this.hotelRepository = hotelRepository;
        }

        /// <summary>
        /// Adds hotel to the DB asynchroniously.
        /// </summary>
        public async Task AddAsync(CreateHotelViewModel model, string userId, string imagePath)
        {
            foreach (var title in model.AmenityTitle.Split("  "))
            {
                if (true)
                {

                }

                model.Amenities.Add(new AmenityViewModel()
                {
                    Title = title,
                });
            }

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
                Amenities = model.Amenities
                    .Select(x => new Amenity()
                    {
                        Title = x.Title,
                    })
                    .ToList(),
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

            //// hotel = this.mapper.Map<Hotel>(model);
            //// hotel = AutoMapperConfig.MapperInstance.Map<Hotel>(model);

            await this.hotelRepository.AddAsync(hotel);
            await this.hotelRepository.SaveChangesAsync();
        }
    }
}

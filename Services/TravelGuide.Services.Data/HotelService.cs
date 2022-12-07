namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Amenity;
    using TravelGuide.Web.ViewModels.Hotel;

    public class HotelService : IHotelService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;

        public HotelService(
            IDeletableEntityRepository<Hotel> hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task AddAsync(CreateHotelViewModel model)
        {
            foreach (var title in model.AmenityTitle.Split("  "))
            {
                model.Amenities.Add(new AmenityViewModel()
                {
                    Title = title,
                });
            }

            var hotel = new Hotel()
            {
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
                WorkingHours = model.WorkingHours
                    .Select(x => new WorkingHours()
                    {
                        WeekDay = x.WorkingHoursWeekDay,
                        RegistrationTime = (int.Parse(x.WorkingHoursRegistrationTime.Split(":")[0]) * 60) + int.Parse(x.WorkingHoursRegistrationTime.Split(":")[1]),
                        LeaveTime = (int.Parse(x.WorkingHoursLeaveTime.Split(":")[0]) * 60) + int.Parse(x.WorkingHoursLeaveTime.Split(":")[1]),
                    })
                    .ToList(),
                Amenities = model.Amenities
                    .Select(x => new Amenity()
                    {
                        Title = x.Title,
                    })
                    .ToList(),
                Images = new List<Image>()
                {
                    // TODO: See image functionallity
                },
            };

            //// hotel = this.mapper.Map<Hotel>(model);
            //// hotel = AutoMapperConfig.MapperInstance.Map<Hotel>(model);

            await this.hotelRepository.AddAsync(hotel);
            await this.hotelRepository.SaveChangesAsync();
        }
    }
}

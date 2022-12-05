namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Hotel;

    public class HotelService : IHotelService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;

        public HotelService(
            IDeletableEntityRepository<Hotel> hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task AddAsync(CreateHotelViewModel createHotelViewModel)
        {
            var hotel = new Hotel()
            {
                Name = createHotelViewModel.Name,
                Location = createHotelViewModel.Location,
                Price = createHotelViewModel.Price,
                Details = createHotelViewModel.Details,
                Rating = createHotelViewModel.Rating,
                Address = new Address()
                {
                    AddressText = createHotelViewModel.AddressAddressText,
                    Country = createHotelViewModel.AddressCountry,
                    Town = new Town()
                    {
                        Name = createHotelViewModel.AddressTownName,
                    },
                },
                PhoneNumber = createHotelViewModel.PhoneNumber,
                WebsiteUrl = createHotelViewModel.WebsiteUrl,
                Email = createHotelViewModel.Email,
                WorkingHours = new List<WorkingHours>()
                {
                    // TODO: Think of a way to do the working hours.
                    new WorkingHours()
                    {
                        WeekDay = "",
                        //// OpenTime = null,
                        //// CloseTime = null,
                    },
                },
                Amenities = new List<Amenity>()
                {
                    // TODO: Think of a way to do the amenities.
                    new Amenity()
                    {
                        Title = "",
                    },
                },
                Images = new List<Image>()
                {
                    // TODO: See image functionallity
                },
            };

            //// hotel = this.mapper.Map<Hotel>(createHotelViewModel);
            //// hotel = AutoMapperConfig.MapperInstance.Map<Hotel>(createHotelViewModel);

            await this.hotelRepository.AddAsync(hotel);
        }
    }
}

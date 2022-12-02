namespace TravelGuide.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.DTOs.Hotel;

    public class HotelService : IHotelService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IMapper mapper;

        public HotelService(
            IDeletableEntityRepository<Hotel> hotelRepository,
            IMapper mapper)
        {
            this.hotelRepository = hotelRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(CreateHotelDto createHotelDto)
        {
            var hotel = this.mapper.Map<Hotel>(createHotelDto);

            await this.hotelRepository.AddAsync(hotel);
        }
    }
}

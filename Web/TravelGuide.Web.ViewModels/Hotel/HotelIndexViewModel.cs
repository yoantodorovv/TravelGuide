namespace TravelGuide.Web.ViewModels.Hotel
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    // TODO: Add validation attributes
    public class HotelIndexViewModel : IMapFrom<Hotel>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Country { get; set; }

        public decimal Price { get; set; }

        public double Rating { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Hotel, HotelIndexViewModel>()
                .ForMember(x => x.Country, opt =>
                    opt.MapFrom(h => h.Address.Country));
        }
    }
}

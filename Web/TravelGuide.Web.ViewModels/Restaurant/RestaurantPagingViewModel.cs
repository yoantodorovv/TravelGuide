namespace TravelGuide.Web.ViewModels.Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    public class RestaurantPagingViewModel : IMapFrom<Restaurant>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public string Location { get; set; }

        public string Country { get; set; }

        public string PriceRange { get; set; }

        public IEnumerable<RestaurantWorkingHours> WorkingHours { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Restaurant, RestaurantPagingViewModel>()
                .ForMember(x => x.Country, opt =>
                    opt.MapFrom(r => r.Address.Country))
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(r => r.Images.FirstOrDefault().ImageUrl));
        }
    }
}

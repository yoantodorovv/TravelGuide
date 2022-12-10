namespace TravelGuide.Web.ViewModels.Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    using static TravelGuide.Common.GlobalConstants.RestaurantConstants;

    public class RestaurantIndexViewModel : IMapFrom<Restaurant>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        [Required]
        [StringLength(LocationMaxLength, MinimumLength = LocationMinLength)]
        public string Location { get; set; }

        public string Country { get; set; }

        [Required]
        public string PriceRange { get; set; }

        public IEnumerable<RestaurantWorkingHours> WorkingHours { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            //// TODO: Make mapping work.

            configuration.CreateMap<Restaurant, RestaurantIndexViewModel>()
                .ForMember(x => x.Country, opt =>
                    opt.MapFrom(r => r.Address.Country));
                //.ForMember(x => x.WorkingHours, opt =>
                //    opt.MapFrom(x => x.WorkingHours.Select(x => x.Restaurant).Select(r => r.WorkingHours)));
        }
    }
}

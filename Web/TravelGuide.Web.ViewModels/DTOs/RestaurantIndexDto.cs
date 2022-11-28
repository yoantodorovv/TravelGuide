﻿namespace TravelGuide.Web.ViewModels.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    using static TravelGuide.Common.GlobalConstants.RestaurantConstants;

    // TODO: Add validation attributes
    public class RestaurantIndexDto : IMapFrom<Restaurant>, IHaveCustomMappings
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

        public IEnumerable<WorkingHours> WorkingHours { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Restaurant, RestaurantIndexDto>()
                .ForMember(x => x.Country, opt =>
                    opt.MapFrom(r => r.Address.Country));
        }
    }
}

namespace TravelGuide.Web.ViewModels.DTOs.Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    using static TravelGuide.Common.GlobalConstants.HotelConstants;

    public class CreateHotelDto : IMapTo<Hotel>, IHaveCustomMappings
    {
        /// <summary>
        /// Gets or sets hotel's name.
        /// </summary>
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets hotel's location.
        /// </summary>
        [Required]
        [StringLength(LocationMaxLength, MinimumLength = LocationMinLength)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets hotel's price.
        /// </summary>
        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)] // TODO: Redo Range attribute
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets hotel's details.
        /// </summary>
        [Required]
        [StringLength(DetailsMaxLength, MinimumLength = DetailsMinLength)]
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets hotel's rating.
        /// </summary>
        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        public string Country { get; set; }

        [Required]
        [StringLength(TownMaxLength, MinimumLength = TownMinLength)]
        public string Town { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets hotel's phone contact number.
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets hotel's website url.
        /// </summary>
        [Required]
        [StringLength(WebsiteMaxLength, MinimumLength = WebsiteMinLength)]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets hotel's contact email address.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the owner of the hotel.
        /// </summary>
        public virtual ApplicationUser Owner { get; set; }

        // TODO: DTOs

        /// <summary>
        /// Gets or sets a collection of the hotel's daily working hours.
        /// </summary>
        [Required]
        public virtual ICollection<WorkingHours> WorkingHours { get; set; } = new HashSet<WorkingHours>();

        /// <summary>
        /// Gets or sets a collection of the hotel's amenities.
        /// </summary>
        [Required]
        public virtual ICollection<Amenity> Amenities { get; set; } = new HashSet<Amenity>();

        /// <summary>
        /// Gets or sets a collection of the hotel's images.
        /// </summary>
        [Required]
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CreateHotelDto, Hotel>()
                .ForMember(x => x.Address.Country, opt => opt.MapFrom(h => h.Country))
                .ForMember(x => x.Address.Town.Name, opt => opt.MapFrom(h => h.Town))
                .ForMember(x => x.Address.AddressText, opt => opt.MapFrom(h => h.Address));
        }
    }
}

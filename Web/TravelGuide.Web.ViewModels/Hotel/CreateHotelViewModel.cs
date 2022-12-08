namespace TravelGuide.Web.ViewModels.Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Amenity;
    using TravelGuide.Web.ViewModels.WorkingHours;

    using static TravelGuide.Common.GlobalConstants.AmenityConstants;
    using static TravelGuide.Common.GlobalConstants.HotelConstants;
    using static TravelGuide.Common.GlobalConstants.WorkingHoursConstants;

    public class CreateHotelViewModel : IMapTo<Hotel>
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
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Price for 1 room")]
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

        /// <summary>
        /// Gets or sets hotel's country.
        /// </summary>
        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        [Display(Name = "Country")]
        public string AddressCountry { get; set; }

        /// <summary>
        /// Gets or sets hotel's town name.
        /// </summary>
        [Required]
        [StringLength(TownMaxLength, MinimumLength = TownMinLength)]
        [Display(Name = "Town")]
        public string AddressTownName { get; set; }

        /// <summary>
        /// Gets or sets hotel's address.
        /// </summary>
        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Display(Name = "Address")]
        public string AddressAddressText { get; set; }

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
        /// Gets or sets the opening time.
        /// </summary>
        [Required]
        [Display(Name = "Registration Time")]
        [RegularExpression(TimeRegex)]
        public string WorkingHoursRegistrationTime { get; set; }

        /// <summary>
        /// Gets or sets the closing time.
        /// </summary>
        [Required]
        [Display(Name = "Leave Time")]
        [RegularExpression(TimeRegex)]
        public string WorkingHoursLeaveTime { get; set; }

        /// <summary>
        /// Gets or sets the day of the week.
        /// </summary>
        [StringLength(WeekDayMaxLength)]
        public string WorkingHoursWeekDay { get; set; } = "Working Time";

        // TODO: Make Amenity Title with chips.

        /// <summary>
        /// Gets or sets amenity title property.
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength)]
        [Display(Name = "Amenities")]
        public string AmenitiesUtil { get; set; }

        // TODO: Finish images.

        /// <summary>
        /// Gets or sets a collection of the hotel's images.
        /// </summary>
        public virtual ICollection<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}

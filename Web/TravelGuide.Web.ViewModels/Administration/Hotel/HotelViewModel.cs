namespace TravelGuide.Web.ViewModels.Administration.Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Amenity;
    using TravelGuide.Web.ViewModels.Image;
    using TravelGuide.Web.ViewModels.Review;

    using static TravelGuide.Common.GlobalConstants.HotelConstants;

    public class HotelViewModel : IMapFrom<Hotel>
    {
        public Guid Id { get; set; }

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
        public string AddressCountry { get; set; }

        [Required]
        [StringLength(TownMaxLength, MinimumLength = TownMinLength)]
        public string AddressTownName { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
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
        /// Gets or sets the owner of the hotel.
        /// </summary>
        public virtual ApplicationUser Owner { get; set; }

        public string WorkingHoursText { get; set; }

        public string WorkingHoursRegistrationTime { get; set; }

        public string WorkingHoursLeaveTime { get; set; }

        /// <summary>
        /// Gets or sets the reservation's price.
        /// </summary>
        [Required]
        public decimal ReservationPrice { get; set; }

        /// <summary>
        /// Gets or sets the reservation's start date and time.
        /// </summary>
        [Required]
        public DateTime ReservationStartDate { get; set; }

        /// <summary>
        /// Gets or sets the reservation's end date and time.
        /// </summary>
        [Required]
        public DateTime ReservationEndDate { get; set; }

        /// <summary>
        /// Gets or sets a collection of the hotel's images.
        /// </summary>
        [Required]
        public virtual ICollection<HotelImageViewModel> Images { get; set; } = new HashSet<HotelImageViewModel>();

        /// <summary>
        /// Gets or sets a collection of the facility's images.
        /// </summary>
        [Required]
        public virtual IFormFileCollection AddedImages { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

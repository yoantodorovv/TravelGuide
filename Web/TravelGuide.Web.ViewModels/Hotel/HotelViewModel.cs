namespace TravelGuide.Web.ViewModels.Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using TravelGuide.Data.Models;

    using static TravelGuide.Common.GlobalConstants.HotelConstants;

    public class HotelViewModel
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

        /// <summary>
        /// Gets or sets a collection of the hotel's daily working hours.
        /// </summary>
        [Required]
        public virtual ICollection<WorkingHours> WorkingHours { get; set; } = new HashSet<WorkingHours>();

        /// <summary>
        /// Gets or sets a collection of the hotel's reviews.
        /// </summary>
        [Required]
        public virtual ICollection<HotelReview> Reviews { get; set; } = new HashSet<HotelReview>();

        /// <summary>
        /// Gets or sets a collection of the hotel's amenities.
        /// </summary>
        [Required]
        public virtual ICollection<Amenity> Amenities { get; set; } = new HashSet<Amenity>();

        /// <summary>
        /// Gets or sets a collection of the hotel's images.
        /// </summary>
        [Required]
        public virtual ICollection<HotelImage> Images { get; set; } = new HashSet<HotelImage>();
    }
}

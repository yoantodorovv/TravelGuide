namespace TravelGuide.Web.ViewModels.Administration.Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Http;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    using static TravelGuide.Common.GlobalConstants.AddressConstants;
    using static TravelGuide.Common.GlobalConstants.RestaurantConstants;

    public class RestaurantViewModel : IMapFrom<Restaurant>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's name.
        /// </summary>
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's rating.
        /// </summary>
        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's location.
        /// </summary>
        [Required]
        [StringLength(LocationMaxLength)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's price range.
        /// </summary>
        [Required]
        public string PriceRange { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's description.
        /// </summary>
        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's contact phone number.
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

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
        /// Gets or sets the reservation's date and time.
        /// </summary>
        [Required]
        public DateTime ReservationDate { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's website url.
        /// </summary>
        [Required]
        [StringLength(WebsiteMaxLength)]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's owner.
        /// </summary>
        public virtual ApplicationUser Owner { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's contact email address.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's menu url.
        /// </summary>
        [Required]
        [Url]
        public string MenuUrl { get; set; }

        /// <summary>
        /// Gets or sets a collection of the restaurant's images.
        /// </summary>
        public virtual ICollection<RestaurantImage> Images { get; set; } = new HashSet<RestaurantImage>();

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

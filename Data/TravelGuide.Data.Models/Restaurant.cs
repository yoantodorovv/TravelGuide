namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.RestaurantConstants;

    /// <summary>
    /// Restaurant entity class.
    /// </summary>
    public class Restaurant : BaseDeletableModel<Guid>
    {
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

        /// <summary>
        /// Gets or sets the restaurant's address.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Address))]
        public Guid AdressId { get; set; }

        [Required]
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's website url.
        /// </summary>
        [Required]
        [StringLength(WebsiteMaxLength)]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's owner id.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

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
        /// Gets or sets a collection of the restaurant's daily working hours.
        /// </summary>
        public virtual ICollection<RestaurantWorkingHours> WorkingHours { get; set; } = new HashSet<RestaurantWorkingHours>();

        /// <summary>
        /// Gets or sets a collection of the restaurant's reviews.
        /// </summary>
        public virtual ICollection<RestaurantReview> Reviews { get; set; } = new HashSet<RestaurantReview>();

        /// <summary>
        /// Gets or sets a collection of the restaurant's images.
        /// </summary>
        public virtual ICollection<RestaurantImage> Images { get; set; } = new HashSet<RestaurantImage>();
    }
}

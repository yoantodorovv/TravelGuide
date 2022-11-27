namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.HotelConstants;

    /// <summary>
    /// Hotel entity class.
    /// </summary>
    public class Hotel : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets hotel's name.
        /// </summary>
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets hotel's location.
        /// </summary>
        [Required]
        [StringLength(LocationMaxLength)]
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
        [StringLength(DetailsMaxLength)]
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets hotel's rating.
        /// </summary>
        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        /// <summary>
        /// Gets or sets hotel's address.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Address))]
        public Guid AdressId { get; set; }

        [Required]
        public Address Address { get; set; }

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
        [StringLength(WebsiteMaxLength)]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets hotel's contact email address.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the id of the hotel owner.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the owner of the hotel.
        /// </summary>
        public virtual ApplicationUser Owner { get; set; }

        /// <summary>
        /// Gets or sets a collection of the hotel's daily working hours.
        /// </summary>
        public virtual ICollection<WorkingHours> WorkingHours { get; set; } = new HashSet<WorkingHours>();

        /// <summary>
        /// Gets or sets a collection of the hotel's reviews.
        /// </summary>
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

        /// <summary>
        /// Gets or sets a collection of the hotel's amenities.
        /// </summary>
        public virtual ICollection<Amenity> Amenities { get; set; } = new HashSet<Amenity>();

        /// <summary>
        /// Gets or sets a collection of the hotel's images.
        /// </summary>
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}

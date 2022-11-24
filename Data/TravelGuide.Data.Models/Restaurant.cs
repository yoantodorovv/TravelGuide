namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.RestaurantConstants;

    public class Restaurant : BaseDeletableModel<Guid>
    {
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]

        public double Rating { get; set; }

        [Required]
        [StringLength(LocationMaxLength)]
        public string Location { get; set; }

        [Required]
        public string PriceRange { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [StringLength(WebsiteMaxLength)]
        public string WebsiteUrl { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // TODO: Might not be required
        [Required]
        [Url]
        public string MenuUrl { get; set; }

        public virtual ICollection<WorkingHours> WorkingHours { get; set; } = new HashSet<WorkingHours>();

        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}

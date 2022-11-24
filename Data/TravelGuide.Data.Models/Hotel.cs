namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.HotelConstants;

    public class Hotel : BaseDeletableModel<Guid>
    {
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(LocationMaxLength)]
        public string Location { get; set; }

        // TODO: Redo Range attribute
        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DetailsMaxLength)]
        public string Details { get; set; }

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        [Required]
        [StringLength(AddressMaxLength)]
        public string Adress { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(WebsiteMaxLength)]
        public string WebsiteUrl { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<WorkingHours> WorkingHours { get; set; } = new HashSet<WorkingHours>();

        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

        public virtual ICollection<Amenity> Amenities { get; set; } = new HashSet<Amenity>();

        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}

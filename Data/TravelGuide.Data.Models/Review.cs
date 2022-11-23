namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.ReviewConstants;

    public class Review : BaseDeletableModel<Guid>
    {
        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public virtual ApplicationUser Author { get; set; }

        [ForeignKey(nameof(Hotel))]
        public Guid? HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public Guid? RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}

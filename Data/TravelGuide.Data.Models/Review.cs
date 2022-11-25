namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.ReviewConstants;

    /// <summary>
    /// Review entity model class.
    /// </summary>
    public class Review : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets the review's title.
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the review's rating.
        /// </summary>
        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        /// <summary>
        /// Gets or sets the review's description.
        /// </summary>
        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the review's author id.
        /// </summary>
        [Required]
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the review's author.
        /// </summary>
        [Required]
        public virtual ApplicationUser Author { get; set; }

        /// <summary>
        /// Gets or sets the review's hotel id.
        /// </summary>
        [ForeignKey(nameof(Hotel))]
        public Guid? HotelId { get; set; }

        /// <summary>
        /// Gets or sets the review's hotel.
        /// </summary>
        public virtual Hotel Hotel { get; set; }

        /// <summary>
        /// Gets or sets the review's restaurant id.
        /// </summary>
        [ForeignKey(nameof(Restaurant))]
        public Guid? RestaurantId { get; set; }

        /// <summary>
        /// Gets or sets the review's restaurant.
        /// </summary>
        public virtual Restaurant Restaurant { get; set; }
    }
}

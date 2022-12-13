namespace TravelGuide.Web.ViewModels.Review
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    using static TravelGuide.Common.GlobalConstants.ReviewConstants;

    public class RestaurantReviewViewModel : IMapFrom<RestaurantReview>
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
    }
}

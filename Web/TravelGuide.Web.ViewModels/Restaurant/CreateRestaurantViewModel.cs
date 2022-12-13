namespace TravelGuide.Web.ViewModels.Restaurant
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Web.ViewModels.Utilities;

    using static TravelGuide.Common.GlobalConstants.RestaurantConstants;
    using static TravelGuide.Common.GlobalConstants.WorkingHoursConstants;

    public class CreateRestaurantViewModel : CreateViewModel
    {
        [Required]
        public string PriceRange { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string MenuUrl { get; set; }

        /// <summary>
        /// Gets or sets the opening time.
        /// </summary>
        [Required]
        [Display(Name = "Opening Time")]
        [RegularExpression(TimeRegex)]
        public string WorkingHoursRegistrationTime { get; set; }

        /// <summary>
        /// Gets or sets the closing time.
        /// </summary>
        [Required]
        [Display(Name = "Closing Time")]
        [RegularExpression(TimeRegex)]
        public string WorkingHoursLeaveTime { get; set; }

        /// <summary>
        /// Gets or sets the day of the week.
        /// </summary>
        [StringLength(TextMaxLength)]
        public string WorkingHoursText { get; set; } = "Working Time:";
    }
}

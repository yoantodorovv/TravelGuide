namespace TravelGuide.Web.ViewModels.Restaurant
{
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Web.ViewModels.Utilities;

    using static TravelGuide.Common.GlobalConstants.RestaurantConstants;

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
    }
}

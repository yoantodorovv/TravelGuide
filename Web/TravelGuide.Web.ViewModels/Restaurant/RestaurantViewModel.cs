namespace TravelGuide.Web.ViewModels.Restaurant
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Image;
    using TravelGuide.Web.ViewModels.Review;

    using static TravelGuide.Common.GlobalConstants.AddressConstants;
    using static TravelGuide.Common.GlobalConstants.RestaurantConstants;

    public class RestaurantViewModel : IMapFrom<Restaurant>
    {
        /// <summary>
        /// Gets or sets hotel's name.
        /// </summary>
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets hotel's location.
        /// </summary>
        [Required]
        [StringLength(LocationMaxLength, MinimumLength = LocationMinLength)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets hotel's price.
        /// </summary>
        [Required]
        public string PriceRange { get; set; }

        /// <summary>
        /// Gets or sets hotel's details.
        /// </summary>
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets hotel's rating.
        /// </summary>
        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

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
        /// Gets or sets hotel's phone contact number.
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets hotel's website url.
        /// </summary>
        [Required]
        [StringLength(WebsiteMaxLength, MinimumLength = WebsiteMinLength)]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets hotel's contact email address.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the owner of the hotel.
        /// </summary>
        public virtual ApplicationUser Owner { get; set; }

        public string WorkingHoursText { get; set; }

        public string WorkingHoursRegistrationTime { get; set; }

        public string WorkingHoursLeaveTime { get; set; }

        /// <summary>
        /// Gets or sets a collection of the hotel's reviews.
        /// </summary>
        [Required]
        public virtual ICollection<RestaurantReviewViewModel> Reviews { get; set; } = new HashSet<RestaurantReviewViewModel>();

        /// <summary>
        /// Gets or sets a collection of the hotel's images.
        /// </summary>
        [Required]
        public virtual ICollection<RestaurantImageViewModel> Images { get; set; } = new HashSet<RestaurantImageViewModel>();
    }
}

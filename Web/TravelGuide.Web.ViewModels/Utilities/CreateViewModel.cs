namespace TravelGuide.Web.ViewModels.Utilities
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using static TravelGuide.Common.GlobalConstants.HotelAndRestaurantsSharedConstants;
    using static TravelGuide.Common.GlobalConstants.WorkingHoursConstants;

    public class CreateViewModel
    {
        /// <summary>
        /// Gets or sets facility's name.
        /// </summary>
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets facility's rating.
        /// </summary>
        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public double Rating { get; set; }

        /// <summary>
        /// Gets or sets facility's location.
        /// </summary>
        [Required]
        [StringLength(LocationMaxLength, MinimumLength = LocationMinLength)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets facility's phone contact number.
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets facility's country.
        /// </summary>
        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        [Display(Name = "Country")]
        public string AddressCountry { get; set; }

        /// <summary>
        /// Gets or sets facility's town name.
        /// </summary>
        [Required]
        [StringLength(TownMaxLength, MinimumLength = TownMinLength)]
        [Display(Name = "Town")]
        public string AddressTownName { get; set; }

        /// <summary>
        /// Gets or sets facility's address.
        /// </summary>
        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Display(Name = "Address")]
        public string AddressAddressText { get; set; }

        /// <summary>
        /// Gets or sets facility's website url.
        /// </summary>
        [Required]
        [StringLength(WebsiteMaxLength, MinimumLength = WebsiteMinLength)]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets facility's contact email address.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a collection of the facility's images.
        /// </summary>
        [Required]
        public virtual IFormFileCollection Images { get; set; }
    }
}

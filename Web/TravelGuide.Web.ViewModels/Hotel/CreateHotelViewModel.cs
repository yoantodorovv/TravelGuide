namespace TravelGuide.Web.ViewModels.Hotel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Utilities;

    using static TravelGuide.Common.GlobalConstants.AmenityConstants;
    using static TravelGuide.Common.GlobalConstants.HotelConstants;

    public class CreateHotelViewModel : CreateViewModel, IMapTo<Hotel>
    {
        /// <summary>
        /// Gets or sets hotel's price.
        /// </summary>
        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Price for 1 room")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets hotel's details.
        /// </summary>
        [Required]
        [StringLength(DetailsMaxLength, MinimumLength = DetailsMinLength)]
        public string Details { get; set; }

        // TODO: Make Amenity Title with chips.

        /// <summary>
        /// Gets or sets amenity title property.
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength)]
        [Display(Name = "Amenities")]
        public string AmenitiesUtil { get; set; }
    }
}

namespace TravelGuide.Web.ViewModels.Amenity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    using static TravelGuide.Common.GlobalConstants.AmenityConstants;

    public class AmenityViewModel : IMapFrom<AmenityHotel>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets amenity title property.
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength)]
        public string AmenityTitle { get; set; }
    }
}

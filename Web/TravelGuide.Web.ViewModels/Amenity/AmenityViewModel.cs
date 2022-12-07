namespace TravelGuide.Web.ViewModels.Amenity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static TravelGuide.Common.GlobalConstants.AmenityConstants;

    public class AmenityViewModel
    {
        /// <summary>
        /// Gets or sets amenity title property.
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }
    }
}

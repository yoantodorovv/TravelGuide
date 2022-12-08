namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.AmenityConstants;

    /// <summary>
    /// Amenity entity class.
    /// </summary>
    public class Amenity : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets amenity title property.
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets hotels collection property.
        /// </summary>
        public virtual ICollection<AmenityHotels> Hotels { get; set; } = new HashSet<AmenityHotels>();
    }
}

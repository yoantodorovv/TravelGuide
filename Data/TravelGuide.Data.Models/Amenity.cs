namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.AmenityConstants;

    public class Amenity : BaseDeletableModel<Guid>
    {
        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; } = new HashSet<Hotel>();
    }
}

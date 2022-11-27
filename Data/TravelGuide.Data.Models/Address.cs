namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.AddressConstants;

    public class Address : BaseDeletableModel<Guid>
    {
        [Required]
        [StringLength(AddressMaxLength)]
        public string AddressText { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [ForeignKey(nameof(Town))]
        public Guid TownId { get; set; }

        [Required]
        public Town Town { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; } = new HashSet<Hotel>();

        public virtual ICollection<Restaurant> Restaurants { get; set; } = new HashSet<Restaurant>();
    }
}

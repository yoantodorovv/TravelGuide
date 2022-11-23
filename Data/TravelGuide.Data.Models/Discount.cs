namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.DiscountConstants;

    public class Discount : BaseDeletableModel<Guid>
    {
        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }

        // TODO: Reform 'range' attribute
        [Required]
        [Range(typeof(decimal), DiscountPercentageMinValue, DiscountPercentageMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountPercentage { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();
    }
}

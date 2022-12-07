namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.DiscountConstants;

    /// <summary>
    /// Discount entity class.
    /// </summary>
    public class Discount : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets discount's title.
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets discount's percentage.
        /// </summary>
        [Required]
        [Range(typeof(decimal), DiscountPercentageMinValue, DiscountPercentageMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets a collection of users that have discounts.
        /// </summary>
        public virtual ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();
    }
}

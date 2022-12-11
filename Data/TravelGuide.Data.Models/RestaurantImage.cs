namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    /// <summary>
    /// Restaurant Image class entity.
    /// </summary>
    public class RestaurantImage : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets image's cloudinary url.
        /// </summary>
        [Url]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets image's restaurant id.
        /// </summary>
        [ForeignKey(nameof(Restaurant))]
        public Guid RestaurantId { get; set; }

        /// <summary>
        /// Gets or sets image's restaurant.
        /// </summary>
        public virtual Restaurant Restaurant { get; set; }
    }
}

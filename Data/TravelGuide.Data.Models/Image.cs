namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    /// <summary>
    /// Image entity class.
    /// </summary>
    public class Image : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets image's extension.
        /// </summary>
        [Required]
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets image's remote url (if the image is not on the server).
        /// </summary>
        [Url]
        public string RemoteImageUrl { get; set; }

        /// <summary>
        /// Gets or sets image's author id.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Gets or sets image's author.
        /// </summary>
        [Required]
        public virtual ApplicationUser Author { get; set; }

        /// <summary>
        /// Gets or sets image's hotel id.
        /// </summary>
        [ForeignKey(nameof(Hotel))]
        public Guid? HotelId { get; set; }

        /// <summary>
        /// Gets or sets image's hotel.
        /// </summary>
        public virtual Hotel Hotel { get; set; }

        /// <summary>
        /// Gets or sets image's restaurant id.
        /// </summary>
        [ForeignKey(nameof(Restaurant))]
        public Guid? RestaurantId { get; set; }

        /// <summary>
        /// Gets or sets image's restaurant.
        /// </summary>
        public virtual Restaurant Restaurant { get; set; }
    }
}

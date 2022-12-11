namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    /// <summary>
    /// Hotel Image entity class.
    /// </summary>
    public class HotelImage : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets image's cloudinary url.
        /// </summary>
        [Url]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets image's hotel id.
        /// </summary>
        [ForeignKey(nameof(Hotel))]
        public Guid? HotelId { get; set; }

        /// <summary>
        /// Gets or sets image's hotel.
        /// </summary>
        public virtual Hotel Hotel { get; set; }
    }
}

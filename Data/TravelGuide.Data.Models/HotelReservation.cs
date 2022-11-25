namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.HotelReservationConstants;

    /// <summary>
    /// Hotel reservation entity class.
    /// </summary>
    public class HotelReservation : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets the price for the reservation.
        /// </summary>
        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the user's id -> that has made the reservation.
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user that has made the reservation.
        /// </summary>
        [Required]
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the hotel's id -> which holds the reservation.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Hotel))]
        public Guid HotelId { get; set; }

        /// <summary>
        /// Gets or sets the hotel which holds the reservation.
        /// </summary>
        [Required]
        public virtual Hotel Hotel { get; set; }

        /// <summary>
        /// Gets or sets the user's discount id (if he has one).
        /// </summary>
        [ForeignKey(nameof(Discount))]
        public Guid? DicountId { get; set; }

        /// <summary>
        /// Gets or sets the user's discount (if he has one).
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// Gets or sets the start day of the reservation.
        /// </summary>
        [Required]
        public DateTime StartDay { get; set; }

        /// <summary>
        /// Gets or sets the last day of the reservation.
        /// </summary>
        [Required]
        public DateTime EndDay { get; set; }
    }
}

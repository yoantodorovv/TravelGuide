namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    /// <summary>
    /// Restaurant reservation entity class.
    /// </summary>
    public class RestaurantReservation : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets the user's id -> that makes the reservation.
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user that makes the reservation.
        /// </summary>
        [Required]
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the restaurant's id -> that holds the reservation.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Restaurant))]
        public Guid RestaurantId { get; set; }

        /// <summary>
        /// Gets or sets the restaurant that holds the reservation.
        /// </summary>
        [Required]
        public virtual Restaurant Restaurant { get; set; }

        /// <summary>
        /// Gets or sets the reservation's date and time.
        /// </summary>
        [Required]
        public DateTime ReservationDate { get; set; }

        /// <summary>
        /// Gets or sets the reservation's discount id (if the user has one).
        /// </summary>
        [ForeignKey(nameof(Discount))]
        public Guid? DiscountId { get; set; }

        /// <summary>
        /// Gets or sets the reservation's discount (if the user has one).
        /// </summary>
        public virtual Discount Discount { get; set; }
    }
}

namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    public class RestaurantReservation : BaseDeletableModel<Guid>
    {
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Restaurant))]
        public Guid RestaurantId { get; set; }

        [Required]
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [ForeignKey(nameof(Discount))]
        public Guid? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }
    }
}

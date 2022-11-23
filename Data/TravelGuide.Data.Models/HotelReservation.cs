namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.HotelReservationConstants;

    public class HotelReservation : BaseDeletableModel<Guid>
    {
        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Hotel))]
        public Guid HotelId { get; set; }

        [Required]
        public virtual Hotel Hotel { get; set; }

        [ForeignKey(nameof(Discount))]
        public Guid? DicountId { get; set; }

        public virtual Discount Discount { get; set; }

        [Required]
        public DateTime StartDay { get; set; }

        [Required]
        public DateTime EndDay { get; set; }
    }
}

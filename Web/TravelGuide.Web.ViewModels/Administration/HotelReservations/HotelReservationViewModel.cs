namespace TravelGuide.Web.ViewModels.Administration.HotelReservations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    using static TravelGuide.Common.GlobalConstants.HotelReservationConstants;

    public class HotelReservationViewModel : IMapFrom<HotelReservation>
    {
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the price for the reservation.
        /// </summary>
        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the user that has made the reservation.
        /// </summary>
        [Required]
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the hotel which holds the reservation.
        /// </summary>
        [Required]
        public virtual Hotel Hotel { get; set; }

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

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

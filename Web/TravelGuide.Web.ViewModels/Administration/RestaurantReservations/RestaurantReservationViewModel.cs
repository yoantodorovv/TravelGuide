namespace TravelGuide.Web.ViewModels.Administration.RestaurantReservations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    public class RestaurantReservationViewModel : IMapFrom<RestaurantReservation>
    {
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the user that has made the reservation.
        /// </summary>
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Gets or sets the hotel which holds the reservation.
        /// </summary>
        public virtual Restaurant Restaurant { get; set; }

        /// <summary>
        /// Gets or sets the user's discount (if he has one).
        /// </summary>
        public virtual Discount Discount { get; set; }

        /// <summary>
        /// Gets or sets the reservation's date and time.
        /// </summary>
        [Required]
        public DateTime ReservationDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

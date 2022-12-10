namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RestaurantWorkingHours
    {
        [ForeignKey(nameof(Restaurant))]
        public Guid RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        [ForeignKey(nameof(WorkingHours))]
        public Guid WorkingHoursId { get; set; }

        public virtual WorkingHours WorkingHours { get; set; }
    }
}

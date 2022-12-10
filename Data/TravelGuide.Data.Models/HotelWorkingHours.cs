namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HotelWorkingHours
    {
        [ForeignKey(nameof(Hotel))]
        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        [ForeignKey(nameof(WorkingHours))]
        public Guid WorkingHoursId { get; set; }

        public virtual WorkingHours WorkingHours { get; set; }
    }
}

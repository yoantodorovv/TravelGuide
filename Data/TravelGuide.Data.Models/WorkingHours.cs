namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.WorkingHoursConstants;

    /// <summary>
    /// Working hours entity class.
    /// </summary>
    public class WorkingHours : BaseDeletableModel<Guid>
    {
        /// <summary>
        /// Gets or sets the day of the week.
        /// </summary>
        [Required]
        [StringLength(WeekDayMaxLength)]
        public string WeekDay { get; set; }

        // TODO: Migration

        /// <summary>
        /// Gets or sets the registration time.
        /// </summary>
        [Required]
        public int RegistrationTime { get; set; }

        /// <summary>
        /// Gets or sets the leaving time.
        /// </summary>
        [Required]
        public int LeaveTime { get; set; }

        /// <summary>
        /// Gets or sets a collection of hotels.
        /// </summary>
        public virtual ICollection<Hotel> Hotels { get; set; } = new HashSet<Hotel>();

        /// <summary>
        /// Gets or sets a collection of restaurants.
        /// </summary>
        public virtual ICollection<Restaurant> Restaurants { get; set; } = new HashSet<Restaurant>();
    }
}

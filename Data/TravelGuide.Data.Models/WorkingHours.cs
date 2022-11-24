﻿namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.WorkingHoursConstants;

    public class WorkingHours : BaseDeletableModel<Guid>
    {
        [Required]
        [StringLength(WeekDayMaxLength)]
        public string WeekDay { get; set; }

        [Required]
        public int OpenTime { get; set; }

        [Required]
        public int CloseTime { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; } = new HashSet<Hotel>();

        public virtual ICollection<Restaurant> Restaurants { get; set; } = new HashSet<Restaurant>();
    }
}
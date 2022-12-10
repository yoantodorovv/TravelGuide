namespace TravelGuide.Web.ViewModels.WorkingHours
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static TravelGuide.Common.GlobalConstants.WorkingHoursConstants;

    public class WorkingHoursViewModel
    {
        /// <summary>
        /// Gets or sets the opening time.
        /// </summary>
        [Required]
        [Display(Name = "Registration Time")]
        [RegularExpression(TimeRegex)]
        public string WorkingHoursRegistrationTime { get; set; }

        /// <summary>
        /// Gets or sets the closing time.
        /// </summary>
        [Required]
        [Display(Name = "Leave Time")]
        [RegularExpression(TimeRegex)]
        public string WorkingHoursLeaveTime { get; set; }

        /// <summary>
        /// Gets or sets the day of the week.
        /// </summary>
        [StringLength(TextMaxLength)]
        public string WorkingHoursWeekDay { get; set; }
    }
}

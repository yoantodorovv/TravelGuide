namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.TownConstants;

    public class Town : BaseDeletableModel<Guid>
    {
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }
    }
}

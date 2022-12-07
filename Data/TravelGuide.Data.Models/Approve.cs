namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Common.Models;

    public class Approve : BaseDeletableModel<Guid>
    {
        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public bool IsApproved { get; set; } = false;
    }
}

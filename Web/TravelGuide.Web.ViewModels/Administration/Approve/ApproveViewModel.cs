namespace TravelGuide.Web.ViewModels.Administration.Approve
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    public class ApproveViewModel : IMapFrom<Approve>
    {
        public Guid Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

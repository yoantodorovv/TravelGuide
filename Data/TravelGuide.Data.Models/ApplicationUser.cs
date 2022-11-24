// ReSharper disable VirtualMemberCallInConstructor
namespace TravelGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    using TravelGuide.Data.Common.Models;

    using static TravelGuide.Common.GlobalConstants.UserConstants;

    public class ApplicationUser : IdentityUser<Guid>, IAuditInfo, IDeletableEntity
    {
        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; } = new HashSet<Discount>();

        public virtual ICollection<IdentityUserRole<Guid>> Roles { get; set; } = new HashSet<IdentityUserRole<Guid>>();

        public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; } = new HashSet<IdentityUserClaim<Guid>>();

        public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; } = new HashSet<IdentityUserLogin<Guid>>();


    }
}

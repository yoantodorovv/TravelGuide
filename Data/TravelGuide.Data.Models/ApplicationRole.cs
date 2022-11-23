// ReSharper disable VirtualMemberCallInConstructor
namespace TravelGuide.Data.Models
{
    using System;

    using Microsoft.AspNetCore.Identity;
    using TravelGuide.Data.Common.Models;

    public class ApplicationRole : IdentityRole<Guid>, IAuditInfo, IDeletableEntity
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

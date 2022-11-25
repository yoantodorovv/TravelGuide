// ReSharper disable VirtualMemberCallInConstructor
namespace TravelGuide.Data.Models
{
    using System;

    using Microsoft.AspNetCore.Identity;
    using TravelGuide.Data.Common.Models;

    /// <summary>
    /// ApplicationRole entity class (Extension of IdentityRole class).
    /// </summary>
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

        /// <summary>
        /// Gets or sets the time of creation.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the last time of modification.
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets whether the entity is deleted or not.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the time of the entity's deletion.
        /// </summary>
        public DateTime? DeletedOn { get; set; }
    }
}

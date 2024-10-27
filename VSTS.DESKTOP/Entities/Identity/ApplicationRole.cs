using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Identity
{
    public class ApplicationRole : IAudited
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [MaxLength(255)]
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string? ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ApplicationRole()
        {
            Users = new HashSet<ApplicationUserRole>();
            Claims = new HashSet<ApplicationRoleClaim>();
            NavigationRoles = new HashSet<NavigationRole>();
        }
        public ApplicationRole(string name, string? description = null)
        {
            Description = description;
            Name = name;

            Users = new HashSet<ApplicationUserRole>();
            Claims = new HashSet<ApplicationRoleClaim>();
            NavigationRoles = new HashSet<NavigationRole>();
        }

        public virtual ICollection<ApplicationUserRole> Users { get; set; }
        public virtual ICollection<ApplicationRoleClaim> Claims { get; set; }
        public virtual ICollection<NavigationRole>? NavigationRoles { get; set; }
    }
}

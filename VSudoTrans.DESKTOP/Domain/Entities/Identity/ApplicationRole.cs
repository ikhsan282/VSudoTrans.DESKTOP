using Domain.Entities.Organization;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Identity
{
    public class ApplicationRole
    {
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string NormalizedName { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ApplicationRole()
        {
            Users = new HashSet<ApplicationUserRole>();
            Claims = new HashSet<ApplicationRoleClaim>();
            NavigationRoles = new HashSet<NavigationRole>();
        }

        public ApplicationRole(string name, string description = null)
        {
            Description = description;
            Name = name;

            Users = new HashSet<ApplicationUserRole>();
            Claims = new HashSet<ApplicationRoleClaim>();
            NavigationRoles = new HashSet<NavigationRole>();
        }

        public virtual ICollection<ApplicationUserRole> Users { get; set; }
        public virtual ICollection<ApplicationRoleClaim> Claims { get; set; }
        public virtual ICollection<NavigationRole> NavigationRoles { get; set; }
    }
}

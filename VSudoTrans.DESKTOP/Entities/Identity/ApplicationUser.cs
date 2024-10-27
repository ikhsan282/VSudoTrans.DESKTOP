using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Identity
{
    public class ApplicationUser : IAudited
    {
        public Guid Id { get; set; }
        [MaxLength(125)]
        public string? FirstName { get; set; }
        [MaxLength(125)]
        public string? LastName { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public bool IsAzureUser { get; set; } = true;
        public bool? IsActive { get; set; } = true;
        [MaxLength(255)]
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string? ModifiedUser { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public ApplicationUser()
        {
            Companys = new HashSet<ApplicationUserCompany>();
            Roles = new HashSet<ApplicationUserRole>();
            Tokens = new HashSet<ApplicationUserToken>();
            Logins = new HashSet<ApplicationUserLogin>();
            Claims = new HashSet<ApplicationUserClaim>();
            Infos = new HashSet<ApplicationUserInfo>();
        }
        public virtual ICollection<ApplicationUserCompany> Companys { get; set; }
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> Roles { get; set; }
        public virtual ICollection<ApplicationUserInfo> Infos { get; set; }

    }

}

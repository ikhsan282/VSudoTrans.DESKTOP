using Domain.Base;
using Domain.Entities.EducationResource;
using Domain.Entities.HumanResource;
using Domain.Entities.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Identity
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        [MaxLength(125)]
        public string FirstName { get; set; }
        [MaxLength(125)]
        public string LastName { get; set; }
        public EnumUserType UserType { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsActive { get; set; } = true;
        [MaxLength(255)]
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public ApplicationUser()
        {
            Companys = new HashSet<ApplicationUserCompany>();
            Roles = new HashSet<ApplicationUserRole>();
        }
        public virtual ICollection<ApplicationUserCompany> Companys { get; set; }
        public virtual ICollection<ApplicationUserRole> Roles { get; set; }

    }

}

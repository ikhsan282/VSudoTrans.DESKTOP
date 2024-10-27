
using System.ComponentModel.DataAnnotations;
using System;

namespace Domain.Entities.Identity
{
    public class ApplicationRoleClaim
    {
        public int Id { get; set; }
        public int ControllerMethodId { get; set; }
        public virtual ApplicationControllerMethod ControllerMethod { get; set; }
        public Guid RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public virtual ApplicationRole Role { get; set; }
        [MaxLength(255)]
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}

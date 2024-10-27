using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations;
using System;

namespace Domain.Entities.Identity
{
    public class ApplicationUserCompany : BaseIdInt
    {
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [MaxLength(255)]
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

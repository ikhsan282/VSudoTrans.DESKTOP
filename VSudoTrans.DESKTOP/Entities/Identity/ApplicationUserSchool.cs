using Domain.Base;
using Domain.Entities.Organization;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Identity
{
    public class ApplicationUserSchool : BaseIdInt, IAudited
    {
        public Guid UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public int SchoolId { get; set; }
        public virtual School? School { get; set; }
        [MaxLength(255)]
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string? ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

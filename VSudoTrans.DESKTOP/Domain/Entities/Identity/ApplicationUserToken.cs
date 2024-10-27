using Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Identity
{
    public class ApplicationUserToken
    {
        public Guid Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        [MaxLength(255)]
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

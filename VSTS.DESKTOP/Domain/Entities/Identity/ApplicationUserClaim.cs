using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Identity
{
    public class ApplicationUserClaim
    {
        public Guid Id { get; set; }
        public int ControllerMethodId { get; set; }
        public virtual ApplicationControllerMethod ControllerMethod { get; set; }
        public virtual ApplicationUser User { get; set; }
        [MaxLength(255)]
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}

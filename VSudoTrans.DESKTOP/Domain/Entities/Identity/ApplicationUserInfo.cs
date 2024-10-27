using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Domain.Entities.Identity
{
    [Table("ApplicationUserInfo")]
    [DisplayName("Info Login")]
    public class ApplicationUserInfo : BaseIdInt
    {
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [MaxLength(50)]
        public string IpAddress { get; set; } 
        public DateTime LoginDate { get; set; } 
        [MaxLength(50)]
        public string AppName { get; set; } 
        [MaxLength(20)]
        public string AppVersion { get; set; } 
        [MaxLength(50)]
        public string DeviceName { get; set; } 
        [MaxLength(255)]
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        [MaxLength(255)]
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

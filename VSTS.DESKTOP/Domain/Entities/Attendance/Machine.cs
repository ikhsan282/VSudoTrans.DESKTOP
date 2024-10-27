using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.Attendance
{
    [Table("Machine")]
    [DisplayName("Mesin Kehadiran")]
    public class Machine : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [MaxLength(20)]
        public string IpAddress { get; set; } 
    }
}

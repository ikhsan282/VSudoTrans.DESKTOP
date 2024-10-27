using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.Attendance
{
    [Table("AttendanceSettingRange")]
    [DisplayName("Pengaturan Jangkauan Absensi")]
    public class AttendanceSettingRange : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public int BeforeIn { get; set; }
        public int AfterIn { get; set; }
        public int BeforeOut { get; set; }
        public int AfterOut { get; set; }
    }
}

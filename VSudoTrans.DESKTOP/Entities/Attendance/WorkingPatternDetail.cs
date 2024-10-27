using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.Attendance
{
    [Table("WorkingPatternDetail")]
    [DisplayName("Detail Pola Kerja")]
    public class WorkingPatternDetail : BaseDomainDetail
    {
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public int CycleNo { get; set; }

        public int WorkingPatternId { get; set; }
        [ForeignKey("WorkingPatternId")]
        public virtual WorkingPattern? WorkingPattern { get; set; }
        public int ShiftId { get; set; }
        [ForeignKey("ShiftId")]
        public virtual Shift? Shift { get; set; }
    }
}

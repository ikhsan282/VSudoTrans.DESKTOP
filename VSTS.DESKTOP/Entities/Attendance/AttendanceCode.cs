using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.Attendance
{
    [Table("AttendanceCode")]
    [DisplayName("Kode Kehadiran")]
    public class AttendanceCode : BaseCodeName
    {
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public EnumAbsenceType GroupType { get; set; } // Untuk Grouping
        public EnumAbsenceAssignmentType AssignmentType { get; set; } // Untuk fungsi
        public EnumGender Gender { get; set; }
        public int MaxLeave { get; set; }
        public decimal? DurationDay { get; set; } // HK 1.0 atau 0.5, atau 0.75
    }
}

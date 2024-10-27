using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.HumanResource;
using Domain.Entities.Organization;
using System;

namespace Domain.Entities.Attendance
{
    [Table("Roster")]
    [DisplayName("Daftar Kehadiran")]
    public class Roster : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int OrganizationStructureId { get; set; }
        public virtual OrganizationStructure OrganizationStructure { get; set; }
        public int JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public int JobPositionId { get; set; }
        public virtual JobPosition JobPosition { get; set; }
        public int JobGradeId { get; set; }
        public virtual JobGrade JobGrade { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }

        public EnumDayType DayType { get; set; }  // Tipe Hari
        public DateTime Date { get; set; }  // Tanggal Roster
        public int IDate { get; set; }

        public DateTime? SStartTime { get; set; } // Schedule In Tanggal Roster 08:00
        public long? ISStartTime { get; set; }
        
        public DateTime? AStartTime { get; set; } // Actual In Tanggal Roster 07:52
        public long? IAStartTime { get; set; }

        public DateTime? SEndTime { get; set; } // Schedule Out Tanggal Roster 17:00
        public long? ISEndTime { get; set; }

        public DateTime? AEndTime { get; set; } // Actual Out Tanggal Roster 17:26
        public long? IAEndTime { get; set; }

        public DateTime? SBreakStartTime { get; set; } // Schedule Break Out 12:00
        public long? ISBreakStartTime { get; set; }

        public DateTime? SBreakEndTime { get; set; } // Schedule Break In 13:00
        public long? ISBreakEndTime { get; set; }

        public int? WeekNum { get; set; } // Week Number
        public int? AttendanceCodeId { get; set; }
        [ForeignKey("AttendanceCodeId")]
        public virtual AttendanceCode AttendanceCode { get; set; } // Untuk attendance atau mangkir
        public int? PermitCodeId { get; set; }
        [ForeignKey("PermitCodeId")]
        public virtual AttendanceCode PermitCode { get; set; } // Untuk permit code atau Leave Code

        public decimal? SDurationDay { get; set; } // Schedule Duration Day, 1 atau 0.5
        public decimal? ADurationDay { get; set; } // Actual Duration Day, 1 atau 0.5

        public TimeSpan? SDurationHour { get; set; } // Schedule Hours
        public TimeSpan? ADurationHour { get; set; } // Productive Hours
        public TimeSpan? BreakDurationHour { get; set; } // Break Hours
    }
}

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
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift? Shift { get; set; }

        public EnumDayType DayType { get; set; } = default!; // Tipe Hari
        public DateTime Date { get; set; } = default!; // Tanggal Roster
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
        public virtual AttendanceCode? AttendanceCode { get; set; } // Untuk attendance atau mangkir
        public int? PermitCodeId { get; set; }
        [ForeignKey("PermitCodeId")]
        public virtual AttendanceCode? PermitCode { get; set; } // Untuk permit code atau Leave Code

        public decimal? SDurationDay { get; set; } // Schedule Duration Day, 1 atau 0.5
        public decimal? ADurationDay { get; set; } // Actual Duration Day, 1 atau 0.5

        public TimeSpan? SDurationHour { get; set; } // Schedule Hours
        public TimeSpan? ADurationHour { get; set; } // Productive Hours
        public TimeSpan? BreakDurationHour { get; set; } // Break Hours
    }
}

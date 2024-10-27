using Contract.Base;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.Attendance
{
    public class RosterDto : EntityDto
    {
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }

        public EnumDayType DayType { get; set; } // Tipe Hari
        public DateTime Date { get; set; } // Tanggal Roster
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

        public int? AttendanceCodeId { get; set; }
        public int? PermitCodeId { get; set; }

        public decimal? SDurationDay { get; set; } // Schedule Duration Day, 1 atau 0.5
        public decimal? ADurationDay { get; set; } // Actual Duration Day, 1 atau 0.5

        public TimeSpan? SDurationHour { get; set; } // Schedule Hours
        public TimeSpan? ADurationHour { get; set; } // Productive Hours
        public TimeSpan? BreakDurationHour { get; set; } // Break Hours
    }

    public class RosterGenerateDto
    {
        public int CompanyId { get; set; }
        public DateTime StartDate { get; set; } // Tanggal mulai membuat roster
        public DateTime EndDate { get; set; } // Tanggal akhir membuat roster
        public int? WorkingPatternId { get; set; }
        public int? WorkingPatternDetailId { get; set; } // Untuk mendapatkan cycle no
        public int? ShiftId { get; set; }
        public List<int> EmployeeIds { get; set; }
    }
}

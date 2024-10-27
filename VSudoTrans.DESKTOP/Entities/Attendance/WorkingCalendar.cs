using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Domain.Entities.Attendance
{
    [Table("WorkingCalendar")]
    [DisplayName("Kalendar Kerja")]
    public class WorkingCalendar : BaseDomainDetail
    {
        public DateTime Date { get; set; }
        public EnumDayType DayType { get; set; }
        [MaxLength(2000)]
        public string? Note { get; set; }
    }
}

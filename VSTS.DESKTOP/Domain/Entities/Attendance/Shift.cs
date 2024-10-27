using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System;

namespace Domain.Entities.Attendance
{
    [Table("Shift")]
    [DisplayName("Shift")]
    public class Shift : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public TimeSpan StartWorkHour { get; set; }
        public TimeSpan EndWorkHour { get; set; }
        public TimeSpan StartBreakHour { get; set; }
        public TimeSpan EndBreakHour { get; set; }
        public decimal? TotalWorkHour { get; set; }
        public EnumDayType Type { get; set; }
    }
}

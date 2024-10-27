using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Entities.Organization;
using System;

namespace Domain.Entities.Attendance
{
    [Table("AttendanceHistory")]
    [DisplayName("Attendance History")]
    public class AttendanceHistory : BaseDomainDetail
    {
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public string PIN { get; set; }
        public DateTime Datetime { get; set; }
        public long IDatetime { get; set; }
    }
}

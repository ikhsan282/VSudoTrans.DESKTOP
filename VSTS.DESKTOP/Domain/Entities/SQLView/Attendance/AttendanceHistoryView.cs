using System;

namespace Domain.Entities.SQLView.Attendance
{
    public class AttendanceHistoryView
    {
        public int Id { get; set; }
        public string PIN { get; set; }
        public DateTime Datetime { get; set; }
        public long IDatetime { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

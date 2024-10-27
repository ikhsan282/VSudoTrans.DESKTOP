using System;

namespace Domain.Entities.SQLView.EducationPayment
{
    public class StudentPaymentSummaryView
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int MajorId { get; set; }
        public string MajorCode { get; set; }
        public string MajorName { get; set; }
        public int ForceYearId { get; set; }
        public string ForceYearName { get; set; }
        public string ForceYearIndex { get; set; }
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public decimal PaymentPaid { get; set; }
        public decimal Arrear { get; set; }
        public decimal Bill { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int Index { get; set; }
        public DateTime? ActualDate { get; set; }
    }
}

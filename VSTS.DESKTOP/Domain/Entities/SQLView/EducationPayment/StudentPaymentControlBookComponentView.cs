namespace Domain.Entities.SQLView.EducationPayment
{
    public class StudentPaymentControlBookComponentView
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
        public int EducationComponentId { get; set; }
        public string EducationComponentCode { get; set; }
        public string EducationComponentName { get; set; }
        public decimal Payment1 { get; set; }
        public decimal Payment2 { get; set; }
        public decimal Payment3 { get; set; }
        public decimal Payment4 { get; set; }
        public decimal Payment5 { get; set; }
        public decimal Payment6 { get; set; }
        public decimal Payment7 { get; set; }
        public decimal Payment8 { get; set; }
        public decimal Payment9 { get; set; }
        public decimal Payment10 { get; set; }
        public decimal Payment11 { get; set; }
        public decimal Payment12 { get; set; }
        public decimal PaymentPaid { get; set; }
        public decimal Arrear { get; set; }
        public decimal Bill { get; set; }
    }
}

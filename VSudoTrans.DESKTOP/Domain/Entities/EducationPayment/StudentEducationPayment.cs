using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using Domain.Entities.EducationResource;
using System.Collections.Generic;

namespace Domain.Entities.EducationPayment
{
    [Table("StudentEducationPayment")]
    [DisplayName("Penerimaan Pembayaran Pendidikan Murid")]
    public class StudentEducationPayment : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public EnumPaymentStatus PaymentStatus { get; set; }
        public virtual List<StudentEducationPaymentComponent> StudentEducationPaymentComponents { get; set; }
    }
}

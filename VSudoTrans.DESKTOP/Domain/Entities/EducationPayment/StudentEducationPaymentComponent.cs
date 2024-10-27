using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using Domain.Entities.EducationResource;
using System;
using System.Collections.Generic;

namespace Domain.Entities.EducationPayment
{
    [Table("StudentEducationPaymentComponent")]
    [DisplayName("Komponen Penerimaan Pembayaran Pendidikan Murid")]
    public class StudentEducationPaymentComponent : BaseDomainDetail
    {
        public int StudentEducationPaymentId { get; set; }
        public StudentEducationPayment StudentEducationPayment { get; set; }
        public int EducationComponentId { get; set; }
        public EducationComponent EducationComponent { get; set; }
        public DateTime Date { get; set; }
        public int IDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public EnumPaymentStatus PaymentStatus { get; set; }
        public int Priority { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using System;

namespace Domain.Entities.EducationPayment
{
    [Table("StudentEducationPaymentHistoryDetail")]
    [DisplayName("Riwayat Detail Penerimaan Pembayaran Pendidikan Murid")]
    public class StudentEducationPaymentHistoryDetail : BaseDomainDetailGuid
    {
        public Guid StudentEducationPaymentHistoryId { get; set; }
        public decimal Amount { get; set; }
        public virtual StudentEducationPaymentHistory StudentEducationPaymentHistory { get; set; }
        public int? StudentEducationPaymentId { get; set; }
        public virtual StudentEducationPayment StudentEducationPayment { get; set; }
        public string Note { get; set; }

    }
}

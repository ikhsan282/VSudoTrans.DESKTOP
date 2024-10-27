using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using System;
using System.Collections.Generic;
using Domain.Entities.EducationResource;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.EducationPayment
{
    [Table("StudentEducationPaymentHistory")]
    [DisplayName("Riwayat Penerimaan Pembayaran Pendidikan Murid")]
    public class StudentEducationPaymentHistory : BaseDomainDetailGuid
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string OrderId { get; set; }
        public decimal GrossAmount { get; set; }
        public EnumPaymentMethod PaymentMethod { get; set; }
        public DateTime ActualDate { get; set; }
        public int IActualDate { get; set; }
        public string Attachment { get; set; }
        public virtual List<StudentEducationPaymentHistoryDetail> StudentEducationPaymentHistoryDetails { get; set; }
        [MaxLength(2000)]
        public string NoteArrear { get; set; }

        public Guid? TransactionId { get; set; }
        public string MerchantId { get; set; }
        public string TransactionTime { get; set; }
        public string TransactionStatus { get; set; }
        public string FraudStatus { get; set; }
        public string ExpiryTime { get; set; }

        #region VA Bank
        public string VABank { get; set; }
        public string VANumber { get; set; }
        #endregion

        #region Mandiri Bill
        public string BillKey { get; set; }
        public string BillerCode { get; set; }
        #endregion

        #region QRIS
        public string QRstring { get; set; }
        public string Acquirer { get; set; }
        public string ActionName { get; set; }
        public string ActionMethod { get; set; }
        public string ActionUrl { get; set; }
        #endregion
    }
}

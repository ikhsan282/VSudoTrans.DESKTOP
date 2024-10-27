using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using Domain.Entities.Shared;
using System;
using Domain.Entities.EducationPayment;

namespace Domain.Entities.Finance
{
    [Table("BudgetTransaction")]
    [DisplayName("Transaksi Anggaran")]
    public class BudgetTransaction : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? StudentEducationPaymentComponentId { get; set; }
        public virtual StudentEducationPaymentComponent StudentEducationPaymentComponent { get; set; }
        public int EducationComponentId { get; set; }
        public EducationComponent EducationComponent { get; set; }
        public int UnitMeasureId { get; set; }
        public UnitMeasure UnitMeasure { get; set; }
        public EnumTransactionIndicator Indicator { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string DocumentNumber { get; set; }
        public string Note { get; set; }
    }
}

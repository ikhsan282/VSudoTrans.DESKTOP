using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using Domain.Entities.Shared;
using System;

namespace Domain.Entities.Finance
{
    [Table("BudgetTransaction")]
    [DisplayName("Transaksi Anggaran")]
    public class BudgetTransaction : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UnitMeasureId { get; set; }
        public UnitMeasure UnitMeasure { get; set; }
        public EnumTransactionIndicator Indicator { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Note { get; set; }
    }
}

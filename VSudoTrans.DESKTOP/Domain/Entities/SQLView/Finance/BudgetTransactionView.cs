
using System;

namespace Domain.Entities.SQLView.Finance
{
    public class BudgetTransactionView
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int UnitMeasureId { get; set; }
        public string UnitMeasureCode { get; set; }
        public string UnitMeasureName { get; set; }
        public EnumTransactionIndicator Indicator { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }

}

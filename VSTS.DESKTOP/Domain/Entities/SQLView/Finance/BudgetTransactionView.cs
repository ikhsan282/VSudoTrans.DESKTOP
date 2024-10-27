
using System;

namespace Domain.Entities.SQLView.Finance
{
    public class BudgetTransactionView
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int EducationComponentId { get; set; }
        public string EducationComponentCode { get; set; }
        public string EducationComponentName { get; set; }
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

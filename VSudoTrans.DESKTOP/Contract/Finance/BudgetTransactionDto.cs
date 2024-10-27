using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Contract.Finance
{
    public class BudgetTransactionDto
    {
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int UnitMeasureId { get; set; }
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
    
    public class ImportBudgetTransactionModel
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string UnitMeasureCode { get; set; }
        public string CategoryCode { get; set; }
        public string DocumentNumber { get; set; }
        public string Indicator { get; set; }
        public string Quantity { get; set; }
        public string Amount { get; set; }
        public string TransactionDate { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryBudgetTransactionModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportBudgetTransactionModel> Data { get; set; }
    }

    public class ImportBudgetTransactionExcelModel
    {
        [JsonProperty("Company Code")]
        public string CompanyCode { get; set; }
        [JsonProperty("Unit Measure Code")]
        public string UnitMeasureCode { get; set; }
        [JsonProperty("Education Component Code")]
        public string CategoryCode { get; set; }
        [JsonProperty("Document Number")]
        public string DocumentNumber { get; set; }
        [JsonProperty("Indicator")]
        public string Indicator { get; set; }
        [JsonProperty("Quantity")]
        public string Quantity { get; set; }
        [JsonProperty("Amount")]
        public string Amount { get; set; }
        [JsonProperty("Transaction Date")]
        public string TransactionDate { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

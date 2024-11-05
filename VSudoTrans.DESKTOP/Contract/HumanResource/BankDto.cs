using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Contract.HumanResource
{
    public class BankDto : EntityDto
    {
        public int? CompanyId { get; set; }
    }

    public class ImportBankModel
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryBankModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportBankModel> Data { get; set; }
    }

    public class ImportBankExcelModel
    {
        [JsonProperty("Company Code")]
        public string CompanyCode { get; set; }
        [JsonProperty("Bank Code")]
        public string Code { get; set; }
        [JsonProperty("Bank Name")]
        public string Name { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Contract.HumanResource
{
    public class JobGradeDto : EntityDto
    {
        public decimal FromAmount { get; set; }
        public decimal MidAmount { get; set; }
        public decimal ToAmount { get; set; }
        public int? CompanyId { get; set; }
    }

    public class ImportJobGradeModel
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FromAmount { get; set; }
        public string ToAmount { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryJobGradeModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportJobGradeModel> Data { get; set; }
    }

    public class ImportJobGradeExcelModel
    {
        [JsonProperty("Company Code")]
        public string CompanyCode { get; set; }
        [JsonProperty("Job Grade Code")]
        public string Code { get; set; }
        [JsonProperty("Job Grade Name")]
        public string Name { get; set; }
        [JsonProperty("From Amount")]
        public string FromAmount { get; set; }
        [JsonProperty("To Amount")]
        public string ToAmount { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

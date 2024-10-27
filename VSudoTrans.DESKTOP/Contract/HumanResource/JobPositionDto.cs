using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Contract.HumanResource
{
    public class JobPositionDto : EntityDto
    {
        public int? ParentId { get; set; }
        public int Level { get; set; }
        public int JobTitleId { get; set; }
        public int? CompanyId { get; set; }
    }

    public class ImportJobPositionModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string ParentCode { get; set; }
        public string JobTitleCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryJobPositionModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportJobPositionModel> Data { get; set; }
    }

    public class ImportJobPositionExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Parent Job Position Code")]
        public string ParentCode { get; set; }
        [JsonProperty("Job Title Code")]
        public string JobTitleCode { get; set; }
        [JsonProperty("Job Position Code")]
        public string Code { get; set; }
        [JsonProperty("Job Position Name")]
        public string Name { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Contract.HumanResource
{
    public class JobTitleDto : EntityDto
    {
        public int Level { get; set; }
        public int? CompanyId { get; set; }
    }

    public class ImportJobTitleModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryJobTitleModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportJobTitleModel> Data { get; set; }
    }

    public class ImportJobTitleExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Job Title Code")]
        public string Code { get; set; }
        [JsonProperty("Job Title Name")]
        public string Name { get; set; }
        [JsonProperty("Level")]
        public string Level { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

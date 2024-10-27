using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Contract.Organization
{
    public class ImportGroupModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryGroupModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportGroupModel> Data { get; set; }
    }

    public class ImportGroupExcelModel
    {
        [JsonProperty("Foundation Code")]
        public string Code { get; set; }
        [JsonProperty("Foundation Name")]
        public string Name { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

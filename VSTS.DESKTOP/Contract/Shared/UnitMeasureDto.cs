using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Contract.Shared
{
    public class ImportUnitMeasureModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Format { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryUnitMeasureModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportUnitMeasureModel> Data { get; set; }
    }

    public class ImportUnitMeasureExcelModel
    {
        [JsonProperty("Satuan Ukuran Kode")]
        public string Code { get; set; }
        [JsonProperty("Satuan Ukuran Nama")]
        public string Name { get; set; }
        [JsonProperty("Satuan Ukuran Format")]
        public string Format { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.EducationResource
{
    public class RombelDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string Name { get; set; }
    }

    public class ImportRombelModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryRombelModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportRombelModel> Data { get; set; }
    }

    public class ImportRombelExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Rombel Name")]
        public string Name { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

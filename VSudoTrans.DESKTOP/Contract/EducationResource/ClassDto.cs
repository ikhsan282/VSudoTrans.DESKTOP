using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.EducationResource
{
    public class ClassDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string Name { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public EnumClass Index { get; set; }
    }

    public class ImportClassModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string Name { get; set; }
        public string Index { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryClassModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportClassModel> Data { get; set; }
    }

    public class ImportClassExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Class Name")]
        public string Name { get; set; }
        [JsonProperty("Class")]
        public string Index { get; set; }
    }
}

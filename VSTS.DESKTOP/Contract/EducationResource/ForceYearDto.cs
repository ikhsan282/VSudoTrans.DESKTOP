using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.EducationResource
{
    public class ForceYearDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string Name { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int FromYear { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int ToYear { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int MajorId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string Index { get; set; }
    }

    public class ImportForceModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string Name { get; set; }
        public string MajorCode { get; set; }
        public string FromYear { get; set; }
        public string ToYear { get; set; }
        public string Rombel { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryForceModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportForceModel> Data { get; set; }
    }

    public class ImportForceExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Force Name")]
        public string Name { get; set; }
        [JsonProperty("From Year")]
        public string FromYear { get; set; }
        [JsonProperty("To Year")]
        public string ToYear { get; set; }
        [JsonProperty("Major Code")]
        public string MajorCode { get; set; }
        [JsonProperty("Rombel")]
        public string Rombel { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

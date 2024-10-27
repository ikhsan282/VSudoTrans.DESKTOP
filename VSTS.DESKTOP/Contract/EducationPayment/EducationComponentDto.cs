using Domain;
using System.ComponentModel.DataAnnotations;
using Contract.Base;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Contract.EducationPayment
{
    public class EducationComponentDto : EntityDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public EnumEducationType EducationType { get; set; }
    }

    public class ImportEducationComponentModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryEducationComponentModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportEducationComponentModel> Data { get; set; }
    }

    public class ImportEducationComponentExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Education Component Code")]
        public string Code { get; set; }
        [JsonProperty("Education Component Name")]
        public string Name { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

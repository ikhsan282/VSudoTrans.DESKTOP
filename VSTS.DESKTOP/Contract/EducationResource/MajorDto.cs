using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.EducationResource
{
    public class MajorDto : EntityDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public EnumTypeEducation TypeEducation { get; set; }
    }

    public class ImportMajorModel
    {
        public int Id { get; set; }
        public string SchoolCode { get; set; }
        public string TypeEducation { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryMajorModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportMajorModel> Data { get; set; }
    }

    public class ImportMajorExcelModel
    {
        [JsonProperty("School Code")]
        public string SchoolCode { get; set; }
        [JsonProperty("Type Education")]
        public string TypeEducation { get; set; }
        [JsonProperty("Major Code")]
        public string Code { get; set; }
        [JsonProperty("Major Name")]
        public string Name { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

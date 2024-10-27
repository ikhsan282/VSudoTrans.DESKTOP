using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.Organization
{
    public class OrganizationStructureDto : EntityDto
    {
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int GroupId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        public int? ParentId { get; set; }
        public int Level { get; set; }
    }

    public class ImportOrganizationStructureModel
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string ParentCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryOrganizationStructureModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportOrganizationStructureModel> Data { get; set; }
    }

    public class ImportOrganizationStructureExcelModel
    {
        [JsonProperty("Company Code")]
        public string CompanyCode { get; set; }
        [JsonProperty("Parent Organization Structure Code")]
        public string ParentCode { get; set; }
        [JsonProperty("Organization Structure Code")]
        public string Code { get; set; }
        [JsonProperty("Organization Structure Name")]
        public string Name { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.Vehicle
{
    public class ModelUnitDto : EntityDto
    {
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int BrandId { get; set; }
    }
    public class ImportModelUnitModel
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string BrandCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryModelUnitModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportModelUnitModel> Data { get; set; }
    }

    public class ImportModelUnitExcelModel
    {
        [JsonProperty("Company Code")]
        public string CompanyCode { get; set; }
        [JsonProperty("Brand Code")]
        public string BrandCode { get; set; }
        [JsonProperty("Model Code")]
        public string Code { get; set; }
        [JsonProperty("Model Name")]
        public string Name { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}
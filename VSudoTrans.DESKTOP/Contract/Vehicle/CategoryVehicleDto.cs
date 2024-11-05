using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.Vehicle
{
    public class CategoryVehicleDto : EntityDto
    {
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
    }
    public class ImportCategoryVehicleModel
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryCategoryVehicleModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportCategoryVehicleModel> Data { get; set; }
    }

    public class ImportCategoryVehicleExcelModel
    {
        [JsonProperty("Company Code")]
        public string CompanyCode { get; set; }
        [JsonProperty("Category Vehicle Code")]
        public string Code { get; set; }
        [JsonProperty("Category Vehicle Name")]
        public string Name { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}
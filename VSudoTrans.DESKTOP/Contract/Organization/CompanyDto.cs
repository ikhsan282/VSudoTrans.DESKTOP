using Contract.Base;
using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.Organization
{
    public class CompanyDto : EntityDto
    {
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int GroupId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string CountryCode { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string Website { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Watermark { get; set; }
        public string WatermarkPaid { get; set; }
        public string WatermarkUnpaid { get; set; }


        public bool IsProduction { get; set; }
        public string Merchant { get; set; }
        public string SandboxServerKey { get; set; }
        public string SandboxClientKey { get; set; }
        public string ProductionServerKey { get; set; }
        public string ProductionClientKey { get; set; }
    }


    public class ImportCompanyModel
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryCompanyModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportCompanyModel> Data { get; set; }
    }

    public class ImportCompanyExcelModel
    {
        [JsonProperty("Group Code")]
        public string GroupCode { get; set; }
        [JsonProperty("School Code")]
        public string Code { get; set; }
        [JsonProperty("School Name")]
        public string Name { get; set; }
        [JsonProperty("Website")]
        public string Website { get; set; }
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("Address")]
        public string Address { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}

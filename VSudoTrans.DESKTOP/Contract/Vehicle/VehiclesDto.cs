using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract.Vehicle
{
    public class VehiclesDto
    {
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int CompanyId { get; set; }
        public int BrandId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        public int ModelUnitId { get; set; }
        public int TypeEngineId { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        [StringLength(50, ErrorMessage = AnnotationHelper.Length + "{1} karakter")]
        public string FrameNumber { get; set; }
        public string MachineNumber { get; set; }
        public int Seat { get; set; }
        public int ProductionYear { get; set; }
        public string VehicleColor { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        [StringLength(10, ErrorMessage = AnnotationHelper.Length + "{1} karakter")]
        public string VehicleNumber { get; set; } = String.Empty;
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        [StringLength(50, ErrorMessage = AnnotationHelper.Length + "{1} karakter")]
        public string BpkbNumber { get; set; }
        public DateTime? TaxDue { get; set; }
        public DateTime? StnkDue { get; set; }
        public DateTime? KirDue { get; set; }
        [Required(ErrorMessage = AnnotationHelper.Invalid)]
        [StringLength(20, ErrorMessage = AnnotationHelper.Length + "{1} karakter")]
        public string Ownership { get; set; } = String.Empty; // Pribadi/Sewa
        public string Note { get; set; }
    }

    public class ImportVehicleModel
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string BrandCode { get; set; }
        public string ModelCode { get; set; }
        public string TypeEngineCode { get; set; }
        public string FrameNumber { get; set; }
        public string MachineNumber { get; set; }
        public string Seat { get; set; }
        public string ProductionYear { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleNumber { get; set; }
        public string Ownership { get; set; }
        public string Note { get; set; }
        public int RowNumber { get; set; }
        public string FailureDescription { get; set; }
        public string StatusImport { get; set; } = EnumStatusImport.Success;
    }

    public class ImportSummaryVehicleModel
    {
        public int Total { get; set; } = 0;
        public int TotalSuccess { get; set; } = 0;
        public int TotalFailed { get; set; } = 0;
        public List<ImportVehicleModel> Data { get; set; }
    }

    public class ImportVehicleExcelModel
    {
        [JsonProperty("Company Code")]
        public string CompanyCode { get; set; }
        [JsonProperty("Brand Code")]
        public string BrandCode { get; set; }
        [JsonProperty("Model Code")]
        public string ModelCode { get; set; }
        [JsonProperty("Type Engine Code")]
        public string TypeEngineCode { get; set; }
        [JsonProperty("Frame Number")]
        public string FrameNumber { get; set; }
        [JsonProperty("Machine Number")]
        public string MachineNumber { get; set; }
        [JsonProperty("Seat")]
        public string Seat { get; set; }
        [JsonProperty("Production Year")]
        public string ProductionYear { get; set; }
        [JsonProperty("Vehicle Color")]
        public string VehicleColor { get; set; }
        [JsonProperty("Vehicle Number")]
        public string VehicleNumber { get; set; }
        [JsonProperty("Ownership")]
        public string Ownership { get; set; }
        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}
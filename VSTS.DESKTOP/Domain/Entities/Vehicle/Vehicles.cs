using Domain.Base;
using Domain.Entities.Organization;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Vehicle
{

    [Table("Vehicle")]
    [DisplayName("Kend/AB/MP")]
    public class Vehicles : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int? BrandId { get; set; }
        public virtual BrandVehicle Brand { get; set; }
        public int? ModelUnitId { get; set; }
        public virtual ModelUnit ModelUnit { get; set; }
        public int? TypeEngineId { get; set; }
        public virtual TypeEngine TypeEngine { get; set; }
        [MaxLength(50)]
        public string FrameNumber { get; set; }
        //[MaxLength(100)]
        //public string Pic { get; set; }
        //[ForeignKey("PicFile")]
        //public int? PicFileId { get; set; }
        //[InverseProperty("PicFile")]
        //public virtual VehicleFile? PicFile { get; set; }
        [MaxLength(10)]
        public string VehicleNumber { get; set; }
        [MaxLength(50)]
        public string BpkbNumber { get; set; }
        //[ForeignKey("BpkbFile")]
        //public int? BpkbFileId { get; set; }
        //[InverseProperty("BpkbFile")]
        //public virtual VehicleFile? BpkbFile { get; set; }
        public DateTime? TaxDue { get; set; }
        //[ForeignKey("TaxFile")]
        //public int? TaxFileId { get; set; }
        //[InverseProperty("TaxFile")]
        //public virtual VehicleFile? TaxFile { get; set; }
        public DateTime? StnkDue { get; set; }
        //[ForeignKey("StnkFile")]
        //public int? StnkFileId { get; set; }
        //[InverseProperty("StnkFile")]
        //public virtual VehicleFile? StnkFile { get; set; }
        public DateTime? KirDue { get; set; }
        //[ForeignKey("KirFile")]
        //public int? KirFileId { get; set; }
        //[InverseProperty("KirFile")]
        //public virtual VehicleFile? KirFile { get; set; }
        //[MaxLength(100)]
        //public string PicLegality { get; set; }
        [MaxLength(20)]
        public string Ownership { get; set; } // Pribadi/Sewa
        [MaxLength(2000)]
        public string Notes { get; set; }
        public string SVersion { get; set; }

    }
}
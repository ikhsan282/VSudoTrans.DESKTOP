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
        public int BrandId { get; set; }
        public virtual BrandVehicle Brand { get; set; }
        public int ModelUnitId { get; set; }
        public virtual ModelUnit ModelUnit { get; set; }
        public int TypeEngineId { get; set; }
        public virtual TypeEngine TypeEngine { get; set; }
        public int CategoryVehicleId { get; set; }
        public virtual CategoryVehicle CategoryVehicle { get; set; }
        public string FrameNumber { get; set; }
        public string MachineNumber { get; set; }
        public int Seat { get; set; }
        public int ProductionYear { get; set; }
        public string VehicleColor { get; set; }
        [MaxLength(10)]
        public string VehicleNumber { get; set; }
        [MaxLength(50)]
        public string BpkbNumber { get; set; }
        public DateTime? TaxDue { get; set; }
        public DateTime? StnkDue { get; set; }
        public DateTime? KirDue { get; set; }
        [MaxLength(20)]
        public string Ownership { get; set; } // Pribadi/Sewa
        [MaxLength(2000)]
        public string Note { get; set; }
        public string SVersion { get; set; }

    }
}
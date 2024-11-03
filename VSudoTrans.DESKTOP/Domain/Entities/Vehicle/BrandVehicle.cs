using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Vehicle
{

    [Table("Brand")]
    [DisplayName("Merk")]
    public class BrandVehicle : BaseCodeName
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
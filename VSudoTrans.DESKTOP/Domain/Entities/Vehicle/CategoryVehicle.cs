using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Entities.Organization;

namespace Domain.Entities.Vehicle
{
    [Table("CategoryVehicle")]
    [DisplayName("Kategori Kendaraan")]
    public class CategoryVehicle : BaseCodeName
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
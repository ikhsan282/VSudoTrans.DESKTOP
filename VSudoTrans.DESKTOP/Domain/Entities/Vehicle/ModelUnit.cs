using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Vehicle
{

    [Table("ModelUnit")]
    [DisplayName("Model Unit")]
    public class ModelUnit : BaseCodeName
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int BrandId { get; set; }
        public virtual BrandVehicle Brand { get; set; }
    }
}
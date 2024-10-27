using Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Vehicle
{

    [Table("ModelUnit")]
    [DisplayName("Model Unit")]
    public class ModelUnit : BaseCodeName
    {
        public int BrandId { get; set; }
        public virtual BrandVehicle Brand { get; set; }
    }
}
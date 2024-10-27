using Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Vehicle
{

    [Table("Brand")]
    [DisplayName("Merk")]
    public class BrandVehicle : BaseCodeName
    {

    }
}
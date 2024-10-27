using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Domain.Entities.Vehicle
{

    [Table("TypeEngine")]
    [DisplayName("Tipe Mesin")]
    public class TypeEngine : BaseCodeName
    {

    }
}
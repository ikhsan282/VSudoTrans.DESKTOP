using Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Demography
{

    [Table("Country")]
    [DisplayName("Negara")]
    public class Country : BaseCodeName
    {

    }
}

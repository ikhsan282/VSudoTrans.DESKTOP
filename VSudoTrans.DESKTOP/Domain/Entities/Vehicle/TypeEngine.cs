using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Entities.Organization;

namespace Domain.Entities.Vehicle
{

    [Table("TypeEngine")]
    [DisplayName("Tipe Mesin")]
    public class TypeEngine : BaseCodeName
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
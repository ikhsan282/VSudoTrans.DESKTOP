using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.HumanResource
{
    [Table("Bank")]
    [DisplayName("Bank")]
    public class Bank : BaseCodeName
    {
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}

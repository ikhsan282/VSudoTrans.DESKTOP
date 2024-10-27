using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.HumanResource
{
    [Table("JobTitle")]
    [DisplayName("Jabatan")]
    public class JobTitle : BaseCodeName
    {
        public int Level { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}

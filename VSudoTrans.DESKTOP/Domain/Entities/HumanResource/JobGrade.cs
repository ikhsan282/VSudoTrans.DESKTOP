using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.HumanResource
{
    [Table("JobGrade")]
    [DisplayName("Golongan Pekerjaan")]
    public class JobGrade : BaseCodeName
    {
        public decimal FromAmount { get; set; }
        public decimal MidAmount { get; set; }
        public decimal ToAmount { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}

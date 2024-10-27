using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.HumanResource
{
    [Table("JobPosition")]
    [DisplayName("Posisi Pekerjaan")]
    public class JobPosition : BaseCodeName
    {
        public int? ParentId { get; set; }
        [NotMapped]
        public JobPosition Parent { get; set; }
        public int Level { get; set; }
        public int JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}

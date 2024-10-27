using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;

namespace Domain.Entities.HumanResource
{
    [Table("TeacherJobTitle")]
    [DisplayName("Guru")]
    public class TeacherJobTitle : BaseDomainDetail
    {
        public int JobTitleId { get; set; }
        public JobTitle? JobTitle { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}

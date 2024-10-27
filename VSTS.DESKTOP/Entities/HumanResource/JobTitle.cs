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
        public int SchoolId { get; set; }
        public School? School { get; set; }
    }
}

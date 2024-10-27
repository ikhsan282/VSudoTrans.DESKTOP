using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.EducationResource
{
    [Table("Major")]
    [DisplayName("Jurusan")]
    public class Major : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public EnumTypeEducation TypeEducation { get; set; }
    }
}

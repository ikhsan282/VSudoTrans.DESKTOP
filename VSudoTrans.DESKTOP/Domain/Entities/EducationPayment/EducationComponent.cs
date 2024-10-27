using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.EducationPayment
{
    [Table("EducationComponent")]
    [DisplayName("Kompenen Pendidikan")]
    public class EducationComponent : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public EnumEducationType EducationType { get; set; }
    }
}

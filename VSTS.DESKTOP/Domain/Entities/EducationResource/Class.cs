using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.EducationResource
{
    [Table("Class")]
    [DisplayName("Kelas")]
    public class Class : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [DisplayName("Nama")]
        [MaxLength(255)]
        public string Name { get; set; }
        public EnumClass Index { get; set; }
    }
}

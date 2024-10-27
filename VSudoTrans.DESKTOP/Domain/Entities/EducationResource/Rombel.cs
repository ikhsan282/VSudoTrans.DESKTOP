using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.EducationResource
{
    [Table("Rombel")]
    [DisplayName("Rombongan Belajar")]
    public class Rombel : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [DisplayName("Nama")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}

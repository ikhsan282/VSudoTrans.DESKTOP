using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.EducationResource
{
    [Table("ForceYear")]
    [DisplayName("Angkatan Tahun")]
    public class ForceYear : BaseDomainDetail
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [DisplayName("Nama")]
        [MaxLength(255)]
        public string Name { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;

namespace Domain.Entities.Organization
{
    [Table("OrganizationStructure")]
    [DisplayName("Organisasi")]
    public class OrganizationStructure : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? ParentId { get; set; }
        [NotMapped]
        public OrganizationStructure Parent { get; set; }
        public int Level { get; set; }
    }
}

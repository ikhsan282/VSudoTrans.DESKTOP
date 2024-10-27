using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;

namespace Domain.Entities.Finance
{
    [Table("Category")]
    [DisplayName("Kategori")]
    public class Category : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

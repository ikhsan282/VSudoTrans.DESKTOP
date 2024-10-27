using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;

namespace Domain.Entities.Organization
{
    [Table("Company")]
    [DisplayName("Perusahaan")]
    public class Company : BaseCodeName
    {
        public int FoundationId { get; set; }
        public Foundation? Foundation { get; set; }
    }
}

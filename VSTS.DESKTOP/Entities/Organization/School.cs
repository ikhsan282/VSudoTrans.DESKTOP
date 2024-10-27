using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;

namespace Domain.Entities.Organization
{
    [Table("School")]
    [DisplayName("Sekolah")]
    public class School : BaseCodeName
    {
        public int FoundationId { get; set; }
        public Foundation? Foundation { get; set; }
    }
}

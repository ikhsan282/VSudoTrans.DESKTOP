using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;

namespace Domain.Entities.Organization
{
    [Table("Foundation")]
    [DisplayName("Yayasan")]
    public class Foundation : BaseCodeName
    {

    }
}

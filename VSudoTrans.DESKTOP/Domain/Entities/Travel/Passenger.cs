using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Domain.Entities.Organization;

namespace Domain.Entities.Travel
{
    [Table("Passenger")]
    [DisplayName("Penumpang")]
    public class Passenger : BaseCodeName
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [MaxLength(10)]
        public string CountryCode { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(1000)]
        public string Email { get; set; }
    }
}

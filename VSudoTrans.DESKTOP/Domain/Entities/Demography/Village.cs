using Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Demography
{
    [Table("Village")]
    [DisplayName("Kelurahan")]
    public class Village : BaseCodeName
    {

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        [MaxLength(5)]
        public string PostalCode { get; set; }
    }
}
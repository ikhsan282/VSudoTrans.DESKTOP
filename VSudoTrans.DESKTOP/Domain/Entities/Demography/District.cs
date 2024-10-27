using Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Demography
{

    [Table("District")]
    [DisplayName("Kecamatan")]
    public class District : BaseCodeName
    {

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
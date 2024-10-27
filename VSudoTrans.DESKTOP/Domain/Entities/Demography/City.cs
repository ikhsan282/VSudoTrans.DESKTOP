using Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Demography
{
    [Table("City")]
    [DisplayName("Kota")]
    public class City : BaseCodeName
    {

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }
    }
}
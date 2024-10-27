using Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Demography
{
    [Table("Province")]
    [DisplayName("Provinsi")]
    public class Province : BaseCodeName
    {

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
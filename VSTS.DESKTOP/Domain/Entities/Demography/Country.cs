using Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Demography
{

    [Table("Country")]
    [DisplayName("Negara")]
    public class Country : BaseCodeName
    {

    }

    public class CountryCode
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Example { get; set; }
    }
}

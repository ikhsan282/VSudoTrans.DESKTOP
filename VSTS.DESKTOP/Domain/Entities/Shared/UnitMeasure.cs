using Domain.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shared
{
    [Table("UnitMeasure")]
    [DisplayName("Satuan Ukuran")]
    public class UnitMeasure : BaseCodeName
    {
        public string Format { get; set; }
    }
}

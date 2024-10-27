using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System.Collections.Generic;

namespace Domain.Entities.EducationPayment
{
    [Table("EducationComponentRegulation")]
    [DisplayName("Peraturan Kompenen Pendidikan")]
    public class EducationComponentRegulation : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public virtual List<EducationComponentRegulationDetail> EducationComponentRegulationDetails { get; set; }
    }
}

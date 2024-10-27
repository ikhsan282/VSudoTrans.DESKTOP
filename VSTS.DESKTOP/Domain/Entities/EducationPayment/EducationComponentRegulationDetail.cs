using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;

namespace Domain.Entities.EducationPayment
{
    [Table("EducationComponentRegulationDetail")]
    [DisplayName("Peraturan Kompenen Pendidikan Detail")]
    public class EducationComponentRegulationDetail : BaseDomainDetail
    {
        public int EducationComponentRegulationId { get; set; }
        public EducationComponentRegulation EducationComponentRegulation { get; set; }
        public int EducationComponentId { get; set; }
        public EducationComponent EducationComponent { get; set; }
        public decimal Amount { get; set; }
        public int NumberOfInstallment { get; set; }
        public decimal PaymentPerInstallment { get; set; }
        public int Priority { get; set; }
    }
}

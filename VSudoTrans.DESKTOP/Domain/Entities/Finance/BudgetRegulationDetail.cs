using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.EducationPayment;

namespace Domain.Entities.Finance
{
    [Table("BudgetRegulationDetail")]
    [DisplayName("Peraturan Anggaran Detail")]
    public class BudgetRegulationDetail : BaseDomainDetail
    {
        public int BudgetRegulationId { get; set; }
        public BudgetRegulation BudgetRegulation { get; set; }
        public int EducationComponentId { get; set; }
        public EducationComponent EducationComponent { get; set; }
        public decimal Amount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;

namespace Domain.Entities.Finance
{
    [Table("BudgetRegulationDetail")]
    [DisplayName("Peraturan Anggaran Detail")]
    public class BudgetRegulationDetail : BaseDomainDetail
    {
        public int BudgetRegulationId { get; set; }
        public BudgetRegulation BudgetRegulation { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; }
    }
}

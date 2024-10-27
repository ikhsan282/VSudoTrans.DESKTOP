using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Domain.Base;
using Domain.Entities.Organization;
using System.Collections.Generic;

namespace Domain.Entities.Finance
{
    [Table("BudgetRegulation")]
    [DisplayName("Peraturan Anggaran")]
    public class BudgetRegulation : BaseCodeName
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
        public EnumTransactionIndicator Indicator { get; set; }
        public virtual List<BudgetRegulationDetail> BudgetRegulationDetails { get; set; }
    }
}

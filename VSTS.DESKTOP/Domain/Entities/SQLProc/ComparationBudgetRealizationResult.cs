namespace Domain.Entities.SQLProc
{
    public class ComparationBudgetRealizationResult
    {
        public string EducationComponentCode { get; set; }
        public string EducationComponentName { get; set; }
        public decimal TotalBudgetAmount { get; set; }
        public decimal TotalRealizedAmount { get; set; }
        public decimal AmountVariance { get; set; }
        public decimal RealizationPercentage { get; set; }
    }
}

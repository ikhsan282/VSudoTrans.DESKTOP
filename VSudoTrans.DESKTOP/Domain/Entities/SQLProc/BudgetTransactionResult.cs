using System;

namespace Domain.Entities.SQLProc
{
    public class BudgetTransactionResult
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Indikator { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public decimal Pengeluaran { get; set; }
        public decimal Penerimaan { get; set; }
        public decimal Saldo { get; set; }
    }
}

using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Transaction.Finance
{
    public partial class frmImportBudgetTransactionWV : frmBaseImportWV
    {
        public frmImportBudgetTransactionWV()
        {
            InitializeComponent();

            this.Text = "Import Transaksi Anggaran";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

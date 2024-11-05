using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    public partial class frmImportBankWV : frmBaseImportWV
    {
        public frmImportBankWV()
        {
            InitializeComponent();

            this.Text = "Import Bank";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Organization
{
    public partial class frmImportCompanyWV : frmBaseImportWV
    {
        public frmImportCompanyWV()
        {
            InitializeComponent();

            this.Text = "Import Perusahaan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.Organization
{
    public partial class frmImportCompanyWV : frmBaseImportWV
    {
        public frmImportCompanyWV()
        {
            InitializeComponent();

            this.Text = "Import Sekolah";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.Organization
{
    public partial class frmImportOrganizationStructureWV : frmBaseImportWV
    {
        public frmImportOrganizationStructureWV()
        {
            InitializeComponent();

            this.Text = "Import Struktur Organisasi";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

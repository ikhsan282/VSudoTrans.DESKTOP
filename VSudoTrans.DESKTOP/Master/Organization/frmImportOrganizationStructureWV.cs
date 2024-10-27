using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Organization
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

using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.Organization
{
    public partial class frmImportJobPositionWV : frmBaseImportWV
    {
        public frmImportJobPositionWV()
        {
            InitializeComponent();

            this.Text = "Import Posisi";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

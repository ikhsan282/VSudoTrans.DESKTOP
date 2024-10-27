using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.HumanCapital
{
    public partial class frmImportJobTitleWV : frmBaseImportWV
    {
        public frmImportJobTitleWV()
        {
            InitializeComponent();

            this.Text = "Import Jabatan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.HumanCapital
{
    public partial class frmImportEmployeeWV : frmBaseImportWV
    {
        public frmImportEmployeeWV()
        {
            InitializeComponent();

            this.Text = "Import Karyawan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

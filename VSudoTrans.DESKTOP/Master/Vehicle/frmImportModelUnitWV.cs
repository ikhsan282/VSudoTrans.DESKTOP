using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmImportModelUnitWV : frmBaseImportWV
    {
        public frmImportModelUnitWV()
        {
            InitializeComponent();

            this.Text = "Import Model";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

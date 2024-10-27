using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Organization
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

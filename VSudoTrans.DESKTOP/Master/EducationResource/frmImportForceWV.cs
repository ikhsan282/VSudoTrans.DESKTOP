using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.EducationResource
{
    public partial class frmImportForceWV : frmBaseImportWV
    {
        public frmImportForceWV()
        {
            InitializeComponent();

            this.Text = "Import Angkatan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

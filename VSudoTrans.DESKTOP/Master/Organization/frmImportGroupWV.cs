using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Organization
{
    public partial class frmImportGroupWV : frmBaseImportWV
    {
        public frmImportGroupWV()
        {
            InitializeComponent();

            this.Text = "Import Yayasan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

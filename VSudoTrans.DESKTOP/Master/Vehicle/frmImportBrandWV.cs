using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmImportBrandWV : frmBaseImportWV
    {
        public frmImportBrandWV()
        {
            InitializeComponent();

            this.Text = "Import Merek";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

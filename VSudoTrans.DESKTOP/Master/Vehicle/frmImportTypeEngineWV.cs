using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmImportTypeEngineWV : frmBaseImportWV
    {
        public frmImportTypeEngineWV()
        {
            InitializeComponent();

            this.Text = "Import Tipe Mesin";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

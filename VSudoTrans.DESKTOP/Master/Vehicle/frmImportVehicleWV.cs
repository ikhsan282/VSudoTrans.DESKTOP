using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmImportVehicleWV : frmBaseImportWV
    {
        public frmImportVehicleWV()
        {
            InitializeComponent();

            this.Text = "Import Kendaraan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

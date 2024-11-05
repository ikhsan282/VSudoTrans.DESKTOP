using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmImportCategoryVehicleWV : frmBaseImportWV
    {
        public frmImportCategoryVehicleWV()
        {
            InitializeComponent();

            this.Text = "Import Kategori Kendaraan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

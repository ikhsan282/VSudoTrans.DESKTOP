using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.Shared
{
    public partial class frmImportUnitMeasureWV : frmBaseImportWV
    {
        public frmImportUnitMeasureWV()
        {
            InitializeComponent();

            this.Text = "Import Satuan Ukuran";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

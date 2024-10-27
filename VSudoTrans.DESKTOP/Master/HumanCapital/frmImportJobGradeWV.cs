using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    public partial class frmImportJobGradeWV : frmBaseImportWV
    {
        public frmImportJobGradeWV()
        {
            InitializeComponent();

            this.Text = "Import Golongan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

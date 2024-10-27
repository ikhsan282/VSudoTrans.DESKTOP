using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.HumanCapital
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

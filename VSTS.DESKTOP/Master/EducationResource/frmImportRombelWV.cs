using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.EducationResource
{
    public partial class frmImportRombelWV : frmBaseImportWV
    {
        public frmImportRombelWV()
        {
            InitializeComponent();

            this.Text = "Import Rombel";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

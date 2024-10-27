using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.EducationResource
{
    public partial class frmImportMajorWV : frmBaseImportWV
    {
        public frmImportMajorWV()
        {
            InitializeComponent();

            this.Text = "Import Jurusan";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

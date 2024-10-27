using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.EducationResource
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

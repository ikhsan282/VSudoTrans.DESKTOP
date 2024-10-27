using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.EducationPayment
{
    public partial class frmImportEducationComponentWV : frmBaseImportWV
    {
        public frmImportEducationComponentWV()
        {
            InitializeComponent();

            this.Text = "Import Education Component";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.Attendance
{
    public partial class frmImportAttendanceCodeWV : frmBaseImportWV
    {
        public frmImportAttendanceCodeWV()
        {
            InitializeComponent();

            this.Text = "Import Kode Absensi";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

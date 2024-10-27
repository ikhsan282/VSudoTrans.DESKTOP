using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Attendance
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

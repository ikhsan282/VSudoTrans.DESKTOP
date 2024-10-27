

namespace VSudoTrans.DESKTOP
{
    public partial class frmLogOff : DevExpress.XtraEditors.XtraForm
    {
        public frmLogOff()
        {
            InitializeComponent();

            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            logOutStatus = (LogOutStatus)_radioGroup.SelectedIndex;
        }

        public LogOutStatus logOutStatus { get; set; } = LogOutStatus.None;

    }
}

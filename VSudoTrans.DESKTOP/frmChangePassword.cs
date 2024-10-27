using System;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP
{
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        private string _Email = "";
        public frmChangePassword(string email)
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
            _Email = email;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(NewPassword.EditValue) != Convert.ToString(ConfirmNewPassword.EditValue))
                MessageHelper.ShowMessageWarning(this, "Password baru tidak sama dengan konfirmasi password baru");
            else
            {
                MessageHelper.WaitFormShow(this);
                await HelperHttpClientExecute.ExecutePostAsync($"/Users/change-password/{_Email}/{Convert.ToString(ConfirmNewPassword.EditValue)}");
                MessageHelper.WaitFormClose(this);
                MessageHelper.ShowMessageInformation(this, "Password berhasil di ubah");
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}

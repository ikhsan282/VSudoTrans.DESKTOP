using Domain.Entities.Identity;
using System;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP
{
    public partial class frmForgotPassword : DevExpress.XtraEditors.XtraForm
    {
        public frmForgotPassword()
        {
            InitializeComponent();

            btnResetPassword.Click += BtnResetPassword_Click;
        }

        private async void BtnResetPassword_Click(object sender, EventArgs e)
        {

            var user = HelperRestSharp.Get<ApplicationUser>($"/Users/By/{EmailTextEdit.EditValue}");
            if (user == null)
                MessageHelper.ShowMessageWarning(this, "Pengguna dengan email tersebut tidak ditemukan");
            else
            {
                MessageHelper.WaitFormShow(this);
                Random random = new Random();
                int code = random.Next(100000, 999999);
                await HelperHttpClientExecute.ExecutePostAsync($"/Users/send-email-verification-code/{EmailTextEdit.EditValue}/{code}");
                MessageHelper.WaitFormClose(this);
                using (var frmVerificationCode = new frmVerificationCode(code.ToString()))
                {
                    frmVerificationCode.ShowDialog();
                    if (frmVerificationCode.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        using (var frmChangePassword = new frmChangePassword(EmailTextEdit.EditValue.ToString()))
                        {
                            frmChangePassword.ShowDialog();
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                    }
                }
            }
        }
    }
}

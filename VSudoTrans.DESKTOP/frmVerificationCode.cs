using System;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP
{
    public partial class frmVerificationCode : DevExpress.XtraEditors.XtraForm
    {

        private int loop = 0;
        private string Code = "";
        public frmVerificationCode(string code)
        {
            InitializeComponent();

            btnVerificationCode.Click += BtnVerificationCode_Click;
            Code = code;
            loop = 0;
        }
        private void BtnVerificationCode_Click(object sender, EventArgs e)
        {
            if (Code != Convert.ToString(CodeTextEdit.EditValue))
            {
                loop++;
                if (loop >= 5)
                {
                    MessageHelper.ShowMessageWarning(this, "Percobaan memasukan Kode OTP sudah habis");
                    DialogResult = DialogResult.Cancel;
                }
                else
                    MessageHelper.ShowMessageInformation(this, "Kode OTP yang dimasukan tidak valid");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}

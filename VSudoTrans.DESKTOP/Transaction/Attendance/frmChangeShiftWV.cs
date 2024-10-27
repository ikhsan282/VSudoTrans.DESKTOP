using Microsoft.IdentityModel.Tokens;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using System.Globalization;
using System.Threading.Tasks;
using System;
using RestSharp;
using PopUpUtils;
using Domain.Entities.Attendance;

namespace VSudoTrans.DESKTOP.Transaction.Attendance
{
    public partial class frmChangeShiftWV : frmBaseWV
    {
        string date = "";
        int employeeId = 0;
        public frmChangeShiftWV(string date, int employeeId)
        {
            InitializeComponent();

            this.date = date;
            this.employeeId = employeeId;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            PopupEditHelper.General<Shift>(fEndPoint: "/Shifts", fTitle: "Shift", fControl: ShiftPopUp);
        }
        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(date) && employeeId > 0 && ShiftPopUp.EditValue != null)
            {
                SaveShift();
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void SaveShift()
        {
            try
            {
                HelperRestSharp.Post($"/Rosters/ChangeShift/{DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")}/{employeeId}/{HelperConvert.Int(AssemblyHelper.GetValueProperty(ShiftPopUp.EditValue, "Id"))}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                MessageHelper.WaitFormClose();
                MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);
            }
        }
    }
}

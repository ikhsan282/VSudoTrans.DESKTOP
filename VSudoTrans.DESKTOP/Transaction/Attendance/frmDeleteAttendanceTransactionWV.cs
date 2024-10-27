using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System.Drawing;

namespace VSudoTrans.DESKTOP.Transaction.Attendance
{
    public partial class frmDeleteAttendanceTransactionWV : frmBaseWV
    {
        public frmDeleteAttendanceTransactionWV()
        {
            InitializeComponent();

            this.EndPoint = "/Machines";
            this.FormTitle = "Panduan Hapus Transaksi Absensi";

            InitializeComponentAfter();
            InitializeSearchLookup();

            GridHelper.GridViewInitializeLayout(this._GridView);
            SetGridViewCheckBoxRowSelect(_GridControl, _GridView, _SearchControl, "Company.Name");

            wizardPage1.PageValidating += WizardPage1_PageValidating;
            wizardPage2.PageValidating += WizardPage2_PageValidating;

            _GridView.RowCellStyle += _GridView_RowCellStyle;
        }

        private void _GridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string status = HelperConvert.String(_GridView.GetRowCellValue(e.RowHandle, "Note"));
            if (status == "C")
                e.Appearance.BackColor = Color.LightGreen;
            else if (status == "D")
                e.Appearance.BackColor = Color.LightPink;
        }


        private void WizardPage2_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                ValidateCompany();
                if (!ActionValidate(_DxValidationProvider))
                {
                    e.Valid = false;
                    return;
                }

                List<Machine> machineList = GetListDataRowSelected(_GridView).OfType<Machine>().ToList();

                if (!machineList.Any())
                {
                    MessageHelper.ShowMessageError(this, "Tidak ada mesin yang dipilih");
                    e.Valid = false;
                    return;
                }

                if (MessageHelper.ShowMessageQuestion("Apakah anda yakin untuk melakukan hapus transaksi absensi", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Valid = false;
                    return;
                }

                MessageHelper.WaitFormShow(this);
                try
                {
                    string msgError = string.Empty;
                    int loop = 0;
                    foreach (var machine in machineList)
                    {
                        loop++;
                        MessageHelper.UpdateProgressWaitFormShow("", $"Connecting {loop}/{machineList.Count()}");
                        var connError = SoapHelper.CheckConnectionMachine(machine.IpAddress);
                        if (!string.IsNullOrEmpty(connError))
                            msgError += connError;
                    }

                    if (!machineList.Any())
                    {
                        MessageHelper.ShowMessageError(this, "Tidak ada mesin yang dipilih");
                        e.Valid = false;
                        return;
                    }
                    else if (!string.IsNullOrEmpty(msgError))
                    {
                        MessageHelper.ShowMessageError(this, $"Gagal terhubung ke mesin {msgError}");
                        e.Valid = false;
                        return;
                    }
                    else
                    {
                        loop = 0;
                        foreach (var machine in machineList)
                        {
                            loop++;
                            MessageHelper.UpdateProgressWaitFormShow("", $"Hapus {loop}/{machineList.Count()}");
                            SoapHelper.DeleteAllTransaction(machine);
                            SoapHelper.RefreshDB(machine);// Refresh DB Mesin Fingerprint
                        }
                        MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.WaitFormClose();
                    MessageHelper.ShowMessageError(this, ex);
                    e.Valid = false;
                    return;
                }
                finally
                {
                    MessageHelper.WaitFormClose();
                }
            }
            else if (e.Direction == DevExpress.XtraWizard.Direction.Backward)
                MyValidationHelper.ClearError(_DxValidationProvider);
        }

        private void WizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                ValidateCompany();
                if (!ActionValidate(_DxValidationProvider))
                {
                    e.Valid = false;
                    return;
                }

                MessageHelper.WaitFormShow(this);
                try
                {
                    //Filter
                    var select = "Id,IpAddress,Code,Name";
                    var expand = "Company($select=id,code,name)";
                    var filter = $"CompanyId eq {Convert.ToInt32(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))} ";
                    List<Machine> machines = HelperRestSharp.GetListOdata<Machine>("/Machines", select, expand, filter);
                    foreach (var machine in machines)
                    {
                        machine.Note = SoapHelper.PingConnectionMachine(machine.IpAddress) == "" ? "C" : "D";
                    }
                    _BindingSourceMachine.DataSource = machines;
                }
                catch (Exception)
                {

                }
                finally
                {
                    MessageHelper.WaitFormClose(this);
                }
            }
            else if (e.Direction == DevExpress.XtraWizard.Direction.Backward)
                MyValidationHelper.ClearError(_DxValidationProvider);
        }

        private void ValidateCompany()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
        }
    }
}

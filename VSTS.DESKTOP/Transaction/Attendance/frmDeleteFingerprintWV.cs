using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Attendance;
using Domain.Entities.HumanResource;
using Domain.Entities.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using PopUpUtils;

namespace VSTS.DESKTOP.Transaction.Attendance
{
    public partial class frmDeleteFingerprintWV : frmBaseWV
    {
        public frmDeleteFingerprintWV()
        {
            InitializeComponent();

            this.EndPoint = "/Machines";
            this.FormTitle = "Panduan Hapus Sidik Jari Karyawan";

            InitializeComponentAfter();
            InitializeSearchLookup();

            GridHelper.GridViewInitializeLayout(this._GridView);
            SetGridViewCheckBoxRowSelect(_GridControl, _GridView, _SearchControlMachine, "Company.Name");

            GridHelper.GridViewInitializeLayout(this._GridViewTeacherTransaction);
            SetGridViewCheckBoxRowSelect(_GridControlTeacherTransaction, _GridViewTeacherTransaction, _SearchControlTeacher, "Company.Name");

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

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
        }

        private void ValidateCompany()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
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

                MessageHelper.WaitFormShow(this);
                try
                {
                    string msgErrorMachine = string.Empty;
                    int loopMachine = 0;
                    foreach (var machine in machineList)
                    {
                        loopMachine++;
                        MessageHelper.UpdateProgressWaitFormShow("", $"Connecting {loopMachine}/{machineList.Count()}");
                        var connError = SoapHelper.CheckConnectionMachine(machine.IpAddress);
                        if (!string.IsNullOrEmpty(connError))
                            msgErrorMachine += connError;
                    }

                    List<Employee> teacherList = GetListDataRowSelected(_GridViewTeacherTransaction).OfType<Employee>().ToList();

                    if (!machineList.Any())
                    {
                        MessageHelper.ShowMessageError(this, "Tidak ada mesin yang dipilih");
                        e.Valid = false;
                        return;
                    }
                    else if (!teacherList.Any())
                    {
                        MessageHelper.ShowMessageError(this, "Tidak ada Karyawan yang dipilih");
                        e.Valid = false;
                        return;
                    }
                    else if (!string.IsNullOrEmpty(msgErrorMachine))
                    {
                        MessageHelper.ShowMessageError(this, $"Gagal terhubung ke mesin {msgErrorMachine}");
                        e.Valid = false;
                        return;
                    }
                    else
                    {
                        MessageHelper.WaitFormClose();
                        if (MessageHelper.ShowMessageQuestion("Apakah anda yakin untuk melakukan hapus master sidik jari Karyawan", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            e.Valid = false;
                            return;
                        }

                        MessageHelper.WaitFormShow(this);
                        foreach (var machine in machineList)
                        {
                            foreach (var teacher in teacherList)
                            {
                                MessageHelper.UpdateProgressWaitFormShow("", $"Delete {machine.Name} - {teacher.Name}");
                                var fingerprintList = SoapHelper.DeleteFingerprintEmployeeByPIN(machine, teacher.Code);//Delete fingerprint
                                SoapHelper.DeleteUserByPIN(machine, teacher.Code);//Delete user di mesin
                                SoapHelper.RefreshDB(machine);// Refresh DB Mesin Fingerprint
                            }
                        }
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
                    string select = "Id,Code,Name";
                    string expand = "Company($select=id,code,name)";
                    string filter = $"CompanyId eq {Convert.ToInt32(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))} ";

                    var Employees = HelperRestSharp.GetListOdata<Employee>($"/Employees", select, expand, filter);
                    _BindingSourceEmployee.DataSource = Employees;

                    //Filter
                    select = "Id,IpAddress,Code,Name";
                    expand = "Company($select=id,code,name)";
                    filter = $"CompanyId eq {Convert.ToInt32(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))} ";
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
    }
}

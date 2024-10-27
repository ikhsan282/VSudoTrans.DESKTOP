using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Attendance;
using Domain.Entities.HumanResource;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using PopUpUtils;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using System.Drawing;

namespace VSTS.DESKTOP.Transaction.Attendance
{
    public partial class frmDownloadFingerprintWV : frmBaseWV
    {
        public frmDownloadFingerprintWV()
        {
            InitializeComponent();

            this.EndPoint = "/Machines";
            this.FormTitle = "Panduan Unduh Sidik Jari Karyawan";

            InitializeComponentAfter();
            InitializeSearchLookup();

            GridHelper.GridViewInitializeLayout(this._GridView);
            SetGridViewCheckBoxRowSelect(_GridControl, _GridView, _SearchControlMachine, "Company.Name");

            GridHelper.GridViewInitializeLayout(this._GridViewEmployeeTransaction);
            SetGridViewCheckBoxRowSelect(_GridControlEmployeeTransaction, _GridViewEmployeeTransaction, _SearchControlTeacher, "Company.Name");

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

                    List<Employee> employeeList = GetListDataRowSelected(_GridViewEmployeeTransaction).OfType<Employee>().ToList();

                    if (!machineList.Any())
                    {
                        MessageHelper.ShowMessageError(this, "Tidak ada mesin yang dipilih");
                        e.Valid = false;
                        return;
                    }
                    else if (!employeeList.Any())
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
                        if (MessageHelper.ShowMessageQuestion("Apakah anda yakin untuk melakukan upload master sidik jari Karyawan", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            e.Valid = false;
                            return;
                        }

                        MessageHelper.WaitFormShow(this);
                        foreach (var machine in machineList)
                        {
                            foreach (var emp in employeeList)
                            {
                                // Saat ini save finger masih per employee (10 row), bisa di ubah logic savenya per 100/200 row
                                MessageHelper.UpdateProgressWaitFormShow("", $"Download {machine.Name} - {emp.Name}");
                                var fingerprintList = SoapHelper.DownloadFingerprintByPIN(machine, emp.Code);
                                if (fingerprintList.Row.Any())
                                    SaveEmployeeFingerprintData(fingerprintList.Row, emp.Id);
                            }
                            SoapHelper.RefreshDB(machine);// Refresh DB Mesin Fingerprint
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

        private List<EmployeeRecognition> GetEmployeeRecognitionByEmployeeId(int employeeId, string msgLoading)
        {
            string select = "id,employeeId,type,index,template,size";
            string expand = "Employee($select=name)";
            string filter = $"employeeId eq {employeeId} and Type eq 'SidikJari' ";

            var employeeRecognitionList = HelperRestSharp.GetListOdata<EmployeeRecognition>("/EmployeeRecognitions", select, expand, filter, msgLoading: msgLoading);

            return employeeRecognitionList;
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
        private void SaveEmployeeFingerprintData(List<RowUserTemplateResponse> trxList, int employeeId)
        {
            trxList.Select(c => { c.EmployeeId = employeeId; return c; }).ToList();

            int limit = 100;
            var totalPage = trxList.Count / limit;
            totalPage++;
            int page = 0;
            for (int i = 0; i < totalPage; i++)
            {
                MessageHelper.UpdateProgressWaitFormShow("", $"Proses menyimpan data sidik jari {i}/{totalPage}");
                page = i;
                var data = new List<RowUserTemplateResponse>();
                int skip = limit * page;
                data = trxList.Skip(skip).Take(limit).ToList();

                //Hit API
                this.OdataEntity = data;
                CreateEntity<List<RowUserTemplateResponse>>();
            }
        }

        protected override object CreateEntity<T>()
        {
            this.EndPoint = "/Machines/FingerprintEmployee";
            return base.CreateEntity<List<RowUserTemplateResponse>>();
        }
    }
}

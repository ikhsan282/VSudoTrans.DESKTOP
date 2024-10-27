using DevExpress.XtraEditors.DXErrorProvider;
using System.Collections.Generic;
using System;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using Domain.Entities.Attendance;
using Domain.Entities.HumanResource;
using System.Linq;
using System.Windows.Forms;
using PopUpUtils;
using System.Drawing;
using Newtonsoft.Json;

namespace VSudoTrans.DESKTOP.Transaction.Attendance
{
    public partial class frmDownloadAttendanceTransactionWV : frmBaseWV
    {
        public frmDownloadAttendanceTransactionWV()
        {
            InitializeComponent();

            this.EndPoint = "/Rosters/AttendanceMachine";
            this.FormTitle = "Panduan Unduh Transaksi Absensi";

            InitializeComponentAfter();
            InitializeSearchLookup();

            GridHelper.GridViewInitializeLayout(this._GridView);
            SetGridViewCheckBoxRowSelect(_GridControl, _GridView, _SearchControl, "Company.Name");

            GridHelper.GridViewInitializeLayout(this._GridViewEmployeeTransaction);
            SetGridViewCheckBoxRowSelect(_GridControlEmployeeTransaction, _GridViewEmployeeTransaction, _SearchControlTeacher, "Company.Name");

            wizardPage1.PageValidating += WizardPage1_PageValidating;
            wizardPage2.PageValidating += WizardPage2_PageValidating;

            HelperConvert.FormatDateEdit(StartDateDateEdit);
            HelperConvert.FormatDateEdit(EndDateDateEdit);

            StartDateDateEdit.EditValue = DateTime.Today;
            EndDateDateEdit.EditValue = DateTime.Today;

            UseFilterDate.Checked = false;
            UseFilterTeacher.Checked = false;
            layoutControlGroupDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroupTeacher.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            UseFilterDate.CheckedChanged += UseFilterDate_CheckedChanged;
            UseFilterTeacher.CheckedChanged += UseFilterTeacher_CheckedChanged;


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

        private void UseFilterTeacher_CheckedChanged(object sender, EventArgs e)
        {
            if (UseFilterTeacher.Checked)
                layoutControlGroupTeacher.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                layoutControlGroupTeacher.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void UseFilterDate_CheckedChanged(object sender, EventArgs e)
        {
            if (UseFilterDate.Checked)
                layoutControlGroupDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                layoutControlGroupDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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

                    List<Employee> teacherList = GetListDataRowSelected(_GridViewEmployeeTransaction).OfType<Employee>().ToList();

                    if (!machineList.Any())
                    {
                        MessageHelper.ShowMessageError(this, "Tidak ada mesin yang dipilih");
                        e.Valid = false;
                        return;
                    }
                    else if (!teacherList.Any() && UseFilterTeacher.Checked)
                    {
                        MessageHelper.ShowMessageError(this, "Tidak ada Karyawan yang dipilih");
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
                        MessageHelper.WaitFormClose();
                        if (MessageHelper.ShowMessageQuestion("Apakah anda yakin untuk melakukan unduh transaksi absensi", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            e.Valid = false;
                            return;
                        }

                        MessageHelper.WaitFormShow(this);
                        loop = 0;
                        foreach (var machine in machineList)
                        {
                            loop++;
                            MessageHelper.UpdateProgressWaitFormShow("", $"Unduh {loop}/{machineList.Count()}");


                            //Filter Employee
                            if (UseFilterTeacher.Checked)
                            {
                                var loopEmployee = 0;
                                int count = teacherList.Count;
                                foreach (var employee in teacherList)
                                {
                                    loopEmployee++;
                                    MessageHelper.UpdateProgressWaitFormShow("", $"Unduh {loopEmployee}/{count} {employee.Code} - {employee.Name} ");

                                    var trxList = SoapHelper.DownloadTransactionByPIN(machine, employee.Code);

                                    if (trxList.Row.Any())
                                    {
                                        if (UseFilterDate.Checked)
                                        {
                                            trxList.Row.Select(s => s.IDateTime = long.Parse(HelperConvert.Date(s.DateTime).ToString("yyyyMMddHHmm"))).ToList();
                                            trxList.Row = trxList.Row.Where(s => s.IDateTime >= long.Parse(HelperConvert.Date(StartDateDateEdit.EditValue).ToString("yyyyMMddHHmm")) && s.IDateTime <= long.Parse(HelperConvert.Date(EndDateDateEdit.EditValue).ToString("yyyyMMddHHmm"))).ToList();
                                        }

                                        if (trxList.Row.Any())
                                        {
                                            var listGroup = trxList.Row.GroupBy(s => new
                                            {
                                                s.PIN
                                            }).Select(s => new LogAttendance()
                                            {
                                                MachineId = machine.Id,
                                                CompanyId = machine.CompanyId,
                                                PIN = s.Key.PIN,
                                                RowAttLogResponse = s.ToList()
                                            }).ToList();

                                            if (listGroup.Any())
                                                SaveAttendanceData(listGroup);
                                        }
                                    }
                                    SoapHelper.RefreshDB(machine);// Refresh DB Mesin Fingerprint
                                }
                            }
                            else
                            {
                                var trxList = SoapHelper.DownloadTransactionAll(machine);

                                if (trxList.Row.Any())
                                {
                                    if (UseFilterDate.Checked)
                                    {
                                        trxList.Row.Select(s => s.IDateTime = long.Parse(HelperConvert.Date(s.DateTime).ToString("yyyyMMddHHmm"))).ToList();
                                        trxList.Row = trxList.Row.Where(s => s.IDateTime >= long.Parse(HelperConvert.Date(StartDateDateEdit.EditValue).ToString("yyyyMMddHHmm")) && s.IDateTime <= long.Parse(HelperConvert.Date(EndDateDateEdit.EditValue).ToString("yyyyMMddHHmm"))).ToList();
                                    }

                                    if (trxList.Row.Any())
                                    {
                                        var listGroup = trxList.Row.GroupBy(s => new
                                        {
                                            s.PIN
                                        }).Select(s => new LogAttendance()
                                        {
                                            MachineId = machine.Id,
                                            CompanyId = machine.CompanyId,
                                            PCName = Environment.MachineName,
                                            PIN = s.Key.PIN,
                                            RowAttLogResponse = s.ToList()
                                        }).ToList();

                                        if (listGroup.Any())
                                            SaveAttendanceData(listGroup);
                                    }
                                }
                                SoapHelper.RefreshDB(machine);// Refresh DB Mesin Fingerprint
                            }
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

        private void SaveAttendanceData(List<LogAttendance> trxList)
        {
            int limit = 5;
            var totalPage = trxList.Count / limit;
            totalPage++;
            int page = 0;
            for (int i = 0; i < totalPage; i++)
            {
                MessageHelper.UpdateProgressWaitFormShow("", $"Proses Menyimpan {i}/{totalPage}");
                page = i;
                var data = new List<LogAttendance>();
                int skip = limit * page;
                data = trxList.Skip(skip).Take(limit).ToList();

                //Hit API
                var jsonString = JsonConvert.SerializeObject(data);
                var response = HelperRestSharp.Post("/Rosters/AttendanceMachine", jsonString);

                if (!string.IsNullOrEmpty(response))
                {

                }
            }
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

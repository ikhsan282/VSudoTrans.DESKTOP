using System.Collections.Generic;
using VSudoTrans.DESKTOP.BaseForm;
using Domain.Entities.Attendance;
using VSudoTrans.DESKTOP.Utils;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Data;
using System.Linq;
using DevExpress.Utils;
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using PopUpUtils;
using Domain.Entities.HumanResource;
using Newtonsoft.Json;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using System.Threading.Tasks;
using System.Threading;
using Domain.Entities.Organization;
using Microsoft.OData;

namespace VSudoTrans.DESKTOP.Transaction.Attendance
{
    public partial class frmRosterLV : frmBaseFilterLV
    {
        private int employeeId = 0;
        private string date = string.Empty;
        public frmRosterLV()
        {
            InitializeComponent();

            this.EndPoint = "/Rosters";
            this.FormTitle = "Kehadiran";

            InitializeComponentAfter<Roster>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;

            _BandedGridView.CustomDrawCell += _BandedGridView_CustomDrawCell;
            _BandedGridView.RowClick += _BandedGridView_RowClick;

            bbiChangeShift.ItemClick += BbiChangeShift_ItemClick;
            bbiDetailRoster.ItemClick += BbiDetailRoster_ItemClick;

            bbiEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bbiCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            InitializeSearchLookup();


            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = DateTime.Today;
            FilterDate2.EditValue = DateTime.Today;

            bbiPollingAttendance.ItemClick += BbiPollingAttendance_ItemClick;
        }


        private void BbiDetailRoster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var roster = HelperRestSharp.GetOdata<Roster>("/Rosters", "Id", fFilter: $"EmployeeId eq {employeeId} and IDate eq {date}");
            if (roster != null)
            {
                FormDetail = new frmRosterDetailDV(roster.Id, employeeId, date);
                base.ActionShowFormDetail();
            }
        }

        private void BbiChangeShift_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (var form = new frmChangeShiftWV(date, employeeId))
                {
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                    {
                        var roster = HelperRestSharp.GetOdata<Roster>("/Rosters", fSelect: "EmployeeId,Date,SStartTime,SEndTime,AStartTime,AEndTime,ShiftId,AttendanceCodeId,PermitCodeId", fExpand: "AttendanceCode($select=grouptype,code,name),PermitCode($select=grouptype,code,name)", fFilter: $"IDate eq {date} and EmployeeId eq {employeeId}");

                        if (roster != null)
                        {
                            // Update peformance set custom grid dengan BeginUpdate dan EndUpdate
                            _BandedGridView.BeginUpdate();
                            var row = _BandedGridView.GetFocusedDataRow();

                            var dataNull = DBNull.Value;
                            if (roster.SStartTime != null)
                                row["SStartTime" + date] = HelperConvert.Date(roster.SStartTime);
                            else
                                row["SStartTime" + date] = dataNull;

                            if (roster.SEndTime != null)
                                row["SEndTime" + date] = HelperConvert.Date(roster.SEndTime);
                            else
                                row["SEndTime" + date] = dataNull;

                            if (roster.AStartTime != null)
                                row["AStartTime" + date] = HelperConvert.Date(roster.AStartTime);
                            else
                                row["AStartTime" + date] = dataNull;

                            if (roster.AEndTime != null)
                                row["AEndTime" + date] = HelperConvert.Date(roster.AEndTime);
                            else
                                row["AEndTime" + date] = dataNull;

                            if (roster.AttendanceCodeId != null)
                                row["AttendanceCodeId" + date] = HelperConvert.Int(roster.AttendanceCodeId);
                            else
                                row["AttendanceCodeId" + date] = dataNull;

                            if (roster.AttendanceCode != null)
                                row["AttendanceCode" + date] = HelperConvert.String(roster.AttendanceCode.Code);
                            else
                                row["AttendanceCode" + date] = dataNull;

                            if (roster.PermitCodeId != null)
                                row["PermitCodeId" + date] = HelperConvert.Int(roster.PermitCodeId);
                            else
                                row["PermitCodeId" + date] = dataNull;

                            if (roster.PermitCode != null)
                                row["PermitCode" + date] = HelperConvert.String(roster.PermitCode.Code);
                            else
                                row["PermitCode" + date] = dataNull;

                            _BandedGridView.EndUpdate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
        }

        private string getDate(string columnName)
        {
            return columnName.Replace("SStartTime", "").Replace("SEndTime", "").Replace("AStartTime", "").Replace("AEndTime", "");
        }

        private void _BandedGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridView view = sender as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
                object value = null;
                if (hitInfo.InRowCell)
                {
                    employeeId = HelperConvert.Int(view.GetRowCellValue(hitInfo.RowHandle, "EmployeeId"));
                    if (hitInfo.Column.FieldName.Contains("SStartTime") || hitInfo.Column.FieldName.Contains("SEndTime") ||
                        hitInfo.Column.FieldName.Contains("AStartTime") || hitInfo.Column.FieldName.Contains("AEndTime"))
                    {
                        date = getDate(hitInfo.Column.FieldName);
                        _PopupMenu.ShowPopup(Cursor.Position);
                    }
                }
                else if (hitInfo.InGroupRow)
                {
                    value = view.GetGroupRowValue(hitInfo.RowHandle);
                }
            }
        }

        private async void BbiPollingAttendance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitializeDefaultValidation();
            if (!ActionValidate()) return;

            var company = FilterPopUp3.EditValue as Company;

            string filter = string.Empty;
            List<Employee> employeeList = new List<Employee>();

            string taskResult = "";
            cancellationTokenSource = new CancellationTokenSource();

            IOverlaySplashScreenHandle overlayHandle = SplashScreenManager.ShowOverlayForm(this, customPainter: new OverlayWindowCompositePainter(overlayLabelTitle, overlayLabelPercentage));
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        filter = $"companyId eq {company.Id} ";

                        if (FilterPopUp4.EditValue != null)
                            filter += $" and Id eq {HelperConvert.Int(Utils.AssemblyHelper.GetValueProperty(FilterPopUp4.EditValue, "Id"))} ";

                        employeeList = HelperRestSharp.GetListOdata<Employee>("/Employees", "Id,Code,Name", "", fFilter: filter);
                    }
                    catch (Exception ex)
                    {
                        taskResult = ex.Message;
                        if (ex.InnerException != null)
                        {
                            taskResult = taskResult + ";" + ex.InnerException.Message;
                        }
                        cancellationTokenSource.Cancel();
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    }

                }, cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                taskResult = "Operation is Cancelled; " + taskResult;
            }
            finally
            {
                SplashScreenManager.CloseOverlayForm(overlayHandle);
            }

            if (taskResult != "") MessageHelper.ShowMessageError(this, taskResult);

            if (taskResult != "")
                MessageHelper.ShowMessageError(this, taskResult);
            else
            {
                if (employeeList == null)
                    return;

                if (MessageHelper.ShowMessageQuestion($"Apakah anda yakin untuk melakukan penarikan ulang data absensi pada {employeeList.Count} karyawan di {company.Code} - {company.Name} dengan tanggal {HelperConvert.Date(FilterDate1.EditValue).ToString("dd-MMM-yyyy")} sampai {HelperConvert.Date(FilterDate2.EditValue).ToString("dd-MMM-yyyy")}", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }

            string msgError = "";
            taskResult = "";
            cancellationTokenSource = new CancellationTokenSource();

            overlayHandle = SplashScreenManager.ShowOverlayForm(this, customPainter: new OverlayWindowCompositePainter(overlayLabelTitle, overlayLabelPercentage));
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        var dateFrom = HelperConvert.Date(FilterDate1.EditValue);
                        var dateTo = HelperConvert.Date(FilterDate2.EditValue);
                        int loop = 0;
                        foreach (var employee in employeeList)
                        {
                            loop++;
                            overlayLabelPercentage.Text = $"Memproses Data [{loop}/{employeeList.Count}] {employee.Code} - {employee.Name}";


                            this.EndPoint = $"/Rosters/PollingAttendance/{company.Id}/{employee.Code}/{long.Parse(dateFrom.ToString("yyyyMMddHHmm"))}/{long.Parse(dateTo.ToString("yyyyMMdd"))}2359";

                            var result = HelperRestSharp.Post(this.EndPoint);
                        }

                    }
                    catch (Exception ex)
                    {
                        taskResult = ex.Message;
                        if (ex.InnerException != null)
                        {
                            taskResult = taskResult + ";" + ex.InnerException.Message;
                        }
                        cancellationTokenSource.Cancel();
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    }

                }, cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                taskResult = "Operation is Cancelled; " + taskResult;
            }
            finally
            {
                SplashScreenManager.CloseOverlayForm(overlayHandle);
            }

            if (taskResult != "") MessageHelper.ShowMessageError(this, taskResult);

            if (taskResult != "")
                MessageHelper.ShowMessageError(this, taskResult);
            else
            {
                if (string.IsNullOrEmpty(msgError))
                    MessageHelper.ShowMessageInformation(this, "Sukses dalam menarik ulang data absensi");
                else
                    MessageHelper.ShowMessageError(this, msgError);
            }
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate1, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate2, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter1.Text = "Tanggal Mulai";

            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter2.Text = "Tanggal Akhir";

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);

            _LayoutControlItemFilter5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter5.Text = "Karyawan";
            PopupEditHelper.General<JobTitle>(fEndPoint: "/Employees", fTitle: "Karyawan", fControl: FilterPopUp4, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");

        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Roster>();
        }

        protected override async void ActionRefresh<T>(string endPoint = "")
        {
            //Validasi searchLookup
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            _GridControl.DataSource = null;
            List<Roster> results = new List<Roster>();

            string taskResult = "";
            cancellationTokenSource = new CancellationTokenSource();

            IOverlaySplashScreenHandle overlayHandle = SplashScreenManager.ShowOverlayForm(this, customPainter: new OverlayWindowCompositePainter(overlayLabelTitle, overlayLabelPercentage));
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        OdataSelect = "Id,EmployeeId,CompanyId,AttendanceCodeId,PermitCodeId,Date,SStartTime,SEndTime,AStartTime,AEndTime,DayType";

                        OdataExpand = "AttendanceCode($select=grouptype,code,name),";
                        OdataExpand += "PermitCode($select=grouptype,code,name),";
                        OdataExpand += "Employee($select=id,code,name),";
                        OdataExpand += "OrganizationStructure($select=id,code,name)";

                        OdataFilter = $"IDate ge {long.Parse(HelperConvert.Date(FilterDate1.EditValue).ToString("yyyyMMdd"))} and IDate le {long.Parse(HelperConvert.Date(FilterDate2.EditValue).ToString("yyyyMMdd"))} ";

                        if (FilterPopUp3.EditValue != null)
                            OdataFilter += $"and CompanyId eq {HelperConvert.Int(Utils.AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

                        if (FilterPopUp4.EditValue != null)
                            OdataFilter += $"and EmployeeId eq {HelperConvert.Int(Utils.AssemblyHelper.GetValueProperty(FilterPopUp4.EditValue, "Id"))} ";

                        results = HelperRestSharp.GetListOdata<Roster>("/Rosters", OdataSelect, OdataExpand, OdataFilter);
                    }
                    catch (Exception ex)
                    {
                        taskResult = ex.Message;
                        if (ex.InnerException != null)
                        {
                            taskResult = taskResult + ";" + ex.InnerException.Message;
                        }
                        cancellationTokenSource.Cancel();
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    }

                }, cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                taskResult = "Operation is Cancelled; " + taskResult;
            }
            finally
            {
                SplashScreenManager.CloseOverlayForm(overlayHandle);
            }

            if (taskResult != "") MessageHelper.ShowMessageError(this, taskResult);

            if (taskResult != "")
                MessageHelper.ShowMessageError(this, taskResult);
            else
            {
                // Update peformance set custom grid dengan BeginUpdate dan EndUpdate
                _BandedGridView.BeginUpdate();
                SetBandedGridView(results);
                _BandedGridView.EndUpdate();
            }
        }

        private void SetBandedGridView(List<Roster> rosterList)
        {
            _BandedGridView.Bands.Clear();

            if (rosterList == null || rosterList.Count == 0)
                return;

            var results = rosterList.ToList().GroupBy(s => s.EmployeeId).ToList();
            System.Data.DataTable tbl = new System.Data.DataTable();

            if (_BandedGridView.Bands["gbKaryawan"] == null)
            {
                // Create Band Fixed
                SetGridBand(DevExpress.XtraGrid.Columns.FixedStyle.Left, _BandedGridView, "Karyawan", new string[] { "OrganizationStructureName", "EmployeeNIK", "EmployeeName" }, new string[] { "Organisasi", "NIK", "Nama" });
            }

            // Create Column Fixed
            tbl.Columns.Add("Id", typeof(int));
            tbl.Columns.Add("EmployeeId", typeof(int));
            tbl.Columns.Add("EmployeeName", typeof(string));
            tbl.Columns.Add("EmployeeNIK", typeof(string));
            tbl.Columns.Add("OrganizationStructureId", typeof(int));
            tbl.Columns.Add("OrganizationStructureName", typeof(string));

            var dates = rosterList.ToList().Select(s => s.Date).Distinct().OrderBy(s => s).ToList();
            //if (dates.Count >= 2)
            //    _BandedGridView.OptionsView.ColumnAutoWidth = false;// Set true for set width column and auto
            //else
            //    _BandedGridView.OptionsView.ColumnAutoWidth = true;// Set true for set width column and auto
            //                                                       // Create Band Dynamic and Column table Dynamic
            var months = dates.GroupBy(s => s.ToString("MMMM")).Select(s => s).ToList();
            int pageCount = 0;

            foreach (var item in months)
            {
                var dateGroups = dates.Where(s => s.Date.ToString("MMMM") == item.Key).ToList();

                GridBand gridBandMonth = _BandedGridView.Bands.Add();
                gridBandMonth.Name = item.Key;
                gridBandMonth.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                gridBandMonth.Caption = item.Key;
                gridBandMonth.AppearanceHeader.Options.UseTextOptions = true;
                gridBandMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //gridBandMonth.AppearanceHeader.BackColor = Color.Gray;

                foreach (var date in dateGroups)
                {
                    MessageHelper.UpdateProgressWaitFormShow("", $"Memuat Tampilan ... {pageCount++}/{dates.Count}");

                    var unikId = date.ToString("yyyyMMdd");
                    var unikCap = date.ToString("dd");
                    if (_BandedGridView.Bands["gbDate" + unikId] == null)
                    {
                        SetGridBand(DevExpress.XtraGrid.Columns.FixedStyle.None, _BandedGridView, "Jadwal Kerja", new string[] { "SStartTime" + unikId, "SEndTime" + unikId }, new string[] { "Masuk", "Keluar" });
                        SetGridBand(DevExpress.XtraGrid.Columns.FixedStyle.None, _BandedGridView, "Aktual Kerja", new string[] { "AStartTime" + unikId, "AEndTime" + unikId }, new string[] { "Masuk", "Keluar" });
                        SetGridBand(DevExpress.XtraGrid.Columns.FixedStyle.None, _BandedGridView, "Status", new string[] { "AttendanceCode" + unikId, "PermitCode" + unikId }, new string[] { " ", " " });
                        GridBand gridBand = _BandedGridView.Bands.Add();
                        gridBand.Name = "gbDate" + unikId;
                        gridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                        gridBand.Caption = unikCap;
                        gridBand.AppearanceHeader.Options.UseTextOptions = true;
                        gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gridBand.Children.Add(_BandedGridView.Bands["gbJadwal Kerja"]);
                        gridBand.Children.Add(_BandedGridView.Bands["gbAktual Kerja"]);
                        gridBand.Children.Add(_BandedGridView.Bands["gbStatus"]);

                        gridBandMonth.Children.Add(gridBand);
                    }
                    if (tbl.Columns["SStartTime" + unikId] == null)
                        tbl.Columns.Add("SStartTime" + unikId, typeof(DateTime));

                    if (tbl.Columns["SEndTime" + unikId] == null)
                        tbl.Columns.Add("SEndTime" + unikId, typeof(DateTime));

                    if (tbl.Columns["AStartTime" + unikId] == null)
                        tbl.Columns.Add("AStartTime" + unikId, typeof(DateTime));

                    if (tbl.Columns["AEndTime" + unikId] == null)
                        tbl.Columns.Add("AEndTime" + unikId, typeof(DateTime));

                    if (tbl.Columns["AttendanceCodeId" + unikId] == null)
                        tbl.Columns.Add("AttendanceCodeId" + unikId, typeof(int));

                    if (tbl.Columns["AttendanceCode" + unikId] == null)
                        tbl.Columns.Add("AttendanceCode" + unikId, typeof(string));

                    if (tbl.Columns["PermitCodeId" + unikId] == null)
                        tbl.Columns.Add("PermitCodeId" + unikId, typeof(int));

                    if (tbl.Columns["PermitCode" + unikId] == null)
                        tbl.Columns.Add("PermitCode" + unikId, typeof(string));
                }
            }

            //Looping lagi untuk mengisi row, tidak bisa di gabung saat membuat band dan column
            foreach (var item in results)
            {
                if (item.Key > 0)
                {
                    rosterList = item.ToList();
                    var data = item.FirstOrDefault();
                    DataRow row = tbl.NewRow();
                    // Set Row Fix Column
                    row["Id"] = data.EmployeeId;
                    row["EmployeeId"] = data.EmployeeId;
                    row["EmployeeNIK"] = data.Employee.Code;
                    row["EmployeeName"] = data.Employee.Name;
                    row["OrganizationStructureId"] = data.OrganizationStructureId;
                    row["OrganizationStructureName"] = data.OrganizationStructure.Name;
                    foreach (var rowFill in rosterList)
                    {
                        // Set Row Dynamic Column
                        var unikId = rowFill.Date.ToString("yyyyMMdd");
                        if (rowFill.AttendanceCodeId != null)
                        {
                            row["AttendanceCodeId" + unikId] = rowFill.AttendanceCodeId;
                            row["AttendanceCode" + unikId] = rowFill.AttendanceCode?.Code;
                        }
                        if (rowFill.PermitCodeId != null)
                        {
                            row["PermitCodeId" + unikId] = rowFill.PermitCodeId;
                            row["PermitCode" + unikId] = rowFill.PermitCode?.Code;
                        }
                        if (rowFill.SStartTime != null)
                            row["SStartTime" + unikId] = rowFill.SStartTime;
                        if (rowFill.SEndTime != null)
                            row["SEndTime" + unikId] = rowFill.SEndTime;
                        if (rowFill.AStartTime != null)
                            row["AStartTime" + unikId] = rowFill.AStartTime;
                        if (rowFill.AEndTime != null)
                            row["AEndTime" + unikId] = rowFill.AEndTime;
                    }
                    tbl.Rows.Add(row);
                }
            }

            _GridControl.DataSource = tbl;

            _BandedGridView.Columns["OrganizationStructureName"].GroupIndex = 0;
            _BandedGridView.Columns["OrganizationStructureName"].SortIndex = 0;
            //_BandedGridView.Columns["KemandoranName"].GroupIndex = 1;
            //_BandedGridView.Columns["KemandoranName"].SortIndex = 1;
            _BandedGridView.OptionsBehavior.AutoExpandAllGroups = true; // Expand all group
        }

        private void SetGridBand(DevExpress.XtraGrid.Columns.FixedStyle fixedStyle, BandedGridView bandedView, string gridBandCaption, string[] columnNames, string[] captionNames)
        {
            GridBand gridBand = bandedView.Bands.Add();
            gridBand.Name = "gb" + gridBandCaption;
            gridBand.Fixed = fixedStyle;
            gridBand.Caption = gridBandCaption;
            gridBand.OptionsBand.FixedWidth = false;
            gridBand.Width = 570;
            gridBand.AppearanceHeader.Options.UseTextOptions = true;
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            int nrOfColumns = columnNames.Length;
            BandedGridColumn[] bandedColumns = new BandedGridColumn[nrOfColumns];
            for (int i = 0; i < nrOfColumns; i++)
            {
                bandedColumns[i] = (BandedGridColumn)bandedView.Columns.AddField(columnNames[i]);
                bandedColumns[i].Caption = captionNames[i];
                bandedColumns[i].OwnerBand = gridBand;
                bandedColumns[i].Visible = true;
                bandedColumns[i].AppearanceHeader.Options.UseTextOptions = true;
                bandedColumns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                bandedColumns[i].OptionsColumn.AllowMove = false;
                bandedColumns[i].OptionsColumn.AllowShowHide = false;
                //bandedColumns[i].AutoFillDown = true;

                if (columnNames[i].Contains("OrganizationStructure"))
                    bandedColumns[i].Width = 120;
                else if (columnNames[i].Contains("EmployeeNIK"))
                    bandedColumns[i].Width = 130;
                else if (columnNames[i].Contains("EmployeeName"))
                    bandedColumns[i].Width = 250;
                //else if (columnNames[i].Contains("LAttendance") || columnNames[i].Contains("LPermit"))
                //    bandedColumns[i].Width = 35;
                else if (columnNames[i].Contains("AttendanceCode") || columnNames[i].Contains("PermitCode"))
                    bandedColumns[i].Width = 70;
                else
                {
                    bandedColumns[i].OptionsColumn.AllowSize = false;
                    if (columnNames[i].Contains("SStartTime") || columnNames[i].Contains("SEndTime") ||
                        columnNames[i].Contains("AStartTime") || columnNames[i].Contains("AEndTime"))
                    {
                        bandedColumns[i].Width = 120;
                        bandedColumns[i].AutoFillDown = true;
                        bandedColumns[i].RowIndex = 0;
                        bandedColumns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        bandedColumns[i].DisplayFormat.FormatString = "dd-MM-yy HH:mm";
                        bandedColumns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }
                }
            }
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new frmRosterAddWV()).ShowDialog();
        }

        private void _BandedGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName.Contains("SStartTime") || e.Column.FieldName.Contains("SEndTime"))
            {
                if (e.CellValue != DBNull.Value)
                {
                    //var date = Convert.ToDateTime(e.CellValue.ToString());
                }
                else
                {
                    LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, Color.Pink, Color.White, LinearGradientMode.ForwardDiagonal);
                    using (brush)
                    {
                        e.Cache.FillRectangle(brush, e.Bounds);
                    }
                }
            }
        }
    }
}

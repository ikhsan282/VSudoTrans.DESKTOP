using DevExpress.Spreadsheet;
using Domain;
using Domain.Entities.Attendance;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace VSudoTrans.DESKTOP.Report.Attendance
{
    public partial class frmAbsenceSV : frmBaseSV
    {
        IWorkbook workbook;
        Worksheet worksheet;
        Worksheet worksheet1;
        Worksheet worksheet2;
        string type;
        public frmAbsenceSV()
        {
            InitializeComponent();

            this.EndPoint = "/Rosters";
            this.FormTitle = "Laporan Absensi";

            this.OdataSelect = "Id,EmployeeId,CompanyId,ShiftId,AttendanceCodeId,PermitCodeId,Date,DayType,SStartTime,SEndTime,AStartTime,AEndTime,ADurationDay";
            this.OdataExpand = "Company($select=id,code,name;$expand=Group($select=Id,Code,Name)),";
            this.OdataExpand += "Shift($select=id,code,name),";
            this.OdataExpand += "AttendanceCode($select=id,code,name),";
            this.OdataExpand += "PermitCode($select=id,code,name),";
            this.OdataExpand += "Employee($select=id,code,name,ResignationDate;$expand=JobTitle($select=Id,Code,Name))";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<Roster>();

            _spreadsheetControl.Options.Behavior.CreateNew = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled;
            _spreadsheetControl.Options.Behavior.Open = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled;

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Roster>();
        }

        protected override void ActionRefresh<T>()
        {
            // Plant wajib isi
            if (FilterPopUp3.EditValue == null)
            {
                FilterPopUp3.ErrorText = _LayoutControlItemFilter3.Text + MessageHelper.MessageCouldNotEmpty;
                MessageHelper.ShowMessageError(this, FilterPopUp3.ErrorText);
                return;
            }
            if (FilterDate1.EditValue == null || FilterDate1.EditValue == DBNull.Value)
            {
                FilterDate1.ErrorText = _LayoutControlItemFilter1.Text + MessageHelper.MessageCouldNotEmpty;
                MessageHelper.ShowMessageError(this, FilterDate1.ErrorText);
                return;
            }
            if (FilterDate2.EditValue == null || FilterDate2.EditValue == DBNull.Value)
            {
                FilterDate2.ErrorText = _LayoutControlItemFilter2.Text + MessageHelper.MessageCouldNotEmpty;
                MessageHelper.ShowMessageError(this, FilterDate2.ErrorText);
                return;
            }

            #region validasi tanggal
            DateTime fdate1;
            DateTime fdate2;

            fdate1 = ((DateTime)FilterDate1.EditValue).Date;
            fdate2 = ((DateTime)FilterDate2.EditValue).Date;

            if (fdate2 < fdate1)
            {
                FilterDate2.ErrorText = $"{_LayoutControlItemFilter2.Text} harus lebih besar atau sama dengan {_LayoutControlItemFilter1.Text}";
                MessageHelper.ShowMessageError(this, FilterDate2.ErrorText);
                return;
            }

            int daysDifference = (fdate2 - fdate1).Days;
            if (daysDifference >= 31)
            {
                FilterDate2.ErrorText = $"Range Tanggal tidak boleh melebihi 31 hari";
                MessageHelper.ShowMessageError(this, FilterDate2.ErrorText);
                return;
            }
            #endregion

            object companyId = AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"); // ambil nilai company dari FilterPopUp3
            object date1 = Convert.ToInt32(FilterDate1.DateTime.ToString("yyyyMMdd"));
            object date2 = Convert.ToInt32(FilterDate2.DateTime.ToString("yyyyMMdd"));

            if (companyId != null)
            {
                if (string.IsNullOrEmpty(companyId.ToString()) == false)
                {
                    this.OdataFilter = $"companyId eq {companyId}";
                }
            }


            if (date1 != null && date2 != null)
            {
                this.OdataFilter += $" and iDate ge {date1} and iDate le {date2}";
                //this.OdataFilter += $" and (Employee/IResignationDate eq null or Employee/IResignationDate ge {date1})";
            }

            base.ActionRefresh<Roster>();
        }

        protected override void WoorkbookConfiguration()
        {
            DateTime? date1 = null;
            DateTime? date2 = null;
            date1 = (DateTime)FilterDate1.EditValue;
            date2 = (DateTime)FilterDate2.EditValue;
            object code = Convert.ToString(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"));
            object name = Convert.ToString(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Name"));
            //string plant = $"{code} - {name}"; //dicoment takut dipake lagi
            string year = $"{date1?.ToString("yyyy")}";
            string period = $"{date1?.ToString("dd-MMM-yyyy")} - {date2?.ToString("dd-MMM-yyyy")}";

            #region setup datasource
            var sheet = DataSource as List<Roster>;

            DataTable tableJumlahHK = ConvertListToDataTableJumlahHK(sheet);
            DataTable tableKodeAbsen = ConvertListToDataTableKodeAbsen(sheet);
            DataTable tableDetailAbsensi = ConvertListToDataTableDetailAbsensi(sheet);

            // Create a new Workbook object.
            workbook = _spreadsheetControl.Document;

            // Add a new worksheet at the specified position in the collection of worksheets.
            var rowCountHK = tableJumlahHK.Rows.Count;
            var rowCountKA = tableKodeAbsen.Rows.Count;
            var rowCountSF = tableDetailAbsensi.Rows.Count;

            var columnCountHK = tableJumlahHK.Columns.Count;
            var columnCountKA = tableKodeAbsen.Columns.Count;
            var columnCountSF = tableDetailAbsensi.Columns.Count;

            try
            {
                for (int i = workbook.Worksheets.Count - 1; i >= 1; i--)
                    workbook.Worksheets.RemoveAt(i);

                workbook.Worksheets.Insert(1, "Kode Absen");
                workbook.Worksheets.Insert(2, "Detail Absensi");

                // Loop through the DataTable rows
                worksheet = workbook.Worksheets[0];
                var customHK = GetExcelColumnName(columnCountHK + 1);
                worksheet[$"B6:{customHK}{rowCountHK + 6}"].Borders.SetAllBorders(System.Drawing.Color.Black, BorderLineStyle.Thin);
                worksheet[$"B6:{customHK}{6}"].FillColor = Color.Gold;
                worksheet[$"B6:{customHK}{6}"].Font.FontStyle = SpreadsheetFontStyle.Bold;
                worksheet[$"G6:{customHK}{6}"].ColumnWidth = 300;
                worksheet.Import(tableJumlahHK, true, 5, 1);
                worksheet.Name = "Jumlah HK";

                // Loop through the DataTable rows
                worksheet1 = workbook.Worksheets[1];
                var customKA = GetExcelColumnName(columnCountKA + 1);
                worksheet1[$"B6:{customKA}{rowCountKA + 6}"].Borders.SetAllBorders(System.Drawing.Color.Black, BorderLineStyle.Thin);
                worksheet1[$"B6:{customKA}{6}"].FillColor = Color.Gold;
                worksheet1[$"B6:{customKA}{6}"].Font.FontStyle = SpreadsheetFontStyle.Bold;
                worksheet1[$"B6:{customKA}{6}"].Font.FontStyle = SpreadsheetFontStyle.Bold;
                worksheet1[$"G6:{customKA}{6}"].ColumnWidth = 300;
                worksheet1.Import(tableKodeAbsen, true, 5, 1);
                worksheet1.Name = "Kode Absensi";

                // Loop through the DataTable rows
                worksheet2 = workbook.Worksheets[2];
                var customSF = GetExcelColumnName(columnCountSF + 1);
                worksheet2[$"B6:{customSF}{rowCountSF + 6}"].Borders.SetAllBorders(System.Drawing.Color.Black, BorderLineStyle.Thin);
                worksheet2[$"B6:{customSF}{6}"].FillColor = Color.Gold;
                worksheet2[$"B6:{customSF}{6}"].Font.FontStyle = SpreadsheetFontStyle.Bold;
                worksheet2.Import(tableDetailAbsensi, true, 5, 1);
                worksheet2.Name = "Detail Absensi";

            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }

            #endregion

            #region setup column & rows

            // Set the width of the column that contains the "E15" cell to 100 points.
            worksheet.Range["A1"].ColumnWidth = 50;
            worksheet1.Range["A1"].ColumnWidth = 50;
            worksheet2.Range["A1"].ColumnWidth = 50;

            worksheet.Range["B6"].ColumnWidth = 700;
            worksheet1.Range["B6"].ColumnWidth = 700;
            worksheet2.Range["B6"].ColumnWidth = 700;

            worksheet.Range["C6"].ColumnWidth = 250;
            worksheet1.Range["C6"].ColumnWidth = 250;
            worksheet2.Range["C6"].ColumnWidth = 250;

            worksheet.Range["D6"].ColumnWidth = 250;
            worksheet1.Range["D6"].ColumnWidth = 250;
            worksheet2.Range["D6"].ColumnWidth = 250;

            worksheet.Range["E6"].ColumnWidth = 350;
            worksheet1.Range["E6"].ColumnWidth = 350;
            worksheet2.Range["E6"].ColumnWidth = 350;

            worksheet.Range["F6"].ColumnWidth = 550;
            worksheet1.Range["F6"].ColumnWidth = 550;
            worksheet2.Range["F6"].ColumnWidth = 550;

            worksheet.Range["G6"].ColumnWidth = 500;
            worksheet1.Range["G6"].ColumnWidth = 500;
            worksheet2.Range["G6"].ColumnWidth = 500;

            worksheet.Range["H6"].ColumnWidth = 300;
            worksheet1.Range["H6"].ColumnWidth = 300;
            worksheet2.Range["H6"].ColumnWidth = 300;

            worksheet.Range["I6"].ColumnWidth = 300;
            worksheet1.Range["I6"].ColumnWidth = 300;
            worksheet2.Range["I6"].ColumnWidth = 300;

            worksheet.Range["J6"].ColumnWidth = 500;
            worksheet1.Range["J6"].ColumnWidth = 500;
            worksheet2.Range["J6"].ColumnWidth = 500;

            worksheet2.Range["K6"].ColumnWidth = 300;
            worksheet2.Range["L6"].ColumnWidth = 300;
            worksheet2.Range["M6"].ColumnWidth = 300;
            worksheet2.Range["N6"].ColumnWidth = 500;
            worksheet2.Range["O6"].ColumnWidth = 500;
            worksheet2.Range["P6"].ColumnWidth = 500;
            worksheet2.Range["Q6"].ColumnWidth = 500;
            worksheet2.Range["R6"].ColumnWidth = 300;
            worksheet2.Range["S6"].ColumnWidth = 300;
            worksheet2.Range["T6"].ColumnWidth = 300;

            // Add a new cell.
            // Cell for worksheet Jumlah HK
            Cell cell1 = worksheet.Cells["B2"];
            Cell cell2 = worksheet.Cells["B3"];
            Cell cell3 = worksheet.Cells["B4"];
            //cell1.Value = plant; //dicoment takut dipake lagi
            cell1.Font.FontStyle = SpreadsheetFontStyle.Bold;
            cell2.Value = year;
            cell2.Font.FontStyle = SpreadsheetFontStyle.Bold;
            cell3.Value = period;
            cell3.Font.FontStyle = SpreadsheetFontStyle.Bold;

            // Cell for worksheet Kode Absensi
            Cell cell4 = worksheet1.Cells["B2"];
            Cell cell5 = worksheet1.Cells["B3"];
            Cell cell6 = worksheet1.Cells["B4"];
            //cell4.Value = plant; //dicoment takut dipake lagi
            cell4.Font.FontStyle = SpreadsheetFontStyle.Bold;
            cell5.Value = year;
            cell5.Font.FontStyle = SpreadsheetFontStyle.Bold;
            cell6.Value = period;
            cell6.Font.FontStyle = SpreadsheetFontStyle.Bold;

            //Cell for worksheet DetailAbsensi

            Cell cell7 = worksheet2.Cells["B2"];
            Cell cell8 = worksheet2.Cells["B3"];
            Cell cell9 = worksheet2.Cells["B4"];
            //cell7.Value = plant; //dicoment takut dipake lagi
            cell7.Font.FontStyle = SpreadsheetFontStyle.Bold;
            cell8.Value = year;
            cell8.Font.FontStyle = SpreadsheetFontStyle.Bold;
            cell9.Value = period;
            cell9.Font.FontStyle = SpreadsheetFontStyle.Bold;

            // Set the width of all columns that contain the "B5:Z5"
            worksheet.MergeCells(worksheet.Range["B5:AK5"]);
            worksheet1.MergeCells(worksheet1.Range["B5:AK5"]);
            worksheet2.MergeCells(worksheet2.Range["B5:O5"]);

            CellRange range = worksheet.Range["B5:AK5"];
            CellRange range1 = worksheet1.Range["B5:AK5"];
            CellRange range2 = worksheet2.Range["B5:O5"];
            range.Value = "LAPORAN JUMLAH HK KARYAWAN";
            range1.Value = "LAPORAN ABSENSI KARYAWAN";
            range2.Value = "LAPORAN ABSENSI KARYAWAN";

            // Begin updating of the range formatting
            Formatting rangeFormatting = range.BeginUpdateFormatting();
            Formatting rangeFormatting1 = range1.BeginUpdateFormatting();
            Formatting rangeFormatting2 = range2.BeginUpdateFormatting();

            rangeFormatting.Font.FontStyle = SpreadsheetFontStyle.Bold;
            rangeFormatting1.Font.FontStyle = SpreadsheetFontStyle.Bold;
            rangeFormatting2.Font.FontStyle = SpreadsheetFontStyle.Bold;

            // Specify text alignment in cells.
            rangeFormatting.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            rangeFormatting1.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            rangeFormatting2.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

            // End updating of the range formatting.
            range.EndUpdateFormatting(rangeFormatting);
            range1.EndUpdateFormatting(rangeFormatting1);
            range2.EndUpdateFormatting(rangeFormatting2);

            #endregion
        }

        private DataTable ConvertListToDataTableJumlahHK(List<Roster> list)
        {

            // New table.
            DataTable dt = new DataTable();
            dt.Columns.Add("Region", typeof(string));
            dt.Columns.Add("Area", typeof(string));
            dt.Columns.Add("Unit Kerja", typeof(string));
            dt.Columns.Add("NIK", typeof(string));
            dt.Columns.Add("Nama Karyawan", typeof(string));
            dt.Columns.Add("Jabatan", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Divisi", typeof(string));
            dt.Columns.Add("Kemandoran", typeof(string));

            var dates = list.ToList().Select(s => s.Date).Distinct().OrderBy(s => s).ToList();

            foreach (var item in dates)
            {
                var unikId = item.Date.ToString("dd-MMM-yyyy");
                dt.Columns.Add(unikId, typeof(decimal));
            }

            var results = list.ToList().GroupBy(s => s.EmployeeId).ToList();
            foreach (var rowFill in results)
            {
                if (rowFill.Key > 0)
                {
                    DataRow r = dt.NewRow();
                    foreach (var data in rowFill.ToList())
                    {
                        // Set Row Dynamic Column
                        r["Region"] = data.Company.Name + "Region";
                        r["Area"] = data.Company.Name + "Area";
                        r["Unit Kerja"] = data.Company.Code;
                        r["NIK"] = data.Employee.Code;
                        r["Nama Karyawan"] = data.Employee.Name;
                        r["Jabatan"] = data.Employee.JobTitle.Name;
                        r["Status"] = data.Employee.JobTitle.Code + "Status Golongan";
                        r["Divisi"] = data.Employee.JobTitle.Name + "Divisi";
                        r["Kemandoran"] = data.Employee.JobTitle.Name + "Kemandoran";

                        var unikId = data.Date.ToString("dd-MMM-yyyy");
                        r[unikId] = (data.ADurationDay != null ? data.ADurationDay : (object)DBNull.Value);

                    }
                    dt.Rows.Add(r);
                }
            }


            return dt;
        }
        private DataTable ConvertListToDataTableKodeAbsen(List<Roster> list)
        {

            // New table.
            DataTable dt = new DataTable();
            dt.Columns.Add("Region", typeof(string));
            dt.Columns.Add("Area", typeof(string));
            dt.Columns.Add("Unit Kerja", typeof(string));
            dt.Columns.Add("NIK", typeof(string));
            dt.Columns.Add("Nama Karyawan", typeof(string));
            dt.Columns.Add("Jabatan", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Divisi", typeof(string));
            dt.Columns.Add("Kemandoran", typeof(string));

            var dates = list.ToList().Select(s => s.Date).Distinct().OrderBy(s => s).ToList();

            foreach (var item in dates)
            {
                var unikId = item.Date.ToString("dd-MMM-yyyy");
                dt.Columns.Add(unikId, typeof(string));
            }

            var results = list.ToList().GroupBy(s => s.EmployeeId).ToList();
            foreach (var rowFill in results)
            {
                if (rowFill.Key > 0)
                {
                    DataRow r = dt.NewRow();
                    foreach (var data in rowFill.ToList())
                    {
                        // Set Row Dynamic Column
                        r["Region"] = data.Company.Name + "Region";
                        r["Area"] = data.Company.Name + "Area";
                        r["Unit Kerja"] = data.Company.Code;
                        r["NIK"] = data.Employee.Code;
                        r["Nama Karyawan"] = data.Employee.Name;
                        r["Jabatan"] = data.Employee.JobTitle.Name;
                        r["Status"] = data.Employee.JobTitle.Code + "Status Golongan";
                        r["Divisi"] = data.Employee.JobTitle.Name + "Divisi";
                        r["Kemandoran"] = data.Employee.JobTitle.Name + "Kemandoran";

                        var unikId = data.Date.ToString("dd-MMM-yyyy");
                        if (data.PermitCode != null)
                        {
                            r[unikId] = (data.PermitCode != null ? data.PermitCode.Code : "");
                        }
                        else
                        {
                            r[unikId] = (data.AttendanceCode != null ? data.AttendanceCode.Code : "");
                        }
                    }
                    dt.Rows.Add(r);
                }
            }

            return dt;
        }
        private DataTable ConvertListToDataTableDetailAbsensi(List<Roster> list)
        {
            // New table.
            DataTable dt = new DataTable();
            dt.Columns.Add("Region", typeof(string));
            dt.Columns.Add("Area", typeof(string));
            dt.Columns.Add("Unit Kerja", typeof(string));
            dt.Columns.Add("NIK", typeof(string));
            dt.Columns.Add("Nama Karyawan", typeof(string));
            dt.Columns.Add("Jabatan", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Divisi", typeof(string));
            dt.Columns.Add("Kemandoran", typeof(string));
            dt.Columns.Add("Tanggal", typeof(string));
            dt.Columns.Add("Kode Shift", typeof(string));
            dt.Columns.Add("Tipe Hari", typeof(string));
            dt.Columns.Add("Jam Mulai Shift", typeof(string));
            dt.Columns.Add("Jam Selesai Shift", typeof(string));
            dt.Columns.Add("Jam Masuk Actual", typeof(string));
            dt.Columns.Add("Jam Pulang Actual", typeof(string));
            dt.Columns.Add("Kode Absensi", typeof(string));
            dt.Columns.Add("Kode Izin", typeof(string));
            dt.Columns.Add("Jumlah HK", typeof(decimal));

            var dates = list.ToList().Select(s => s.Date).Distinct().OrderBy(s => s).ToList();

            var results = list.ToList();

            foreach (var data in results)
            {
                string SStartTime = String.Format("{0:dd-MMM-yyyy HH:mm.ss}", data.SStartTime);
                string SEndTime = String.Format("{0:dd-MMM-yyyy HH:mm.ss}", data.SEndTime);
                string AStartTime = String.Format("{0:dd-MMM-yyyy HH:mm.ss}", data.AStartTime);
                string AEndTime = String.Format("{0:dd-MMM-yyyy HH:mm.ss}", data.AEndTime);

                if (data.DayType == EnumDayType.HariKerja) { type = "Hari Kerja"; }
                if (data.DayType == EnumDayType.HariKerjaPendek) { type = "Hari Kerja Pendek"; }
                if (data.DayType == EnumDayType.HariLibur) { type = "Hari Libur"; }
                if (data.DayType == EnumDayType.HariLiburNasional) { type = "Hari Libur Nasional"; }
                if (data.DayType == EnumDayType.HariLiburWilayah) { type = "Hari Libur Wilayah"; }
                if (data.DayType == EnumDayType.HariCutiBersama) { type = "Hari Cuti Bersama"; }

                // Set Row Dynamic Column
                DataRow r = dt.NewRow();
                r["Region"] = data.Company.Name + "Region";
                r["Area"] = data.Company.Name + "Area   ";
                r["Unit Kerja"] = data.Company.Code;
                r["NIK"] = data.Employee.Code;
                r["Nama Karyawan"] = data.Employee.Name;
                r["Jabatan"] = data.Employee.JobTitle.Name;
                r["Status"] = data.Employee.JobTitle.Name + "Status Golongan";
                r["Divisi"] = data.Employee.JobTitle.Name + "Divisi";
                r["Kemandoran"] = data.Employee.JobTitle.Name + "Kemandoran";
                r["Tanggal"] = data.Date.ToString("dd-MMM-yyyy");
                r["Kode Shift"] = data.Shift.Code;
                r["Tipe Hari"] = type;
                r["Jam Mulai Shift"] = SStartTime;
                r["Jam Selesai Shift"] = SEndTime;
                r["Jam Masuk Actual"] = AStartTime;
                r["Jam Pulang Actual"] = AEndTime;
                r["Kode Absensi"] = (data.AttendanceCode != null ? data.AttendanceCode.Code : "");
                r["Kode Izin"] = (data.PermitCode != null ? data.PermitCode.Code : "");
                r["Jumlah HK"] = (data.ADurationDay != null ? data.ADurationDay : (object)DBNull.Value);

                dt.Rows.Add(r);
            }


            return dt;
        }
        private string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
        }
    }
}

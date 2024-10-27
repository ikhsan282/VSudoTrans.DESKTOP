using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using Domain.Entities.SQLView.Attendance;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System;

namespace VSudoTrans.DESKTOP.Report.Attendance
{
    public partial class frmAttendanceHistoryEmployeeLV : frmBaseFilterLV
    {
        public frmAttendanceHistoryEmployeeLV()
        {
            InitializeComponent();

            this.EndPoint = "/SQLViews/AttendanceHistoryViews";
            this.FormTitle = "Riwayat Kehadiran";

            this.OdataSelect = "PIN,Datetime,EmployeeCode,EmployeeName,CompanyCode,CompanyName,CreatedUser,CreatedDate";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            GridHelper.GridColumnInitializeLayout(colDatetime, typeof(DateTime), "dd-MMM-yyyy HH:mm:ss");
            GridHelper.GridColumnInitializeLayout(colCreatedDate, typeof(DateTime), "dd-MMM-yyyy HH:mm:ss");

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<AttendanceHistoryView>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;

            _GridView.CustomDrawCell += _GridView_CustomDrawCell;

            InitializeSearchLookup();
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
            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            this.OdataFilter = $"IDatetime ge {long.Parse(HelperConvert.Date(FilterDate1.EditValue).ToString("yyyyMMddHHmm"))} and IDatetime le {long.Parse(HelperConvert.Date(FilterDate2.EditValue).ToString("yyyyMMdd") + "2359")}";

            if (FilterPopUp3.EditValue != null)
                OdataFilter += $" and CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<AttendanceHistoryView>();
        }

        private void _GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue != DBNull.Value && e.CellValue != null)
            {
                if (e.Column.FieldName.Contains("Time"))
                    e.DisplayText = ((TimeSpan)e.CellValue).ToString(@"hh\:mm");
            }
        }
    }
}

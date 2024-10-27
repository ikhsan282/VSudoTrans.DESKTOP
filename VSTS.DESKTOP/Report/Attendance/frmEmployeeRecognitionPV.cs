using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraPivotGrid;
using Domain;
using Domain.Entities.SQLView.HumanResource;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using PopUpUtils;
using System;

namespace VSTS.DESKTOP.Report.Attendance
{
    public partial class frmEmployeeRecognitionPV : frmBasePV
    {
        public frmEmployeeRecognitionPV()
        {
            InitializeComponent();

            this.EndPoint = "/SQLViews/EmployeeRecognitionViews";
            this.FormTitle = "Data Sidik Jari dan Wajah";

            this.OdataSelect = "EmployeeId,EmployeeCode,EmployeeName,";
            this.OdataSelect += "CompanyId,CompanyCode,CompanyName,";
            this.OdataSelect += "Type,IndexType,IndexTotal";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<EmployeeRecognitionView>();
            bbiRefresh.ItemClick += BbiRefresh_ItemClick;

            _pivotGridControl.CustomCellDisplayText += _pivotGridControl_CustomCellDisplayText;
            _pivotGridControl.FieldValueDisplayText += _pivotGridControl_FieldValueDisplayText;
        }

        private void _pivotGridControl_FieldValueDisplayText(object sender, DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs e)
        {
            if (e.ValueType == PivotGridValueType.Value && e.Field != null && e.Field.Caption == "Sistem Pendeteksi")
            {
                if (e.Value != null)
                {
                    e.DisplayText = EnumHelper.EnumRecognitionToString((EnumRecognition)e.Value);
                }
            }
        }

        private void _pivotGridControl_CustomCellDisplayText(object sender, DevExpress.XtraPivotGrid.PivotCellDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                e.DisplayText = "0";
            }
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>()
        {
            if (FilterPopUp3.EditValue != null)
                this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<EmployeeRecognitionView>();
        }
    }
}

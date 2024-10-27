using DevExpress.XtraEditors.DXErrorProvider;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System;
using Domain.Entities.SQLView.Finance;
using Domain;
using Domain.Entities.Finance;

namespace VSudoTrans.DESKTOP.Report.Finance
{
    public partial class frmBudgetTransactionPV : frmBasePV
    {
        public frmBudgetTransactionPV()
        {
            InitializeComponent();

            EndPoint = "/SQLViews/BudgetTransactionViews";
            FormTitle = "Keuangan (Pivot Table)";

            OdataSelect = "*";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            HelperConvert.FormatDateTextEdit(YearTextEdit, "yyyy");
            HelperConvert.FormatDateTextEdit(MonthTextEdit, "MMMM");

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<BudgetTransactionView>();
            bbiRefresh.ItemClick += BbiRefresh_ItemClick;

            pivotGridFieldCompanyName.BestFit();
            pivotGridFieldUnitMeasureName.BestFit();
            pivotGridFieldQuantity.BestFit();
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);

            _LayoutControlItemFilter4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter4.Text = "Indikator";
            SLUHelper.SetEnumDataSource<EnumTransactionIndicator>(FilterPopUp4, EnumHelper.EnumTransactionIndicatorToString);

            _LayoutControlItemFilter5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter5.Text = "Kategori";
            PopupEditHelper.General<Category>(fEndPoint: "/Categorys", fTitle: "Kategori", fControl: FilterPopUp5, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama", fWidthColumn: "250;100;400", fDisplayText: "Code;Name");

            _LayoutControlItemFilter8.Text = "Tahun";
            _LayoutControlItemFilter9.Text = "Bulan";
        }

        protected override void ActionRefresh<T>()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;
            
            OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            if (FilterPopUp4.EditValue != null)
                OdataFilter += $"and Indicator eq '{FilterPopUp4.EditValue}' ";

            if (FilterPopUp5.EditValue != null)
                OdataFilter += $"and CategoryId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp5.EditValue, "Id"))} ";

            if (YearTextEdit.EditValue != null)
                OdataFilter += $"and Year eq {HelperConvert.Date(YearTextEdit.EditValue).Year} ";

            if (MonthTextEdit.EditValue != null)
                OdataFilter += $"and Month eq {HelperConvert.Date(MonthTextEdit.EditValue).Month} ";

            base.ActionRefresh<T>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<BudgetTransactionView>();
        }
    }
}

using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Finance;
using PopUpUtils;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Finance
{
    public partial class frmBudgetRegulationLV : frmBaseFilterLV
    {
        public frmBudgetRegulationLV()
        {
            InitializeComponent();

            EndPoint = "/BudgetRegulations";
            FormTitle = "Rencana Anggaran Pendapatan Dan Belanja Perusahaan (RAPBS)";

            OdataSelect = "Id,Year,Indicator,Code,Name";
            OdataExpand = "Company($select=name)";
            OdataExpand += ",BudgetRegulationDetails($select=Amount;$expand=Category($select=code,name))";

            InitializeComponentAfter<BudgetRegulation>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;

            GridHelper.GridViewInitializeLayout(_GridViewDetail);
            _GridViewDetail.OptionsView.ShowFooter = true;
            _GridViewDetail.ViewCaption = "Detail Anggaran";
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<BudgetRegulation>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<BudgetRegulation>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmBudgetRegulationDV(EntityId, EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>(endPoint);
        }
    }
}

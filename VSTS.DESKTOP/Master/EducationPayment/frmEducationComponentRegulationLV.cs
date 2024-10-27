using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.EducationPayment;
using PopUpUtils;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Master.EducationPayment
{
    public partial class frmEducationComponentRegulationLV : frmBaseFilterLV
    {
        public frmEducationComponentRegulationLV()
        {
            InitializeComponent();

            this.EndPoint = "/EducationComponentRegulations";
            this.FormTitle = "Peraturan Mata Anggaran";

            this.OdataSelect = "Id,Code,Name";
            this.OdataExpand = "Company($select=name)";
            this.OdataExpand += ",EducationComponentRegulationDetails($select=Amount,NumberOfInstallment,PaymentPerInstallment,Priority;$expand=EducationComponent($select=code,name))";

            InitializeComponentAfter<EducationComponentRegulation>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;

            GridHelper.GridViewInitializeLayout(_GridViewDetail);
            _GridViewDetail.OptionsView.ShowFooter = true;
            _GridViewDetail.ViewCaption = "Detail Peraturan Mata Anggaran";
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colPaymentPerInstallment, typeof(decimal), "n2", fTotal: true);
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<EducationComponentRegulation>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<EducationComponentRegulation>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmEducationComponentRegulationDV(this.EntityId, this.EndPoint, fCopy);
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
            _LayoutControlItemFilter3.Text = "Sekolah";
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

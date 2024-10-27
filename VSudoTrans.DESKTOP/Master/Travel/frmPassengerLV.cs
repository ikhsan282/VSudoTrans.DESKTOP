using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Travel;
using PopUpUtils;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Travel
{
    public partial class frmPassengerLV : frmBaseFilterLV
    {
        public frmPassengerLV()
        {
            InitializeComponent();

            this.EndPoint = "/Passengers";
            this.FormTitle = "Penumpang";

            this.OdataSelect = "Id,PhoneNumber,Email,Code,Name";
            this.OdataExpand = "Company($select=code,name)";

            InitializeComponentAfter<Passenger>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<Passenger>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Passenger>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmPassengerDV(this.EntityId, this.EndPoint, fCopy);
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

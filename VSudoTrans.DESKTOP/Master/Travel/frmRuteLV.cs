using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Travel;
using PopUpUtils;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Travel
{
    public partial class frmRuteLV : frmBaseFilterLV
    {
        public frmRuteLV()
        {
            InitializeComponent();

            this.EndPoint = "/Rutes";
            this.FormTitle = "Konfigurasi Rute";

            this.OdataSelect = "Id,Code,Name";
            this.OdataExpand = "Company($select=name)";
            this.OdataExpand += ",PickupPointDistricts($select=DistrictId;$expand=District($select=name))";
            this.OdataExpand += ",DeliveryPointDistricts($select=DistrictId;$expand=District($select=name))";
            this.OdataExpand += ",TravelPrices($select=PriceType,Price,StartCapacitySeat,EndCapacitySeat)";
            this.OdataExpand += ",RuteSchedules($select=scheduleId;$expand=schedule($select=name))";

            InitializeComponentAfter<Rute>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;

            GridHelper.GridViewInitializeLayout(_GridViewPickup);
            _GridViewPickup.ViewCaption = "Radius Penjemputan";
            GridHelper.GridViewInitializeLayout(_GridViewDelivery);
            _GridViewDelivery.ViewCaption = "Radius Pengantaran";
            GridHelper.GridViewInitializeLayout(_GridViewRuteSchedule);
            _GridViewRuteSchedule.ViewCaption = "Jadwal";
            GridHelper.GridViewInitializeLayout(_GridViewTravelPrice);
            _GridViewTravelPrice.ViewCaption = "Harga";
            GridHelper.GridColumnInitializeLayout(colPrice, typeof(decimal), "n0");
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<Rute>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Rute>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmRuteDV(this.EntityId, this.EndPoint, fCopy);
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

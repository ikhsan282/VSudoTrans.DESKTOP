using Domain.Entities.Travel;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Master.Travel
{
    public partial class frmRuteLV : frmBaseLV
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
    }
}

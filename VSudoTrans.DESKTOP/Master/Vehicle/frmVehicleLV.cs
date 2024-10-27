using Domain.Entities.Vehicle;
using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmVehicleLV : frmBaseLV
    {
        public frmVehicleLV()
        {
            InitializeComponent();

            this.EndPoint = "/Vehicles";
            this.FormTitle = "Kendaraan";

            this.OdataSelect = "Id,VehicleNumber";
            this.OdataExpand = "Company($select=name)";
            this.OdataExpand += ",Brand($select=name)";
            this.OdataExpand += ",ModelUnit($select=name)";

            InitializeComponentAfter<Vehicles>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<Vehicles>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Vehicles>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmVehicleDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

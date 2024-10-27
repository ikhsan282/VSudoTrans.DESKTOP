using Domain.Entities.Vehicle;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Master.Vehicle;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmBrandLV : frmBaseLV
    {
        public frmBrandLV()
        {
            InitializeComponent();

            this.EndPoint = "/BrandVehicles";
            this.FormTitle = "Merek";

            this.OdataSelect = "Id,Code,Name";

            InitializeComponentAfter<BrandVehicle>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<BrandVehicle>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<BrandVehicle>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmBrandDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

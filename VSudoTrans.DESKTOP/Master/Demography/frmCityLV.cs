using Domain.Entities.Demography;
using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Demography
{
    public partial class frmCityLV : frmBaseLV
    {
        public frmCityLV()
        {
            InitializeComponent();

            this.EndPoint = "/Citys";
            this.FormTitle = "Kotamadya/Kabupaten";

            this.OdataSelect = "Id,Code,Name";
            this.OdataExpand = "Province($select=name)";

            InitializeComponentAfter<City>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<City>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<City>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmCityDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

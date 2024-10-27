using Domain.Entities.Vehicle;
using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmModelUnitLV : frmBaseLV
    {
        public frmModelUnitLV()
        {
            InitializeComponent();

            this.EndPoint = "/ModelUnits";
            this.FormTitle = "Model Unit";

            this.OdataSelect = "Id,Code,Name";
            this.OdataExpand = "Brand($select=name)";

            InitializeComponentAfter<ModelUnit>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<ModelUnit>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<ModelUnit>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmModelUnitDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

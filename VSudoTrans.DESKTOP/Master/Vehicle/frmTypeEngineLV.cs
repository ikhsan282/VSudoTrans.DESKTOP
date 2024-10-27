using Domain.Entities.Vehicle;
using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmTypeEngineLV : frmBaseLV
    {
        public frmTypeEngineLV()
        {
            InitializeComponent();

            this.EndPoint = "/TypeEngines";
            this.FormTitle = "Tipe Mesin";

            this.OdataSelect = "Id,Code,Name";

            InitializeComponentAfter<TypeEngine>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<TypeEngine>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<TypeEngine>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmTypeEngineDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

using Domain.Entities.Demography;
using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Master.Demography
{
    public partial class frmDistrictLV : frmBaseLV
    {
        public frmDistrictLV()
        {
            InitializeComponent();

            this.EndPoint = "/Districts";
            this.FormTitle = "Kecamatan";

            this.OdataSelect = "Id,Code,Name";
            this.OdataExpand = "City($select=name)";

            InitializeComponentAfter<District>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<District>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<District>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmDistrictDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

using Domain.Entities.Demography;
using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.Demography
{
    public partial class frmProvinceLV : frmBaseLV
    {
        public frmProvinceLV()
        {
            InitializeComponent();

            this.EndPoint = "/Provinces";
            this.FormTitle = "Provinsi";

            this.OdataSelect = "Id,Code,Name";
            this.OdataExpand = "Country($select=name)";

            InitializeComponentAfter<Province>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<Province>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Province>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmProvinceDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

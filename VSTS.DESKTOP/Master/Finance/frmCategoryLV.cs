using Domain.Entities.Finance;
using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.Finance
{
    public partial class frmCategoryLV : frmBaseLV
    {
        public frmCategoryLV()
        {
            InitializeComponent();

            EndPoint = "/Categorys";
            FormTitle = "Kategori";

            OdataSelect = "Id,Code,Name";
            OdataExpand = "Company($select=name)";

            InitializeComponentAfter<Category>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<Category>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Category>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmCategoryDV(EntityId, EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

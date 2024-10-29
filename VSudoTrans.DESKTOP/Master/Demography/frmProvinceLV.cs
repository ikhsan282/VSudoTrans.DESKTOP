using Domain.Entities.Demography;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Demography
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

            var roleNames = ApplicationSettings.Instance.UserRoles.Select(s => s.Name);
            if (roleNames.FirstOrDefault(s => s == "Super Administrator") == null)
            {
                bbiNew.Enabled = false;
                bbiEdit.Enabled = false;
                bbiDelete.Enabled = false;
                bbiImportData.Enabled = false;
            }
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

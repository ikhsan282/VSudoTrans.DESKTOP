using Domain.Entities.Demography;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Demography
{
    public partial class frmVillageLV : frmBaseLV
    {
        public frmVillageLV()
        {
            InitializeComponent();

            this.EndPoint = "/Villages";
            this.FormTitle = "Kelurahan";

            this.OdataSelect = "Id,Code,Name";
            this.OdataExpand = "District($select=name)";

            InitializeComponentAfter<Village>();

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
            ActionDelete<Village>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Village>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmVillageDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

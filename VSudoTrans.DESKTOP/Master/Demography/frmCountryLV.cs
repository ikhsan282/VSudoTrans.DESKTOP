using Domain.Entities.Demography;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Demography
{
    public partial class frmCountryLV : frmBaseLV
    {
        public frmCountryLV()
        {
            InitializeComponent();

            this.EndPoint = "/Countrys";
            this.FormTitle = "Negara";

            this.OdataSelect = "Id,Code,Name";

            InitializeComponentAfter<Country>();

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
            ActionDelete<Country>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Country>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmCountryDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

using Domain.Entities.Demography;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

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

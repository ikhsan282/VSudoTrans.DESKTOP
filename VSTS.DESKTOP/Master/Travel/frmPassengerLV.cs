using VSTS.DESKTOP.BaseForm;
using Domain.Entities.Travel;

namespace VSTS.DESKTOP.Master.Travel
{
    public partial class frmPassengerLV : frmBaseLV
    {
        public frmPassengerLV()
        {
            InitializeComponent();

            this.EndPoint = "/Passengers";
            this.FormTitle = "Penumpang";

            this.OdataSelect = "Id,PhoneNumber,Email,Code,Name";
            this.OdataExpand = "Company($select=code,name)";

            InitializeComponentAfter<Passenger>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<Passenger>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Passenger>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmPassengerDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

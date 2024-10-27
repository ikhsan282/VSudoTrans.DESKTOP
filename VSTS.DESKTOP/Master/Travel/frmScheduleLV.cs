using Domain.Entities.Travel;
using VSTS.DESKTOP.BaseForm;

namespace VSTS.DESKTOP.Master.Travel
{
    public partial class frmScheduleLV : frmBaseLV
    {
        public frmScheduleLV()
        {
            InitializeComponent();

            this.EndPoint = "/Schedules";
            this.FormTitle = "Jadwal";


            this.OdataSelect = "Id,Code,Name,Start,End,StartBreak,EndBreak,Duration,TotalDuration";
            this.OdataExpand = "Company($select=name)";

            InitializeComponentAfter<Schedule>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<Schedule>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Schedule>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmScheduleDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

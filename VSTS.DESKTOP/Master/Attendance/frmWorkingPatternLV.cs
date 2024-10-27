using VSTS.DESKTOP.BaseForm;
using Domain.Entities.Attendance;
using VSTS.DESKTOP.Utils;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;

namespace VSTS.DESKTOP.Master.Attendance
{
    public partial class frmWorkingPatternLV : frmBaseFilterLV
    {
        public frmWorkingPatternLV()
        {
            InitializeComponent();

            this.EndPoint = "/WorkingPatterns";
            this.FormTitle = "Pola Kerja";

            this.OdataSelect = "Id,Code,Name,CycleLength,WorkingDay";
            this.OdataExpand = "Company($select=name), ";
            this.OdataExpand += "WorkingPatternDetails($select=CycleNo;$expand=Shift($select=code,name,Type))";

            InitializeComponentAfter<WorkingPattern>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            GridHelper.GridViewInitializeLayout(_GridViewDetail);
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<WorkingPattern>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<WorkingPattern>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmWorkingPatternDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>(endPoint);
        }
    }
}

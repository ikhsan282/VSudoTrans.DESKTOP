using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Attendance;
using PopUpUtils;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Master.Attendance
{
    public partial class frmAttendanceSettingRangeLV : frmBaseFilterLV
    {
        public frmAttendanceSettingRangeLV()
        {
            InitializeComponent();

            this.EndPoint = "/AttendanceSettingRanges";
            this.FormTitle = "Toleransi Absensi";

            this.OdataSelect = "Id,BeforeIn,AfterIn,BeforeOut,AfterOut";
            this.OdataExpand = "Company($select=name)";

            InitializeComponentAfter<AttendanceSettingRange>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<AttendanceSettingRange>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<AttendanceSettingRange>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmAttendanceSettingRangeDV(this.EntityId, this.EndPoint, fCopy);
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

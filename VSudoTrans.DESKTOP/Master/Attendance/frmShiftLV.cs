using VSudoTrans.DESKTOP.BaseForm;
using Domain.Entities.Attendance;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Attendance
{
    public partial class frmShiftLV : frmBaseFilterLV
    {
        public frmShiftLV()
        {
            InitializeComponent();

            this.EndPoint = "/Shifts";
            this.FormTitle = "Jadwal Kerja";

            OdataSelect = "Id,StartWorkHour,EndWorkHour,StartBreakHour,EndBreakHour,TotalWorkHour,Type,Code,Name,Note";
            this.OdataExpand = "Company($select=name)";

            InitializeComponentAfter<Shift>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<Shift>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Shift>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmShiftDV(this.EntityId, this.EndPoint, fCopy);
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
            _LayoutControlItemFilter3.Text = "Perusahaan";
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

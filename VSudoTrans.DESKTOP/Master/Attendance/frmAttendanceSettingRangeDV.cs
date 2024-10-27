using Domain.Entities.Attendance;
using Domain;
using System.Threading.Tasks;
using VSudoTrans.DESKTOP.Utils;
using VSudoTrans.DESKTOP.BaseForm;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Organization;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.Attendance
{
    public partial class frmAttendanceSettingRangeDV : frmBaseDV
    {
        AttendanceSettingRange _AttendanceSettingRange;
        public frmAttendanceSettingRangeDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<AttendanceSettingRange>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;
            InitializeSearchLookup();

            HelperConvert.FormatSpinEdit(BeforeInSpinEdit, "n0", 0, 480);
            HelperConvert.FormatSpinEdit(AfterInSpinEdit, "n0", 0, 480);
            HelperConvert.FormatSpinEdit(BeforeOutSpinEdit, "n0", 0, 480);
            HelperConvert.FormatSpinEdit(AfterOutSpinEdit, "n0", 0, 480);
            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.BeforeInSpinEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.AfterInSpinEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.BeforeOutSpinEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.AfterOutSpinEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
        }


        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("BeforeIn");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<AttendanceSettingRange>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<AttendanceSettingRange>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<AttendanceSettingRange>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _AttendanceSettingRange = OdataEntity as AttendanceSettingRange;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _AttendanceSettingRange = new AttendanceSettingRange()
            {
                Id = _AttendanceSettingRange.Id,
                BeforeIn = HelperConvert.Int(BeforeInSpinEdit.EditValue),
                BeforeOut = HelperConvert.Int(BeforeOutSpinEdit.EditValue),
                AfterIn = HelperConvert.Int(AfterInSpinEdit.EditValue),
                AfterOut = HelperConvert.Int(AfterOutSpinEdit.EditValue),
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))
            };
            OdataEntity = _AttendanceSettingRange;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<AttendanceSettingRange>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<AttendanceSettingRange>();
        }
    }
}

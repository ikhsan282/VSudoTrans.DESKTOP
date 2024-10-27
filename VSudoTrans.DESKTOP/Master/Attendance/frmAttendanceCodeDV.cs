using VSudoTrans.DESKTOP.BaseForm;
using Domain.Entities.Attendance;
using VSudoTrans.DESKTOP.Utils;
using Domain;
using System;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.Attendance
{
    public partial class frmAttendanceCodeDV : frmBaseDV
    {
        AttendanceCode _AttendanceCode;
        public frmAttendanceCodeDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<AttendanceCode>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;
            InitializeSearchLookup();

            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");

            GroupTypeSearchLookUpEdit.EditValueChanged += GroupTypeSearchLookUpEdit_EditValueChanged;
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _AttendanceCode = OdataEntity as AttendanceCode;

            if (_AttendanceCode != null)
            {
                GroupTypeSearchLookUpEdit.EditValue = _AttendanceCode.GroupType;
                AssignmentTypeSearchLookUpEdit.EditValue = _AttendanceCode.AssignmentType;
            }
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.GroupTypeSearchLookUpEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.AssignmentTypeSearchLookUpEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DurationDayTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.GenderSearchLookUpEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);

            SetDataSourceAbsenceTypes();
            SLUHelper.SetEnumDataSource<EnumGender>(GenderSearchLookUpEdit, EnumHelper.EnumGenderAttendanceCodeToString);
        }

        #region Set Datasource Enum Type

        private void SetDataSourceAbsenceTypes()
        {
            GroupTypeSearchLookUpEdit.EditValue = "";
            GroupTypeSearchLookUpEdit.Properties.NullText = "";
            SLUHelper.SetEnumDataSource(GroupTypeSearchLookUpEdit, new Converter<EnumAbsenceType, string>(EnumHelper.EnumGroupAbsenceAssignmentTypeToString));
        }

        private void SetDataSourceAssignmentTypes(EnumAbsenceType? enumAbsenceType)
        {
            AssignmentTypeSearchLookUpEdit.Properties.DataSource = null;

            switch (enumAbsenceType)
            {
                case EnumAbsenceType.CT:
                    SLUHelper.SetEnumDataSource(AssignmentTypeSearchLookUpEdit, new Converter<EnumAbsenceAssignmentType, string>(EnumHelper.EnumYearlyAbsenceAssignmentTypeToString));
                    break;
                case EnumAbsenceType.CK:
                    SLUHelper.SetEnumDataSource(AssignmentTypeSearchLookUpEdit, new Converter<EnumAbsenceAssignmentType, string>(EnumHelper.EnumSpecialAbsenceAssignmentTypeToString));
                    break;
                case EnumAbsenceType.S:
                    SLUHelper.SetEnumDataSource(AssignmentTypeSearchLookUpEdit, new Converter<EnumAbsenceAssignmentType, string>(EnumHelper.EnumSickAbsenceAssignmentTypeToString));
                    break;
                case EnumAbsenceType.P:
                    SLUHelper.SetEnumDataSource(AssignmentTypeSearchLookUpEdit, new Converter<EnumAbsenceAssignmentType, string>(EnumHelper.EnumPermitAbsenceAssignmentTypeToString));
                    break;
                case EnumAbsenceType.D:
                    SLUHelper.SetEnumDataSource(AssignmentTypeSearchLookUpEdit, new Converter<EnumAbsenceAssignmentType, string>(EnumHelper.EnumBusinessTripAbsenceAssignmentTypeToString));
                    break;
                case EnumAbsenceType.H:
                    SLUHelper.SetEnumDataSource(AssignmentTypeSearchLookUpEdit, new Converter<EnumAbsenceAssignmentType, string>(EnumHelper.EnumPresenceAbsenceAssignmentTypeToString));
                    break;
                case EnumAbsenceType.M:
                    SLUHelper.SetEnumDataSource(AssignmentTypeSearchLookUpEdit, new Converter<EnumAbsenceAssignmentType, string>(EnumHelper.EnumLeaveAbsenceAssignmentTypeToString));
                    break;
                case EnumAbsenceType.L:
                    SLUHelper.SetEnumDataSource(AssignmentTypeSearchLookUpEdit, new Converter<EnumAbsenceAssignmentType, string>(EnumHelper.EnumLiburAbsenceAssignmentTypeToString));
                    break;
                default:
                    AssignmentTypeSearchLookUpEdit.Properties.DataSource = null;
                    break;
            }
        }
        #endregion

        private void GroupTypeSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            AssignmentTypeSearchLookUpEdit.EditValue = null;

            if (GroupTypeSearchLookUpEdit.EditValue != null)
            {
                EnumAbsenceType? enumAbsenceType = GroupTypeSearchLookUpEdit.EditValue as EnumAbsenceType?;
                SetDataSourceAssignmentTypes(enumAbsenceType);
            }
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<AttendanceCode>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<AttendanceCode>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<AttendanceCode>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _AttendanceCode = new AttendanceCode()
            {
                Id = _AttendanceCode.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                GroupType = (EnumAbsenceType)GroupTypeSearchLookUpEdit.EditValue,
                AssignmentType = (EnumAbsenceAssignmentType)AssignmentTypeSearchLookUpEdit.EditValue,
                DurationDay = HelperConvert.Decimal(DurationDayTextEdit.EditValue),
                Gender = (EnumGender)GenderSearchLookUpEdit.EditValue,
                MaxLeave = HelperConvert.Int(MaxLeaveTextEdit.EditValue)
            };
            OdataEntity = _AttendanceCode;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<AttendanceCode>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<AttendanceCode>();
        }
    }
}

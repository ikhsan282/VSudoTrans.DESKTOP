using Domain;
using Domain.Entities.Attendance;
using Domain.Entities.HumanResource;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using System;
using System.Globalization;

namespace VSTS.DESKTOP.Transaction.Attendance
{
    public partial class frmRosterDetailDV : frmBaseDV
    {
        private Employee employee;
        private DateTime dateRoster;
        private Roster _Roster;
        public DateTime startTime;
        public DateTime endTime;
        public DateTime startTimeBreak;
        public DateTime endTimeBreak;
        public frmRosterDetailDV(object id, int employeeId, string dateStringRoster)
        {
            this.EntityId = id;

            InitializeComponent();

            DateTime.TryParseExact(dateStringRoster, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRoster);

            HelperConvert.FormatDateTextEdit(DateTextEdit, "dd-MMM-yyyy");
            HelperConvert.FormatDateTextEdit(SStartTimeTextEdit);
            HelperConvert.FormatDateTextEdit(SEndTimeTextEdit);
            HelperConvert.FormatDateTextEdit(AStartTimeTextEdit);
            HelperConvert.FormatDateTextEdit(AEndTimeTextEdit);
            //HelperConvert.FormatDateTextEdit(SBeforeStartTimeDateEdit);
            //HelperConvert.FormatDateTextEdit(SBeforeEndTimeDateEdit);
            //HelperConvert.FormatDateTextEdit(SAfterStartTimeDateEdit);
            //HelperConvert.FormatDateTextEdit(SAfterEndTimeDateEdit);
            HelperConvert.FormatDateTextEdit(SBreakStartTimeTextEdit);
            HelperConvert.FormatDateTextEdit(SBreakEndTimeTextEdit);

            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");

            //btnAuditTrailDetail.Click += BtnAuditTrailDetail_Click;

            SLUHelper.SetEnumDataSource(DayTypeSearchLookUpEdit, new Converter<EnumDayType, string>(EnumHelper.EnumDayTypeToString));

            FormStatus = enumFormStatus.Edit;

            string fSelect = "*";
            string fExpand = "Company($select=Code,Name)";
            fExpand += ",Employee($select=Code,Name)";
            fExpand += ",Shift($select=Code,Name,StartWorkHour,EndWorkHour)";
            fExpand += ",AttendanceCode($select=Code,Name)";
            fExpand += ",PermitCode($select=Code,Name)";

            _Roster = HelperRestSharp.GetOdata<Roster>("/Rosters", fSelect: fSelect, fExpand: fExpand, fFilter: $"Id eq {id}");
            if (_Roster != null)
            {
                if (_Roster.Company != null)
                    CompanyTextEdit.EditValue = $"{_Roster.Company.Code} - {_Roster.Company.Name}";

                if (_Roster.Employee != null)
                    EmployeeTextEdit.EditValue = $"{_Roster.Employee.Code} - {_Roster.Employee.Name}";

                if (_Roster.AttendanceCode != null)
                    AttendanceCodeTextEdit.EditValue = $"{_Roster.AttendanceCode.Code} - {_Roster.AttendanceCode.Name}";

                if (_Roster.PermitCode != null)
                    PermitCodeTextEdit.EditValue = $"{_Roster.PermitCode.Code} - {_Roster.PermitCode.Name}";

                if (_Roster.Shift != null)
                    ShiftTextEdit.EditValue = $"{_Roster.Shift.Code} - {_Roster.Shift.Name}";

                DayTypeSearchLookUpEdit.EditValue = _Roster.DayType;

                DateTextEdit.EditValue = _Roster.Date;

                SStartTimeTextEdit.EditValue = _Roster.SStartTime;
                SEndTimeTextEdit.EditValue = _Roster.SEndTime;

                AStartTimeTextEdit.EditValue = _Roster.AStartTime;
                AEndTimeTextEdit.EditValue = _Roster.AEndTime;

                SBreakStartTimeTextEdit.EditValue = _Roster.SBreakStartTime;
                SBreakEndTimeTextEdit.EditValue = _Roster.SBreakEndTime;

                BreakDurationHourTextEdit.EditValue = _Roster.BreakDurationHour;

                WeekNumTextEdit.EditValue = _Roster.WeekNum;

                ADurationHourTimeSpanEdit.EditValue = _Roster.ADurationHour;
                ADurationDayTextEdit.EditValue = _Roster.ADurationDay;

                CreatedDateDateEdit.EditValue = _Roster.CreatedDate;
                ModifiedDateDateEdit.EditValue = _Roster.ModifiedDate;
                CreatedUserTextEdit.EditValue = _Roster.CreatedUser;
                ModifiedUserTextEdit.EditValue = _Roster.ModifiedUser;

                ScheduleWorkingHourSpanEdit.EditValue = TimeSpan.Parse(_Roster.SDurationHour.GetValueOrDefault().ToString()) - TimeSpan.Parse(_Roster.BreakDurationHour.GetValueOrDefault().ToString());
                TotalScheduleWorkingHourSpanEdit.EditValue = _Roster.SDurationHour;
                startTime = HelperConvert.Date(_Roster.SStartTime);
                endTime = HelperConvert.Date(_Roster.SEndTime);
                startTimeBreak = HelperConvert.Date(_Roster.SBreakStartTime);
                endTimeBreak = HelperConvert.Date(_Roster.SBreakEndTime);
                calculateTotalhour();

                this.OdataEntity = _Roster;
            }

            InitializeFomTitle();
        }

        private void calculateTotalhour()
        {
            if (_Roster == null)
            {
                return;
            }
            double totBreakHour = 0;


            double totalHourWork = endTime.Subtract(startTime).TotalHours;
            totalHourWork = totalHourWork < 0 ? totalHourWork + 24 : (totalHourWork > 24 ? 0 : totalHourWork);
            if (startTimeBreak != DateTime.MinValue && endTimeBreak != DateTime.MinValue)
            {
                totBreakHour = endTimeBreak.Subtract(startTimeBreak).TotalHours;
                totBreakHour = totBreakHour < 0 ? totBreakHour + 24 : (totBreakHour > 24 ? 0 : totBreakHour);
            }
            var totHour = (totalHourWork - totBreakHour) < 0 ? 0 : (totalHourWork - totBreakHour);
            TotalScheduleWorkingHourSpanEdit.Text = decimal.Round(HelperConvert.Decimal(totHour), 2).ToString();
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("IDate");
        }
    }
}

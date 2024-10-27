using VSTS.DESKTOP.BaseForm;
using Domain.Entities.Attendance;
using System.Threading.Tasks;
using VSTS.DESKTOP.Utils;
using Domain;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Organization;
using System;
using PopUpUtils;

namespace VSTS.DESKTOP.Master.Attendance
{
    public partial class frmShiftDV : frmBaseDV
    {
        Shift _Shift;
        public double totBreakHour { get; set; } = 0;
        public DateTime startTime;
        public DateTime endTime;
        public DateTime startTimeBreak;
        public DateTime endTimeBreak;
        public frmShiftDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Shift>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;
            InitializeSearchLookup();

            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");

            HelperConvert.FormatDateTextEdit(StartWorkHourTextEdit, "HH:mm");
            HelperConvert.FormatDateTextEdit(EndWorkHourTextEdit, "HH:mm");
            HelperConvert.FormatDateTextEdit(StartBreakHourTextEdit, "HH:mm");
            HelperConvert.FormatDateTextEdit(EndBreakHourTextEdit, "HH:mm");

            StartWorkHourTextEdit.EditValueChanging += StartWorkHourTextEdit_EditValueChanging;
            EndWorkHourTextEdit.EditValueChanging += EndWorkHourTextEdit_EditValueChanging;
            StartBreakHourTextEdit.EditValueChanging += StartBreakHourTextEdit_EditValueChanging;
            EndBreakHourTextEdit.EditValueChanging += EndBreakHourTextEdit_EditValueChanging;
        }

        private void EndBreakHourTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime.TryParse(e.NewValue.ToString(), out endTimeBreak);
            calculateTotalHour();
        }

        private void StartBreakHourTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime.TryParse(e.NewValue.ToString(), out startTimeBreak);
            calculateTotalHour();
        }

        private void EndWorkHourTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime.TryParse(e.NewValue.ToString(), out endTime);
            calculateTotalHour();
        }

        private void StartWorkHourTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime.TryParse(e.NewValue.ToString(), out startTime);
            calculateTotalHour();
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StartWorkHourTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.EndWorkHourTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StartBreakHourTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.EndBreakHourTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.TypeSearchLookUpEdit, ConditionOperator.IsNotBlank);
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Shift = OdataEntity as Shift;
            if (_Shift != null)
            {
                DateTime.TryParse(_Shift.StartWorkHour.ToString(), out startTime);
                DateTime.TryParse(_Shift.EndWorkHour.ToString(), out endTime);
                DateTime.TryParse(_Shift.StartBreakHour.ToString(), out startTimeBreak);
                DateTime.TryParse(_Shift.EndBreakHour.ToString(), out endTimeBreak);
                StartWorkHourTextEdit.EditValue = startTime;
                EndWorkHourTextEdit.EditValue = endTime;
                StartBreakHourTextEdit.EditValue = startTimeBreak;
                EndBreakHourTextEdit.EditValue = endTimeBreak;
                calculateTotalHour();

                totBreakHour = endTimeBreak.Subtract(startTimeBreak).TotalHours;

                this.TotalWorkHourTextEdit.EditValue = _Shift.TotalWorkHour;
            }
        }

        private void calculateTotalHour()
        {
            if (_Shift == null)
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
            TotalWorkHourTextEdit.Text = decimal.Round(HelperConvert.Decimal(totHour), 2).ToString();
        }


        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            DateTime startTime;
            DateTime endTime;
            DateTime startTimeBreak;
            DateTime endTimeBreak;

            DateTime.TryParse(HelperConvert.Date(StartWorkHourTextEdit.EditValue).ToString(), out startTime);
            DateTime.TryParse(HelperConvert.Date(EndWorkHourTextEdit.EditValue).ToString(), out endTime);
            DateTime.TryParse(HelperConvert.Date(StartBreakHourTextEdit.EditValue).ToString(), out startTimeBreak);
            DateTime.TryParse(HelperConvert.Date(EndBreakHourTextEdit.EditValue).ToString(), out endTimeBreak);


            DateTime start = startTime;
            DateTime end = endTime < start ? endTime.AddDays(1) : endTime;
            DateTime startBreak = startTimeBreak;
            DateTime endBreak = endTimeBreak < startBreak ? endTimeBreak.AddDays(1) : endTimeBreak;

            this.StartBreakHourTextEdit.ErrorText = "";
            this.EndBreakHourTextEdit.ErrorText = "";
            if (startBreak < start && startBreak < end)
            {
                this.StartBreakHourTextEdit.ErrorText = "Nilai tidak valid (jam mulai istirahat harus setelah jam masuk kerja)";
                result = false;
            }
            else if (startBreak > end && startBreak > start)
            {
                this.StartBreakHourTextEdit.ErrorText = "Nilai tidak valid (jam mulai istirahat harus sebelum jam pulang kerja)";
                result = false;
            }
            else if (endBreak > end && endBreak > start)
            {
                this.EndBreakHourTextEdit.ErrorText = "Nilai tidak valid (jam selesai istirahat harus sebelum jam pulang kerja)";
                result = false;
            }
            else if (endBreak < start && endBreak < end)
            {
                this.EndBreakHourTextEdit.ErrorText = "Nilai tidak valid (jam selesai istirahat harus setelah jam masuk kerja)";
                result = false;
            }
            return result;
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);

            SLUHelper.SetEnumDataSource(TypeSearchLookUpEdit, new Converter<EnumDayType, string>(EnumHelper.EnumDayTypeToString));
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Shift>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Shift>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Shift>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Shift = new Shift()
            {
                Id = _Shift.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                Type = (EnumDayType)TypeSearchLookUpEdit.EditValue,
                StartWorkHour = HelperConvert.Date(StartWorkHourTextEdit.EditValue).TimeOfDay,
                EndWorkHour = HelperConvert.Date(EndWorkHourTextEdit.EditValue).TimeOfDay,
                StartBreakHour = HelperConvert.Date(StartBreakHourTextEdit.EditValue).TimeOfDay,
                EndBreakHour = HelperConvert.Date(EndBreakHourTextEdit.EditValue).TimeOfDay,
                TotalWorkHour = HelperConvert.Decimal(TotalWorkHourTextEdit.EditValue),
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))
            };

            OdataEntity = _Shift;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Shift>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Shift>();
        }
    }
}

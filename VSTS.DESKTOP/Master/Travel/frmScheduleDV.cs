using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Organization;
using Domain.Entities.Travel;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using PopUpUtils;
using System;
using System.Threading.Tasks;

namespace VSTS.DESKTOP.Master.Travel
{
    public partial class frmScheduleDV : frmBaseDV
    {
        Schedule _Schedule;
        public double totBreak { get; set; } = 0;
        public DateTime startTime;
        public DateTime endTime;
        public DateTime startTimeBreak;
        public DateTime endTimeBreak;
        public frmScheduleDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Schedule>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;
            InitializeSearchLookup();

            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");

            HelperConvert.FormatDateTextEdit(StartTextEdit, "HH:mm");
            HelperConvert.FormatDateTextEdit(EndTextEdit, "HH:mm");
            HelperConvert.FormatDateTextEdit(StartBreakTextEdit, "HH:mm");
            HelperConvert.FormatDateTextEdit(EndBreakTextEdit, "HH:mm");

            StartTextEdit.EditValueChanging += StartTextEdit_EditValueChanging;
            EndTextEdit.EditValueChanging += EndTextEdit_EditValueChanging;
            StartBreakTextEdit.EditValueChanging += StartBreakTextEdit_EditValueChanging;
            EndBreakTextEdit.EditValueChanging += EndBreakTextEdit_EditValueChanging;
        }

        private void EndBreakTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime.TryParse(e.NewValue.ToString(), out endTimeBreak);
            calculateTotal();
        }

        private void StartBreakTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime.TryParse(e.NewValue.ToString(), out startTimeBreak);
            calculateTotal();
        }

        private void EndTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime.TryParse(e.NewValue.ToString(), out endTime);
            calculateTotal();
        }

        private void StartTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DateTime.TryParse(e.NewValue.ToString(), out startTime);
            calculateTotal();
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StartTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.EndTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StartBreakTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.EndBreakTextEdit, ConditionOperator.IsNotBlank);
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Schedule = OdataEntity as Schedule;
            if (_Schedule != null)
            {
                DateTime.TryParse(_Schedule.Start.ToString(), out startTime);
                DateTime.TryParse(_Schedule.End.ToString(), out endTime);
                DateTime.TryParse(_Schedule.StartBreak.ToString(), out startTimeBreak);
                DateTime.TryParse(_Schedule.EndBreak.ToString(), out endTimeBreak);
                StartTextEdit.EditValue = startTime;
                EndTextEdit.EditValue = endTime;
                StartBreakTextEdit.EditValue = startTimeBreak;
                EndBreakTextEdit.EditValue = endTimeBreak;
                calculateTotal();

                totBreak = endTimeBreak.Subtract(startTimeBreak).TotalHours;

                this.DurationTextEdit.EditValue = _Schedule.Duration;
                this.TotalDurationTextEdit.EditValue = _Schedule.TotalDuration;
            }
        }

        private void calculateTotal()
        {
            if (_Schedule == null)
            {
                return;
            }

            double totBreak = 0;

            double total = endTime.Subtract(startTime).TotalHours;
            total = total < 0 ? total + 24 : (total > 24 ? 0 : total);
            TotalDurationTextEdit.Text = decimal.Round(HelperConvert.Decimal(total), 2).ToString();

            if (startTimeBreak != DateTime.MinValue && endTimeBreak != DateTime.MinValue)
            {
                totBreak = endTimeBreak.Subtract(startTimeBreak).TotalHours;
                totBreak = totBreak < 0 ? totBreak + 24 : (totBreak > 24 ? 0 : totBreak);
            }

            var tot = (total - totBreak) < 0 ? 0 : (total - totBreak);
            DurationTextEdit.Text = decimal.Round(HelperConvert.Decimal(tot), 2).ToString();
        }


        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            DateTime startTime;
            DateTime endTime;
            DateTime startTimeBreak;
            DateTime endTimeBreak;

            DateTime.TryParse(HelperConvert.Date(StartTextEdit.EditValue).ToString(), out startTime);
            DateTime.TryParse(HelperConvert.Date(EndTextEdit.EditValue).ToString(), out endTime);
            DateTime.TryParse(HelperConvert.Date(StartBreakTextEdit.EditValue).ToString(), out startTimeBreak);
            DateTime.TryParse(HelperConvert.Date(EndBreakTextEdit.EditValue).ToString(), out endTimeBreak);


            DateTime start = startTime;
            DateTime end = endTime < start ? endTime.AddDays(1) : endTime;
            DateTime startBreak = startTimeBreak;
            DateTime endBreak = endTimeBreak < startBreak ? endTimeBreak.AddDays(1) : endTimeBreak;

            this.StartBreakTextEdit.ErrorText = "";
            this.EndBreakTextEdit.ErrorText = "";
            if (startBreak < start && startBreak < end)
            {
                this.StartBreakTextEdit.ErrorText = "Nilai tidak valid (jam mulai istirahat harus setelah jam masuk kerja)";
                result = false;
            }
            else if (startBreak > end && startBreak > start)
            {
                this.StartBreakTextEdit.ErrorText = "Nilai tidak valid (jam mulai istirahat harus sebelum jam pulang kerja)";
                result = false;
            }
            else if (endBreak > end && endBreak > start)
            {
                this.EndBreakTextEdit.ErrorText = "Nilai tidak valid (jam selesai istirahat harus sebelum jam pulang kerja)";
                result = false;
            }
            else if (endBreak < start && endBreak < end)
            {
                this.EndBreakTextEdit.ErrorText = "Nilai tidak valid (jam selesai istirahat harus setelah jam masuk kerja)";
                result = false;
            }
            return result;
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Schedule>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Schedule>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Schedule>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Schedule = new Schedule()
            {
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                Start = HelperConvert.Date(StartTextEdit.EditValue).TimeOfDay,
                End = HelperConvert.Date(EndTextEdit.EditValue).TimeOfDay,
                StartBreak = HelperConvert.Date(StartBreakTextEdit.EditValue).TimeOfDay,
                EndBreak = HelperConvert.Date(EndBreakTextEdit.EditValue).TimeOfDay,
                TotalDuration = HelperConvert.Decimal(TotalDurationTextEdit.EditValue),
                Duration = HelperConvert.Decimal(DurationTextEdit.EditValue),
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))
            };

            OdataEntity = _Schedule;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Schedule>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Schedule>();
        }
    }
}

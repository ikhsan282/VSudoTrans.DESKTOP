using VSudoTrans.DESKTOP.BaseForm;
using Domain.Entities.HumanResource;
using VSudoTrans.DESKTOP.Utils;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    public partial class frmJobGradeDV : frmBaseDV
    {
        JobGrade _JobGrade;
        public frmJobGradeDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<JobGrade>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
            HelperConvert.FormatSpinEdit(FromAmountSpinEdit, "n0", 0, 888888888888888);
            HelperConvert.FormatSpinEdit(MidAmountSpinEdit, "n0", 0, 888888888888888);
            HelperConvert.FormatSpinEdit(ToAmountSpinEdit, "n0", 0, 888888888888888);

            FromAmountSpinEdit.EditValueChanged += UpdatedAmountSpinEdit_EditValueChanged;
            ToAmountSpinEdit.EditValueChanged += UpdatedAmountSpinEdit_EditValueChanged;

            MidAmountSpinEdit.ReadOnly = true;
        }

        private void UpdatedAmountSpinEdit_EditValueChanged(object sender, System.EventArgs e)
        {
            if (ToAmountSpinEdit.EditValue != null)
            {
                long fromAmount = HelperConvert.Long(FromAmountSpinEdit.EditValue);
                long toAmount = HelperConvert.Long(ToAmountSpinEdit.EditValue);

                long totalAmount = (toAmount + fromAmount);
                if (totalAmount > 0)
                {
                    double middleValue = totalAmount / 2;
                    long roundedMiddleValue = (long)Math.Round(middleValue);

                    MidAmountSpinEdit.EditValue = roundedMiddleValue;
                }
            }
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FromAmountSpinEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.MidAmountSpinEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ToAmountSpinEdit, ConditionOperator.IsNotBlank);
        }
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            if (FromAmountSpinEdit.EditValue != null && ToAmountSpinEdit.EditValue != null)
            {
                if (HelperConvert.Long(FromAmountSpinEdit.EditValue) >= HelperConvert.Long(ToAmountSpinEdit.EditValue))
                {
                    MessageHelper.ShowMessageError(this, "Jumlah Dari tidak bisa lebih besar dari Jumlah Ke");
                    result = false;
                }
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
            ActionSaveNew<JobGrade>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<JobGrade>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<JobGrade>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _JobGrade = OdataEntity as JobGrade;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _JobGrade = new JobGrade()
            {
                Id = _JobGrade.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                FromAmount = HelperConvert.Long(FromAmountSpinEdit.EditValue),
                MidAmount = HelperConvert.Long(MidAmountSpinEdit.EditValue),
                ToAmount = HelperConvert.Long(ToAmountSpinEdit.EditValue)
            };

            OdataEntity = _JobGrade;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<JobGrade>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<JobGrade>();
        }
    }
}

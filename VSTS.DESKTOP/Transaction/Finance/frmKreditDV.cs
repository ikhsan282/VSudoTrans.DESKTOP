using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using Domain;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;
using Domain.Entities.Finance;
using System;
using Domain.Entities.Shared;
using Domain.Entities.EducationPayment;

namespace VSTS.DESKTOP.Transaction.Finance
{
    public partial class frmKreditDV : frmBaseDV
    {
        BudgetTransaction _BudgetTransaction;
        int _year;
        public frmKreditDV(object id, string endPoint, object copy = null)
        {
            EntityId = id;
            EndPoint = endPoint;
            OdataCopyId = copy;

            InitializeComponent();

            TransactionDateEdit.EditValue = DateTime.Today;

            InitializeComponentAfter<BudgetTransaction>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;
            TransactionDateEdit.EditValueChanged += TransactionDateEdit_EditValueChanged;
            InitializeSearchLookup();

            HelperConvert.FormatDecimalTextEdit(AmountTextEdit, "n0");

            HelperConvert.FormatDateEdit(TransactionDateEdit, "dd-MMM-yyyy");
            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
        }

        private void TransactionDateEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected override void InitializeFomTitle(string fieldNames = "Code")
        {
            base.InitializeFomTitle("EducationComponent.Name;UnitMeasure.Name");
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _BudgetTransaction = OdataEntity as BudgetTransaction;

            if (_BudgetTransaction.StudentEducationPaymentComponentId != null)
            {
                InializeDataReadOnly();
            }
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, DocumentNumberTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, TransactionDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, EducationComponentPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, UnitMeasurePopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, QuantityTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, AmountTextEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            PopupEditHelper.General<UnitMeasure>(fEndPoint: "/UnitMeasures", fTitle: "Satuan Unit", fControl: UnitMeasurePopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama", fWidthColumn: "100;400", fDisplayText: "Code;Name");
            PopupEditHelper.General<EducationComponent>(fEndPoint: "/EducationComponents", fFilter: $"", fTitle: "Mata Anggaran", fControl: EducationComponentPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama", fWidthColumn: "100;400", fDisplayText: "Code;Name");
        }


        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<BudgetTransaction>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<BudgetTransaction>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<BudgetTransaction>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _BudgetTransaction = new BudgetTransaction()
            {
                Id = _BudgetTransaction.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                EducationComponentId = HelperConvert.Int(AssemblyHelper.GetValueProperty(EducationComponentPopUp.EditValue, "Id")),
                UnitMeasureId = HelperConvert.Int(AssemblyHelper.GetValueProperty(UnitMeasurePopUp.EditValue, "Id")),
                Indicator = EnumTransactionIndicator.Kredit,
                Quantity = HelperConvert.Int(QuantityTextEdit.EditValue),
                Amount = HelperConvert.Decimal(AmountTextEdit.EditValue),
                DocumentNumber = HelperConvert.String(DocumentNumberTextEdit.EditValue),
                TransactionDate = HelperConvert.Date(TransactionDateEdit.EditValue),
                Year = HelperConvert.Date(TransactionDateEdit.EditValue).Year,
                Month = HelperConvert.Date(TransactionDateEdit.EditValue).Month,
                Day = HelperConvert.Date(TransactionDateEdit.EditValue).Day,
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
            };
            OdataEntity = _BudgetTransaction;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<BudgetTransaction>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<BudgetTransaction>();
        }
    }
}

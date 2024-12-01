using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using Domain;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;
using Domain.Entities.Finance;
using System;
using Domain.Entities.Shared;

namespace VSudoTrans.DESKTOP.Transaction.Finance
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

            DateEdit.EditValue = DateTime.Today;

            InitializeComponentAfter<BudgetTransaction>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;
            DateEdit.EditValueChanged += DateEdit_EditValueChanged;
            InitializeSearchLookup();

            HelperConvert.FormatDecimalTextEdit(AmountTextEdit, "n0");

            HelperConvert.FormatDateEdit(DateEdit, "dd-MMM-yyyy");
            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
        }

        private void DateEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected override void InitializeFomTitle(string fieldNames = "Code")
        {
            base.InitializeFomTitle("Category.Name;UnitMeasure.Name");
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _BudgetTransaction = OdataEntity as BudgetTransaction;
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, DateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, CategoryPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, UnitMeasurePopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, QuantityTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, AmountTextEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            PopupEditHelper.General<UnitMeasure>(fEndPoint: "/UnitMeasures", fTitle: "Satuan Unit", fControl: UnitMeasurePopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama", fWidthColumn: "100;400", fDisplayText: "Code;Name");
            PopupEditHelper.General<Category>(fEndPoint: "/Categorys", fFilter: $"", fTitle: "Kategori", fControl: CategoryPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama", fWidthColumn: "100;400", fDisplayText: "Code;Name");
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
                CategoryId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CategoryPopUp.EditValue, "Id")),
                UnitMeasureId = HelperConvert.Int(AssemblyHelper.GetValueProperty(UnitMeasurePopUp.EditValue, "Id")),
                Indicator = EnumTransactionIndicator.Kredit,
                Quantity = HelperConvert.Int(QuantityTextEdit.EditValue),
                Amount = HelperConvert.Decimal(AmountTextEdit.EditValue),
                Date = HelperConvert.Date(DateEdit.EditValue),
                Year = HelperConvert.Date(DateEdit.EditValue).Year,
                Month = HelperConvert.Date(DateEdit.EditValue).Month,
                Day = HelperConvert.Date(DateEdit.EditValue).Day,
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

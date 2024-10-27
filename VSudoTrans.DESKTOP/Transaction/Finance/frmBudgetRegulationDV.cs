using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using Domain;
using Domain.Entities.EducationPayment;
using Domain.Entities.Finance;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Transaction.Finance
{
    public partial class frmBudgetRegulationDV : frmBaseDV
    {
        BudgetRegulation _BudgetRegulation;
        List<BudgetRegulationDetail> _BudgetRegulationDetail = new List<BudgetRegulationDetail>();
        public frmBudgetRegulationDV(object id, string endPoint, object copy = null)
        {
            EntityId = id;
            EndPoint = endPoint;
            OdataCopyId = copy;
            InitializeComponent();

            IndicatorSearchLookUpEdit.EditValue = EnumTransactionIndicator.Debit;

            InitializeComponentAfter<BudgetRegulation>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick; 
            
            _GridViewDetail.ValidateRow += _GridViewDetail_ValidateRow;
            _GridViewDetail.RowEditCanceled += _GridViewDetail_RowEditCanceled;
            _GridViewDetail.RowUpdated += _GridViewDetail_RowUpdated;

            FromYearTextEdit.KeyPress += YearTextEdit_KeyPress;
            ToYearTextEdit.KeyPress += YearTextEdit_KeyPress;

            HelperConvert.FormatSpinEdit(AmountSpinEdit, "n0", 0, 9999999999);

            _BindingSourceDetail.DataSource = _BudgetRegulationDetail;

            _GridViewDetail.OptionsView.ShowFooter = true;
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);

            GridHelper.GridViewInitializeLayout(_GridViewDetail);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlDetail, true, true, true, true, true, true, true, true, true, true, true, true);
            _GridViewDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridViewDetail.OptionsBehavior.Editable = true;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            SLUHelper.SetEnumDataSource(IndicatorSearchLookUpEdit, new Converter<EnumTransactionIndicator, string>(EnumHelper.EnumTransactionIndicatorToString));
        }

        private void YearTextEdit_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void _GridViewDetail_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;

            // update dulu id yang bersesuian
            if (!(e.Row is BudgetRegulationDetail row)) return;
            row.EducationComponentId = HelperConvert.Int(AssemblyHelper.GetValueProperty(row.EducationComponent, "Id"));
            row.BudgetRegulationId = _BudgetRegulation.Id;
        }

        private void _GridViewDetail_RowEditCanceled(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;
            GridView view = sender as GridView;

            // update dulu id yang bersesuian
            if (!(e.Row is BudgetRegulationDetail row)) return;

            for (int i = 0; i < view.RowCount; i++)
            {
                if (i != view.GetDataSourceRowIndex(view.FocusedRowHandle))
                {
                    var tempVal = HelperConvert.Int(view.GetRowCellValue(i, "EducationComponentId"));
                    if (row.EducationComponentId > 0)
                    {
                        if (tempVal == row.EducationComponentId)
                        {
                            view.DeleteRow(e.RowHandle);
                            return;
                        }
                    }
                }
            }
        }

        private void _GridViewDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            if (!(gridView.GetFocusedRow() is BudgetRegulationDetail result)) return;

            var EducationComponent = result.EducationComponent;

            if (EducationComponent == null)
            {
                gridView.SetColumnError(colEducationComponent, $"Mata Anggaran tidak boleh kosong");
                e.Valid = false;
                return;
            }

            var amount = result.Amount;

            if (amount <= 0)
            {
                gridView.SetColumnError(colAmount, $"Jumlah tidak boleh 0");
                e.Valid = false;
                return;
            }
            else if (amount > 9999999999)
            {
                gridView.SetColumnError(colAmount, $"Jumlah tidak boleh lebih besar 9.999.999.999");
                e.Valid = false;
                return;
            }

            for (int i = 0; i < gridView.RowCount; i++)
            {
                if (i != gridView.GetDataSourceRowIndex(gridView.FocusedRowHandle))
                {
                    var tempVal = HelperConvert.Int(gridView.GetRowCellValue(i, "EducationComponentId"));
                    if (tempVal == EducationComponent.Id)
                    {
                        gridView.SetColumnError(colEducationComponent, "Adanya duplikasi data Mata Anggaran");
                        e.Valid = false;
                        return;
                    }
                }
            }

            if (e.Valid)
                gridView.ClearColumnErrors();
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, FromYearTextEdit, ConditionOperator.IsNotBlank);
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _BudgetRegulation = OdataEntity as BudgetRegulation;

            if (_BudgetRegulation != null)
            {
                _BudgetRegulationDetail.AddRange(_BudgetRegulation.BudgetRegulationDetails.ToList());
                _BindingSourceDetail.DataSource = _BudgetRegulationDetail;
            }
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            PopupEditHelper.General<EducationComponent>(fEndPoint: "/EducationComponents", fTitle: "Mata Anggaran", fControl: EducationComponentPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama", fWidthColumn: "100;400", fDisplayText: "Code;Name");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<BudgetRegulation>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<BudgetRegulation>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<BudgetRegulation>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _BudgetRegulation = new BudgetRegulation
            {
                Id = _BudgetRegulation.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                FromYear = HelperConvert.Int(FromYearTextEdit.EditValue),
                ToYear = HelperConvert.Int(ToYearTextEdit.EditValue),
                BudgetRegulationDetails = _BudgetRegulationDetail
            };

            if (IndicatorSearchLookUpEdit.EditValue != null)
                _BudgetRegulation.Indicator = (EnumTransactionIndicator)IndicatorSearchLookUpEdit.EditValue;

            OdataEntity = _BudgetRegulation;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<BudgetRegulation>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<BudgetRegulation>();
        }
    }
}

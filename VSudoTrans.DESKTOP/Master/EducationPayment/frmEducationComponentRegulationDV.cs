using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using Domain.Entities.EducationPayment;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.EducationPayment
{
    public partial class frmEducationComponentRegulationDV : frmBaseDV
    {
        EducationComponentRegulation _EducationComponentRegulation;
        List<EducationComponentRegulationDetail> _EducationComponentRegulationDetail = new List<EducationComponentRegulationDetail>();
        public frmEducationComponentRegulationDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;
            InitializeComponent();

            InitializeComponentAfter<EducationComponentRegulation>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick; 
            
            _GridViewDetail.ValidateRow += _GridViewDetail_ValidateRow;
            _GridViewDetail.RowEditCanceled += _GridViewDetail_RowEditCanceled;
            _GridViewDetail.RowUpdated += _GridViewDetail_RowUpdated;

            _BindingSourceDetail.DataSource = _EducationComponentRegulationDetail;

            _GridViewDetail.OptionsView.ShowFooter = true;
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colPaymentPerInstallment, typeof(decimal), "n2", fTotal: true);

            GridHelper.GridViewInitializeLayout(_GridViewDetail);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlDetail, true, true, true, true, true, true, true, true, true, true, true, true);
            _GridViewDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridViewDetail.OptionsBehavior.Editable = true;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        private void _GridViewDetail_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;

            // update dulu id yang bersesuian
            EducationComponentRegulationDetail row = e.Row as EducationComponentRegulationDetail;
            if (row == null) return;
            row.EducationComponentId = HelperConvert.Int(AssemblyHelper.GetValueProperty(row.EducationComponent, "Id"));
            row.EducationComponentRegulationId = _EducationComponentRegulation.Id;

            if (row.Amount > 0 && row.NumberOfInstallment > 0)
                row.PaymentPerInstallment = Math.Floor(row.Amount / row.NumberOfInstallment);
            else
                row.PaymentPerInstallment = 0;
        }

        private void _GridViewDetail_RowEditCanceled(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;
            GridView view = sender as GridView;

            // update dulu id yang bersesuian
            EducationComponentRegulationDetail row = e.Row as EducationComponentRegulationDetail;
            if (row == null) return;

            for (int i = 0; i < view.RowCount; i++)
            {
                if (i != view.GetDataSourceRowIndex(view.FocusedRowHandle))
                {
                    var tempVal = HelperConvert.Int(view.GetRowCellValue(i, "ScheduleId"));
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

            var result = gridView.GetFocusedRow() as EducationComponentRegulationDetail;

            if (result == null) return;

            var educationComponent = result.EducationComponent;

            if (educationComponent == null)
            {
                gridView.SetColumnError(colEducationComponent, $"Mata Anggaran tidak boleh kosong");
                e.Valid = false;
                return;
            }

            var priority = result.Priority;

            if (priority <= 0)
            {
                gridView.SetColumnError(colPriority, $"Prioritas tidak boleh 0");
                e.Valid = false;
                return;
            }
            else if (priority > 99)
            {
                gridView.SetColumnError(colPriority, $"Prioritas tidak boleh lebih besar 99");
                e.Valid = false;
                return;
            }

            var numberOfInstallment = result.NumberOfInstallment;

            if (numberOfInstallment <= 0)
            {
                gridView.SetColumnError(colNumberOfInstallment, $"Angsuran tidak boleh 0");
                e.Valid = false;
                return;
            }
            else if (numberOfInstallment > 12)
            {
                gridView.SetColumnError(colNumberOfInstallment, $"Angsuran tidak boleh lebih besar 12");
                e.Valid = false;
                return;
            }

            var amount = result.Amount;

            if (amount <= 0)
            {
                gridView.SetColumnError(colAmount, $"Total Tagihan tidak boleh 0");
                e.Valid = false;
                return;
            }
            else if (amount > 90000000)
            {
                gridView.SetColumnError(colAmount, $"Total Tagihan tidak boleh lebih besar 90.000.000");
                e.Valid = false;
                return;
            }

            for (int i = 0; i < gridView.RowCount; i++)
            {
                if (i != gridView.GetDataSourceRowIndex(gridView.FocusedRowHandle))
                {
                    var tempVal = HelperConvert.Int(gridView.GetRowCellValue(i, "EducationComponentId"));
                    if (tempVal == educationComponent.Id)
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
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _EducationComponentRegulation = OdataEntity as EducationComponentRegulation;

            if (_EducationComponentRegulation != null)
            {
                _EducationComponentRegulationDetail.AddRange(_EducationComponentRegulation.EducationComponentRegulationDetails.ToList());
                _BindingSourceDetail.DataSource = _EducationComponentRegulationDetail;
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
            ActionSaveNew<EducationComponentRegulation>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<EducationComponentRegulation>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<EducationComponentRegulation>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _EducationComponentRegulation = new EducationComponentRegulation()
            {
                Id = _EducationComponentRegulation.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue)
            };

            _EducationComponentRegulation.EducationComponentRegulationDetails = _EducationComponentRegulationDetail;

            OdataEntity = _EducationComponentRegulation;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<EducationComponentRegulation>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<EducationComponentRegulation>();
        }
    }
}

using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using Domain;
using Domain.Entities.Rental;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Rental
{
    public partial class frmRentalCarRegulationEmployeeDV : frmBaseDV
    {
        RentalCarRegulationEmployee _RentalCarRegulationEmployee;
        List<RentalCarRegulationEmployeeDetail> _RentalCarRegulationEmployeeDetail = new List<RentalCarRegulationEmployeeDetail>();
        public frmRentalCarRegulationEmployeeDV(object id, string endPoint, object copy = null)
        {
            EntityId = id;
            EndPoint = endPoint;
            OdataCopyId = copy;
            InitializeComponent();

            InitializeComponentAfter<RentalCarRegulationEmployee>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick; 
            
            _GridViewDetail.ValidateRow += _GridViewDetail_ValidateRow;
            _GridViewDetail.RowEditCanceled += _GridViewDetail_RowEditCanceled;
            _GridViewDetail.RowUpdated += _GridViewDetail_RowUpdated;

            HelperConvert.FormatSpinEdit(AmountSpinEdit, "n0", 0, 9999999999);
            HelperConvert.FormatDateEdit(StartDateDateEdit);
            HelperConvert.FormatDateEdit(EndDateDateEdit);

            _BindingSourceDetail.DataSource = _RentalCarRegulationEmployeeDetail;

            _GridViewDetail.OptionsView.ShowFooter = true;
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);

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
            if (!(e.Row is RentalCarRegulationEmployeeDetail row)) return;
            row.RentalCarRegulationEmployeeId = _RentalCarRegulationEmployee.Id;
        }

        private void _GridViewDetail_RowEditCanceled(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;
            GridView view = sender as GridView;

            // update dulu id yang bersesuian
            if (!(e.Row is RentalCarRegulationEmployeeDetail row)) return;

        }

        private void _GridViewDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            if (!(gridView.GetFocusedRow() is RentalCarRegulationEmployeeDetail result)) return;

            var employeeRole = result.EmployeeRole;

            if (employeeRole == null)
            {
                gridView.SetColumnError(colEmployeeRole, $"Tipe Karyawan tidak boleh kosong");
                e.Valid = false;
                return;
            }

            var Type = result.Type;

            if (Type == null)
            {
                gridView.SetColumnError(colType, $"Tipe tidak boleh kosong");
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

            if (e.Valid)
                gridView.ClearColumnErrors();
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, StartDateDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, EndDateDateEdit, ConditionOperator.IsNotBlank);
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _RentalCarRegulationEmployee = OdataEntity as RentalCarRegulationEmployee;

            if (_RentalCarRegulationEmployee != null)
            {
                _RentalCarRegulationEmployeeDetail.AddRange(_RentalCarRegulationEmployee.RentalCarRegulationEmployeeDetails.ToList());
                _BindingSourceDetail.DataSource = _RentalCarRegulationEmployeeDetail;
            }
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);

            SLUHelper.SetEnumDataSource(TypeSearchLookUpEdit, new Converter<EnumRentalCarEmployeeRegulationType, string>(EnumHelper.EnumRentalCarEmployeeRegulationTypeToString));
            SLUHelper.SetEnumDataSource(EmployeeRoleSearchLookUpEdit, new Converter<EnumEmployeeRole, string>(EnumHelper.EnumEmployeeRoleToString));
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<RentalCarRegulationEmployee>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<RentalCarRegulationEmployee>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<RentalCarRegulationEmployee>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _RentalCarRegulationEmployee = new RentalCarRegulationEmployee
            {
                Id = _RentalCarRegulationEmployee.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                StartDate = HelperConvert.Date(StartDateDateEdit.EditValue),
                EndDate = HelperConvert.Date(EndDateDateEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                RentalCarRegulationEmployeeDetails = _RentalCarRegulationEmployeeDetail
            };

            OdataEntity = _RentalCarRegulationEmployee;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<RentalCarRegulationEmployee>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<RentalCarRegulationEmployee>();
        }
    }
}

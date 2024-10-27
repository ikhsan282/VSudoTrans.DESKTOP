using VSudoTrans.DESKTOP.BaseForm;
using Domain.Entities.Attendance;
using VSudoTrans.DESKTOP.Utils;
using System.Collections.Generic;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Linq;
using PopUpUtils;
using System;
using DevExpress.XtraGrid.Views.Grid;

namespace VSudoTrans.DESKTOP.Master.Attendance
{
    public partial class frmWorkingPatternDV : frmBaseDV
    {
        WorkingPattern _WorkingPattern = new WorkingPattern();
        public frmWorkingPatternDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<WorkingPattern>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;
            btnGenerate.Click += BtnGenerate_Click;
            InitializeSearchLookup();

            HelperConvert.FormatSpinEdit(DaySpinEdit, "n0", 0, 100);

            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");

            GridHelper.GridViewInitializeLayout(_GridView);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControl, true, true, true, true, true, true, true, true, true, true, true, true);
            _GridView.OptionsDetail.EnableMasterViewMode = false;
            _GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridView.OptionsBehavior.Editable = true;
            colCycleNo.OptionsColumn.AllowEdit = false;

            workingPatternDetailsBindingSource.DataSource = new List<WorkingPatternDetail>();

            _GridView.RowUpdated += _GridView_RowUpdated;
        }

        private void _GridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;
            GridView view = sender as GridView;

            // update dulu id yang bersesuian
            WorkingPatternDetail row = e.Row as WorkingPatternDetail;
            if (row == null) return;
            row.ShiftId = Convert.ToInt32(AssemblyHelper.GetValueProperty(row.Shift, "Id"));
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
        }
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            var workingPatternDetails = _WorkingPattern.WorkingPatternDetails;
            if (workingPatternDetails != null)
            {
                if (!workingPatternDetails.Any())
                {
                    MessageHelper.ShowMessageError(this, "Pola kerja tidak boleh kosong!");
                    result = false;
                }
            }
            else
            {
                MessageHelper.ShowMessageError(this, "Pola kerja tidak boleh kosong!");
                result = false;
            }

            return result;
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            PopupEditHelper.General<Shift>(fEndPoint: "/Shifts", fTitle: "Shift", fControl: ShiftPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
            
            PopupEditHelper.General<Shift>(fEndPoint: "/Shifts", fTitle: "Shift", fControl: ShiftRepositoryItemPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");

        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _WorkingPattern = OdataEntity as WorkingPattern;
            _GridControl.DataSource = _WorkingPattern.WorkingPatternDetails.ToList();
            //workingPatternDetailsBindingSource.DataSource = _WorkingPattern.WorkingPatternDetails.ToList();
        }

        private void BtnGenerate_Click(object sender, System.EventArgs e)
        {
            _WorkingPattern.WorkingPatternDetails = new List<WorkingPatternDetail>();
            _GridControl.DataSource = null;
            workingPatternDetailsBindingSource.DataSource = null;

            for (int i = 1; i <= HelperConvert.Int(DaySpinEdit.EditValue); i++)
            {
                WorkingPatternDetail wpd = new WorkingPatternDetail()
                {
                    Shift = ShiftPopUp.EditValue as Shift,
                    ShiftId = HelperConvert.Int(AssemblyHelper.GetValueProperty(ShiftPopUp.EditValue, "Id")),
                    WorkingPatternId = _WorkingPattern.Id,
                    CycleNo = i,
                    CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))
                };
                _WorkingPattern.WorkingPatternDetails.Add(wpd);
            }
            _GridControl.DataSource = _WorkingPattern.WorkingPatternDetails;
            workingPatternDetailsBindingSource.DataSource = _WorkingPattern.WorkingPatternDetails;
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<WorkingPattern>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<WorkingPattern>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<WorkingPattern>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            if (_WorkingPattern == null)
                _WorkingPattern = new WorkingPattern();

            _WorkingPattern.Code = HelperConvert.String(CodeTextEdit.EditValue);
            _WorkingPattern.Name = HelperConvert.String(NameTextEdit.EditValue);
            _WorkingPattern.Note = HelperConvert.String(NoteMemoEdit.EditValue);
            _WorkingPattern.CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"));

            OdataEntity = _WorkingPattern;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<WorkingPattern>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<WorkingPattern>();
        }
    }
}

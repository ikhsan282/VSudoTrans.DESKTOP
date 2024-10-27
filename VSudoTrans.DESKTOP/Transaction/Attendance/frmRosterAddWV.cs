using Domain.Entities.Attendance;
using Domain.Entities.HumanResource;
using System;
using System.Collections.Generic;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Contract.Attendance;
using Domain.Entities.Organization;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using System.ComponentModel;

namespace VSudoTrans.DESKTOP.Transaction.Attendance
{
    public partial class frmRosterAddWV : frmBaseWV
    {
        List<WorkingPattern> _WorkingPatterns;
        List<Employee> _DataEmployee = new List<Employee>();
        public frmRosterAddWV()
        {
            InitializeComponent();
            this.EndPoint = "/Rosters";
            this.FormTitle = "Panduan Membuat Daftar Kehadiran Baru";

            InitializeComponentAfter();

            InitializeSearchLookup();

            // Set Default Tab
            rdWorkingPattern.Checked = true;
            tabLayoutShift.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            HelperConvert.FormatDateEdit(FromDateShiftDateEdit);
            HelperConvert.FormatDateEdit(ToDateShiftDateEdit);
            HelperConvert.FormatDateEdit(FromDateWPDateEdit);
            HelperConvert.FormatDateEdit(ToDateWPDateEdit);

            wizardPage1.PageValidating += wizardPage1_PageValidating;
            wizardPage2.PageValidating += wizardPage2_PageValidating;
            wizardPage3.PageValidating += wizardPage3_PageValidating;

            GridHelper.GridViewInitializeLayout(_gvEmployeeList);
            _gvEmployeeList.OptionsCustomization.AllowFilter = true;
            GridHelper.GridViewInitializeLayout(_gvEmployeeListSelected);
            _gvEmployeeListSelected.OptionsCustomization.AllowFilter = true;
            GridHelper.GridControlInitializeEmbeddedNavigator(_gcEmployeeList, fNext: true, fPrev: true);
            GridHelper.GridControlInitializeEmbeddedNavigator(_gcEmployeeListSelected, fNext: true, fPrev: true);

            SearchControlHelper.InitializeSearchControl(_SearchControlEmployeeList);
            SearchControlHelper.InitializeSearchControl(_SearchControlEmployeeListSelected);

            _gvEmployeeList.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _gvEmployeeList.OptionsBehavior.AutoExpandAllGroups = true;
            _gvEmployeeList.ExpandAllGroups();
            _gvEmployeeList.OptionsView.ShowIndicator = false;
            _gvEmployeeList.OptionsDetail.EnableMasterViewMode = false;
            _gvEmployeeList.OptionsFind.AllowFindPanel = false;
            _gvEmployeeList.OptionsView.ShowGroupPanel = false;
            _gvEmployeeList.OptionsView.ColumnAutoWidth = false;
            _gvEmployeeList.OptionsSelection.MultiSelect = true;
            _gvEmployeeList.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            _gvEmployeeList.SelectionChanged += _gvEmployeeListSelected_SelectionChanged;


            _gvEmployeeListSelected.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _gvEmployeeListSelected.OptionsBehavior.AutoExpandAllGroups = true;
            _gvEmployeeListSelected.ExpandAllGroups();
            _gvEmployeeListSelected.OptionsView.ShowIndicator = false;
            _gvEmployeeListSelected.OptionsDetail.EnableMasterViewMode = false;
            _gvEmployeeListSelected.OptionsView.ColumnAutoWidth = false;
            _gvEmployeeListSelected.OptionsBehavior.Editable = false;
            _gvEmployeeListSelected.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            _gvEmployeeListSelected.OptionsSelection.MultiSelect = true;
            _gvEmployeeListSelected.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            _gvEmployeeListSelected.SelectionChanged += _gvEmployeeListSelected_SelectionChanged;

            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;

            _DataEmployee = new List<Employee>();
            _BindingSourceEmployeeSelect.DataSource = _DataEmployee;
            _gvEmployeeList.OptionsView.ShowViewCaption = true;
            _gvEmployeeList.ViewCaption = "Daftar Karyawan";
            _gvEmployeeListSelected.OptionsView.ShowViewCaption = true;
            _gvEmployeeListSelected.ViewCaption = "Data Karyawan Terpilih";

            _gvEmployeeList.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _gvEmployeeListSelected.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            colOrganizationStructureCode.Group();
            colOrganizationStructureCodeSelect.Group();
        }
        private void _gvEmployeeListSelected_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (e.Action == CollectionChangeAction.Add && gridView == _gvEmployeeList)
            {
                _gvEmployeeListSelected.ClearSelection();
            }
            else if (e.Action == CollectionChangeAction.Add && gridView == _gvEmployeeListSelected)
            {
                _gvEmployeeList.ClearSelection();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _gvEmployeeListSelected.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;

            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Karyawan belum ada yang terpilih !");
                return;
            }

            _gvEmployeeListSelected.DeleteSelectedRows();
            _gvEmployeeListSelected.BestFitColumns(true);

            _gvEmployeeListSelected.RefreshData();
            _gvEmployeeList.RefreshData();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _gvEmployeeList.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;
            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Karyawan belum ada yang terpilih !");
                return;

            }

            foreach (var item in selectedEmployee)
            {
                var dataRow = _gvEmployeeList.GetRow(item) as Employee;
                if (!_DataEmployee.Any(x => x.Id == dataRow.Id))
                {
                    _DataEmployee.Add(dataRow);
                };
            }

            _gvEmployeeListSelected.BestFitColumns(true);
            _gvEmployeeList.ClearSelection();
            _gvEmployeeListSelected.RefreshData();
            _gvEmployeeList.RefreshData();
        }

        private void ValidationWorkingPattern()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.WorkingPatternPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.WorkingPatternDetailPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FromDateWPDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ToDateWPDateEdit, ConditionOperator.IsNotBlank);
        }

        private void ValidationShift()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ShiftPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FromDateShiftDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ToDateShiftDateEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.General<Shift>(fEndPoint: "/Shifts", fControl: ShiftPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId");

            PopupEditHelper.General<WorkingPattern>(fEndPoint: "/WorkingPatterns", fControl: WorkingPatternPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fChild: WorkingPatternDetailPopUp);
            PopupEditHelper.General<WorkingPatternDetail>(fEndPoint: "/WorkingPatternDetails", fControl: WorkingPatternDetailPopUp, fCascade: WorkingPatternPopUp, fCascadeMember: "WorkingPatternId", fSelect: "id,cycleno,workingpatternid", fExpand: "shift($select=id,code,name)", fDisplaycolumn: "CycleNo;Shift.Name", fCaptionColumn: "No;Shift");

            PopupEditHelper.Company(CompanyPopUp);

            WorkingPatternDetailPopUp.QueryDisplayText += WorkingPatternDetailPopUp_QueryDisplayText;
        }

        private void WorkingPatternDetailPopUp_QueryDisplayText(object sender, QueryDisplayTextEventArgs e)
        {
            if (e.EditValue != null && e.EditValue != DBNull.Value)
            {
                try
                {
                    string code = AssemblyHelper.GetValueProperty(e.EditValue, "CycleNo").ToString();
                    var name = (AssemblyHelper.GetValueProperty(e.EditValue, "Shift") as Shift)?.Name;
                    e.DisplayText = $"{code} - {name}";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                e.DisplayText = "";
            }
        }


        private void rdWorkingPattern_CheckedChanged(object sender, EventArgs e)
        {
            if (rdWorkingPattern.Checked)
            {
                tabLayoutWorkingPattern.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tabLayoutShift.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                tabLayoutShift.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tabLayoutWorkingPattern.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void rdShift_CheckedChanged(object sender, EventArgs e)
        {
            if (rdWorkingPattern.Checked)
            {
                tabLayoutWorkingPattern.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tabLayoutShift.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                tabLayoutShift.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tabLayoutWorkingPattern.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void ValidationEmployee()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
        }

        private void wizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                var company = CompanyPopUp.EditValue as Company;

                ValidationEmployee();
                if (!ActionValidate(_DxValidationProvider))
                {
                    e.Valid = false;
                    return;
                }

                string filter = $"companyId eq {company.Id}";
                var employeeList = HelperRestSharp.GetListOdata<Employee>("/Employees", "Id,Code,Name", "OrganizationStructure($select=Id,Code,Name)", filter);

                if (employeeList == null || employeeList.Count == 0)
                    return;

                _gcEmployeeList.DataSource = employeeList;
                _gvEmployeeList.BestFitColumns(true);
                _gvEmployeeListSelected.BestFitColumns(true);
            }
            else if (e.Direction == DevExpress.XtraWizard.Direction.Backward)
                MyValidationHelper.ClearError(_DxValidationProvider);
        }

        private void wizardPage2_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                if (_DataEmployee.Count == 0)
                {
                    MessageHelper.ShowMessageInformation(this, "Data Karyawan belum ada yang terpilih !");
                    e.Valid = false;
                }
            }
            else if (e.Direction == DevExpress.XtraWizard.Direction.Backward)
                MyValidationHelper.ClearError(_DxValidationProvider);
        }

        private void wizardPage3_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                MessageHelper.WaitFormShow(this);
                try
                {
                    if (rdShift.Checked)
                        ValidationShift();
                    else if (rdWorkingPattern.Checked)
                        ValidationWorkingPattern();

                    if (!ActionValidate(_DxValidationProvider))
                    {
                        e.Valid = false;
                        return;
                    }

                    CreateEntity<RosterGenerateDto>();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    MessageHelper.WaitFormClose(this);
                }
            }
            else if (e.Direction == DevExpress.XtraWizard.Direction.Backward)
                MyValidationHelper.ClearError(_DxValidationProvider);
        }

        protected override object CreateEntity<T>()
        {
            RosterGenerateDto rosterGenerateDto = new RosterGenerateDto();
            rosterGenerateDto.CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue,"Id"));
            rosterGenerateDto.EmployeeIds = _DataEmployee.Select(s => s.Id).ToList();

            if (rdWorkingPattern.Checked)
            {
                rosterGenerateDto.StartDate = HelperConvert.Date(FromDateWPDateEdit.EditValue);
                rosterGenerateDto.EndDate = HelperConvert.Date(ToDateWPDateEdit.EditValue);
                rosterGenerateDto.WorkingPatternId = HelperConvert.Int(AssemblyHelper.GetValueProperty(WorkingPatternPopUp.EditValue, "Id"));
                rosterGenerateDto.WorkingPatternDetailId = HelperConvert.Int(AssemblyHelper.GetValueProperty(WorkingPatternDetailPopUp.EditValue, "Id"));
            }
            else if (rdShift.Checked)
            {
                rosterGenerateDto.StartDate = HelperConvert.Date(FromDateShiftDateEdit.EditValue);
                rosterGenerateDto.EndDate = HelperConvert.Date(ToDateShiftDateEdit.EditValue);
                rosterGenerateDto.ShiftId = HelperConvert.Int(AssemblyHelper.GetValueProperty(ShiftPopUp.EditValue, "Id"));
            }

            OdataEntity = rosterGenerateDto;

            return base.CreateEntity<RosterGenerateDto>();
        }
    }
}

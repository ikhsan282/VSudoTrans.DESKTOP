using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Domain.Entities.HumanResource;
using Domain.Entities.Identity;
using Domain.Entities.Organization;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.CodeParser;
using System.ComponentModel;

namespace VSudoTrans.DESKTOP.Master.Identity
{
    public partial class frmUserDV : frmBaseDV
    {
        ApplicationUser _ApplicationUser = null;
        List<Company> _DataApplicationCompanyMethod = new List<Company>();
        public frmUserDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            GridHelper.GridViewInitializeLayout(this._GridViewRoles);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlRoles, fNext: true, fPrev: true, fRemove: true);
            _GridViewRoles.OptionsDetail.EnableMasterViewMode = false;
            _GridViewRoles.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridViewRoles.OptionsBehavior.Editable = true;
            colRole.OptionsColumn.AllowEdit = true;

            this._GridViewRoles.RowUpdated += _GridViewRoles_RowUpdated;
            this._GridViewRoles.ValidateRow += _GridViewRoles_ValidateRow;

            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");

            InitializeSearchLookup();

            InitializeComponentAfter<ApplicationUser>();

            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            PasswordTextEdit.EditValue = "";


            GridHelper.GridViewInitializeLayout(_GridViewCompany);
            GridHelper.GridViewInitializeLayout(_GridViewCompanySelect);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlCompany, fNext: true, fPrev: true);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlCompanySelect, fNext: true, fPrev: true);

            _GridViewCompany.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _GridViewCompany.OptionsBehavior.AutoExpandAllGroups = true;
            _GridViewCompany.ExpandAllGroups();
            colId.Visible = false;
            colName.Visible = true;
            _GridViewCompany.OptionsView.ShowIndicator = false;
            _GridViewCompany.OptionsFind.AllowFindPanel = false;
            _GridViewCompany.OptionsView.ShowGroupPanel = false;
            _GridViewCompany.OptionsView.ColumnAutoWidth = false;
            _GridViewCompany.OptionsSelection.MultiSelect = true;
            _GridViewCompany.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            _GridViewCompany.SelectionChanged += _GridViewCompanySelect_SelectionChanged;
            _GridViewCompany.BestFitColumns();

            _GridViewCompanySelect.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _GridViewCompanySelect.OptionsBehavior.AutoExpandAllGroups = true;
            _GridViewCompanySelect.ExpandAllGroups();
            colIdSelect.Visible = false;
            colNameSelect.Visible = true;
            _GridViewCompanySelect.OptionsView.ShowIndicator = false;
            _GridViewCompanySelect.OptionsDetail.EnableMasterViewMode = false;
            _GridViewCompanySelect.OptionsView.ColumnAutoWidth = false;
            _GridViewCompanySelect.OptionsBehavior.Editable = false;
            _GridViewCompanySelect.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            _GridViewCompanySelect.OptionsSelection.MultiSelect = true;
            _GridViewCompanySelect.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            _GridViewCompanySelect.SelectionChanged += _GridViewCompanySelect_SelectionChanged;
            _GridViewCompanySelect.BestFitColumns();

            _btnAddCompany.Click += _btnAddCompany_Click;
            _btnRemoveCompany.Click += _btnRemoveCompany_Click;

            _BindingSourceCompanySelect.DataSource = _DataApplicationCompanyMethod;

            _GridViewCompany.OptionsView.ShowViewCaption = true;
            _GridViewCompany.ViewCaption = "Daftar Akses Kontrol";
            _GridViewCompanySelect.OptionsView.ShowViewCaption = true;
            _GridViewCompanySelect.ViewCaption = "Data Akses Kontrol Terpilih";
        }
        private void _GridViewCompanySelect_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (e.Action == CollectionChangeAction.Add && gridView == _GridViewCompany)
            {
                _GridViewCompanySelect.ClearSelection();
            }
            else if (e.Action == CollectionChangeAction.Add && gridView == _GridViewCompanySelect)
            {
                _GridViewCompany.ClearSelection();
            }
            _GridViewCompany.BestFitColumns();
            _GridViewCompanySelect.BestFitColumns();
        }

        private void _btnRemoveCompany_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _GridViewCompanySelect.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;

            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Akses Kontrol belum ada yang terpilih !");
                return;
            }

            _GridViewCompanySelect.DeleteSelectedRows();

            _GridViewCompanySelect.RefreshData();
            _GridViewCompany.RefreshData();

            _GridViewCompany.BestFitColumns();
            _GridViewCompanySelect.BestFitColumns();
        }

        private void _btnAddCompany_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _GridViewCompany.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;
            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Akses Kontrol belum ada yang terpilih !");
                return;

            }

            foreach (var item in selectedEmployee)
            {
                var dataRow = _GridViewCompany.GetRow(item) as Company;
                if (!_DataApplicationCompanyMethod.Any(x => x.Id == dataRow.Id))
                {
                    _DataApplicationCompanyMethod.Add(dataRow);
                };
            }

            _GridViewCompanySelect.BestFitColumns(true);
            _GridViewCompany.ClearSelection();
            _GridViewCompanySelect.RefreshData();
            _GridViewCompany.RefreshData();
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("UserName");
        }

        private void _GridViewRoles_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn colRole = view.Columns.Where(x => x.FieldName.Equals("Role")).FirstOrDefault() as GridColumn;

            var _role = view.GetRowCellValue(e.RowHandle, colRole) as ApplicationRole;
            if (_role == null)
            {
                e.Valid = false;
                view.SetColumnError(colRole, "Data tidak boleh kosong");
                return;
            }

            for (int i = 0; i < view.RowCount; i++)
            {
                if (i != view.GetDataSourceRowIndex(view.FocusedRowHandle))
                {
                    var tempVal = view.GetRowCellValue(i, "Role") as ApplicationRole;
                    if (tempVal.Id == _role.Id)
                    {
                        view.SetColumnError(colRole, "Terdapat Duplikasi Data Akses Peran");
                        e.Valid = false;
                        break;
                    }
                }
            }
        }

        private void _GridViewRoles_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (e.Row == null) return;
            GridView view = sender as GridView;

            var row = e.Row as ApplicationUserRole;

            if (row == null) return;

            string roleId = AssemblyHelper.GetValueProperty(row.Role, "Id").ToString();
            row.RoleId = Guid.Parse(roleId);
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _ApplicationUser = OdataEntity as ApplicationUser;

            tabbedControlGroup1.SelectedTabPageIndex = 0;

            if (_ApplicationUser != null)
            {
                EmployeePopUp.EditValue = _ApplicationUser.Employee;

                if (_ApplicationUser.PasswordHash != null)
                    PasswordTextEdit.EditValue = "";

                _UserRoleBindingSource.DataSource = _ApplicationUser.Roles.ToList();

                _DataApplicationCompanyMethod = new List<Company>();

                var companys = new List<Company>();
                var roleNames = ApplicationSettings.Instance.UserRoles.Select(s => s.Name);
                if (roleNames.FirstOrDefault(s => s == "Super Administrator") != null)
                    companys = HelperRestSharp.GetListOdata<Company>("/Companys");
                else
                    companys = ApplicationSettings.Instance.UserCompanys.ToList();

                _BindingSourceCompany.DataSource = companys;

                var companyIds = (OdataEntity as ApplicationUser).Companys.Select(s => s.CompanyId).ToList();
                _DataApplicationCompanyMethod.AddRange(companys.Where(s => companyIds.Contains(s.Id)));
                _GridViewCompanySelect.RefreshData();
                _GridViewCompany.RefreshData();
            }
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FirstNameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.UserNameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
        }

        //Validasi kedua
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            //List<Company> userPlants = GetListDataRowSelected(_GridViewCompanySelect).OfType<Company>().ToList();
            //if (!userPlants.Any())
            //{
            //    MessageHelper.ShowMessageError(this, "Otorisasi Sekolah harus diisi!");
            //    result = false;
            //}

            var userRoles = _UserRoleBindingSource.DataSource as List<ApplicationUserRole>;
            if (userRoles != null)
            {
                if (userRoles.Count == 0)
                {
                    MessageHelper.ShowMessageError(this, "Akses Peran harus diisi!");
                    result = false;
                }
            }


            if (string.IsNullOrEmpty(HelperConvert.String(FirstNameTextEdit.EditValue)))
            {
                this.FirstNameTextEdit.ErrorText = "Inputan tidak boleh kosong ...";
                result = false;
            }

            if (string.IsNullOrEmpty(HelperConvert.String(UserNameTextEdit.EditValue)))
            {
                this.UserNameTextEdit.ErrorText = "Inputan tidak boleh kosong ...";
                result = false;
            }

            if (string.IsNullOrEmpty(HelperConvert.String(PasswordTextEdit.EditValue)) && FormStatus == enumFormStatus.New)
            {
                this.PasswordTextEdit.ErrorText = "Inputan tidak boleh kosong ...";
                result = false;
            }

            return result;
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp, EmployeePopUp);
            PopupEditHelper.General<Employee>(fEndPoint: "/Employees", fTitle: "Karyawan", fControl: EmployeePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fSelect: "id,code,name,phonenumber");
            PopupEditHelper.General<ApplicationRole>(fEndPoint: "/Roles", fTitle: "Peran", fControl: RolePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fSelect: "Id,Name", fExpand: "", fFilter: "", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fWidthColumn: "300", fFilterColumn: "Name", fDisplayText: "Name");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<ApplicationUser>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<ApplicationUser>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<ApplicationUser>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _ApplicationUser = new ApplicationUser()
            {
                Id = _ApplicationUser.Id,
                UserType = Domain.EnumUserType.Employee,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                FirstName = HelperConvert.String(FirstNameTextEdit.EditValue),
                LastName = HelperConvert.String(LastNameTextEdit.EditValue),
                UserName = HelperConvert.String(UserNameTextEdit.EditValue),
                PasswordHash = PasswordTextEdit.EditValue.ToString() == "" ? _ApplicationUser.PasswordHash : PasswordTextEdit.EditValue.ToString(),
            };

            if (IsActiveCheckEdit.Checked)
                _ApplicationUser.IsActive = true;
            else
                _ApplicationUser.IsActive = false;

            _ApplicationUser.Companys.Clear();
            List<Company> companys = _BindingSourceCompanySelect.DataSource as List<Company>;
            foreach (Company m in companys)
            {
                _ApplicationUser.Companys.Add(new ApplicationUserCompany()
                {
                    Id = 0,
                    UserId = _ApplicationUser.Id,
                    CompanyId = m.Id,
                });
            }

            _ApplicationUser.Roles = _UserRoleBindingSource.DataSource as List<ApplicationUserRole>;

            if (EmployeePopUp.EditValue != null)
                _ApplicationUser.EmployeeId = HelperConvert.Int(AssemblyHelper.GetValueProperty(EmployeePopUp.EditValue, "Id"));

            if (_ApplicationUser.EmployeeId == 0)
                _ApplicationUser.EmployeeId = null;

            OdataEntity = _ApplicationUser;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<ApplicationUser>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<ApplicationUser>();
        }
    }
}

using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Domain.Entities.HumanResource;
using Domain.Entities.Identity;
using Domain.Entities.Organization;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.EducationResource;

namespace VSTS.DESKTOP.Master.Identity
{
    public partial class frmUserStudentDV : frmBaseDV
    {
        ApplicationUser _ApplicationUser = null;
        public frmUserStudentDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");

            InitializeComponentAfter<ApplicationUser>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            InitializeSearchLookup();

            PasswordTextEdit.EditValue = "";
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("UserName");
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _ApplicationUser = OdataEntity as ApplicationUser;

            tabbedControlGroup1.SelectedTabPageIndex = 0;

            if (_ApplicationUser != null)
            {
                StudentPopUp.EditValue = _ApplicationUser.Employee;

                if (_ApplicationUser.PasswordHash != null)
                    PasswordTextEdit.EditValue = "";
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

            if (string.IsNullOrEmpty(HelperConvert.String(PasswordTextEdit.EditValue)) && FormStatus == enumFormStatus.New)
            {
                this.PasswordTextEdit.ErrorText = "Inputan tidak boleh kosong ...";
                result = false;
            }

            return result;
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp, StudentPopUp);
            PopupEditHelper.General<Student>(fEndPoint: "/Students", fTitle: "Murid", fControl: StudentPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fSelect: "id,code,name");
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
                UserType = Domain.EnumUserType.Student,
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

            if (StudentPopUp.EditValue != null)
                _ApplicationUser.StudentId = HelperConvert.Int(AssemblyHelper.GetValueProperty(StudentPopUp.EditValue, "Id"));

            if (_ApplicationUser.StudentId == 0)
                _ApplicationUser.StudentId = null;

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

using DevExpress.XtraEditors.DXErrorProvider;
using Domain;
using Domain.Entities.EducationResource;
using PopUpUtils;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Master.EducationResource
{
    public partial class frmMajorDV : frmBaseDV
    {
        Major _Major;
        public frmMajorDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;
            InitializeComponent();

            InitializeComponentAfter<Major>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("Code;Name");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.TypeEducationSearchLookUpEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            SLUHelper.SetEnumDataSource<EnumTypeEducation>(TypeEducationSearchLookUpEdit, EnumHelper.EnumTypeEducationToString, "Key");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Major>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Major>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Major>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Major = OdataEntity as Major;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Major = new Major()
            {
                Id = _Major.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                TypeEducation = (EnumTypeEducation)TypeEducationSearchLookUpEdit.EditValue,
            };

            OdataEntity = _Major;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Major>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Major>();
        }
    }
}

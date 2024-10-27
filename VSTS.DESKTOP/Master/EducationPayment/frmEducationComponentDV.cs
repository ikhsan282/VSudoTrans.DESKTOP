using DevExpress.XtraEditors.DXErrorProvider;
using Domain;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using PopUpUtils;
using System;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Master.EducationPayment
{
    public partial class frmEducationComponentDV : frmBaseDV
    {
        EducationComponent _EducationComponent;
        public frmEducationComponentDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;
            InitializeComponent();

            InitializeComponentAfter<EducationComponent>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("Code");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _EducationComponent = OdataEntity as EducationComponent;

            if (_EducationComponent != null)
            {
                EducationTypeSearchLookUpEdit.EditValue = _EducationComponent.EducationType;
            }
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            SLUHelper.SetEnumDataSource(EducationTypeSearchLookUpEdit, new Converter<EnumEducationType, string>(EnumHelper.EnumEducationTypeToString));
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<EducationComponent>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<EducationComponent>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<EducationComponent>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _EducationComponent = new EducationComponent()
            {
                Id = _EducationComponent.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue)
            };

            if (EducationTypeSearchLookUpEdit.EditValue != null)
                _EducationComponent.EducationType = (EnumEducationType)EducationTypeSearchLookUpEdit.EditValue;

            OdataEntity = _EducationComponent;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<EducationComponent>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<EducationComponent>();
        }
    }
}

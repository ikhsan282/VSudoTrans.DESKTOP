using DevExpress.XtraEditors.DXErrorProvider;
using Domain;
using Domain.Entities.Attendance;
using Domain.Entities.EducationResource;
using PopUpUtils;
using System;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.EducationResource
{
    public partial class frmClassDV : frmBaseDV
    {
        Class _Class;
        public frmClassDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;
            InitializeComponent();

            InitializeComponentAfter<Class>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("Name");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            SLUHelper.SetEnumDataSource(IndexSearchLookUpEdit, new Converter<EnumClass, string>(EnumHelper.EnumClassToString));
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Class>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Class>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Class>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Class = OdataEntity as Class;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Class = new Class()
            {
                Id = _Class.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Index = (EnumClass)IndexSearchLookUpEdit.EditValue
            };

            OdataEntity = _Class;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Class>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Class>();
        }
    }
}

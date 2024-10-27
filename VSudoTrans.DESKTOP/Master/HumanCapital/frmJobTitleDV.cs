using VSudoTrans.DESKTOP.BaseForm;
using Domain.Entities.HumanResource;
using VSudoTrans.DESKTOP.Utils;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    public partial class frmJobTitleDV : frmBaseDV
    {
        JobTitle _JobTitle;
        public frmJobTitleDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<JobTitle>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
            HelperConvert.FormatSpinEdit(LevelSpinEdit, "n0", 0, 99);
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.LevelSpinEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<JobTitle>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<JobTitle>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<JobTitle>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _JobTitle = OdataEntity as JobTitle;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _JobTitle = new JobTitle()
            {
                Id = _JobTitle.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                Level = HelperConvert.Int(LevelSpinEdit.EditValue)
            };

            OdataEntity = _JobTitle;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<JobTitle>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<JobTitle>();
        }
    }
}

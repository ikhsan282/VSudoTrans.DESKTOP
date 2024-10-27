using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using Domain;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;
using Domain.Entities.Finance;

namespace VSTS.DESKTOP.Master.Finance
{
    public partial class frmCategoryDV : frmBaseDV
    {
        Category _Category;
        public frmCategoryDV(object id, string endPoint, object copy = null)
        {
            EntityId = id;
            EndPoint = endPoint;
            OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Category>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;
            InitializeSearchLookup();

            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Category = OdataEntity as Category;
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, CompanyPopUp, ConditionOperator.IsNotBlank);
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
            ActionSaveNew<Category>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Category>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Category>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Category = new Category()
            {
                Id = _Category.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
            };
            OdataEntity = _Category;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Category>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Category>();
        }
    }
}

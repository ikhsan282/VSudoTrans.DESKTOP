using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Vehicle;
using PopUpUtils;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmCategoryVehicleDV : frmBaseDV
    {
        CategoryVehicle _CategoryVehicle;
        public frmCategoryVehicleDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<CategoryVehicle>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<CategoryVehicle>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<CategoryVehicle>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<CategoryVehicle>();
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _CategoryVehicle = OdataEntity as CategoryVehicle;
        }
        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _CategoryVehicle = new CategoryVehicle()
            {
                Id = _CategoryVehicle.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue)
            };
            OdataEntity = _CategoryVehicle;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<CategoryVehicle>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<CategoryVehicle>();
        }
    }
}

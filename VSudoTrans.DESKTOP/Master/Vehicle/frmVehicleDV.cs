using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Vehicle;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmVehicleDV : frmBaseDV
    {
        Vehicles _Vehicles;
        public frmVehicleDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Vehicles>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
            HelperConvert.FormatDateEdit(TaxDueDateEdit);
            HelperConvert.FormatDateEdit(StnkDueDateEdit);
            HelperConvert.FormatDateEdit(KirDueDateEdit);
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("VehicleNumber");
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);

            PopupEditHelper.General<BrandVehicle>(fEndPoint: "/BrandVehicles", fTitle: "Merek", fControl: BrandPopUp, fChild: ModelUnitPopUp, fSelect: "id,code,name");

            PopupEditHelper.General<ModelUnit>(fEndPoint: "/ModelUnits", fTitle: "Model Unit", fControl: ModelUnitPopUp, fCascade: BrandPopUp, fCascadeMember: "BrandId", fSelect: "id,code,name");

            PopupEditHelper.General<TypeEngine>(fEndPoint: "/TypeEngines", fTitle: "Tipe Mesin", fControl: TypeEnginePopUp, fSelect: "id,code,name");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.BrandPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.TypeEnginePopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ModelUnitPopUp, ConditionOperator.IsNotBlank);

            MyValidationHelper.SetValidation(_DxValidationProvider, this.FrameNumberTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.VehicleNumberTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.BpkbNumberTextEdit, ConditionOperator.IsNotBlank);

            MyValidationHelper.SetValidation(_DxValidationProvider, this.TaxDueDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StnkDueDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.KirDueDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.OwnershipTextEdit, ConditionOperator.IsNotBlank);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Vehicles>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Vehicles>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Vehicles>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Vehicles = OdataEntity as Vehicles;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Vehicles = new Vehicles()
            {
                Id = _Vehicles.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                BrandId = HelperConvert.Int(AssemblyHelper.GetValueProperty(BrandPopUp.EditValue, "Id")),
                TypeEngineId = HelperConvert.Int(AssemblyHelper.GetValueProperty(TypeEnginePopUp.EditValue, "Id")),
                ModelUnitId = HelperConvert.Int(AssemblyHelper.GetValueProperty(ModelUnitPopUp.EditValue, "Id")),

                FrameNumber = HelperConvert.String(FrameNumberTextEdit.EditValue),
                VehicleNumber = HelperConvert.String(VehicleNumberTextEdit.EditValue),
                BpkbNumber = HelperConvert.String(BpkbNumberTextEdit.EditValue),

                Ownership = HelperConvert.String(OwnershipTextEdit.EditValue),

                TaxDue = HelperConvert.Date(TaxDueDateEdit.EditValue),
                StnkDue = HelperConvert.Date(StnkDueDateEdit.EditValue),
                KirDue = HelperConvert.Date(KirDueDateEdit.EditValue),

                Notes = HelperConvert.String(NotesMemoEdit.EditValue),
            };

            OdataEntity = _Vehicles;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Vehicles>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Vehicles>();
        }
    }
}

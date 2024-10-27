using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Vehicle;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System.Threading.Tasks;

namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    public partial class frmModelUnitDV : frmBaseDV
    {
        ModelUnit _ModelUnit;
        public frmModelUnitDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<ModelUnit>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }


        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.General<BrandVehicle>(fEndPoint: "/BrandVehicles", fTitle: "Model", fControl: BrandPopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.BrandPopUp, ConditionOperator.IsNotBlank);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<ModelUnit>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<ModelUnit>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<ModelUnit>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _ModelUnit = new ModelUnit()
            {
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                BrandId = HelperConvert.Int(AssemblyHelper.GetValueProperty(BrandPopUp.EditValue, "Id")),
            };
            OdataEntity = _ModelUnit;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<ModelUnit>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<ModelUnit>();
        }
    }
}

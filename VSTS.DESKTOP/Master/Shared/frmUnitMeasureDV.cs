using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Shared;

namespace VSTS.DESKTOP.Master.Shared
{
    public partial class frmUnitMeasureDV : frmBaseDV
    {
        UnitMeasure _UnitMeasure;
        public frmUnitMeasureDV(object id, string endPoint, object copy = null)
        {
            EntityId = id;
            EndPoint = endPoint;
            OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<UnitMeasure>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _UnitMeasure = OdataEntity as UnitMeasure;
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, FormatTextEdit, ConditionOperator.IsNotBlank);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<UnitMeasure>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<UnitMeasure>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<UnitMeasure>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _UnitMeasure = new UnitMeasure()
            {
                Id = _UnitMeasure.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Format = HelperConvert.String(FormatTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
            };
            OdataEntity = _UnitMeasure;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<UnitMeasure>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<UnitMeasure>();
        }
    }
}

using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Demography;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using System.Threading.Tasks;

namespace VSTS.DESKTOP.Master.Demography
{
    public partial class frmCountryDV : frmBaseDV
    {
        Country _Country;
        public frmCountryDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Country>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Country>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Country>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Country>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Country = OdataEntity as Country;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Country = new Country()
            {
                Id = _Country.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
            };
            OdataEntity = _Country;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Country>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Country>();
        }
    }
}

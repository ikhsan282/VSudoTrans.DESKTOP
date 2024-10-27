using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Demography;
using Domain.Entities.HumanResource;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using PopUpUtils;

namespace VSTS.DESKTOP.Master.Demography
{
    public partial class frmProvinceDV : frmBaseDV
    {
        Province _Province;
        public frmProvinceDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Province>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.General<Country>(fEndPoint: "/Countrys", fTitle: "Negara", fControl: CountryPopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CountryPopUp, ConditionOperator.IsNotBlank);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Province>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Province>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Province>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Province = OdataEntity as Province;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Province = new Province()
            {
                Id = _Province.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                CountryId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CountryPopUp.EditValue, "Id"))
            };
            OdataEntity = _Province;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Province>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Province>();
        }
    }
}

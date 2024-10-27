using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Demography;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.Demography
{
    public partial class frmCityDV : frmBaseDV
    {
        City _City;
        public frmCityDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<City>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.General<Country>(fEndPoint: "/Countrys", fTitle: "Negara", fControl: CountryPopUp, fChild: ProvincePopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
            PopupEditHelper.General<Province>(fEndPoint: "/Provinces", fTitle: "Provinsi", fControl: ProvincePopUp, fCascade: CountryPopUp, fCascadeMember: "CountryId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CountryPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ProvincePopUp, ConditionOperator.IsNotBlank);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<City>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<City>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<City>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _City = OdataEntity as City;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _City = new City()
            {
                Id = _City.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                CountryId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CountryPopUp.EditValue, "Id")),
                ProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(ProvincePopUp.EditValue, "Id"))
            };
            OdataEntity = _City;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<City>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<City>();
        }
    }
}

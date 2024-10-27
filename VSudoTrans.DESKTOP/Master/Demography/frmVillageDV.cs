using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Demography;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System.Threading.Tasks;

namespace VSudoTrans.DESKTOP.Master.Demography
{
    public partial class frmVillageDV : frmBaseDV
    {
        Village _Village;
        public frmVillageDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Village>();
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
            PopupEditHelper.General<City>(fEndPoint: "/Citys", fTitle: "Kota", fControl: CityPopUp, fCascade: ProvincePopUp, fCascadeMember: "ProvinceId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
            PopupEditHelper.General<District>(fEndPoint: "/Districts", fTitle: "Kecamatan", fControl: DistrictPopUp, fCascade: CityPopUp, fCascadeMember: "CityId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CountryPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ProvincePopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CityPopUp, ConditionOperator.IsNotBlank);
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Village>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Village>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Village>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Village = OdataEntity as Village;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Village = new Village()
            {
                Id = _Village.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                CountryId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CountryPopUp.EditValue, "Id")),
                ProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(ProvincePopUp.EditValue, "Id")),
                CityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CityPopUp.EditValue, "Id")),
                DistrictId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DistrictPopUp.EditValue, "Id"))
            };
            OdataEntity = _Village;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Village>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Village>();
        }
    }
}

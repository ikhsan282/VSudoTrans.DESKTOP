using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Demography;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System.Threading.Tasks;
using DevExpress.Persistent.Base.General;

namespace VSudoTrans.DESKTOP.Master.Demography
{
    public partial class frmDistrictDV : frmBaseDV
    {
        District _District;
        public frmDistrictDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<District>();
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
            ActionSaveNew<District>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<District>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<District>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _District = OdataEntity as District;
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _District = new District()
            {
                Id = _District.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                CountryId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CountryPopUp.EditValue, "Id")),
                ProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(ProvincePopUp.EditValue, "Id")),
                CityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CityPopUp.EditValue, "Id"))
            };
            OdataEntity = _District;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<District>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<District>();
        }
    }
}

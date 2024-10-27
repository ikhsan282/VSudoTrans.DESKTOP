using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using Domain.Entities.Organization;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Travel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Domain.Entities.Demography;
using System.Linq;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.Travel
{
    public partial class frmPassengerDV : frmBaseDV
    {
        List<CountryCode> countryCodeList = new List<CountryCode>();
        Passenger _Passenger;
        public frmPassengerDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Passenger>();
            InitializeSearchLookup();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            //this.PhoneNumberTextEdit.Properties.Mask.EditMask = @"^(\+?\d{1,4}\s?)?(\d{7,15})$";
            this.PhoneNumberTextEdit.Properties.Mask.EditMask = "(\\d{9})|(\\d{10})|(\\d{11})|(\\d{12})|(\\d{13})|(\\d{14})|(\\d{15})";
            this.PhoneNumberTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.PhoneNumberTextEdit.Properties.Mask.ShowPlaceHolders = false;

            PhoneNumberTextEdit.Validating += PhoneNumberTextEdit_Validating;
            CountryCodeSearchLookUpEdit.EditValueChanged += CountryCodeSearchLookUpEdit_EditValueChanged;

            this.CountryCodeSearchLookUpEdit.EditValue = countryCodeList.FirstOrDefault(s => s.Code == "62").Id;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
        }

        private void CountryCodeSearchLookUpEdit_EditValueChanged(object sender, System.EventArgs e)
        {
            if (CountryCodeSearchLookUpEdit.EditValue != null)
                PhoneNumberTextEdit.EditValue = HelperConvert.String(CountryCodeSearchLookUpEdit.EditValue);
        }

        //Validasi pertama
        private void PhoneNumberTextEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CountryCodeSearchLookUpEdit.EditValue != null)
            {
                var countryCodeLength = CountryCodeSearchLookUpEdit.EditValue.ToString().Length;
                Regex regex = new Regex("^(\\+?\\d{1,4}\\s?)?(\\d{7,15})$");//new Regex("^[\\s-]?0?8[1-9]{1}\\d{1}\\d{4}[\\s-]?\\d{2,5}$");
                if (!regex.IsMatch(HelperConvert.String(this.PhoneNumberTextEdit.EditValue)))
                {
                    //this.PhoneNumberTextEdit.ErrorText = "Awalan nomor telepon harus '08' dan tidak boleh ada tanda '-' dan spasi";
                    this.PhoneNumberTextEdit.ErrorText = "Nomor telepon tidak valid";
                    e.Cancel = true;
                }
                else if (HelperConvert.String(this.PhoneNumberTextEdit.EditValue).Length >= countryCodeLength)
                {
                    var countryCode = HelperConvert.String(CountryCodeSearchLookUpEdit.EditValue);
                    if (HelperConvert.String(this.PhoneNumberTextEdit.EditValue).Substring(0, countryCodeLength) != countryCode)
                    {
                        this.PhoneNumberTextEdit.ErrorText = $"Awalan nomor telepon harus '{countryCode}'";
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                this.PhoneNumberTextEdit.ErrorText = "Pilih kode negara terlebih dahulu";
                e.Cancel = true;
            }
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Passenger = OdataEntity as Passenger;

            if (_Passenger != null)
            {
                PhoneNumberTextEdit.EditValue = _Passenger.PhoneNumber;
                CountryCodeSearchLookUpEdit.EditValue = _Passenger.CountryCode;
            }
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PhoneNumberTextEdit, ConditionOperator.IsNotBlank);
        }

        //Validasi kedua
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            if (CountryCodeSearchLookUpEdit.EditValue != null)
            {
                var countryCodeLength = CountryCodeSearchLookUpEdit.EditValue.ToString().Length;
                Regex regex = new Regex("^(\\+?\\d{1,4}\\s?)?(\\d{7,15})$");//new Regex("^[\\s-]?0?8[1-9]{1}\\d{1}\\d{4}[\\s-]?\\d{2,5}$");
                if (!regex.IsMatch(HelperConvert.String(this.PhoneNumberTextEdit.EditValue)))
                {
                    //this.PhoneNumberTextEdit.ErrorText = "Awalan nomor telepon harus '08' dan tidak boleh ada tanda '-' dan spasi";
                    MessageHelper.ShowMessageError(this, "Nomor telepon tidak valid");
                    result = false;
                }
                else if (HelperConvert.String(this.PhoneNumberTextEdit.EditValue).Length >= countryCodeLength)
                {
                    var countryCode = HelperConvert.String(CountryCodeSearchLookUpEdit.EditValue);
                    if (HelperConvert.String(this.PhoneNumberTextEdit.EditValue).Substring(0, countryCodeLength) != countryCode)
                    {
                        MessageHelper.ShowMessageError(this, $"Awalan nomor telepon harus '{countryCode}'");
                        result = false;
                    }
                }
            }
            else
            {
                MessageHelper.ShowMessageError(this, "Pilih kode negara terlebih dahulu");
                result = false;
            }

            return result;
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);

            countryCodeList = DataCountryCodes.GetCountryCodes();
            SLUHelper.GeneralSlU(CountryCodeSearchLookUpEdit, countryCodeList, displayMember: "Code");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Passenger>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Passenger>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Passenger>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Passenger = new Passenger()
            {
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                CountryCode = HelperConvert.String(CountryCodeSearchLookUpEdit.EditValue),
                PhoneNumber = HelperConvert.String(PhoneNumberTextEdit.EditValue),
                Email = HelperConvert.String(EmailTextEdit.EditValue),
            };
            OdataEntity = _Passenger;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Passenger>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Passenger>();
        }
    }
}

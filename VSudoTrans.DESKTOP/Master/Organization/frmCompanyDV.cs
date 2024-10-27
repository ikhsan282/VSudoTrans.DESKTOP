using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Organization;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using System.Collections.Generic;
using PopUpUtils;
using System.IO;
using System;
using Domain;

namespace VSudoTrans.DESKTOP.Master.Organization
{
    public partial class frmCompanyDV : frmBaseDV
    {
        List<CountryCode> countryCodeList = new List<CountryCode>();
        Company _Company;
        public frmCompanyDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeSearchLookup();
            InitializeComponentAfter<Company>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            this.PhoneNumberTextEdit.Properties.Mask.EditMask = "(\\d{9})|(\\d{10})|(\\d{11})|(\\d{12})|(\\d{13})|(\\d{14})|(\\d{15})";
            this.PhoneNumberTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.PhoneNumberTextEdit.Properties.Mask.ShowPlaceHolders = false;

            PhoneNumberTextEdit.Validating += PhoneNumberTextEdit_Validating;
            CountryCodeSearchLookUpEdit.EditValueChanged += CountryCodeSearchLookUpEdit_EditValueChanged;

            LogoPictureEdit.ImageLoading += LogoPictureEdit_ImageLoading;
            WatermarkPictureEdit.ImageLoading += WatermarkPictureEdit_ImageLoading;
            WatermarkPaidPictureEdit.ImageLoading += WatermarkPaidPictureEdit_ImageLoading;
            WatermarkUnpaidPictureEdit.ImageLoading += WatermarkUnpaidPictureEdit_ImageLoading;

            LogoPictureEdit.PopupMenuShowing += PictureEdit_PopupMenuShowing;
            WatermarkPictureEdit.PopupMenuShowing += PictureEdit_PopupMenuShowing;
            WatermarkPaidPictureEdit.PopupMenuShowing += PictureEdit_PopupMenuShowing;
            WatermarkUnpaidPictureEdit.PopupMenuShowing += PictureEdit_PopupMenuShowing;

            SandboxServerKeyButtonEdit.ButtonClick += SandboxServerKeyButtonEdit_ButtonClick;
            SandboxClientKeyButtonEdit.ButtonClick += SandboxClientKeyButtonEdit_ButtonClick;
            ProductionServerKeyButtonEdit.ButtonClick += ProductionServerKeyButtonEdit_ButtonClick;
            ProductionClientKeyButtonEdit.ButtonClick += ProductionClientKeyButtonEdit_ButtonClick;
        }
        private void ProductionClientKeyButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (ProductionClientKeyButtonEdit.Properties.UseSystemPasswordChar == true)
                ProductionClientKeyButtonEdit.Properties.UseSystemPasswordChar = false;
            else
                ProductionClientKeyButtonEdit.Properties.UseSystemPasswordChar = true;
        }

        private void ProductionServerKeyButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (ProductionServerKeyButtonEdit.Properties.UseSystemPasswordChar == true)
                ProductionServerKeyButtonEdit.Properties.UseSystemPasswordChar = false;
            else
                ProductionServerKeyButtonEdit.Properties.UseSystemPasswordChar = true;
        }

        private void SandboxClientKeyButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (SandboxClientKeyButtonEdit.Properties.UseSystemPasswordChar == true)
                SandboxClientKeyButtonEdit.Properties.UseSystemPasswordChar = false;
            else
                SandboxClientKeyButtonEdit.Properties.UseSystemPasswordChar = true;
        }

        private void SandboxServerKeyButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (SandboxServerKeyButtonEdit.Properties.UseSystemPasswordChar == true)
                SandboxServerKeyButtonEdit.Properties.UseSystemPasswordChar = false;
            else
                SandboxServerKeyButtonEdit.Properties.UseSystemPasswordChar = true;
        }

        private void WatermarkPaidPictureEdit_PopupMenuShowing(object sender, DevExpress.XtraEditors.Events.PopupMenuShowingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void WatermarkUnpaidPictureEdit_ImageLoading(object sender, DevExpress.XtraEditors.Repository.SaveLoadImageEventArgs e)
        {
            if (GroupPopUp.EditValue == null)
            {
                e.Handled = false;
                return;
            }

            MessageHelper.WaitFormShow(this);
            try
            {
                FileInfo fi = new FileInfo(e.FileName);
                string fileExtension = fi.Extension.ToLower();

                if (!string.IsNullOrEmpty(e.FileName))
                {
                    byte[] file = File.ReadAllBytes(e.FileName);
                    string fileName = fi.Name;

                    var result = HelperRestSharp.UploadFile(file, fileName, typeof(Company).Name.ToLower());

                    if (string.IsNullOrEmpty(result))
                        MessageHelper.ShowMessageError(this, $"Gagal unggah file! : {fi.Name}");

                    _Company.WatermarkUnpaid = result;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No connection"))
                    MessageHelper.ShowMessageError(this, "Tidak dapat terhubung, Url tidak aktif");
                else
                    MessageHelper.ShowMessageError(this, ex);
            }
            finally
            {
                MessageHelper.WaitFormClose();
            }
        }

        private void WatermarkPaidPictureEdit_ImageLoading(object sender, DevExpress.XtraEditors.Repository.SaveLoadImageEventArgs e)
        {
            if (GroupPopUp.EditValue == null)
            {
                e.Handled = false;
                return;
            }

            MessageHelper.WaitFormShow(this);
            try
            {
                FileInfo fi = new FileInfo(e.FileName);
                string fileExtension = fi.Extension.ToLower();

                if (!string.IsNullOrEmpty(e.FileName))
                {
                    byte[] file = File.ReadAllBytes(e.FileName);
                    string fileName = fi.Name;

                    var result = HelperRestSharp.UploadFile(file, fileName, typeof(Company).Name.ToLower());

                    if (string.IsNullOrEmpty(result))
                        MessageHelper.ShowMessageError(this, $"Gagal unggah file! : {fi.Name}");

                    _Company.WatermarkPaid = result;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No connection"))
                    MessageHelper.ShowMessageError(this, "Tidak dapat terhubung, Url tidak aktif");
                else
                    MessageHelper.ShowMessageError(this, ex);
            }
            finally
            {
                MessageHelper.WaitFormClose();
            }
        }

        private void PictureEdit_PopupMenuShowing(object sender, DevExpress.XtraEditors.Events.PopupMenuShowingEventArgs e)
        {
            if (GroupPopUp.EditValue == null)
            {
                e.Cancel = true;
                MessageHelper.ShowMessageError(this, "Kolom grup tidak boleh kosong!");
                return;
            }
        }

        private void WatermarkPictureEdit_ImageLoading(object sender, DevExpress.XtraEditors.Repository.SaveLoadImageEventArgs e)
        {
            if (GroupPopUp.EditValue == null)
            {
                e.Handled = false;
                return;
            }

            MessageHelper.WaitFormShow(this);
            try
            {
                FileInfo fi = new FileInfo(e.FileName);
                string fileExtension = fi.Extension.ToLower();

                if (!string.IsNullOrEmpty(e.FileName))
                {
                    byte[] file = File.ReadAllBytes(e.FileName);
                    string fileName = fi.Name;

                    var result = HelperRestSharp.UploadFile(file, fileName, typeof(Company).Name.ToLower());

                    if (string.IsNullOrEmpty(result))
                        MessageHelper.ShowMessageError(this, $"Gagal unggah file! : {fi.Name}");

                    _Company.Watermark = result;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No connection"))
                    MessageHelper.ShowMessageError(this, "Tidak dapat terhubung, Url tidak aktif");
                else
                    MessageHelper.ShowMessageError(this, ex);
            }
            finally
            {
                MessageHelper.WaitFormClose();
            }
        }

        private void LogoPictureEdit_ImageLoading(object sender, DevExpress.XtraEditors.Repository.SaveLoadImageEventArgs e)
        {
            if (GroupPopUp.EditValue == null)
            {
                e.Handled = false;
                return;
            }

            MessageHelper.WaitFormShow(this);
            try
            {
                FileInfo fi = new FileInfo(e.FileName);
                string fileExtension = fi.Extension.ToLower();

                if (!string.IsNullOrEmpty(e.FileName))
                {
                    byte[] file = File.ReadAllBytes(e.FileName);
                    string fileName = fi.Name;

                    var result = HelperRestSharp.UploadFile(file, fileName, typeof(Company).Name.ToLower());

                    if (string.IsNullOrEmpty(result))
                        MessageHelper.ShowMessageError(this, $"Gagal unggah file! : {fi.Name}");

                    _Company.Logo = result;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No connection"))
                    MessageHelper.ShowMessageError(this, "Tidak dapat terhubung, Url tidak aktif");
                else
                    MessageHelper.ShowMessageError(this, ex);
            }
            finally
            {
                MessageHelper.WaitFormClose();
            }
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
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^(\\+?\\d{1,4}\\s?)?(\\d{7,15})$");//new Regex("^[\\s-]?0?8[1-9]{1}\\d{1}\\d{4}[\\s-]?\\d{2,5}$");
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

        //Validasi kedua
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            if (CountryCodeSearchLookUpEdit.EditValue != null)
            {
                var countryCodeLength = CountryCodeSearchLookUpEdit.EditValue.ToString().Length;
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^(\\+?\\d{1,4}\\s?)?(\\d{7,15})$");//new Regex("^[\\s-]?0?8[1-9]{1}\\d{1}\\d{4}[\\s-]?\\d{2,5}$");
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

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.GroupPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CountryCodeSearchLookUpEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PhoneNumberTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.WebsiteTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.AddressMemoEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.General<Group>(fEndPoint: "/Groups", fTitle: "Group", fControl: GroupPopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");

            countryCodeList = DataCountryCodes.GetCountryCodes();
            SLUHelper.GeneralSlU(CountryCodeSearchLookUpEdit, countryCodeList, displayMember: "Code");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Company>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Company>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Company>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Company = OdataEntity as Company;

            if (_Company != null)
            {
                if (!string.IsNullOrEmpty(_Company.LogoUrl))
                {
                    LogoPictureEdit.LoadAsync(_Company.LogoUrl);
                }

                if (!string.IsNullOrEmpty(_Company.WatermarkUrl))
                {
                    WatermarkPictureEdit.LoadAsync(_Company.WatermarkUrl);
                }

                if (!string.IsNullOrEmpty(_Company.WatermarkPaidUrl))
                {
                    WatermarkPaidPictureEdit.LoadAsync(_Company.WatermarkPaidUrl);
                }

                if (!string.IsNullOrEmpty(_Company.WatermarkUnpaidUrl))
                {
                    WatermarkUnpaidPictureEdit.LoadAsync(_Company.WatermarkUnpaidUrl);
                }
            }
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Company = new Company()
            {
                Id = _Company.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                GroupId = HelperConvert.Int(AssemblyHelper.GetValueProperty(GroupPopUp.EditValue, "Id")),
                CountryCode = HelperConvert.String(CountryCodeSearchLookUpEdit.EditValue),
                PhoneNumber = HelperConvert.String(PhoneNumberTextEdit.EditValue),
                Address = HelperConvert.String(AddressMemoEdit.EditValue),
                Website = HelperConvert.String(WebsiteTextEdit.EditValue),
                Logo = _Company.Logo,
                Watermark = _Company.Watermark,
                WatermarkPaid = _Company.WatermarkPaid,
                WatermarkUnpaid = _Company.WatermarkUnpaid,

                IsProduction = IsProductionCheckEdit.Checked,
                Merchant = HelperConvert.String(MerchantTextEdit.EditValue),
                SandboxClientKey = HelperConvert.String(SandboxClientKeyButtonEdit.EditValue),
                SandboxServerKey = HelperConvert.String(SandboxServerKeyButtonEdit.EditValue),
                ProductionClientKey = HelperConvert.String(ProductionClientKeyButtonEdit.EditValue),
                ProductionServerKey = HelperConvert.String(ProductionServerKeyButtonEdit.EditValue),
            };

            OdataEntity = _Company;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Company>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Company>();
        }
    }
}

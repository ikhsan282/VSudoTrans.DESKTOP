using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Filtering;
using Domain;
using Domain.Entities.Demography;
using Domain.Entities.EducationResource;
using Domain.Entities.HumanResource;
using Domain.Entities.Organization;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.IO;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.EducationResource
{
    public partial class frmStudentDV : frmBaseDV
    {
        List<CountryCode> countryCodeList = new List<CountryCode>();
        Student _Student;
        StudentPersonalData _StudentPersonalData;
        public frmStudentDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;
            InitializeComponent();

            InitializeComponentAfter<Student>();

            InitializeSearchLookup();

            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateEdit(JoinDateDateEdit, "dd-MMM-yyyy");
            HelperConvert.FormatDateEdit(EndDateDateEdit, "dd-MMM-yyyy");
            HelperConvert.FormatSpinEdit(HeightSpinEdit, "n0", 0, 300);
            HelperConvert.FormatSpinEdit(WeightSpinEdit, "n0", 0, 300);
            HelperConvert.FormatSpinEdit(ChildSpinEdit, "n0", 0, 50);
            HelperConvert.FormatSpinEdit(SiblingSpinEdit, "n0", 0, 50);
            HelperConvert.FormatDateEdit(BirthDayDateEdit, "dd-MMM-yyyy");

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            this.PhoneNumberTextEdit.Properties.Mask.EditMask = "(\\d{9})|(\\d{10})|(\\d{11})|(\\d{12})|(\\d{13})|(\\d{14})|(\\d{15})";
            this.PhoneNumberTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.PhoneNumberTextEdit.Properties.Mask.ShowPlaceHolders = false;

            this.AlternatePhoneNumberTextEdit.Properties.Mask.EditMask = "(\\d{9})|(\\d{10})|(\\d{11})|(\\d{12})|(\\d{13})|(\\d{14})|(\\d{15})";
            this.AlternatePhoneNumberTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.AlternatePhoneNumberTextEdit.Properties.Mask.ShowPlaceHolders = false;

            PhoneNumberTextEdit.Validating += PhoneNumberTextEdit_Validating;
            CountryCodeSearchLookUpEdit.EditValueChanged += CountryCodeSearchLookUpEdit_EditValueChanged;

            AlternatePhoneNumberTextEdit.Validating += AlternatePhoneNumberTextEdit_Validating;
            AlternateCountryCodeSearchLookUpEdit.EditValueChanged += AlternateCountryCodeSearchLookUpEdit_EditValueChanged;

            PhotoPictureEdit.ImageLoading += PhotoPictureEdit_ImageLoading;
            SignaturePictureEdit.ImageLoading += SignaturePictureEdit_ImageLoading;

            PhotoPictureEdit.PopupMenuShowing += PictureEdit_PopupMenuShowing;
            SignaturePictureEdit.PopupMenuShowing += PictureEdit_PopupMenuShowing;
        }

        private void PictureEdit_PopupMenuShowing(object sender, DevExpress.XtraEditors.Events.PopupMenuShowingEventArgs e)
        {
            if (CompanyPopUp.EditValue == null)
            {
                e.Cancel = true;
                MessageHelper.ShowMessageError(this, "Kolom Sekolah tidak boleh kosong!");
                return;
            }
        }

        private void SignaturePictureEdit_ImageLoading(object sender, DevExpress.XtraEditors.Repository.SaveLoadImageEventArgs e)
        {
            if (CompanyPopUp.EditValue == null)
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

                    var result = HelperRestSharp.UploadFile(file, fileName, typeof(Student).Name.ToLower());

                    if (string.IsNullOrEmpty(result))
                        MessageHelper.ShowMessageError(this, $"Gagal unggah file! : {fi.Name}");

                    _StudentPersonalData.Signature = result;
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

        private void PhotoPictureEdit_ImageLoading(object sender, DevExpress.XtraEditors.Repository.SaveLoadImageEventArgs e)
        {
            if (CompanyPopUp.EditValue == null)
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

                    var result = HelperRestSharp.UploadFile(file, fileName, typeof(Student).Name.ToLower());

                    if (string.IsNullOrEmpty(result))
                        MessageHelper.ShowMessageError(this, $"Gagal unggah file! : {fi.Name}");

                    _StudentPersonalData.Photo = result;
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
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^(\\+?\\d{1,4}\\s?)?(\\d{7,15})$");
                if (!regex.IsMatch(HelperConvert.String(this.PhoneNumberTextEdit.EditValue)))
                {
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

        private void AlternateCountryCodeSearchLookUpEdit_EditValueChanged(object sender, System.EventArgs e)
        {
            if (AlternateCountryCodeSearchLookUpEdit.EditValue != null)
                AlternatePhoneNumberTextEdit.EditValue = HelperConvert.String(AlternateCountryCodeSearchLookUpEdit.EditValue);
        }

        //Validasi pertama
        private void AlternatePhoneNumberTextEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (AlternateCountryCodeSearchLookUpEdit.EditValue != null)
            {
                var countryCodeLength = AlternateCountryCodeSearchLookUpEdit.EditValue.ToString().Length;
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^(\\+?\\d{1,4}\\s?)?(\\d{7,15})$");
                if (!regex.IsMatch(HelperConvert.String(this.AlternatePhoneNumberTextEdit.EditValue)))
                {
                    this.AlternatePhoneNumberTextEdit.ErrorText = "Nomor telepon tidak valid";
                    e.Cancel = true;
                }
                else if (HelperConvert.String(this.AlternatePhoneNumberTextEdit.EditValue).Length >= countryCodeLength)
                {
                    var countryCode = HelperConvert.String(AlternateCountryCodeSearchLookUpEdit.EditValue);
                    if (HelperConvert.String(this.AlternatePhoneNumberTextEdit.EditValue).Substring(0, countryCodeLength) != countryCode)
                    {
                        this.AlternatePhoneNumberTextEdit.ErrorText = $"Awalan nomor telepon harus '{countryCode}'";
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                this.AlternatePhoneNumberTextEdit.ErrorText = "Pilih kode negara terlebih dahulu";
                e.Cancel = true;
            }
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("Code;Name");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ClassPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.MajorPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.RombelPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ForceYearPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
        }

        //Validasi kedua
        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            if (CountryCodeSearchLookUpEdit.EditValue != null)
            {
                if (this.PhoneNumberTextEdit.EditValue != null && HelperConvert.String(this.PhoneNumberTextEdit.EditValue) != "")
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
            PopupEditHelper.General<Class>(fEndPoint: "/Classes", fTitle: "Kelas", fControl: ClassPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fDisplayText: "Name");
            PopupEditHelper.General<Rombel>(fEndPoint: "/Rombels", fTitle: "Rombel", fControl: RombelPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fDisplayText: "Name");
            PopupEditHelper.General<Major>(fEndPoint: "/Majors", fTitle: "Jurusan", fControl: MajorPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "TypeEducation;Code;Name", fCaptionColumn: "Tipe Pendidikan;Kode;Nama", fWidthColumn: "250;100;400", fDisplayText: "TypeEducation;Code;Name");
            PopupEditHelper.General<ForceYear>(fEndPoint: "/ForceYears", fTitle: "Angkatan", fControl: ForceYearPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fWidthColumn: "100", fDisplayText: "Name");

            PopupEditHelper.General<Province>(fEndPoint: "/Provinces", fTitle: "Provinsi", fControl: FromSchoolProvincePopUp, fChild: FromSchoolCityPopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
            PopupEditHelper.General<City>(fEndPoint: "/Citys", fTitle: "Kota", fControl: FromSchoolCityPopUp, fCascade: FromSchoolProvincePopUp, fCascadeMember: "ProvinceId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");

            countryCodeList = DataCountryCodes.GetCountryCodes();
            SLUHelper.GeneralSlU(CountryCodeSearchLookUpEdit, countryCodeList, displayMember: "Code");
            SLUHelper.GeneralSlU(AlternateCountryCodeSearchLookUpEdit, countryCodeList, displayMember: "Code");
            SLUHelper.GeneralSlU(CountryCodeFatherSearchLookUpEdit, countryCodeList, displayMember: "Code");
            SLUHelper.GeneralSlU(CountryCodeMotherSearchLookUpEdit, countryCodeList, displayMember: "Code");


            SLUHelper.SetEnumDataSource(ReligionSearchLookUpEdit, new Converter<EnumReligion, string>(EnumHelper.EnumReligionToString));
            SLUHelper.SetEnumDataSource(GenderSearchLookUpEdit, new Converter<EnumGender, string>(EnumHelper.EnumGenderToString));
            SLUHelper.SetEnumDataSource(BloodTypeSearchLookUpEdit, new Converter<EnumBloodType, string>(EnumHelper.EnumBloodTypeToString));
            SLUHelper.SetEnumDataSource(MaritalStatusSearchLookUpEdit, new Converter<EnumMaritalStatus, string>(EnumHelper.EnumMaritalStatusToString));
            SLUHelper.SetEnumDataSource(ParentalStatusSearchLookUpEdit, new Converter<EnumParentalStatus, string>(EnumHelper.EnumParentalStatusToString));
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Student>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Student>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Student>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Student = OdataEntity as Student;

            _StudentPersonalData = _Student.StudentPersonalData;

            if (_StudentPersonalData != null)
            {
                AlternateCountryCodeSearchLookUpEdit.EditValue = _StudentPersonalData.AlternateCountryCode;
                AlternatePhoneNumberTextEdit.EditValue = _StudentPersonalData.AlternatePhoneNumber;
                AlternateEmailTextEdit.EditValue = _StudentPersonalData.AlternateEmail;

                FromSchoolProvincePopUp.EditValue = _StudentPersonalData.FromSchoolProvince;
                FromSchoolCityPopUp.EditValue = _StudentPersonalData.FromSchoolCity;
                FromSchoolTextEdit.EditValue = _StudentPersonalData.FromSchool;
                NoSKHUNTextEdit.EditValue = _StudentPersonalData.NoSKHUN;
                GraduationYearTextEdit.EditValue = _StudentPersonalData.GraduationYear;

                NoKTPTextEdit.EditValue = _StudentPersonalData.NoKTP;
                NoKKTextEdit.EditValue = _StudentPersonalData.NoKK;
                AddressMemoEdit.EditValue = _StudentPersonalData.Address;
                PresentAddressMemoEdit.EditValue = _StudentPersonalData.PresentAddress;
                BirthPlaceTextEdit.EditValue = _StudentPersonalData.BirthPlace;
                BirthDayDateEdit.EditValue = _StudentPersonalData.BirthDay;

                ReligionSearchLookUpEdit.EditValue = _StudentPersonalData.Religion;
                GenderSearchLookUpEdit.EditValue = _StudentPersonalData.Gender;
                BloodTypeSearchLookUpEdit.EditValue = _StudentPersonalData.BloodType;
                MaritalStatusSearchLookUpEdit.EditValue = _StudentPersonalData.MaritalStatus;
                HeightSpinEdit.EditValue = _StudentPersonalData.Height;
                WeightSpinEdit.EditValue = _StudentPersonalData.Weight;
                EthnicTextEdit.EditValue = _StudentPersonalData.Ethnic;
                NationalityTextEdit.EditValue = _StudentPersonalData.Nationality;
                ChildSpinEdit.EditValue = _StudentPersonalData.Child;
                SiblingSpinEdit.EditValue = _StudentPersonalData.Sibling;

                FatherNameTextEdit.EditValue = _StudentPersonalData.FatherName;
                CountryCodeFatherSearchLookUpEdit.EditValue = _StudentPersonalData.CountryCodeFather;
                PhoneNumberFatherTextEdit.EditValue = _StudentPersonalData.PhoneNumberFather;
                FatherWorkTextEdit.EditValue = _StudentPersonalData.FatherWork;

                MotherNameTextEdit.EditValue = _StudentPersonalData.MotherName;
                CountryCodeMotherSearchLookUpEdit.EditValue = _StudentPersonalData.CountryCodeMother;
                PhoneNumberMotherTextEdit.EditValue = _StudentPersonalData.PhoneNumberMother;
                MotherWorkTextEdit.EditValue = _StudentPersonalData.MotherWork;

                if (!string.IsNullOrEmpty(_StudentPersonalData.PhotoUrl))
                {
                    PhotoPictureEdit.LoadAsync(_StudentPersonalData.PhotoUrl);
                }
                if (!string.IsNullOrEmpty(_StudentPersonalData.SignatureUrl))
                {
                    SignaturePictureEdit.LoadAsync(_StudentPersonalData.SignatureUrl);
                }
            }
            else
                _StudentPersonalData = new StudentPersonalData();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Student = new Student()
            {
                Id = _Student.Id,
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                ClassId = HelperConvert.Int(AssemblyHelper.GetValueProperty(ClassPopUp.EditValue, "Id")),
                MajorId = HelperConvert.Int(AssemblyHelper.GetValueProperty(MajorPopUp.EditValue, "Id")),
                RombelId = HelperConvert.Int(AssemblyHelper.GetValueProperty(RombelPopUp.EditValue, "Id")),
                ForceYearId = HelperConvert.Int(AssemblyHelper.GetValueProperty(ForceYearPopUp.EditValue, "Id")),
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),

                JoinDate = HelperConvert.Date(JoinDateDateEdit.EditValue),
                CountryCode = HelperConvert.String(CountryCodeSearchLookUpEdit.EditValue),
                PhoneNumber = HelperConvert.String(PhoneNumberTextEdit.EditValue),
                Email = HelperConvert.String(EmailTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
            };


            var endDate = HelperConvert.Date(EndDateDateEdit.EditValue);
            if (endDate.Date != DateTime.MinValue)
                _Student.EndDate = HelperConvert.Date(EndDateDateEdit.EditValue);
            else
                _Student.EndDate = null;

            if (ParentalStatusSearchLookUpEdit.EditValue != null)
                _Student.ParentalStatus = (EnumParentalStatus)ParentalStatusSearchLookUpEdit.EditValue;

            if (NISNTextEdit.EditValue != null)
                _Student.NISN = HelperConvert.String(NISNTextEdit.EditValue);
            else
                _Student.NISN = null;

            _StudentPersonalData.AlternateCountryCode = HelperConvert.String(AlternateCountryCodeSearchLookUpEdit.EditValue);
            _StudentPersonalData.AlternatePhoneNumber = HelperConvert.String(AlternatePhoneNumberTextEdit.EditValue);
            _StudentPersonalData.AlternateEmail = HelperConvert.String(AlternateEmailTextEdit.EditValue);

            if (FromSchoolProvincePopUp.EditValue != null)
                _StudentPersonalData.FromSchoolProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(FromSchoolProvincePopUp.EditValue, "Id"));
            else
                _StudentPersonalData.FromSchoolProvinceId = null;

            if (FromSchoolCityPopUp.EditValue != null)
                _StudentPersonalData.FromSchoolCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(FromSchoolCityPopUp.EditValue, "Id"));
            else
                _StudentPersonalData.FromSchoolCityId = null;

            _StudentPersonalData.FromSchool = HelperConvert.String(FromSchoolTextEdit.EditValue);
            _StudentPersonalData.NoSKHUN = HelperConvert.String(NoSKHUNTextEdit.EditValue);
            _StudentPersonalData.GraduationYear = HelperConvert.String(GraduationYearTextEdit.EditValue);

            _StudentPersonalData.NoKTP = HelperConvert.String(NoKTPTextEdit.EditValue);
            _StudentPersonalData.NoKK = HelperConvert.String(NoKKTextEdit.EditValue);
            _StudentPersonalData.Address = HelperConvert.String(AddressMemoEdit.EditValue);
            _StudentPersonalData.PresentAddress = HelperConvert.String(PresentAddressMemoEdit.EditValue);
            _StudentPersonalData.BirthPlace = HelperConvert.String(BirthPlaceTextEdit.EditValue);
            _StudentPersonalData.BirthDay = HelperConvert.Date(BirthDayDateEdit.EditValue);

            if (ReligionSearchLookUpEdit.EditValue != null)
                _StudentPersonalData.Religion = (EnumReligion)ReligionSearchLookUpEdit.EditValue;

            if (GenderSearchLookUpEdit.EditValue != null)
                _StudentPersonalData.Gender = (EnumGender)GenderSearchLookUpEdit.EditValue;

            if (BloodTypeSearchLookUpEdit.EditValue != null)
                _StudentPersonalData.BloodType = (EnumBloodType)BloodTypeSearchLookUpEdit.EditValue;

            if (MaritalStatusSearchLookUpEdit.EditValue != null)
                _StudentPersonalData.MaritalStatus = (EnumMaritalStatus)MaritalStatusSearchLookUpEdit.EditValue;

            _StudentPersonalData.Height = HelperConvert.Int(HeightSpinEdit.EditValue);
            _StudentPersonalData.Weight = HelperConvert.Int(WeightSpinEdit.EditValue);
            _StudentPersonalData.Ethnic = HelperConvert.String(EthnicTextEdit.EditValue);
            _StudentPersonalData.Nationality = HelperConvert.String(NationalityTextEdit.EditValue);
            _StudentPersonalData.Child = HelperConvert.Int(ChildSpinEdit.EditValue);
            _StudentPersonalData.Sibling = HelperConvert.Int(SiblingSpinEdit.EditValue);

            _StudentPersonalData.FatherName = HelperConvert.String(FatherNameTextEdit.EditValue);
            _StudentPersonalData.CountryCodeFather = HelperConvert.String(CountryCodeFatherSearchLookUpEdit.EditValue);
            _StudentPersonalData.PhoneNumberFather = HelperConvert.String(PhoneNumberFatherTextEdit.EditValue);
            _StudentPersonalData.FatherWork = HelperConvert.String(FatherWorkTextEdit.EditValue);

            _StudentPersonalData.MotherName = HelperConvert.String(MotherNameTextEdit.EditValue);
            _StudentPersonalData.CountryCodeMother = HelperConvert.String(CountryCodeMotherSearchLookUpEdit.EditValue);
            _StudentPersonalData.PhoneNumberMother = HelperConvert.String(PhoneNumberMotherTextEdit.EditValue);
            _StudentPersonalData.MotherWork = HelperConvert.String(MotherWorkTextEdit.EditValue);

            _Student.StudentPersonalData = _StudentPersonalData;

            if (_Student.StudentPersonalData != null)
                _Student.StudentPersonalData.StudentId = _Student.Id;

            OdataEntity = _Student;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Student>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Student>();
        }
    }
}

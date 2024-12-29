using System.Collections.Generic;
using System.Threading.Tasks;
using VSudoTrans.DESKTOP.BaseForm;
using Domain.Entities.HumanResource;
using VSudoTrans.DESKTOP.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System;
using Domain.Entities.Organization;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Demography;
using PopUpUtils;
using System.IO;
using Domain;

namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    public partial class frmEmployeeDV : frmBaseDV
    {
        List<CountryCode> countryCodeList = new List<CountryCode>();
        Employee _Employee;
        EmployeePersonalData _EmployeePersonalData;
        public frmEmployeeDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Employee>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;
            InitializeSearchLookup();

            HelperConvert.FormatDateEdit(JoinDateDateEdit, "dd-MMM-yyyy");
            //HelperConvert.FormatDateEdit(EndDateDateEdit, "dd-MMM-yyyy");
            HelperConvert.FormatDateEdit(ResignationDateDateEdit, "dd-MMM-yyyy");
            HelperConvert.FormatDateEdit(CreatedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");
            HelperConvert.FormatDateEdit(ModifiedDateDateEdit, "dd-MMM-yyyy HH:mm:ss");

            this.PhoneNumberTextEdit.Properties.Mask.EditMask = "(\\d{9})|(\\d{10})|(\\d{11})|(\\d{12})|(\\d{13})|(\\d{14})|(\\d{15})";
            this.PhoneNumberTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.PhoneNumberTextEdit.Properties.Mask.ShowPlaceHolders = false;

            PhoneNumberTextEdit.Validating += PhoneNumberTextEdit_Validating;
            CountryCodeSearchLookUpEdit.EditValueChanged += CountryCodeSearchLookUpEdit_EditValueChanged;

            JobTitlePopUp.ReadOnly = true;

            JobPositionPopUp.EditValueChanged += JobPositionPopUp_EditValueChanged;

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
                MessageHelper.ShowMessageError(this, "Kolom Perusahaan tidak boleh kosong!");
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

                    var result = HelperRestSharp.UploadFile(file, fileName, typeof(Employee).Name.ToLower());

                    if (string.IsNullOrEmpty(result))
                        MessageHelper.ShowMessageError(this, $"Gagal unggah file! : {fi.Name}");

                    _EmployeePersonalData.Signature = result;
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

                    var result = HelperRestSharp.UploadFile(file, fileName, typeof(Employee).Name.ToLower());

                    if (string.IsNullOrEmpty(result))
                        MessageHelper.ShowMessageError(this, $"Gagal unggah file! : {fi.Name}");

                    _EmployeePersonalData.Photo = result;
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

        private void JobPositionPopUp_EditValueChanged(object sender, EventArgs e)
        {
            if (JobPositionPopUp.EditValue != null)
            {
                var jobPosition = JobPositionPopUp.EditValue as JobPosition;
                if (jobPosition != null)
                    JobTitlePopUp.EditValue = jobPosition.JobTitle;
                else
                    JobTitlePopUp.EditValue = null;
            }
            else
                JobTitlePopUp.EditValue = null;
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
            MyValidationHelper.SetValidation(_DxValidationProvider, this.JobTitlePopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.JoinDateDateEdit, ConditionOperator.IsNotBlank);
            //MyValidationHelper.SetValidation(_DxValidationProvider, this.EndDateDateEdit, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            PopupEditHelper.General<OrganizationStructure>(fEndPoint: "/OrganizationStructures", fTitle: "Organisasi", fControl: OrganizationStructurePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
            PopupEditHelper.General<JobTitle>(fEndPoint: "/JobTitles", fTitle: "Jabatan", fControl: JobTitlePopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
            PopupEditHelper.General<JobPosition>(fEndPoint: "/JobPositions", fTitle: "Posisi Pekerjaan", fControl: JobPositionPopUp, fDisplaycolumn: "Code;Name;JobTitle.Code;JobTitle.Name", fCaptionColumn: "Kode;Nama;Kode Jabatan; Nama Jabatan", fExpand: "JobTitle($select=Id,Code,Name)");
            PopupEditHelper.General<JobGrade>(fEndPoint: "/JobGrades", fTitle: "Golongan", fControl: JobGradePopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
            PopupEditHelper.General<Bank>(fEndPoint: "/Banks", fTitle: "Bank", fControl: BankPopUp, fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");

            countryCodeList = DataCountryCodes.GetCountryCodes();
            SLUHelper.GeneralSlU(CountryCodeSearchLookUpEdit, countryCodeList, displayMember: "Code");
            SLUHelper.GeneralSlU(AlternateCountryCodeSearchLookUpEdit, countryCodeList, displayMember: "Code");
            SLUHelper.GeneralSlU(CountryCodeFatherSearchLookUpEdit, countryCodeList, displayMember: "Code");
            SLUHelper.GeneralSlU(CountryCodeMotherSearchLookUpEdit, countryCodeList, displayMember: "Code");

            SLUHelper.SetEnumDataSource(ReligionSearchLookUpEdit, new Converter<EnumReligion, string>(EnumHelper.EnumReligionToString));
            SLUHelper.SetEnumDataSource(GenderSearchLookUpEdit, new Converter<EnumGender, string>(EnumHelper.EnumGenderToString));
            SLUHelper.SetEnumDataSource(BloodTypeSearchLookUpEdit, new Converter<EnumBloodType, string>(EnumHelper.EnumBloodTypeToString));
            SLUHelper.SetEnumDataSource(MaritalStatusSearchLookUpEdit, new Converter<EnumMaritalStatus, string>(EnumHelper.EnumMaritalStatusToString));
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Employee>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Employee>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Employee>();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Employee = OdataEntity as Employee;

            _EmployeePersonalData = _Employee.EmployeePersonalData;

            if (_EmployeePersonalData != null)
            {
                AlternateCountryCodeSearchLookUpEdit.EditValue = _EmployeePersonalData.AlternateCountryCode;
                AlternatePhoneNumberTextEdit.EditValue = _EmployeePersonalData.AlternatePhoneNumber;
                AlternateEmailTextEdit.EditValue = _EmployeePersonalData.AlternateEmail;

                NoKTPTextEdit.EditValue = _EmployeePersonalData.NoKTP;
                NoKKTextEdit.EditValue = _EmployeePersonalData.NoKK;
                AddressMemoEdit.EditValue = _EmployeePersonalData.Address;
                PresentAddressMemoEdit.EditValue = _EmployeePersonalData.PresentAddress;
                BirthPlaceTextEdit.EditValue = _EmployeePersonalData.BirthPlace;
                BirthDayDateEdit.EditValue = _EmployeePersonalData.BirthDay;

                ReligionSearchLookUpEdit.EditValue = _EmployeePersonalData.Religion;
                GenderSearchLookUpEdit.EditValue = _EmployeePersonalData.Gender;
                BloodTypeSearchLookUpEdit.EditValue = _EmployeePersonalData.BloodType;
                MaritalStatusSearchLookUpEdit.EditValue = _EmployeePersonalData.MaritalStatus;
                HeightSpinEdit.EditValue = _EmployeePersonalData.Height;
                WeightSpinEdit.EditValue = _EmployeePersonalData.Weight;
                EthnicTextEdit.EditValue = _EmployeePersonalData.Ethnic;
                NationalityTextEdit.EditValue = _EmployeePersonalData.Nationality;
                ChildSpinEdit.EditValue = _EmployeePersonalData.Child;
                SiblingSpinEdit.EditValue = _EmployeePersonalData.Sibling;

                FatherNameTextEdit.EditValue = _EmployeePersonalData.FatherName;
                CountryCodeFatherSearchLookUpEdit.EditValue = _EmployeePersonalData.CountryCodeFather;
                PhoneNumberFatherTextEdit.EditValue = _EmployeePersonalData.PhoneNumberFather;
                FatherWorkTextEdit.EditValue = _EmployeePersonalData.FatherWork;

                MotherNameTextEdit.EditValue = _EmployeePersonalData.MotherName;
                CountryCodeMotherSearchLookUpEdit.EditValue = _EmployeePersonalData.CountryCodeMother;
                PhoneNumberMotherTextEdit.EditValue = _EmployeePersonalData.PhoneNumberMother;
                MotherWorkTextEdit.EditValue = _EmployeePersonalData.MotherWork;

                if (!string.IsNullOrEmpty(_EmployeePersonalData.PhotoUrl))
                {
                    PhotoPictureEdit.LoadAsync(_EmployeePersonalData.PhotoUrl);
                }
                if (!string.IsNullOrEmpty(_EmployeePersonalData.SignatureUrl))
                {
                    SignaturePictureEdit.LoadAsync(_EmployeePersonalData.SignatureUrl);
                }
            }
            else
                _EmployeePersonalData = new EmployeePersonalData();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Employee = new Employee()
            {
                Id = _Employee.Id,
                Code = HelperConvert.String(CodeTextEdit.EditValue),
                Name = HelperConvert.String(NameTextEdit.EditValue),
                Note = HelperConvert.String(NoteMemoEdit.EditValue),
                JoinDate = HelperConvert.Date(JoinDateDateEdit.EditValue),
                //EndDate = HelperConvert.Date(EndDateDateEdit.EditValue),
                CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                OrganizationStructureId = HelperConvert.Int(AssemblyHelper.GetValueProperty(OrganizationStructurePopUp.EditValue, "Id")),
                JobTitleId = HelperConvert.Int(AssemblyHelper.GetValueProperty(JobTitlePopUp.EditValue, "Id")),
                JobGradeId = HelperConvert.Int(AssemblyHelper.GetValueProperty(JobGradePopUp.EditValue, "Id")),
                JobPositionId = HelperConvert.Int(AssemblyHelper.GetValueProperty(JobPositionPopUp.EditValue, "Id")),
                CountryCode = HelperConvert.String(CountryCodeSearchLookUpEdit.EditValue),
                PhoneNumber = HelperConvert.String(PhoneNumberTextEdit.EditValue),
                Email = HelperConvert.String(EmailTextEdit.EditValue),

                AccountNumber = HelperConvert.String(AccountNumberTextEdit.EditValue),
                AccountName = HelperConvert.String(AccountNameTextEdit.EditValue),
            };

            var resignationDate = HelperConvert.Date(ResignationDateDateEdit.EditValue);
            if (resignationDate.Date != DateTime.MinValue)
                _Employee.ResignationDate = resignationDate;
            else
                _Employee.ResignationDate = null;

            var bank = BankPopUp.EditValue as Bank;
            if (bank != null)
                _Employee.BankId = bank.Id;
            else
                _Employee.BankId = null;

            _EmployeePersonalData.AlternateCountryCode = HelperConvert.String(AlternateCountryCodeSearchLookUpEdit.EditValue);
            _EmployeePersonalData.AlternatePhoneNumber = HelperConvert.String(AlternatePhoneNumberTextEdit.EditValue);
            _EmployeePersonalData.AlternateEmail = HelperConvert.String(AlternateEmailTextEdit.EditValue);

            _EmployeePersonalData.NoKTP = HelperConvert.String(NoKTPTextEdit.EditValue);
            _EmployeePersonalData.NoKK = HelperConvert.String(NoKKTextEdit.EditValue);
            _EmployeePersonalData.Address = HelperConvert.String(AddressMemoEdit.EditValue);
            _EmployeePersonalData.PresentAddress = HelperConvert.String(PresentAddressMemoEdit.EditValue);
            _EmployeePersonalData.BirthPlace = HelperConvert.String(BirthPlaceTextEdit.EditValue);
            _EmployeePersonalData.BirthDay = HelperConvert.Date(BirthDayDateEdit.EditValue);

            if (ReligionSearchLookUpEdit.EditValue != null)
                _EmployeePersonalData.Religion = (EnumReligion)ReligionSearchLookUpEdit.EditValue;

            if (GenderSearchLookUpEdit.EditValue != null)
                _EmployeePersonalData.Gender = (EnumGender)GenderSearchLookUpEdit.EditValue;

            if (BloodTypeSearchLookUpEdit.EditValue != null)
                _EmployeePersonalData.BloodType = (EnumBloodType)BloodTypeSearchLookUpEdit.EditValue;

            if (MaritalStatusSearchLookUpEdit.EditValue != null)
                _EmployeePersonalData.MaritalStatus = (EnumMaritalStatus)MaritalStatusSearchLookUpEdit.EditValue;

            _EmployeePersonalData.Height = HelperConvert.Int(HeightSpinEdit.EditValue);
            _EmployeePersonalData.Weight = HelperConvert.Int(WeightSpinEdit.EditValue);
            _EmployeePersonalData.Ethnic = HelperConvert.String(EthnicTextEdit.EditValue);
            _EmployeePersonalData.Nationality = HelperConvert.String(NationalityTextEdit.EditValue);
            _EmployeePersonalData.Child = HelperConvert.Int(ChildSpinEdit.EditValue);
            _EmployeePersonalData.Sibling = HelperConvert.Int(SiblingSpinEdit.EditValue);

            _EmployeePersonalData.FatherName = HelperConvert.String(FatherNameTextEdit.EditValue);
            _EmployeePersonalData.CountryCodeFather = HelperConvert.String(CountryCodeFatherSearchLookUpEdit.EditValue);
            _EmployeePersonalData.PhoneNumberFather = HelperConvert.String(PhoneNumberFatherTextEdit.EditValue);
            _EmployeePersonalData.FatherWork = HelperConvert.String(FatherWorkTextEdit.EditValue);

            _EmployeePersonalData.MotherName = HelperConvert.String(MotherNameTextEdit.EditValue);
            _EmployeePersonalData.CountryCodeMother = HelperConvert.String(CountryCodeMotherSearchLookUpEdit.EditValue);
            _EmployeePersonalData.PhoneNumberMother = HelperConvert.String(PhoneNumberMotherTextEdit.EditValue);
            _EmployeePersonalData.MotherWork = HelperConvert.String(MotherWorkTextEdit.EditValue);

            _Employee.EmployeePersonalData = _EmployeePersonalData;

            if (_Employee.EmployeePersonalData != null)
                _Employee.EmployeePersonalData.EmployeeId = _Employee.Id;

            OdataEntity = _Employee;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Employee>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Employee>();
        }
    }
}

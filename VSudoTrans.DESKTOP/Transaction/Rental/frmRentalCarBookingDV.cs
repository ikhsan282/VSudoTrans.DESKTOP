using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Domain;
using Domain.Entities.Demography;
using Domain.Entities.Rental;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VSudoTrans.DESKTOP.Master.Travel;
using VSudoTrans.DESKTOP.Master.Transportation;
using Domain.Entities.Transportation;
using Domain.Entities.Travel;
using Domain.Entities.Vehicle;

namespace VSudoTrans.DESKTOP.Transaction.Rental
{
    public partial class frmRentalCarBookingDV : frmBaseDV
    {
        RentalCarBooking _RentalCarBooking;
        public frmRentalCarBookingDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();
            InitializeSearchLookup();

            InitializeComponentAfter<RentalCarBooking>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateEdit(DateDateEdit);
            HelperConvert.FormatDateTimeEdit(TimeDateEdit, "HH:mm");

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            HelperConvert.FormatSpinEdit(TotalPriceSpinEdit, "n0", 0, 888888888888888);

            PickupDistrictPopUp.EditValueChanged += PickupDistrictPopUp_EditValueChanged;
            DeliveryDistrictPopUp.EditValueChanged += DeliveryDistrictPopUp_EditValueChanged;

            groupPassenger.CustomButtonClick += GroupPassenger_CustomButtonClick;
        }

        private void GroupPassenger_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            //LayoutControlGroup layoutGroup = sender as LayoutControlGroup;
            if (e.Button.Properties.Caption.Contains("Tambah Penumpang"))
            {
                using (var form = new frmPassengerDV(0, "/Passengers"))
                {
                    form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    form.bbiSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    form.bbiSaveAndNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    form.ShowDialog();

                    //if (CompanyPopUp.EditValue != null)
                    //    PopupEditHelper.General<Passenger>("/Passengers", PassengerPopUp, fFilter: $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))}", fDisplaycolumn: "Code;Name;PhoneNumber", fCaptionColumn: "Kode;Nama;Nomor Telepon");
                }
            }
        }

        private void DeliveryDistrictPopUp_EditValueChanged(object sender, EventArgs e)
        {
            var district = DeliveryDistrictPopUp.EditValue as District;

            if (district != null)
            {
                DeliveryProvinceTextEdit.EditValue = $"{district.Province.Code} - {district.Province.Name}";
                DeliveryCityTextEdit.EditValue = $"{district.City.Code} - {district.City.Name}";
            }
        }

        private void PickupDistrictPopUp_EditValueChanged(object sender, EventArgs e)
        {
            var district = PickupDistrictPopUp.EditValue as District;

            if (district != null)
            {
                PickupProvinceTextEdit.EditValue = $"{district.Province.Code} - {district.Province.Name}";
                PickupCityTextEdit.EditValue = $"{district.City.Code} - {district.City.Name}";
            }
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("DocumentNumber");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DateDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.TimeDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StatusSearchLookUpEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupDistrictPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryDistrictPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupAddressMemoEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryAddressMemoEdit, ConditionOperator.IsNotBlank);

            MyValidationHelper.SetValidation(_DxValidationProvider, this.TotalPriceSpinEdit, ConditionOperator.IsNotBlank);
        }

        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            //if (rute != null)
            //{
            //    string ranges = "";
            //    foreach (var ruteSchedule in rute.RuteSchedules)
            //    {
            //        ranges += $"({ruteSchedule.Schedule.Start.Subtract(new TimeSpan(1, 0, 0))} - {ruteSchedule.Schedule.Start.Add(new TimeSpan(1, 0, 0))})" + Environment.NewLine;
            //    }

            //    var schedule = rute.RuteSchedules.Where(s => HelperConvert.Date(TimeDateEdit.EditValue).TimeOfDay >= s.Schedule.Start.Subtract(new TimeSpan(1, 0, 0)) && HelperConvert.Date(TimeDateEdit.EditValue).TimeOfDay <= s.Schedule.Start.Add(new TimeSpan(1, 0, 0))).ToList();
            //    if (!schedule.Any())
            //    {
            //        result = false;
            //        MessageHelper.ShowMessageError(this, "Pastikan kamu memilih jam sesuai range jadwal yang di tetapkan rute tersebut!" + Environment.NewLine + ranges);
            //    }
            //}

            return result;
        }

        protected override void DisplayEntity<T>()
        {
            StatusSearchLookUpEdit.EditValue = EnumStatusBooking.New;
            PassengerTypeSearchLookUpEdit.EditValue = EnumPassengerType.Person;

            DateDateEdit.EditValue = DateTime.Today;
            TimeDateEdit.EditValue = DateTime.Now.TimeOfDay;

            base.DisplayEntity<T>();

            _RentalCarBooking = OdataEntity as RentalCarBooking;
            if (_RentalCarBooking != null)
            {
                this.TotalPriceSpinEdit.EditValue = _RentalCarBooking.TotalPrice;
                this.TimeDateEdit.EditValue = new DateTime(_RentalCarBooking.Time.Ticks);
            }
        }

        protected override void InitializeSearchLookup()
        {
            SLUHelper.SetEnumDataSource(StatusSearchLookUpEdit, new Converter<EnumStatusBooking, string>(EnumHelper.EnumStatusBookingToString));
            SLUHelper.SetEnumDataSource(PassengerTypeSearchLookUpEdit, new Converter<EnumPassengerType, string>(EnumHelper.EnumPassengerTypeToString));

            PopupEditHelper.Company(CompanyPopUp);
            PopupEditHelper.Passenger(PassengerPopUp, CompanyPopUp, "CompanyId");
            PopupEditHelper.General<CategoryVehicle>("/CategoryVehicles", CategoryVehiclePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");

            PopupEditHelper.General<District>(fEndPoint: "/Districts", fTitle: "Kecamatan", fControl: PickupDistrictPopUp, fWidthColumn: "150;200;300", fDisplaycolumn: "Province.Name;City.Name;Name", fCaptionColumn: "Provinsi;Kota;Kecamatan", fDisplayText: "Name", fSelect: "Id,Name,ProvinceId,CityId", fExpand: "Province($select=code,name),City($select=code,name)");

            PopupEditHelper.General<District>(fEndPoint: "/Districts", fTitle: "Kecamatan", fControl: DeliveryDistrictPopUp, fWidthColumn: "150;200;300", fDisplaycolumn: "Province.Name;City.Name;Name", fCaptionColumn: "Provinsi;Kota;Kecamatan", fDisplayText: "Name", fSelect: "Id,Name,ProvinceId,CityId", fExpand: "Province($select=code,name),City($select=code,name)");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<RentalCarBooking>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<RentalCarBooking>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<RentalCarBooking>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            if (_RentalCarBooking.Id == 0)
                _RentalCarBooking = new RentalCarBooking();

            _RentalCarBooking.Id = _RentalCarBooking.Id;
            _RentalCarBooking.CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"));
            _RentalCarBooking.PassengerId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PassengerPopUp.EditValue, "Id"));
            _RentalCarBooking.CategoryVehicleId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CategoryVehiclePopUp.EditValue, "Id"));
            _RentalCarBooking.Date = HelperConvert.Date(DateDateEdit.EditValue);
            _RentalCarBooking.Time = HelperConvert.Date(TimeDateEdit.EditValue).TimeOfDay;
            _RentalCarBooking.PassengerType = (EnumPassengerType)PassengerTypeSearchLookUpEdit.EditValue;
            _RentalCarBooking.Status = (EnumStatusBooking)StatusSearchLookUpEdit.EditValue;

            _RentalCarBooking.PickupPointProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupDistrictPopUp.EditValue, "ProvinceId"));
            _RentalCarBooking.PickupPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupDistrictPopUp.EditValue, "CityId"));
            _RentalCarBooking.PickupPointDistrictId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupDistrictPopUp.EditValue, "Id"));
            _RentalCarBooking.PickupAddress = HelperConvert.String(PickupAddressMemoEdit.EditValue);

            _RentalCarBooking.DeliveryPointProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryDistrictPopUp.EditValue, "ProvinceId"));
            _RentalCarBooking.DeliveryPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryDistrictPopUp.EditValue, "CityId"));
            _RentalCarBooking.DeliveryPointDistrictId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryDistrictPopUp.EditValue, "Id"));
            _RentalCarBooking.DeliveryAddress = HelperConvert.String(DeliveryAddressMemoEdit.EditValue);

            _RentalCarBooking.TotalPrice = HelperConvert.Decimal(TotalPriceSpinEdit.EditValue);

            _RentalCarBooking.Note = HelperConvert.String(NoteMemoEdit.EditValue);

            OdataEntity = _RentalCarBooking;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<RentalCarBooking>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<RentalCarBooking>();
        }
    }
}

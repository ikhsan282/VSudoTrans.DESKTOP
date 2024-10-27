using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraSplashScreen;
using Domain;
using Domain.Entities.Attendance;
using Domain.Entities.Demography;
using Domain.Entities.Organization;
using Domain.Entities.Travel;
using Microsoft.OData.Client;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Microsoft.Graph.CoreConstants;

namespace VSTS.DESKTOP.Master.Travel
{
    public partial class frmTravelTicketBookingDV : frmBaseDV
    {
        TravelTicketBooking _TravelTicketBooking;
        public frmTravelTicketBookingDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();
            InitializeSearchLookup();

            InitializeComponentAfter<TravelTicketBooking>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateEdit(DateDateEdit);
            HelperConvert.FormatDateTimeEdit(TimeDateEdit, "HH:mm");

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            HelperConvert.FormatDecimalTextEdit(TotalPriceTextEdit);
            HelperConvert.FormatSpinEdit(TotalTicketSpinEdit, "n0", 0, 200);

            CompanyPopUp.EditValueChanged += CompanyPopUp_EditValueChanged;

            PickupDistrictPopUp.EditValueChanged += PickupDistrictPopUp_EditValueChanged;
            DeliveryDistrictPopUp.EditValueChanged += DeliveryDistrictPopUp_EditValueChanged;


            GridHelper.GridViewInitializeLayout(_GridViewPassenger);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlPassenger, true, true, true, true, true, true, true, true, true, true, true, true);
            GridHelper.GridColumnInitializeLayout(colPrice, typeof(decimal), "n0");
            _GridViewPassenger.ValidateRow += _GridViewPassenger_ValidateRow;
            _GridViewPassenger.RowEditCanceled += _GridViewPassenger_RowEditCanceled;
            _GridViewPassenger.RowUpdated += _GridViewPassenger_RowUpdated;

            _GridViewPassenger.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridViewPassenger.OptionsBehavior.Editable = true;

            SLUHelper.SetEnumDataSource(PassengerTypeSearchLookUpEdit, new Converter<EnumPassengerType, string>(EnumHelper.EnumPassengerTypeToString));
            SLUHelper.SetEnumDataSource(StatusSearchLookUpEdit, new Converter<EnumStatusBooking, string>(EnumHelper.EnumStatusBookingToString));
            //SLUHelper.SetEnumDataSource(PaymentTypeSearchLookUpEdit, new Converter<EnumPaymentType, string>(EnumHelper.EnumPaymentTypeToString));
            SLUHelper.SetEnumDataSource(PriceTypeSearchLookUpEdit, new Converter<EnumPriceType, string>(EnumHelper.EnumPriceTypeToString));

            groupPassenger.CustomButtonClick += GroupPassenger_CustomButtonClick;
            groupRute.CustomButtonClick += GroupRute_CustomButtonClick;
        }

        private void GroupRute_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            //LayoutControlGroup layoutGroup = sender as LayoutControlGroup;
            if (e.Button.Properties.Caption.Contains("Tambah Rute"))
            {
                using (var form = new frmRuteDV(0, "/Rutes"))
                {
                    form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    form.bbiSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    form.bbiSaveAndNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    form.ShowDialog();

                    SearchRute();
                }
            }
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

                    if (CompanyPopUp.EditValue != null)
                        PopupEditHelper.General<Passenger>("/Passengers", PassengerPopUp, fFilter: $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))}", fDisplaycolumn: "Code;Name;PhoneNumber", fCaptionColumn: "Kode;Nama;Nomor Telepon");
                }
            }
        }

        private void DeliveryDistrictPopUp_EditValueChanged(object sender, EventArgs e)
        {
            IOverlaySplashScreenHandle handle = MessageHelper.ShowOverlayWait(this);

            if (DeliveryDistrictPopUp.EditValue != null)
                SearchRute();

            MessageHelper.CloseOverlayWait(handle);
        }

        private void PickupDistrictPopUp_EditValueChanged(object sender, EventArgs e)
        {
            IOverlaySplashScreenHandle handle = MessageHelper.ShowOverlayWait(this);

            if (PickupDistrictPopUp.EditValue != null)
                SearchRute();

            MessageHelper.CloseOverlayWait(handle);
        }

        private void CompanyPopUp_EditValueChanged(object sender, EventArgs e)
        {
            if (CompanyPopUp.EditValue != null)
            {
                PopupEditHelper.General<Passenger>("/Passengers", PassengerPopUp, fFilter: $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))}", fDisplaycolumn: "Code;Name;PhoneNumber", fCaptionColumn: "Kode;Nama;Nomor Telepon");

                SearchRute();
            }
        }

        private void _GridViewPassenger_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;

            // update dulu id yang bersesuian
            TravelTicketBookingDetail row = e.Row as TravelTicketBookingDetail;
            if (row == null) return;
            //row.ScheduleId = row.ScheduleId;
            row.TravelTicketBookingId = _TravelTicketBooking.Id;
            row.PassengerId = HelperConvert.Int(AssemblyHelper.GetValueProperty(row.Passenger, "Id"));

            SumTotalPrice();
        }

        private void SumTotalPrice()
        {
            TotalPriceTextEdit.EditValue = (_BindingSourcePassenger.DataSource as List<TravelTicketBookingDetail>).Sum(s => s.Price);
        }

        private void _GridViewPassenger_RowEditCanceled(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //if (e.Row == null) return;
            //GridView view = sender as GridView;

            //// update dulu id yang bersesuian
            //RuteSchedule row = e.Row as RuteSchedule;
            //if (row == null) return;

            //for (int i = 0; i < view.RowCount; i++)
            //{
            //    if (i != view.GetDataSourceRowIndex(view.FocusedRowHandle))
            //    {
            //        var tempVal = HelperConvert.Int(view.GetRowCellValue(i, "ScheduleId"));
            //        if (row.ScheduleId != null)
            //        {
            //            if (tempVal == row.ScheduleId)
            //            {
            //                view.DeleteRow(e.RowHandle);
            //                return;
            //            }
            //        }
            //    }
            //}
        }

        private void _GridViewPassenger_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            var result = gridView.GetFocusedRow() as TravelTicketBookingDetail;

            if (result == null) return;

            var price = result.Price;
            if (price != null)
            {
                if (price == null)
                {
                    gridView.SetColumnError(colPrice, $"Harga tidak boleh kosong");
                    e.Valid = false;
                    return;
                }
                else if (price <= 0)
                {
                    gridView.SetColumnError(colPrice, $"Harga tidak boleh 0");
                    e.Valid = false;
                    return;
                }
                else
                {
                    var priceTravel = rute.TravelPrices.Where(s => s.PriceType == (EnumPriceType)HelperConvert.Int(PriceTypeSearchLookUpEdit.EditValue)).FirstOrDefault();
                    if (priceTravel != null)
                    {
                        if (price < priceTravel.MinPrice)
                        {
                            gridView.SetColumnError(colPrice, $"Harga tidak boleh dibawah {string.Format("{0:N0}", priceTravel.MinPrice)}");
                            e.Valid = false;
                            return;
                        }
                        else
                        if (price > priceTravel.MaxPrice)
                        {
                            gridView.SetColumnError(colPrice, $"Harga tidak boleh diatas {string.Format("{0:N0}", priceTravel.MaxPrice)}");
                            e.Valid = false;
                            return;
                        }
                    }
                }
            }

            var passenger = result.Passenger;

            if (passenger == null)
            {
                gridView.SetColumnError(colPassengerId, $"Penumpang tidak boleh kosong");
                e.Valid = false;
                return;
            }
            else if (passenger.Id == 0)
            {
                gridView.SetColumnError(colPassengerId, $"Penumpang tidak boleh kosong");
                e.Valid = false;
                return;
            }

            var passengerType = result.PassengerType;

            if (passengerType == null)
            {
                gridView.SetColumnError(colPassengerId, $"Tipe tidak boleh kosong");
                e.Valid = false;
                return;
            }

            if (e.Valid)
                gridView.ClearColumnErrors();
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
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PaymentTypeSearchLookUpEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StatusSearchLookUpEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupDistrictPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryDistrictPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupAddressMemoEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryAddressMemoEdit, ConditionOperator.IsNotBlank);

            MyValidationHelper.SetValidation(_DxValidationProvider, this.TotalPriceTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.TotalTicketSpinEdit, ConditionOperator.IsNotBlank);
        }

        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            List<TravelTicketBookingDetail> travelTicketBookingDetails = _BindingSourcePassenger.DataSource as List<TravelTicketBookingDetail>;
            if (travelTicketBookingDetails != null)
            {
                if (!travelTicketBookingDetails.Any())
                {
                    MessageHelper.ShowMessageError(this, "Penumpang tidak boleh kosong!");
                    result = false;
                }
                else
                {
                    foreach (var item in travelTicketBookingDetails)
                    {
                        if (item.PassengerId == 0)
                        {
                            MessageHelper.ShowMessageError(this, "Penumpang tidak boleh kosong!");
                            result = false;
                        }
                    }
                }
            }
            else
            {
                MessageHelper.ShowMessageError(this, "Penumpang tidak boleh kosong!");
                result = false;
            }

            if (HelperConvert.Int(TotalTicketSpinEdit.EditValue) > travelTicketBookingDetails.Count)
            {
                MessageHelper.ShowMessageError(this, "Jumlah tiket tidak boleh lebih dari jumlah data penumpang!");
                result = false;
            }
            else if (HelperConvert.Int(TotalTicketSpinEdit.EditValue) < travelTicketBookingDetails.Count)
            {
                MessageHelper.ShowMessageError(this, "Jumlah tiket tidak boleh kurang dari jumlah data penumpang!");
                result = false;
            }

            if (rute != null)
            {
                string ranges = "";
                foreach (var ruteSchedule in rute.RuteSchedules)
                {
                    ranges += $"({ruteSchedule.Schedule.Start.Subtract(new TimeSpan(1, 0, 0))} - {ruteSchedule.Schedule.Start.Add(new TimeSpan(1, 0, 0))})" + Environment.NewLine;
                }

                var schedule = rute.RuteSchedules.Where(s=> HelperConvert.Date(TimeDateEdit.EditValue).TimeOfDay >= s.Schedule.Start.Subtract(new TimeSpan(1, 0, 0)) && HelperConvert.Date(TimeDateEdit.EditValue).TimeOfDay <= s.Schedule.Start.Add(new TimeSpan(1, 0, 0))).ToList();
                if (!schedule.Any())
                {
                    result = false;
                    MessageHelper.ShowMessageError(this, "Pastikan kamu memilih jam sesuai range jadwal yang di tetapkan rute tersebut!" + Environment.NewLine + ranges);
                }
            }

            return result;
        }

        protected override void DisplayEntity<T>()
        {
            TotalTicketSpinEdit.EditValue = 1;
            StatusSearchLookUpEdit.EditValue = EnumStatusBooking.New;
            //PaymentTypeSearchLookUpEdit.EditValue = EnumPaymentType.Debit;
            PriceTypeSearchLookUpEdit.EditValue = EnumPriceType.Regular;

            DateDateEdit.EditValue = DateTime.Today;
            TimeDateEdit.EditValue = DateTime.Now;

            base.DisplayEntity<T>();

            _TravelTicketBooking = OdataEntity as TravelTicketBooking;
            if (_TravelTicketBooking != null)
            {
                //District pickup = HelperRestSharp.GetById<District>(_TravelTicketBooking.PickupPointDistrictId, "/Districts");
                //if (pickup != null)
                //{
                //    var province = HelperRestSharp.GetById<Province>(pickup.ProvinceId, $"/Provinces");
                //    var city = HelperRestSharp.GetById<City>(pickup.CityId, $"/Citys");

                //    PickupProvincePopUp.EditValue = province;
                //    PickupCityPopUp.EditValue = city;
                //}
                //District delivery = HelperRestSharp.GetById<District>(_TravelTicketBooking.DeliveryPointDistrictId, "/Districts");
                //if (delivery != null)
                //{
                //    var province = HelperRestSharp.GetById<Province>(delivery.ProvinceId, $"/Provinces");
                //    var city = HelperRestSharp.GetById<City>(delivery.CityId, $"/Citys");

                //    DeliveryProvincePopUp.EditValue = province;
                //    DeliveryCityPopUp.EditValue = city;
                //}
                this.TotalTicketSpinEdit.EditValue = _TravelTicketBooking.TotalTicket;
                this.TimeDateEdit.EditValue = new DateTime(_TravelTicketBooking.Time.Ticks);
                _BindingSourcePassenger.DataSource = _TravelTicketBooking.TravelTicketBookingDetails.ToList(); // setelah totaltiket agar aman
                //_GridControlPassenger.DataSource = _BindingSourcePassenger.DataSource; // setelah totaltiket agar aman
            }
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);

            PopupEditHelper.General<Province>(fEndPoint: "/Provinces", fTitle: "Provinsi", fControl: PickupProvincePopUp, fChild: PickupCityPopUp, fCascadeMember: "CountryId", fSelect: "id,code,name,countryid");
            PopupEditHelper.General<City>(fEndPoint: "/Citys", fCascadeMember: "ProvinceId", fTitle: "Kota", fControl: PickupCityPopUp, fCascade: PickupProvincePopUp, fChild: PickupDistrictPopUp, fSelect: "id,code,name,provinceid");
            PopupEditHelper.General<District>(fEndPoint: "/Districts", fCascadeMember: "CityId", fTitle: "Kecamatan", fControl: PickupDistrictPopUp, fCascade: PickupCityPopUp, fDisplaycolumn: "Name", fCaptionColumn: "Nama", fSelect: "id,code,name,cityid");
            
            PopupEditHelper.General<Province>(fEndPoint: "/Provinces", fTitle: "Provinsi", fControl: DeliveryProvincePopUp, fChild: DeliveryCityPopUp, fCascadeMember: "CountryId", fSelect: "id,code,name,countryid");
            PopupEditHelper.General<City>(fEndPoint: "/Citys", fCascadeMember: "ProvinceId", fTitle: "Kota", fControl: DeliveryCityPopUp, fCascade: DeliveryProvincePopUp, fChild: DeliveryDistrictPopUp, fSelect: "id,code,name,provinceid");
            PopupEditHelper.General<District>(fEndPoint: "/Districts", fCascadeMember: "CityId", fTitle: "Kecamatan", fControl: DeliveryDistrictPopUp, fCascade: DeliveryCityPopUp, fDisplaycolumn: "Name", fCaptionColumn: "Nama", fSelect: "id,code,name,cityid");
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<TravelTicketBooking>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<TravelTicketBooking>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<TravelTicketBooking>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            if (_TravelTicketBooking.Id == 0)
                _TravelTicketBooking = new TravelTicketBooking();

            _TravelTicketBooking.Id = _TravelTicketBooking.Id;
            _TravelTicketBooking.CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"));
            _TravelTicketBooking.Date = HelperConvert.Date(DateDateEdit.EditValue);
            _TravelTicketBooking.Time = HelperConvert.Date(TimeDateEdit.EditValue).TimeOfDay;
            _TravelTicketBooking.Status = (EnumStatusBooking)StatusSearchLookUpEdit.EditValue;
            //_TravelTicketBooking.PaymentType = (EnumPaymentType)PaymentTypeSearchLookUpEdit.EditValue;
            _TravelTicketBooking.PriceType = (EnumPriceType)PriceTypeSearchLookUpEdit.EditValue;
            _TravelTicketBooking.PickupPointProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupProvincePopUp.EditValue, "Id"));
            _TravelTicketBooking.PickupPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupCityPopUp.EditValue, "Id"));
            _TravelTicketBooking.PickupPointDistrictId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupDistrictPopUp.EditValue, "Id"));
            _TravelTicketBooking.PickupAddress = HelperConvert.String(PickupAddressMemoEdit.EditValue);
            _TravelTicketBooking.DeliveryPointProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryProvincePopUp.EditValue, "Id"));
            _TravelTicketBooking.DeliveryPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryCityPopUp.EditValue, "Id"));
            _TravelTicketBooking.DeliveryPointDistrictId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryDistrictPopUp.EditValue, "Id"));
            _TravelTicketBooking.DeliveryAddress = HelperConvert.String(DeliveryAddressMemoEdit.EditValue);

            _TravelTicketBooking.RuteId = rute.Id;

            _TravelTicketBooking.TotalPrice = HelperConvert.Decimal(TotalPriceTextEdit.EditValue);
            _TravelTicketBooking.TotalTicket = HelperConvert.Int(TotalTicketSpinEdit.EditValue);

            _TravelTicketBooking.Note = HelperConvert.String(NoteMemoEdit.EditValue);

            List<TravelTicketBookingDetail> travelTicketBookingDetails = _BindingSourcePassenger.DataSource as List<TravelTicketBookingDetail>;
            _TravelTicketBooking.TravelTicketBookingDetails = travelTicketBookingDetails;

            OdataEntity = _TravelTicketBooking;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<TravelTicketBooking>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<TravelTicketBooking>();
        }

        Rute rute = null;
        private void SearchRute()
        {
            if (CompanyPopUp.EditValue != null && PickupDistrictPopUp.EditValue != null && DeliveryDistrictPopUp.EditValue != null)
            {

                //rute = HelperRestSharp.GetListOdata<Rute>($"/Rutes", "id,code,name", fFilter: $"cityId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupCityPopUp.EditValue, "Id"))}");
                rute = HelperRestSharp.Get<Rute>($"/Rutes/By/District/{HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))}/{HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupDistrictPopUp.EditValue, "Id"))}/{HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryDistrictPopUp.EditValue, "Id"))}");
                if (rute != null)
                {
                    string price = "";
                    foreach (var travelPrice in rute.TravelPrices)
                    {
                        price += $"{EnumHelper.EnumPriceTypeToString(travelPrice.PriceType)} : {string.Format("{0:N0}", travelPrice.Price)}{Environment.NewLine}";
                    }
                    TravelPriceMemoEdit.EditValue = price;

                    List<Schedule> schedules = new List<Schedule>();
                    string schedule = "";
                    foreach (var ruteSchedule in rute.RuteSchedules.OrderBy(s => s.Schedule.Start).ToList())
                    {
                        schedule += $"{ruteSchedule.Schedule.Start.ToString(@"hh\:mm")} - {ruteSchedule.Schedule.End.ToString(@"hh\:mm")}{Environment.NewLine}";
                        schedules.Add(ruteSchedule.Schedule);
                    }

                    TravelScheduleMemoEdit.EditValue = schedule;
                    TravelPickupDistrictMemoEdit.EditValue = string.Join(Environment.NewLine, rute.PickupPointDistricts.Select(s => s.District.Name).OrderBy(s => s).ToList());
                    TravelDeliveryDistrictMemoEdit.EditValue = string.Join(Environment.NewLine, rute.DeliveryPointDistricts.Select(s => s.District.Name).OrderBy(s => s).ToList());

                    RuteTextEdit.EditValue = rute.Name;
                }
                else
                {
                    rute = null;
                    RuteTextEdit.EditValue = "Rute tidak ditemukan, silahkan tambahkan rute terlebih dahulu";
                }
            }
        }
    }
}

using Domain.Entities.Travel;
using Domain;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;
using Domain.Entities.Demography;
using Domain.Entities.Vehicle;
using Domain.Entities.HumanResource;
using DevExpress.XtraGrid.Views.Grid;

namespace VSudoTrans.DESKTOP.Master.Travel
{
    public partial class frmTripScheduleDV : frmBaseDV
    {
        TripSchedule _TripSchedule;
        public frmTripScheduleDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();
            InitializeSearchLookup();

            InitializeComponentAfter<TripSchedule>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateEdit(DateDateEdit);
            HelperConvert.FormatDateTimeEdit(StartTimeDateEdit, "HH:mm");
            HelperConvert.FormatDateTimeEdit(EndTimeDateEdit, "HH:mm");

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            GridHelper.GridViewInitializeLayout(_GridViewDetail);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlDetail, true, true, true, true, true, true, true, true, true, true, true, true);
            GridHelper.GridColumnInitializeLayout(colLineNumber, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colLineNumberDelivery, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colTravelTicketBooking3, typeof(decimal), "HH:mm");
            GridHelper.GridColumnInitializeLayout(colTravelTicketBooking4, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colTravelTicketBooking5, typeof(decimal), "n0");

            colTravelTicketBooking1.OptionsColumn.AllowEdit = false;
            colTravelTicketBooking2.OptionsColumn.AllowEdit = false;
            colTravelTicketBooking3.OptionsColumn.AllowEdit = false;
            colTravelTicketBooking4.OptionsColumn.AllowEdit = false;
            colTravelTicketBooking5.OptionsColumn.AllowEdit = false;

            _GridViewDetail.ValidateRow += _GridViewDetail_ValidateRow;
            _GridViewDetail.RowEditCanceled += _GridViewDetail_RowEditCanceled;
            _GridViewDetail.RowUpdated += _GridViewDetail_RowUpdated;

            _GridViewDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridViewDetail.OptionsBehavior.Editable = true;
        }
        private void _GridViewDetail_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;

            // update dulu id yang bersesuian
            TripScheduleDetail row = e.Row as TripScheduleDetail;
            if (row == null) return;
            row.TravelTicketBookingId = HelperConvert.Int(AssemblyHelper.GetValueProperty(row.TravelTicketBooking, "Id"));
            row.TripScheduleId = _TripSchedule.Id;
        }

        private void _GridViewDetail_RowEditCanceled(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;
            GridView view = sender as GridView;

            // update dulu id yang bersesuian
            TripScheduleDetail row = e.Row as TripScheduleDetail;
            if (row == null) return;

            for (int i = 0; i < view.RowCount; i++)
            {
                if (i != view.GetDataSourceRowIndex(view.FocusedRowHandle))
                {
                    var tempVal = HelperConvert.Int(view.GetRowCellValue(i, "TravelTicketBookingId"));
                    if (row.TravelTicketBookingId != null)
                    {
                        if (tempVal == row.TravelTicketBookingId)
                        {
                            view.DeleteRow(e.RowHandle);
                            return;
                        }
                    }
                }
            }
        }

        private void _GridViewDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            var result = gridView.GetFocusedRow() as TripScheduleDetail;

            if (result == null) return;

            var travelTicketBooking = result.TravelTicketBooking;

            if (travelTicketBooking == null)
            {
                gridView.SetColumnError(colTravelTicketBooking, $"Tiket tidak boleh kosong");
                e.Valid = false;
                return;
            }

            for (int i = 0; i < gridView.RowCount; i++)
            {
                if (i != gridView.GetDataSourceRowIndex(gridView.FocusedRowHandle))
                {
                    var tempVal = HelperConvert.Int(gridView.GetRowCellValue(i, "TravelTicketBookingId"));
                    if (tempVal == travelTicketBooking.Id)
                    {
                        gridView.SetColumnError(colTravelTicketBooking, "Adanya duplikasi data tiket");
                        e.Valid = false;
                        return;
                    }
                }
            }

            if (e.Valid)
                gridView.ClearColumnErrors();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _TripSchedule = OdataEntity as TripSchedule;

            if (_TripSchedule != null)
            {
                District pickup = HelperRestSharp.GetById<District>(_TripSchedule.PickupPointDistrictId, "/Districts");
                if (pickup != null)
                {
                    var province = HelperRestSharp.GetById<Province>(pickup.ProvinceId, $"/Provinces");
                    var city = HelperRestSharp.GetById<City>(pickup.CityId, $"/Citys");

                    PickupProvincePopUp.EditValue = province;
                    PickupCityPopUp.EditValue = city;
                }
                District delivery = HelperRestSharp.GetById<District>(_TripSchedule.DeliveryPointDistrictId, "/Districts");
                if (delivery != null)
                {
                    var province = HelperRestSharp.GetById<Province>(delivery.ProvinceId, $"/Provinces");
                    var city = HelperRestSharp.GetById<City>(delivery.CityId, $"/Citys");

                    DeliveryProvincePopUp.EditValue = province;
                    DeliveryCityPopUp.EditValue = city;
                }

                DateDateEdit.EditValue = _TripSchedule.Date;
                StartTimeDateEdit.EditValue = _TripSchedule.StartTime;
                EndTimeDateEdit.EditValue = _TripSchedule.EndTime;
            }
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.EmployeePopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.VehiclePopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DateDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StartTimeDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.EndTimeDateEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.TotalDurationTextEdit, ConditionOperator.IsNotBlank);

            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupProvincePopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryProvincePopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupCityPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryCityPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupDistrictPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryDistrictPopUp, ConditionOperator.IsNotBlank);
        }
        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("DocumentNumber");
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            PopupEditHelper.General<Vehicles>(fEndPoint: "/Vehicles", fTitle: "Kendaraan", fControl: VehiclePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fSelect: "id,vehicleNumber", fExpand: "brand($select=name),modelunit($select=name)", fDisplayText: "VehicleNumber;Brand.Name;ModelUnit.Name", fDisplaycolumn: "VehicleNumber;Brand.Name;ModelUnit.Name", fCaptionColumn: "Plat Nomor;Merek;Model");
            PopupEditHelper.General<Employee>(fEndPoint: "/Employees", fTitle: "Supir", fControl: EmployeePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fSelect: "id,code,name,phonenumber");
            PopupEditHelper.General<TravelTicketBooking>(fEndPoint: "/TravelTicketBookings", fTitle: "Tiket Pemesanan", fControl: TravelTicketBookingPopUp, fCascade: CompanyPopUp, 
                fCascadeMember: "CompanyId", fSelect: "id,Date,Time,DocumentNumber,TotalTicket,TotalPrice", fExpand: "PickupPointCity($select=Name),DeliveryPointCity($select=Name)", fDisplayText: "DocumentNumber", 
                fDisplaycolumn: "DocumentNumber;Date;Time;TotalTicket;TotalPrice;PickupPointCity.Name;DeliveryPointCity.Name", fCaptionColumn: "No Dokumen;Tanggal;Jam;Total Tiket;Total Harga;Kota Penjemputan;Kota Pengantaran", fOptionsDisplayFormat: "string;dd-MMM-yyyy;hh:mm;n0;n0;string;string",
                fWidthColumn: "210;100;80;70;110;150;150");

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
            ActionSaveNew<TripSchedule>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<TripSchedule>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<TripSchedule>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            if (_TripSchedule.Id == 0)
                _TripSchedule = new TripSchedule();

            _TripSchedule.Id = _TripSchedule.Id;

            _TripSchedule.CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"));
            _TripSchedule.DocumentNumber = HelperConvert.String(DocumentNumberTextEdit.EditValue);
            _TripSchedule.EmployeeId = HelperConvert.Int(AssemblyHelper.GetValueProperty(EmployeePopUp.EditValue, "Id"));
            _TripSchedule.VehicleId = HelperConvert.Int(AssemblyHelper.GetValueProperty(VehiclePopUp.EditValue, "Id"));

            _TripSchedule.PickupPointProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupProvincePopUp.EditValue, "Id"));
            _TripSchedule.PickupPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupCityPopUp.EditValue, "Id"));
            _TripSchedule.PickupPointDistrictId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupDistrictPopUp.EditValue, "Id"));

            _TripSchedule.DeliveryPointProvinceId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryProvincePopUp.EditValue, "Id"));
            _TripSchedule.DeliveryPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryCityPopUp.EditValue, "Id"));
            _TripSchedule.DeliveryPointDistrictId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryDistrictPopUp.EditValue, "Id"));

            _TripSchedule.Date = HelperConvert.Date(DateDateEdit.EditValue);

            _TripSchedule.StartTime = HelperConvert.Date(StartTimeDateEdit.EditValue).TimeOfDay;
            _TripSchedule.EndTime = HelperConvert.Date(EndTimeDateEdit.EditValue).TimeOfDay;
            _TripSchedule.TotalDuration = HelperConvert.Decimal(TotalDurationTextEdit.EditValue);

            OdataEntity = _TripSchedule;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<TripSchedule>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<TripSchedule>();
        }
    }
}

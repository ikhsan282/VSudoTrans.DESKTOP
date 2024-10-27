using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Organization;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using Domain.Entities.Travel;
using System.Threading.Tasks;
using Domain.Entities.Demography;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using System;
using System.Linq;
using Domain;
using DevExpress.XtraSplashScreen;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.Travel
{
    public partial class frmRuteDV : frmBaseDV
    {
        Rute _Rute;
        List<District> _DataDistrictPickup = new List<District>();
        List<District> _DistrictPickup = new List<District>();
        List<District> _DataDistrictDelivery = new List<District>();
        List<District> _DistrictDelivery = new List<District>();
        public frmRuteDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;

            InitializeComponent();

            InitializeComponentAfter<Rute>();
            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            PickupCityPopUp.EditValueChanged += PickupCityPopUp_EditValueChanged;
            DeliveryCityPopUp.EditValueChanged += DeliveryCityPopUp_EditValueChanged;

            HelperConvert.FormatSpinEdit(MinPriceSpinEdit, "n0", 0, 100000000);
            HelperConvert.FormatSpinEdit(PriceSpinEdit, "n0", 0, 100000000);
            HelperConvert.FormatSpinEdit(MaxPriceSpinEdit, "n0", 0, 100000000);
            HelperConvert.FormatSpinEdit(StartCapacitySpinEdit, "n0", 0, 100);
            HelperConvert.FormatSpinEdit(EndCapacitySpinEdit, "n0", 0, 100);

            GridHelper.GridColumnInitializeLayout(colPrice, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colMinPrice, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colMaxPrice, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colStartCapacitySeat, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colEndCapacitySeat, typeof(decimal), "n0");

            GridHelper.GridViewInitializeLayout(_GridViewTravelPrice);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlTravelPrice, true, true, true, true, true, true, true, true, true, true, true, true);
            _GridViewTravelPrice.ValidateRow += _GridViewTravelPrice_ValidateRow;
            _GridViewTravelPrice.RowEditCanceled += _GridViewTravelPrice_RowEditCanceled;
            _GridViewTravelPrice.RowUpdated += _GridViewTravelPrice_RowUpdated;

            _GridViewTravelPrice.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridViewTravelPrice.OptionsBehavior.Editable = true;
            //_BindingSourceTravelPrice.DataSource = new List<TravelPrice>();

            GridHelper.GridViewInitializeLayout(_GridViewSchedule);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlSchedule, true, true, true, true, true, true, true, true, true, true, true, true);
            _GridViewSchedule.ValidateRow += _GridViewSchedule_ValidateRow;
            _GridViewSchedule.RowEditCanceled += _GridViewSchedule_RowEditCanceled;
            _GridViewSchedule.RowUpdated += _GridViewSchedule_RowUpdated;

            _GridViewSchedule.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridViewSchedule.OptionsBehavior.Editable = true;
            //_BindingSourceRuteSchedules.DataSource = new List<RuteSchedule>();

            GridHelper.GridViewInitializeLayout(_GridViewPickupDistrict);
            //_GridViewPickupDistrict.OptionsView.ColumnAutoWidth = true;
            GridHelper.GridViewInitializeLayout(_GridViewPickupDistrictSelect);
            //_GridViewPickupDistrictSelect.OptionsView.ColumnAutoWidth = true;
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlPickupDistrict, fNext: true, fPrev: true);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlPickupDistrictSelect, fNext: true, fPrev: true);

            GridHelper.GridViewInitializeLayout(_GridViewDeliveryDistrict);
            //_GridViewDeliveryDistrict.OptionsView.ColumnAutoWidth = true;
            GridHelper.GridViewInitializeLayout(_GridViewDeliveryDistrictSelect);
            //_GridViewDeliveryDistrictSelect.OptionsView.ColumnAutoWidth = true;
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlDeliveryDistrict, fNext: true, fPrev: true);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlDeliveryDistrictSelect, fNext: true, fPrev: true);

            #region Pickup
            colCityNamePickup.Group();
            _GridViewPickupDistrict.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _GridViewPickupDistrict.OptionsBehavior.AutoExpandAllGroups = true;
            _GridViewPickupDistrict.ExpandAllGroups();
            colIdPickup.Visible = false;
            colCityNamePickup.Visible = false;
            _GridViewPickupDistrict.OptionsView.ShowIndicator = false;
            _GridViewPickupDistrict.OptionsFind.AllowFindPanel = false;
            _GridViewPickupDistrict.OptionsView.ShowGroupPanel = false;
            _GridViewPickupDistrict.OptionsView.ColumnAutoWidth = false;
            _GridViewPickupDistrict.OptionsSelection.MultiSelect = true;
            _GridViewPickupDistrict.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

            colCityNamePickupSelect.Group();
            _GridViewPickupDistrictSelect.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _GridViewPickupDistrictSelect.OptionsBehavior.AutoExpandAllGroups = true;
            _GridViewPickupDistrictSelect.ExpandAllGroups();
            colIdPickupSelect.Visible = false;
            colCityNamePickupSelect.Visible = false;
            _GridViewPickupDistrictSelect.OptionsView.ShowIndicator = false;
            _GridViewPickupDistrictSelect.OptionsDetail.EnableMasterViewMode = false;
            _GridViewPickupDistrictSelect.OptionsView.ColumnAutoWidth = false;
            _GridViewPickupDistrictSelect.OptionsBehavior.Editable = false;
            _GridViewPickupDistrictSelect.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            _GridViewPickupDistrictSelect.OptionsSelection.MultiSelect = true;
            _GridViewPickupDistrictSelect.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            _GridViewPickupDistrictSelect.SelectionChanged += _GridViewPickupDistrictSelect_SelectionChanged;

            btnAddPickup.Click += btnAddPickup_Click;
            btnRemovePickup.Click += btnRemovePickup_Click;

            _BindingSourceDistrictPickupSelect.DataSource = _DataDistrictPickup;

            _GridViewPickupDistrict.OptionsView.ShowViewCaption = true;
            _GridViewPickupDistrict.ViewCaption = "Daftar Radius Kecamatan Penjemputan";
            _GridViewPickupDistrictSelect.OptionsView.ShowViewCaption = true;
            _GridViewPickupDistrictSelect.ViewCaption = "Data Radius Kecamatan Penjemputan Terpilih";
            #endregion

            #region Delivery
            colCityNameDelivery.Group();
            _GridViewDeliveryDistrict.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _GridViewDeliveryDistrict.OptionsBehavior.AutoExpandAllGroups = true;
            _GridViewDeliveryDistrict.ExpandAllGroups();
            colIdDelivery.Visible = false;
            colCityNameDelivery.Visible = false;
            _GridViewDeliveryDistrict.OptionsView.ShowIndicator = false;
            _GridViewDeliveryDistrict.OptionsFind.AllowFindPanel = false;
            _GridViewDeliveryDistrict.OptionsView.ShowGroupPanel = false;
            _GridViewDeliveryDistrict.OptionsView.ColumnAutoWidth = false;
            _GridViewDeliveryDistrict.OptionsSelection.MultiSelect = true;
            _GridViewDeliveryDistrict.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;


            colCityNameDeliverySelect.Group();
            _GridViewDeliveryDistrictSelect.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _GridViewDeliveryDistrictSelect.OptionsBehavior.AutoExpandAllGroups = true;
            _GridViewDeliveryDistrictSelect.ExpandAllGroups();
            colIdDeliverySelect.Visible = false;
            colCityNameDeliverySelect.Visible = false;
            _GridViewDeliveryDistrictSelect.OptionsView.ShowIndicator = false;
            _GridViewDeliveryDistrictSelect.OptionsDetail.EnableMasterViewMode = false;
            _GridViewDeliveryDistrictSelect.OptionsView.ColumnAutoWidth = false;
            _GridViewDeliveryDistrictSelect.OptionsBehavior.Editable = false;
            _GridViewDeliveryDistrictSelect.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            _GridViewDeliveryDistrictSelect.OptionsSelection.MultiSelect = true;
            _GridViewDeliveryDistrictSelect.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            _GridViewDeliveryDistrictSelect.SelectionChanged += _GridViewDeliveryDistrictSelect_SelectionChanged;


            btnAddDelivery.Click += btnAddDelivery_Click;
            btnRemoveDelivery.Click += btnRemoveDelivery_Click;

            _BindingSourceDistrictDeliverySelect.DataSource = _DataDistrictDelivery;

            _GridViewDeliveryDistrict.OptionsView.ShowViewCaption = true;
            _GridViewDeliveryDistrict.ViewCaption = "Daftar Radius Kecamatan Pengantaran";
            _GridViewDeliveryDistrictSelect.OptionsView.ShowViewCaption = true;
            _GridViewDeliveryDistrictSelect.ViewCaption = "Data Radius Kecamatan Pengantaran Terpilih";
            #endregion

            InitializeSearchLookup();

            SLUHelper.SetEnumDataSource(PriceTypeSearchLookUpEdit, new Converter<EnumPriceType, string>(EnumHelper.EnumPriceTypeToString));
        }

        private void _GridViewTravelPrice_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;

            // update dulu id yang bersesuian
            TravelPrice row = e.Row as TravelPrice;
            if (row == null) return;
            //row.ScheduleId = row.ScheduleId;
            row.RuteId = _Rute.Id;
        }

        private void _GridViewTravelPrice_RowEditCanceled(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
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

        private void _GridViewTravelPrice_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            var result = gridView.GetFocusedRow() as TravelPrice;

            if (result == null) return;


            var price = result.Price;

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

            var minPrice = result.MinPrice;

            if (minPrice == null)
            {
                gridView.SetColumnError(colMinPrice, $"Harga Minimum tidak boleh kosong");
                e.Valid = false;
                return;
            }
            else if (minPrice <= 0)
            {
                gridView.SetColumnError(colMinPrice, $"Harga Minimum tidak boleh 0");
                e.Valid = false;
                return;
            }

            var maxPrice = result.MaxPrice;

            if (maxPrice == null)
            {
                gridView.SetColumnError(colMaxPrice, $"Harga Maximum tidak boleh kosong");
                e.Valid = false;
                return;
            }
            else if (maxPrice <= 0)
            {
                gridView.SetColumnError(colMaxPrice, $"Harga Maximum tidak boleh 0");
                e.Valid = false;
                return;
            }

            var cekpriceType = result.PriceType;
            if (cekpriceType != null)
            {
                var priceType = (EnumPriceType)cekpriceType;
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (i != gridView.GetDataSourceRowIndex(gridView.FocusedRowHandle))
                    {
                        var tempVal = (EnumPriceType)gridView.GetRowCellValue(i, "PriceType");
                        if (tempVal == priceType)
                        {
                            gridView.SetColumnError(colPriceType, "Adanya duplikasi data tipe harga");
                            e.Valid = false;
                            return;
                        }
                    }
                }
            }

            if (e.Valid)
                gridView.ClearColumnErrors();
        }

        private void _GridViewSchedule_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;

            // update dulu id yang bersesuian
            RuteSchedule row = e.Row as RuteSchedule;
            if (row == null) return;
            row.ScheduleId = HelperConvert.Int(AssemblyHelper.GetValueProperty(row.Schedule, "Id"));
            row.RuteId = _Rute.Id;
        }

        private void _GridViewSchedule_RowEditCanceled(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;
            GridView view = sender as GridView;

            // update dulu id yang bersesuian
            RuteSchedule row = e.Row as RuteSchedule;
            if (row == null) return;

            for (int i = 0; i < view.RowCount; i++)
            {
                if (i != view.GetDataSourceRowIndex(view.FocusedRowHandle))
                {
                    var tempVal = HelperConvert.Int(view.GetRowCellValue(i, "ScheduleId"));
                    if (row.ScheduleId != null)
                    {
                        if (tempVal == row.ScheduleId)
                        {
                            view.DeleteRow(e.RowHandle);
                            return;
                        }
                    }
                }
            }
        }

        private void _GridViewSchedule_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            var result = gridView.GetFocusedRow() as RuteSchedule;

            if (result == null) return;

            var schedule = result.Schedule;

            if (schedule == null)
            {
                gridView.SetColumnError(colSchedule, $"Jadwal tidak boleh kosong");
                e.Valid = false;
                return;
            }

            for (int i = 0; i < gridView.RowCount; i++)
            {
                if (i != gridView.GetDataSourceRowIndex(gridView.FocusedRowHandle))
                {
                    var tempVal = HelperConvert.Int(gridView.GetRowCellValue(i, "ScheduleId"));
                    if (tempVal == schedule.Id)
                    {
                        gridView.SetColumnError(colSchedule, "Adanya duplikasi data jadwal");
                        e.Valid = false;
                        return;
                    }
                }
            }

            if (e.Valid)
                gridView.ClearColumnErrors();
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("Name");
        }

        private void DeliveryCityPopUp_EditValueChanged(object sender, EventArgs e)
        {
            if (DeliveryCityPopUp.EditValue != null)
            {
                IOverlaySplashScreenHandle handle = MessageHelper.ShowOverlayWait(this);
                try
                {
                    SetDeliveryDistrictGridView();
                }
                catch (Exception)
                {

                }
                finally
                {
                    MessageHelper.CloseOverlayWait(handle);
                }
            }
        }

        private void SetDeliveryDistrictGridView()
        {
            var deliveryDistricts = HelperRestSharp.GetListOdata<District>($"/Districts", "id,code,name", fFilter: $"cityId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryCityPopUp.EditValue, "Id"))}");
            _DistrictDelivery = deliveryDistricts;
            _BindingSourceDistrictDelivery.DataSource = _DistrictDelivery;

            if (_Rute != null)
            {
                var districtIds = _Rute.DeliveryPointDistricts.Select(s => s.DistrictId).ToList();
                _DataDistrictDelivery.AddRange(_DistrictDelivery.Where(s => districtIds.Contains(s.Id)).ToList());
            }

            _GridViewDeliveryDistrictSelect.RefreshData();
            _GridViewDeliveryDistrict.RefreshData();
        }

        private void PickupCityPopUp_EditValueChanged(object sender, EventArgs e)
        {
            if (PickupCityPopUp.EditValue != null)
            {
                IOverlaySplashScreenHandle handle = MessageHelper.ShowOverlayWait(this);
                try
                {
                    SetPickupDistrictGridView();
                }
                catch (Exception)
                {

                }
                finally
                {
                    MessageHelper.CloseOverlayWait(handle);
                }
            }
        }

        private void SetPickupDistrictGridView()
        {
            var pickupDistricts = HelperRestSharp.GetListOdata<District>($"/Districts", "id,code,name", fFilter: $"cityId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupCityPopUp.EditValue, "Id"))}");
            _DistrictPickup = pickupDistricts;
            _BindingSourceDistrictPickup.DataSource = _DistrictPickup;

            if (_Rute != null)
            {
                var districtIds = _Rute.PickupPointDistricts.Select(s => s.DistrictId).ToList();
                _DataDistrictPickup.AddRange(_DistrictPickup.Where(s => districtIds.Contains(s.Id)).ToList());
            }

            _GridViewPickupDistrictSelect.RefreshData();
            _GridViewPickupDistrict.RefreshData();
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Rute = OdataEntity as Rute;
            if (_Rute != null)
            {
                City pickup = HelperRestSharp.GetById<City>(_Rute.PickupPointCityId, "/Citys");
                if (pickup != null)
                {
                    Province province = HelperRestSharp.GetById<Province>(pickup.ProvinceId, "/Provinces");

                    PickupProvincePopUp.EditValue = province;
                    PickupCityPopUp.EditValue = _Rute.PickupPointCity;
                    SetPickupDistrictGridView();
                }
                City delivery = HelperRestSharp.GetById<City>(_Rute.DeliveryPointCityId, "/Citys");
                if (delivery != null)
                {
                    Province province = HelperRestSharp.GetById<Province>(delivery.ProvinceId, "/Provinces");

                    DeliveryProvincePopUp.EditValue = province;
                    DeliveryCityPopUp.EditValue = _Rute.DeliveryPointCity;
                    SetDeliveryDistrictGridView();
                }

                _BindingSourceRuteSchedules.DataSource = _Rute.RuteSchedules.ToList(); // setelah totaltiket agar aman
                _BindingSourceTravelPrice.DataSource = _Rute.TravelPrices.ToList(); // setelah totaltiket agar aman
                //_BindingSourceRuteSchedules.DataSource = _Rute.RuteSchedules;
                //_BindingSourceTravelPrice.DataSource = _Rute.TravelPrices;
                //_GridViewSchedule.RefreshData();
            }
        }

        #region Pickup
        private void _GridViewPickupDistrictSelect_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (e.Action == CollectionChangeAction.Add && gridView == _GridViewPickupDistrict)
            {
                _GridViewPickupDistrictSelect.ClearSelection();
            }
            else if (e.Action == CollectionChangeAction.Add && gridView == _GridViewPickupDistrictSelect)
            {
                _GridViewPickupDistrict.ClearSelection();
            }
        }

        private void btnRemovePickup_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _GridViewPickupDistrictSelect.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;

            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Kecamatan belum ada yang terpilih !");
                return;
            }

            _GridViewPickupDistrictSelect.DeleteSelectedRows();
            _GridViewPickupDistrictSelect.BestFitColumns(true);

            _GridViewPickupDistrictSelect.RefreshData();
            _GridViewPickupDistrict.RefreshData();
        }

        private void btnAddPickup_Click(object sender, EventArgs e)
        {
            List<District> districts = GetListDataRowSelected(_GridViewPickupDistrict).OfType<District>().ToList();
            if (!(districts.Count() > 0))
            {
                MessageHelper.ShowMessageInformation(this, "Data Kecamatan belum ada yang terpilih !");
                return;

            }

            foreach (var item in districts)
            {
                if (!_DataDistrictPickup.Any(x => x.Id == item.Id))
                {
                    _DataDistrictPickup.Add(item);
                };
            }

            _GridViewPickupDistrictSelect.BestFitColumns(true);
            _GridViewPickupDistrict.ClearSelection();
            _GridViewPickupDistrictSelect.RefreshData();
            _GridViewPickupDistrict.RefreshData();
        }
        #endregion

        #region Delivery
        private void _GridViewDeliveryDistrictSelect_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (e.Action == CollectionChangeAction.Add && gridView == _GridViewDeliveryDistrict)
            {
                _GridViewDeliveryDistrictSelect.ClearSelection();
            }
            else if (e.Action == CollectionChangeAction.Add && gridView == _GridViewDeliveryDistrictSelect)
            {
                _GridViewDeliveryDistrict.ClearSelection();
            }
        }

        private void btnRemoveDelivery_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _GridViewDeliveryDistrictSelect.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;

            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Kecamatan belum ada yang terpilih !");
                return;
            }

            _GridViewDeliveryDistrictSelect.DeleteSelectedRows();
            _GridViewDeliveryDistrictSelect.BestFitColumns(true);
            _GridViewDeliveryDistrictSelect.RefreshData();
            _GridViewDeliveryDistrict.RefreshData();
        }

        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            List<District> districts = GetListDataRowSelected(_GridViewDeliveryDistrict).OfType<District>().ToList();
            if (!(districts.Count() > 0))
            {
                MessageHelper.ShowMessageInformation(this, "Data Kecamatan belum ada yang terpilih !");
                return;

            }

            foreach (var item in districts)
            {
                if (!_DataDistrictDelivery.Any(x => x.Id == item.Id))
                {
                    _DataDistrictDelivery.Add(item);
                };
            }

            _GridViewDeliveryDistrictSelect.BestFitColumns(true);
            _GridViewDeliveryDistrict.ClearSelection();
            _GridViewDeliveryDistrictSelect.RefreshData();
            _GridViewDeliveryDistrict.RefreshData();
        }
        #endregion

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CodeTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.NameTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupCityPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryCityPopUp, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            //IOverlaySplashScreenHandle handle = MessageHelper.ShowOverlayWait(this);
            try
            {
                PopupEditHelper.Company(CompanyPopUp);

                PopupEditHelper.General<Schedule>(fEndPoint: "/Schedules", fTitle: "Provinsi", fControl: SchedulePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fSelect: "id,code,name");
                
                PopupEditHelper.General<Province>(fEndPoint: "/Provinces", fTitle: "Provinsi", fControl: PickupProvincePopUp, fChild: PickupCityPopUp, fCascadeMember: "CountryId", fSelect: "id,code,name,countryid");
                PopupEditHelper.General<City>(fEndPoint: "/Citys", fCascadeMember: "ProvinceId", fTitle: "Kota", fControl: PickupCityPopUp, fCascade: PickupProvincePopUp, fSelect: "id,code,name,provinceid");
                
                PopupEditHelper.General<Province>(fEndPoint: "/Provinces", fTitle: "Provinsi", fControl: DeliveryProvincePopUp, fChild: DeliveryCityPopUp, fCascadeMember: "CountryId", fSelect: "id,code,name,countryid");
                PopupEditHelper.General<City>(fEndPoint: "/Citys", fCascadeMember: "ProvinceId", fTitle: "Kota", fControl: DeliveryCityPopUp, fCascade: DeliveryProvincePopUp, fSelect: "id,code,name,provinceid");
            }
            catch (Exception)
            {

            }
            finally
            {
                //MessageHelper.CloseOverlayWait(handle);
            }
        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<Rute>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<Rute>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<Rute>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            if (_Rute == null)
            {
                _Rute = new Rute()
                {
                    Code = HelperConvert.String(CodeTextEdit.EditValue),
                    Name = HelperConvert.String(NameTextEdit.EditValue),
                    Note = HelperConvert.String(NoteMemoEdit.EditValue),
                    CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id")),
                    PickupPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupCityPopUp.EditValue, "Id")),
                    DeliveryPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryCityPopUp.EditValue, "Id")),
                };
            }
            else
            {
                _Rute.Code = HelperConvert.String(CodeTextEdit.EditValue);
                _Rute.Name = HelperConvert.String(NameTextEdit.EditValue);
                _Rute.Note = HelperConvert.String(NoteMemoEdit.EditValue);
                _Rute.CompanyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"));
                _Rute.PickupPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(PickupCityPopUp.EditValue, "Id"));
                _Rute.DeliveryPointCityId = HelperConvert.Int(AssemblyHelper.GetValueProperty(DeliveryCityPopUp.EditValue, "Id"));
            }

            _Rute.PickupPointDistricts.Clear();
            List<District> districtPickups = _BindingSourceDistrictPickupSelect.DataSource as List<District>;
            foreach (District d in districtPickups)
            {
                _Rute.PickupPointDistricts.Add(new PickupPointDistrict()
                {
                    Id = 0,
                    RuteId = _Rute.Id,
                    DistrictId = d.Id,
                });
            }
            
            _Rute.DeliveryPointDistricts.Clear();
            List<District> districtDeliverys = _BindingSourceDistrictDeliverySelect.DataSource as List<District>;
            foreach (District d in districtDeliverys)
            {
                _Rute.DeliveryPointDistricts.Add(new DeliveryPointDistrict()
                {
                    Id = 0,
                    RuteId = _Rute.Id,
                    DistrictId = d.Id,
                });
            }

            List<RuteSchedule> ruteSchedules = _BindingSourceRuteSchedules.DataSource as List<RuteSchedule>;
            _Rute.RuteSchedules = ruteSchedules;

            List<TravelPrice> travelPrices = _BindingSourceTravelPrice.DataSource as List<TravelPrice>;
            _Rute.TravelPrices = travelPrices;

            OdataEntity = _Rute;
        }

        //Untuk new belum auto bound
        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<Rute>();
        }

        //Untuk update Sudah auto bound
        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<Rute>();
        }
    }
}

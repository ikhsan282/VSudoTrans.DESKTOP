using DevExpress.XtraEditors.DXErrorProvider;
using Domain;
using Domain.Entities.Demography;
using Domain.Entities.Rental;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System;
using VSudoTrans.DESKTOP.Master.Transportation;
using Domain.Entities.Vehicle;
using Domain.Entities.HumanResource;
using System.Linq;
using Domain.Entities.Travel;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using System.Runtime.InteropServices.Expando;
using Domain.Entities.Organization;

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
            HelperConvert.FormatDateEdit(EndDateDateEdit);
            HelperConvert.FormatDateTimeEdit(TimeDateEdit, "HH:mm");

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);

            HelperConvert.FormatSpinEdit(AmountEmployeeSpinEdit, "n0", 0, 888888888888888);
            HelperConvert.FormatSpinEdit(AmountPaymentSpinEdit, "n0", 0, 888888888888888);
            HelperConvert.FormatSpinEdit(TotalPriceSpinEdit, "n0", 0, 888888888888888);
            HelperConvert.FormatSpinEdit(BBMSpinEdit, "n0", 0, 888888888888888);
            HelperConvert.FormatSpinEdit(TotalPaymentSpinEdit, "n0", 0, 888888888888888);
            HelperConvert.FormatSpinEdit(TotalOperationalCostSpinEdit, "n0", 0, 888888888888888);

            PickupDistrictPopUp.EditValueChanged += PickupDistrictPopUp_EditValueChanged;
            DeliveryDistrictPopUp.EditValueChanged += DeliveryDistrictPopUp_EditValueChanged;

            groupPassenger.CustomButtonClick += GroupPassenger_CustomButtonClick;

            groupEmployee.CustomButtonClick += GroupEmployee_CustomButtonClick;

            GridHelper.GridViewInitializeLayout(_GridViewEmployee);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlEmployee, true, true, true, true, true, true, true, true, true, true, true, true);
            GridHelper.GridColumnInitializeLayout(colAmountEmployee, typeof(decimal), "n0", fTotal: true);
            _GridViewEmployee.OptionsView.ShowFooter = true;
            _GridViewEmployee.ValidateRow += _GridViewEmployee_ValidateRow;
            _GridViewEmployee.RowEditCanceled += _GridViewEmployee_RowEditCanceled;
            _GridViewEmployee.RowUpdated += _GridViewEmployee_RowUpdated;

            _GridViewEmployee.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridViewEmployee.OptionsBehavior.Editable = true;


            GridHelper.GridViewInitializeLayout(_GridViewPayment);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControlPayment, true, true, true, true, true, true, true, true, true, true, true, true);
            GridHelper.GridColumnInitializeLayout(colAmountPayment, typeof(decimal), "n0", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colDate, typeof(DateTime), "dd-MMM-yyyy");
            _GridViewPayment.OptionsView.ShowFooter = true;
            _GridViewPayment.ValidateRow += _GridViewPayment_ValidateRow;
            _GridViewPayment.RowUpdated += _GridViewPayment_RowUpdated;

            _GridViewPayment.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            _GridViewPayment.OptionsBehavior.Editable = true;

            BBMSpinEdit.EditValueChanged += BBMSpinEdit_EditValueChanged;
        }

        private void GroupEmployee_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            //LayoutControlGroup layoutGroup = sender as LayoutControlGroup;
            if (e.Button.Properties.Caption.Contains("Hitung Pembagian Hasil Karyawan"))
            {
                var company = CompanyPopUp.EditValue as Company;
                var totalPrice = HelperConvert.Decimal(TotalPriceSpinEdit.EditValue);
                if (company != null && DateDateEdit.EditValue != null && totalPrice > 0)
                {
                    int iDate = HelperConvert.Int(HelperConvert.Date(DateDateEdit.EditValue).ToString("yyyyMMdd"));
                    string fFilter = $"CompanyId eq {company.Id} and IStartDate le {iDate} and IEndDate ge {iDate}";
                    var rentalCarRegulationEmployee = HelperRestSharp.GetOdata<RentalCarRegulationEmployee>("RentalCarRegulationEmployees", fSelect: "Id,CompanyId,StartDate,EndDate", fExpand: "RentalCarRegulationEmployeeDetails($select=Id,Type,Amount)", fFilter: fFilter);

                    _BindingSourceEmployee.Clear();
                    var rentalCarBookingEmployees = new List<RentalCarBookingEmployee>();
                    foreach (var rentalCarRegulationEmployeeDetail in rentalCarRegulationEmployee.RentalCarRegulationEmployeeDetails)
                    {
                        var rentalCarBookingEmployee = new RentalCarBookingEmployee()
                        {
                            EmployeeId = 0,
                            Amount = rentalCarRegulationEmployeeDetail.Type == EnumRentalCarEmployeeRegulationType.Fix ? rentalCarRegulationEmployeeDetail.Amount : rentalCarRegulationEmployeeDetail.Type == EnumRentalCarEmployeeRegulationType.Percentage ? totalPrice * (rentalCarRegulationEmployeeDetail.Amount / 100) : 0
                        };

                        rentalCarBookingEmployees.Add(rentalCarBookingEmployee);
                    }
                    _BindingSourceEmployee.DataSource = rentalCarBookingEmployees;
                    CalculateOperationalCost();
                }
            }
        }

        private void BBMSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            CalculateOperationalCost();
        }

        private void CalculateOperationalCost()
        {
            if (BBMSpinEdit.EditValue != null)
            {
                List<RentalCarBookingEmployee> rentalCarBookingEmployees = _BindingSourceEmployee.DataSource as List<RentalCarBookingEmployee>;
                TotalOperationalCostSpinEdit.EditValue = HelperConvert.Decimal(BBMSpinEdit.EditValue) + rentalCarBookingEmployees.Sum(s => s.Amount);
            }
        }

        private void CalculatePayment()
        {
            List<RentalCarBookingPayment> rentalCarBookingPayment = _BindingSourcePayment.DataSource as List<RentalCarBookingPayment>;
            TotalPaymentSpinEdit.EditValue = rentalCarBookingPayment.Sum(s => s.Amount);
        }

        private void _GridViewPayment_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;

            // update dulu id yang bersesuian
            RentalCarBookingPayment row = e.Row as RentalCarBookingPayment;
            if (row == null) return;
            row.RentalCarBookingId = _RentalCarBooking.Id;
            CalculatePayment();
        }

        private void _GridViewPayment_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            var result = gridView.GetFocusedRow() as RentalCarBookingPayment;

            if (result == null) return;

            var amount = result.Amount;
            if (amount != null)
            {
                if (amount <= 0)
                {
                    gridView.SetColumnError(colAmountPayment, $"Jumlah tidak boleh 0");
                    e.Valid = false;
                    return;
                }
            }
            else
            {
                gridView.SetColumnError(colAmountPayment, $"Jumlah tidak boleh kosong");
                e.Valid = false;
                return;
            }

            var paymentMethod = result.PaymentMethod;

            if (paymentMethod == null)
            {
                gridView.SetColumnError(colPaymentMethod, $"Metode Pembayaran tidak boleh kosong");
                e.Valid = false;
                return;
            }

            var date = result.Date;

            if (date == null)
            {
                gridView.SetColumnError(colDate, $"Tanggal tidak boleh kosong");
                e.Valid = false;
                return;
            }

            if (e.Valid)
                gridView.ClearColumnErrors();
        }

        private void _GridViewEmployee_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;

            // update dulu id yang bersesuian
            RentalCarBookingEmployee row = e.Row as RentalCarBookingEmployee;
            if (row == null) return;
            row.EmployeeId = HelperConvert.Int(AssemblyHelper.GetValueProperty(row.Employee, "Id"));
            row.RentalCarBookingId = _RentalCarBooking.Id;
            CalculateOperationalCost();
        }

        private void _GridViewEmployee_RowEditCanceled(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null) return;
            GridView view = sender as GridView;

            // update dulu id yang bersesuian
            if (!(e.Row is RentalCarBookingEmployee row)) return;

            for (int i = 0; i < view.RowCount; i++)
            {
                if (i != view.GetDataSourceRowIndex(view.FocusedRowHandle))
                {
                    var tempVal = HelperConvert.Int(view.GetRowCellValue(i, "EmployeeId"));
                    if (row.EmployeeId > 0)
                    {
                        if (tempVal == row.EmployeeId)
                        {
                            view.DeleteRow(e.RowHandle);
                            return;
                        }
                    }
                }
            }
        }

        private void _GridViewEmployee_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView gridView = sender as GridView;

            var result = gridView.GetFocusedRow() as RentalCarBookingEmployee;

            if (result == null) return;

            var price = result.Amount;
            if (price != null)
            {
                if (price <= 0)
                {
                    gridView.SetColumnError(colAmountEmployee, $"Jumlah tidak boleh 0");
                    e.Valid = false;
                    return;
                }
            }
            else
            {
                gridView.SetColumnError(colAmountEmployee, $"Jumlah tidak boleh kosong");
                e.Valid = false;
                return;
            }

            var employee = result.Employee;

            if (employee == null)
            {
                gridView.SetColumnError(colEmployee, $"Karyawan tidak boleh kosong");
                e.Valid = false;
                return;
            }
            else if (employee.Id == 0)
            {
                gridView.SetColumnError(colEmployee, $"Karyawan tidak boleh kosong");
                e.Valid = false;
                return;
            }

            if (e.Valid)
                gridView.ClearColumnErrors();
        }

        private void GroupPassenger_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            //LayoutControlGroup layoutGroup = sender as LayoutControlGroup;
            if (e.Button.Properties.Caption.Contains("Tambah Pelanggan"))
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
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupDistrictPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryDistrictPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PickupAddressMemoEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.DeliveryAddressMemoEdit, ConditionOperator.IsNotBlank);

            MyValidationHelper.SetValidation(_DxValidationProvider, this.TotalPriceSpinEdit, ConditionOperator.IsNotBlank);
        }

        protected override bool InitializeAdditionalValidation()
        {
            bool result = base.InitializeAdditionalValidation();

            List<RentalCarBookingEmployee> rentalCarBookingEmployees = _BindingSourceEmployee.DataSource as List<RentalCarBookingEmployee>;
            if (rentalCarBookingEmployees != null)
            {
                if (rentalCarBookingEmployees.Any())
                {
                    foreach (var item in rentalCarBookingEmployees)
                    {
                        if (item.EmployeeId == 0)
                        {
                            MessageHelper.ShowMessageError(this, "Karyawan tidak boleh kosong!");
                            result = false;
                        }
                    }
                }

                if (HelperConvert.Decimal(TotalPriceSpinEdit.EditValue) < rentalCarBookingEmployees.Sum(s => s.Amount))
                {
                    MessageHelper.ShowMessageError(this, "Total nominal karyawan tidak boleh lebih besar dari harga!");
                    result = false;
                }
            }



            List<RentalCarBookingPayment> rentalCarBookingPayments = _BindingSourcePayment.DataSource as List<RentalCarBookingPayment>;
            if (rentalCarBookingPayments != null)
            {
                if (HelperConvert.Decimal(TotalPriceSpinEdit.EditValue) < rentalCarBookingPayments.Sum(s => s.Amount))
                {
                    MessageHelper.ShowMessageError(this, "Total nominal pembayaran tidak boleh lebih besar dari harga!");
                    result = false;
                }
            }

            return result;
        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _RentalCarBooking = OdataEntity as RentalCarBooking;
            if (_RentalCarBooking != null)
            {
                this.TotalPriceSpinEdit.EditValue = _RentalCarBooking.TotalPrice;
                this.TotalOperationalCostSpinEdit.EditValue = _RentalCarBooking.TotalOperationalCost;
                this.TotalPaymentSpinEdit.EditValue = _RentalCarBooking.TotalPayment;
                this.TimeDateEdit.EditValue = new DateTime(_RentalCarBooking.Time.Ticks);
                _BindingSourceEmployee.DataSource = _RentalCarBooking.RentalCarBookingEmployees.ToList();
                _BindingSourcePayment.DataSource = _RentalCarBooking.RentalCarBookingPayments.ToList();
            }
        }

        protected override void InitializeSearchLookup()
        {
            SLUHelper.SetEnumDataSource(PaymentMethodSearchLookUpEdit, new Converter<EnumPaymentMethod, string>(EnumHelper.EnumPaymentMethodToString));
            SLUHelper.SetEnumDataSource(EmployeeRoleSearchLookUpEdit, new Converter<EnumEmployeeRole, string>(EnumHelper.EnumEmployeeRoleToString));

            PopupEditHelper.Company(CompanyPopUp);
            PopupEditHelper.Passenger(PassengerPopUp, CompanyPopUp, "CompanyId");
            PopupEditHelper.General<Employee>("/Employees", EmployeePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fWidthColumn: "150;150;100;200;150;150;150", fDisplaycolumn: "OrganizationStructure.Name;JobPosition.Name;Code;Name;JoinDate;ResignationDate;PhoneNumber", fCaptionColumn: "Organisasi;Posisi;Kode;Nama;Tanggal Masuk;Tanggal Keluar;Nomor Telepon", fSelect: "Id,OrganizationStructureId,JobPositionId,Code,Name,JoinDate,ResignationDate,PhoneNumber", fExpand: "OrganizationStructure($select=name),JobPosition($select=name)");

            PopupEditHelper.General<CategoryVehicle>("/CategoryVehicles", CategoryVehiclePopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama");
            PopupEditHelper.General<Vehicles>("/Vehicles", VehiclePopUp, fCascade: CategoryVehiclePopUp, fCascadeMember: "CategoryVehicleId", fWidthColumn: "200;200;300;200;200", fDisplaycolumn: "Brand.Name;ModelUnit.Name;VehicleNumber;VehicleColor;Seat", fCaptionColumn: "Merek;Model;Nomor Kendaraan (Plat);Warna;Jumlah Bangku", fDisplayText: "Brand.Name;ModelUnit.Name;VehicleNumber;VehicleColor;Seat", fSelect: "Id,BrandId,ModelUnitId,CategoryVehicleId,VehicleNumber,VehicleColor,Seat", fExpand: "Brand($select=name),ModelUnit($select=name)");

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
            _RentalCarBooking.VehicleId = HelperConvert.Int(AssemblyHelper.GetValueProperty(VehiclePopUp.EditValue, "Id"));
            _RentalCarBooking.Date = HelperConvert.Date(DateDateEdit.EditValue);
            _RentalCarBooking.StartDate = HelperConvert.Date(DateDateEdit.EditValue);
            _RentalCarBooking.EndDate = HelperConvert.Date(EndDateDateEdit.EditValue);
            _RentalCarBooking.Time = HelperConvert.Date(TimeDateEdit.EditValue).TimeOfDay;

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

            List<RentalCarBookingEmployee> rentalCarBookingEmployees = _BindingSourceEmployee.DataSource as List<RentalCarBookingEmployee>;
            _RentalCarBooking.RentalCarBookingEmployees = rentalCarBookingEmployees;

            _RentalCarBooking.TotalOperationalCost = rentalCarBookingEmployees.Sum(s => s.Amount) + HelperConvert.Decimal(BBMSpinEdit.EditValue);

            List<RentalCarBookingPayment> rentalCarBookingPayments = _BindingSourcePayment.DataSource as List<RentalCarBookingPayment>;
            _RentalCarBooking.RentalCarBookingPayments = rentalCarBookingPayments;

            _RentalCarBooking.TotalPayment = rentalCarBookingPayments.Sum(s => s.Amount);

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

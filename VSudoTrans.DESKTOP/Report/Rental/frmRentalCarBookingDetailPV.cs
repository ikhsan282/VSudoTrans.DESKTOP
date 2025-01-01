using DevExpress.DashboardCommon.Viewer;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using Domain.Entities.Organization;
using Domain.Entities.Rental;
using PopUpUtils;
using System;
using System.Data;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Rental
{
    public partial class frmRentalCarBookingDetailPV : frmBasePV
    {
        public frmRentalCarBookingDetailPV()
        {
            InitializeComponent();

            this.EndPoint = "/RentalCarBookings";
            this.FormTitle = "Detail Rental Kendaraan (Pivot)";

            OdataSelect = "*";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            FilterDate2.EditValue = new DateTime(DateTime.Today.Year, 12, 31);

            InitializeComponentAfter<RentalCarBooking>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
        }
        protected override void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter1.Text = "Tanggal Mulai";
            HelperConvert.FormatDateEdit(FilterDate1);

            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter2.Text = "Tanggal Selesai";
            HelperConvert.FormatDateEdit(FilterDate2);

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            _pivotGridControl.Fields.Clear();
            MessageHelper.WaitFormShow(this);
            try
            {
                Company company = FilterPopUp3.EditValue as Company;
                int iStartDate = HelperConvert.Int(HelperConvert.Date(FilterDate1.EditValue).ToString("yyyyMMdd"));
                int iEndDate = HelperConvert.Int(HelperConvert.Date(FilterDate2.EditValue).ToString("yyyyMMdd"));
                if (company != null && iStartDate > 0 && iEndDate > 0)
                {
                    this.OdataFilter = $"CompanyId eq {company.Id} ";

                    if (FilterDate1.EditValue != null && FilterDate1.EditValue != null)
                        OdataFilter += $" and IDate ge {iStartDate} and IDate le {iEndDate} ";

                    string select = "Id,Time,Date,StartDate,EndDate,Trip,TotalPayment,TotalPrice,TotalOperationalCost,BBM,PickupAddress,DeliveryAddress";
                    string expand = "Passenger($select=Id,Code,Name,PhoneNumber),Vehicle($expand=Brand,ModelUnit),RentalCarBookingEmployees($expand=Employee($select=Id,Code,Name)),RentalCarBookingPayments($select=Date,Amount)";

                    var rentalCarBookings = HelperRestSharp.GetListOdata<RentalCarBooking>("/RentalCarBookings", fSelect: select, fExpand: expand, OdataFilter, fOrder: "Id");

                    if (rentalCarBookings.Any())
                    {
                        DataTable dt = new DataTable();
                        dt.TableName = "Table1";
                        dt.Columns.Add("DetailNo", typeof(string));
                        dt.Columns.Add("DetailPassengerName", typeof(string));
                        dt.Columns.Add("DetailPassengerPhoneNumber", typeof(string));
                        dt.Columns.Add("DetailTime", typeof(string));
                        dt.Columns.Add("DetailYear", typeof(string));
                        dt.Columns.Add("DetailMonth", typeof(string));
                        dt.Columns.Add("DetailStartDate", typeof(string));
                        dt.Columns.Add("DetailEndDate", typeof(string));
                        dt.Columns.Add("DetailTrip", typeof(decimal));
                        dt.Columns.Add("DetailPickupAddress", typeof(string));
                        dt.Columns.Add("DetailDeliveryAddress", typeof(string));

                        dt.Columns.Add("DetailVehicleBrand", typeof(string));
                        dt.Columns.Add("DetailVehicleModel", typeof(string));
                        dt.Columns.Add("DetailVehicleColor", typeof(string));
                        dt.Columns.Add("DetailVehicleSeat", typeof(string));
                        dt.Columns.Add("DetailVehicleNumber", typeof(string));

                        dt.Columns.Add("DetailPayment1", typeof(string));
                        dt.Columns.Add("DetailPayment2", typeof(string));
                        dt.Columns.Add("DetailPayment3", typeof(string));

                        dt.Columns.Add("DetailPayment1Date", typeof(string));
                        dt.Columns.Add("DetailPayment2Date", typeof(string));
                        dt.Columns.Add("DetailPayment3Date", typeof(string));

                        dt.Columns.Add("DetailPayment1Amount", typeof(decimal));
                        dt.Columns.Add("DetailPayment2Amount", typeof(decimal));
                        dt.Columns.Add("DetailPayment3Amount", typeof(decimal));

                        dt.Columns.Add("DetailTotalPayment", typeof(decimal));
                        dt.Columns.Add("DetailTotalPrice", typeof(decimal));

                        dt.Columns.Add("DetailDriver", typeof(string));
                        dt.Columns.Add("DetailConductor", typeof(string));
                        dt.Columns.Add("DetailMechanic", typeof(string));

                        dt.Columns.Add("DetailDriverName", typeof(string));
                        dt.Columns.Add("DetailConductorName", typeof(string));
                        dt.Columns.Add("DetailMechanicName", typeof(string));

                        dt.Columns.Add("DetailDriverAmount", typeof(decimal));
                        dt.Columns.Add("DetailConductorAmount", typeof(decimal));
                        dt.Columns.Add("DetailMechanicAmount", typeof(decimal));

                        dt.Columns.Add("DetailBBM", typeof(decimal));

                        dt.Columns.Add("DetailAmount", typeof(decimal));

                        int loop = 0;
                        foreach (var rentalCarBooking in rentalCarBookings.OrderBy(s => s.Date))
                        {
                            loop++;
                            DataRow totalRow = dt.NewRow();
                            totalRow["DetailNo"] = $"{loop}.";
                            totalRow["DetailPassengerName"] = rentalCarBooking.Passenger.Name;
                            totalRow["DetailPassengerPhoneNumber"] = rentalCarBooking.Passenger.PhoneNumber;

                            totalRow["DetailTime"] = rentalCarBooking.Time.ToString(@"hh\:mm");

                            totalRow["DetailYear"] = rentalCarBooking.Date.ToString("yyyy");
                            totalRow["DetailMonth"] = rentalCarBooking.Date.ToString("MMMM");
                            totalRow["DetailStartDate"] = rentalCarBooking.StartDate.ToString("dd-MMM-yyyy");
                            totalRow["DetailEndDate"] = rentalCarBooking.EndDate.ToString("dd-MMM-yyyy");
                            totalRow["DetailTrip"] = rentalCarBooking.Trip;

                            totalRow["DetailPickupAddress"] = rentalCarBooking.PickupAddress;
                            totalRow["DetailDeliveryAddress"] = rentalCarBooking.DeliveryAddress;

                            totalRow["DetailVehicleBrand"] = rentalCarBooking.Vehicle.Brand.Name;
                            totalRow["DetailVehicleModel"] = rentalCarBooking.Vehicle.ModelUnit.Name;
                            totalRow["DetailVehicleColor"] = rentalCarBooking.Vehicle.VehicleColor;
                            totalRow["DetailVehicleSeat"] = rentalCarBooking.Vehicle.Seat;
                            totalRow["DetailVehicleNumber"] = rentalCarBooking.Vehicle.VehicleNumber;

                            int loopPayment = 0;
                            foreach (var rentalCarBookingPayment in rentalCarBooking.RentalCarBookingPayments)
                            {
                                loopPayment++;
                                if (loopPayment == 1)
                                {
                                    totalRow["DetailPayment1"] = $"{rentalCarBookingPayment.Date.ToString("dd-MMM-yyyy")}\r\n{HelperConvert.FormatRupiah(rentalCarBookingPayment.Amount)}";
                                    totalRow["DetailPayment1Date"] = rentalCarBookingPayment.Date.ToString("dd-MMM-yyyy");
                                    totalRow["DetailPayment1Amount"] = rentalCarBookingPayment.Amount;
                                }

                                if (loopPayment == 2)
                                {
                                    totalRow["DetailPayment2"] = $"{rentalCarBookingPayment.Date.ToString("dd-MMM-yyyy")}\r\n{HelperConvert.FormatRupiah(rentalCarBookingPayment.Amount)}";
                                    totalRow["DetailPayment2Date"] = rentalCarBookingPayment.Date.ToString("dd-MMM-yyyy");
                                    totalRow["DetailPayment2Amount"] = rentalCarBookingPayment.Amount;
                                }

                                if (loopPayment >= 3)
                                {
                                    totalRow["DetailPayment3"] += $"{rentalCarBookingPayment.Date.ToString("dd-MMM-yyyy")}\r\n{HelperConvert.FormatRupiah(rentalCarBookingPayment.Amount)}\r\n";
                                    totalRow["DetailPayment3Date"] = $"{HelperConvert.String(totalRow["DetailPayment3Date"])}\r\n{rentalCarBookingPayment.Date.ToString("dd-MMM-yyyy")}";
                                    totalRow["DetailPayment3Amount"] = HelperConvert.Decimal(totalRow["DetailPayment3Amount"]) + rentalCarBookingPayment.Amount;
                                }
                            }

                            totalRow["DetailTotalPayment"] = rentalCarBooking.TotalPayment;
                            totalRow["DetailTotalPrice"] = rentalCarBooking.TotalPrice;

                            var drivers = rentalCarBooking.RentalCarBookingEmployees.Where(s => s.EmployeeRole == Domain.EnumEmployeeRole.Driver).ToList();
                            foreach (var driver in drivers)
                            {
                                totalRow["DetailDriver"] += $"{driver.Employee.Name}\r\n{HelperConvert.FormatRupiah(driver.Amount)}\r\n";
                                totalRow["DetailDriverName"] += $"{driver.Employee.Name}\r\n";
                            }

                            totalRow["DetailDriverAmount"] = drivers.Sum(s => s.Amount);

                            var conductors = rentalCarBooking.RentalCarBookingEmployees.Where(s => s.EmployeeRole == Domain.EnumEmployeeRole.Conductor).ToList();
                            foreach (var conductor in conductors)
                            {
                                totalRow["DetailConductor"] += $"{conductor.Employee.Name}\r\n{HelperConvert.FormatRupiah(conductor.Amount)}\r\n";
                                totalRow["DetailConductorName"] += $"{conductor.Employee.Name}\r\n";
                            }
                            totalRow["DetailConductorAmount"] = conductors.Sum(s => s.Amount);

                            var mechanics = rentalCarBooking.RentalCarBookingEmployees.Where(s => s.EmployeeRole == Domain.EnumEmployeeRole.Mechanic).ToList();
                            foreach (var mechanic in mechanics)
                            {
                                totalRow["DetailMechanic"] += $"{mechanic.Employee.Name}\r\n{HelperConvert.FormatRupiah(mechanic.Amount)}\r\n";
                                totalRow["DetailMechanicName"] += $"{mechanic.Employee.Name}\r\n";
                            }
                            totalRow["DetailMechanicAmount"] = mechanics.Sum(s => s.Amount);

                            totalRow["DetailBBM"] = rentalCarBooking.BBM;

                            totalRow["DetailAmount"] = rentalCarBooking.TotalPrice - rentalCarBooking.TotalOperationalCost;

                            dt.Rows.Add(totalRow);
                        }

                        _pivotGridControl.DataSource = dt;
                        _pivotGridControl.BestFit();
                        _pivotGridControl.RefreshData();
                        _pivotGridControl.LayoutChanged();

                        _GridControl.DataSource = dt;
                        GridHelper.GridViewInitializeLayout(this._GridView);
                        GridHelper.GridControlInitializeEmbeddedNavigator(this._GridControl, fNext: true, fPrev: true);
                        this._GridView.OptionsView.ShowFooter = true;
                        this._GridView.OptionsView.ColumnAutoWidth = false;
                        this._GridView.BestFitColumns();

                        SetGridField("DetailPassengerName", "Nama Pelanggan", PivotArea.FilterArea);
                        SetGridField("DetailPassengerPhoneNumber", "Nomor Telepon Pelanggan", PivotArea.FilterArea);

                        SetGridField("DetailTime", "Jam", PivotArea.FilterArea);
                        SetGridField("DetailYear", "Tahun", PivotArea.RowArea);
                        SetGridField("DetailMonth", "Bulan", PivotArea.RowArea);
                        SetGridField("DetailStartDate", "Tanggal Mulai", PivotArea.FilterArea, FormatType.DateTime, "dd-MMM-yyyy");
                        SetGridField("DetailEndDate", "Tanggal Selesai", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");
                        SetGridField("DetailTrip", "Trip", PivotArea.FilterArea);
                        SetGridField("DetailPickupAddress", "Penjemputan", PivotArea.FilterArea);
                        SetGridField("DetailDeliveryAddress", "Pengantaran", PivotArea.FilterArea);

                        SetGridField("DetailVehicleBrand", "Merek", PivotArea.FilterArea);
                        SetGridField("DetailVehicleModel", "Model", PivotArea.FilterArea);
                        SetGridField("DetailVehicleColor", "Warna", PivotArea.FilterArea);
                        SetGridField("DetailVehicleSeat", "Bangku", PivotArea.FilterArea);
                        SetGridField("DetailVehicleNumber", "Nomor Kendaraan (Plat Nomor)", PivotArea.FilterArea);

                        SetGridField("DetailPayment1", "Pembayaran 1", PivotArea.FilterArea);
                        SetGridField("DetailPayment1Date", "Tanggal Pembayaran 1", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");
                        SetGridField("DetailPayment1Amount", "Nominal Pembayaran 1", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");

                        SetGridField("DetailPayment2", "Pembayaran 2", PivotArea.FilterArea);
                        SetGridField("DetailPayment2Date", "Tanggal Pembayaran 2", PivotArea.FilterArea, FormatType.DateTime, "dd-MMM-yyyy");
                        SetGridField("DetailPayment2Amount", "Nominal Pembayaran 2", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");

                        SetGridField("DetailPayment3", "Pembayaran 3", PivotArea.FilterArea);
                        SetGridField("DetailPayment3Date", "Tanggal Pembayaran 3", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");
                        SetGridField("DetailPayment3Amount", "Nominal Pembayaran 3", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");

                        SetGridField("DetailTotalPayment", "Total Pembayaran", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");
                        SetGridField("DetailTotalPrice", "Total Harga", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");

                        SetGridField("DetailDriver", "Sopir", PivotArea.FilterArea);
                        SetGridField("DetailDriverName", "Nama Sopir", PivotArea.FilterArea);
                        SetGridField("DetailDriverAmount", "Komisi Sopir", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");

                        SetGridField("DetailConductor", "Kernet", PivotArea.FilterArea);
                        SetGridField("DetailConductorName", "Nama Kernet", PivotArea.FilterArea);
                        SetGridField("DetailConductorAmount", "Komisi Kernet", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");

                        SetGridField("DetailMechanic", "Montir", PivotArea.FilterArea);
                        SetGridField("DetailMechanicName", "Nama Montir", PivotArea.FilterArea);
                        SetGridField("DetailMechanicAmount", "Komisi Montir", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");

                        SetGridField("DetailBBM", "BBM", PivotArea.FilterArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");
                        SetGridField("DetailAmount", "Jumlah", PivotArea.DataArea, FormatType.Numeric, "{0:#,##0.00;(#,##0.00);}");
                    }
                    else
                    {
                        _GridControl.DataSource = null;
                        _pivotGridControl.DataSource = null;
                        MessageHelper.ShowMessageError(this, "Data tidak ditemukan.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex.Message);
            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }

           //base.ActionRefresh<T>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<RentalCarBooking>();
        }
    }
}

using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Domain.Entities.Organization;
using Domain.Entities.Rental;
using Domain.Entities.SQLView.EducationPayment;
using PopUpUtils;
using System;
using System.Data;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Rental
{
    public partial class frmRentalCarBookingDetailDVV : frmBaseFilterDVV
    {
        public frmRentalCarBookingDetailDVV()
        {
            InitializeComponent();

            this.EndPoint = "/RentalCarBookings";
            this.FormTitle = "Detail Rental Kendaraan (Dokumen)";

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

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate1, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate2, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void ActionRefresh()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

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

                    string select = "Id,Time,StartDate,EndDate,Trip,TotalPayment,TotalPrice,TotalOperationalCost,BBM,PickupAddress,DeliveryAddress";
                    string expand = "Passenger($select=Id,Code,Name,PhoneNumber),Vehicle($expand=Brand,ModelUnit),RentalCarBookingEmployees($expand=Employee($select=Id,Code,Name)),RentalCarBookingPayments($select=Date,Amount)";

                    var rentalCarBookings = HelperRestSharp.GetListOdata<RentalCarBooking>("/RentalCarBookings", fSelect: select, fExpand: expand, OdataFilter, fOrder: "Id");

                    if (rentalCarBookings.Any())
                    {
                        // set report destination
                        rptRentalCarBookingDetail report = new rptRentalCarBookingDetail();
                        report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                        if (company.WatermarkUrl != null)
                            SetPictureWatermark(report, HelperConvert.UrlToImageSource(company.WatermarkUrl));

                        DataTable dt = new DataTable();
                        dt.TableName = "Table1";
                        dt.Columns.Add("DetailNo", typeof(string));
                        dt.Columns.Add("DetailPassengerName", typeof(string));
                        dt.Columns.Add("DetailPassengerPhoneNumber", typeof(string));
                        dt.Columns.Add("DetailTime", typeof(string));
                        dt.Columns.Add("DetailRangeDate", typeof(string));
                        dt.Columns.Add("DetailTrip", typeof(decimal));
                        dt.Columns.Add("DetailPickupAddress", typeof(string));
                        dt.Columns.Add("DetailDeliveryAddress", typeof(string));

                        dt.Columns.Add("DetailVehicle", typeof(string));

                        dt.Columns.Add("DetailPayment1", typeof(string));
                        dt.Columns.Add("DetailPayment2", typeof(string));
                        dt.Columns.Add("DetailPayment3", typeof(string));

                        dt.Columns.Add("DetailPayment1Amount", typeof(decimal));
                        dt.Columns.Add("DetailPayment2Amount", typeof(decimal));
                        dt.Columns.Add("DetailPayment3Amount", typeof(decimal));

                        dt.Columns.Add("DetailTotalPayment", typeof(decimal));
                        dt.Columns.Add("DetailTotalPrice", typeof(decimal));

                        dt.Columns.Add("DetailDriver", typeof(string));
                        dt.Columns.Add("DetailConductor", typeof(string));
                        dt.Columns.Add("DetailMechanic", typeof(string));


                        dt.Columns.Add("DetailDriverAmount", typeof(decimal));
                        dt.Columns.Add("DetailConductorAmount", typeof(decimal));
                        dt.Columns.Add("DetailMechanicAmount", typeof(decimal));

                        dt.Columns.Add("DetailBBM", typeof(decimal));

                        dt.Columns.Add("DetailAmount", typeof(decimal));

                        int loop = 0;
                        foreach (var rentalCarBooking in rentalCarBookings)
                        {
                            DataRow totalRow = dt.NewRow();
                            totalRow["DetailNo"] = $"{loop++}.";
                            totalRow["DetailPassengerName"] = rentalCarBooking.Passenger.Name;
                            totalRow["DetailPassengerPhoneNumber"] = rentalCarBooking.Passenger.PhoneNumber;

                            totalRow["DetailTime"] = rentalCarBooking.Time.ToString(@"hh\:mm");
                            totalRow["DetailRangeDate"] = $"{rentalCarBooking.StartDate.ToString("dd-MMM-yyyy")}\r\n-\r\n{rentalCarBooking.EndDate.ToString("dd-MMM-yyyy")}";
                            totalRow["DetailTrip"] = rentalCarBooking.Trip;

                            totalRow["DetailPickupAddress"] = rentalCarBooking.PickupAddress;
                            totalRow["DetailDeliveryAddress"] = rentalCarBooking.DeliveryAddress;

                            totalRow["DetailVehicle"] = $"{rentalCarBooking.Vehicle.Brand.Name} {rentalCarBooking.Vehicle.ModelUnit.Name}\r\n{rentalCarBooking.Vehicle.VehicleColor} {rentalCarBooking.Vehicle.Seat} Seat\r\n{rentalCarBooking.Vehicle.VehicleNumber}";

                            int loopPayment = 0;
                            foreach (var rentalCarBookingPayment in rentalCarBooking.RentalCarBookingPayments)
                            {
                                loopPayment++;
                                if (loopPayment == 1)
                                {
                                    totalRow["DetailPayment1"] = $"{rentalCarBookingPayment.Date.ToString("dd-MMM-yyyy")}\r\n{HelperConvert.FormatRupiah(rentalCarBookingPayment.Amount)}";
                                    totalRow["DetailPayment1Amount"] = rentalCarBookingPayment.Amount;
                                }

                                if (loopPayment == 2)
                                {
                                    totalRow["DetailPayment2"] = $"{rentalCarBookingPayment.Date.ToString("dd-MMM-yyyy")}\r\n{HelperConvert.FormatRupiah(rentalCarBookingPayment.Amount)}";
                                    totalRow["DetailPayment2Amount"] = rentalCarBookingPayment.Amount;
                                }

                                if (loopPayment >= 3)
                                {
                                    totalRow["DetailPayment3"] += $"{rentalCarBookingPayment.Date.ToString("dd-MMM-yyyy")}\r\n{HelperConvert.FormatRupiah(rentalCarBookingPayment.Amount)}\r\n";
                                    totalRow["DetailPayment3Amount"] = HelperConvert.Decimal(totalRow["DetailPayment3Amount"]) + rentalCarBookingPayment.Amount;
                                }
                            }

                            totalRow["DetailTotalPayment"] = rentalCarBooking.TotalPayment;
                            totalRow["DetailTotalPrice"] = rentalCarBooking.TotalPrice;

                            var drivers = rentalCarBooking.RentalCarBookingEmployees.Where(s => s.EmployeeRole == Domain.EnumEmployeeRole.Driver).ToList();
                            foreach (var driver in drivers)
                            {
                                totalRow["DetailDriver"] += $"{driver.Employee.Name}\r\n{HelperConvert.FormatRupiah(driver.Amount)}\r\n";
                            }

                            totalRow["DetailDriverAmount"] = drivers.Sum(s => s.Amount);

                            var conductors = rentalCarBooking.RentalCarBookingEmployees.Where(s => s.EmployeeRole == Domain.EnumEmployeeRole.Conductor).ToList();
                            foreach (var conductor in conductors)
                            {
                                totalRow["DetailConductor"] += $"{conductor.Employee.Name}\r\n{HelperConvert.FormatRupiah(conductor.Amount)}\r\n";
                            }
                            totalRow["DetailConductorAmount"] = conductors.Sum(s => s.Amount);

                            var mechanics = rentalCarBooking.RentalCarBookingEmployees.Where(s => s.EmployeeRole == Domain.EnumEmployeeRole.Mechanic).ToList();
                            foreach (var mechanic in mechanics)
                            {
                                totalRow["DetailMechanic"] += $"{mechanic.Employee.Name}\r\n{HelperConvert.FormatRupiah(mechanic.Amount)}\r\n";
                            }
                            totalRow["DetailMechanicAmount"] = mechanics.Sum(s => s.Amount);

                            totalRow["DetailBBM"] = rentalCarBooking.BBM;

                            totalRow["DetailAmount"] = rentalCarBooking.TotalPrice - rentalCarBooking.TotalOperationalCost;

                            dt.Rows.Add(totalRow);
                        }

                        report.DataSource = dt;

                        //Detail
                        report.xrDetailPassengerName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPassengerName]"));
                        report.xrDetailPassengerPhoneNumber.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPassengerPhoneNumber]"));

                        report.xrDetailPickupAddress.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPickupAddress]"));
                        report.xrDetailDeliveryAddress.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDeliveryAddress]"));

                        report.xrDetailVehicle.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailVehicle]"));

                        report.xrDetailPayment1.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment1]"));
                        report.xrDetailPayment2.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment2]"));
                        report.xrDetailPayment3.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment3]"));

                        report.xrDetailTotalPayment.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalPayment]"));
                        report.xrDetailTotalPrice.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalPrice]"));

                        report.xrDetailDriver.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDriver]"));
                        report.xrDetailConductor.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailConductor]"));
                        report.xrDetailMechanic.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailMechanic]"));

                        report.xrDetailBBM.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailBBM]"));

                        report.xrDetailTime.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTime]"));
                        report.xrDetailRangeDate.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailRangeDate]"));
                        report.xrDetailTrip.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTrip]"));

                        report.xrDetailAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailAmount]"));

                        report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
                        report.xrPeriodeDate.Text = $"{HelperConvert.Date(FilterDate1.EditValue).ToString("dd MMMM yyyy")} - {HelperConvert.Date(FilterDate2.EditValue).ToString("dd MMMM yyyy")}";

                        report.xrUsernameFooter.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                        report.xrDateFooter.Text = $"Kota Tangerang, {DateTime.Today.ToString("dd MMMM yyyy")}";

                        report.Name = $"DetailRentalKendaraan_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                        string path = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + $"{report.Name}.pdf";
                        report.DisplayName = report.Name;
                        report.PrinterName = report.Name;

                        //set document source
                        _DocumentViewer.DocumentSource = report;
                        _DocumentViewer.InitiateDocumentCreation();
                    }
                    else
                    {
                        _DocumentViewer.DocumentSource = null;
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
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh();
        }
    }
}

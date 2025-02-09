﻿using DevExpress.XtraEditors.DXErrorProvider;
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
    public partial class frmRentalCarBookingScheduleDVV : frmBaseFilterDVV
    {
        public frmRentalCarBookingScheduleDVV()
        {
            InitializeComponent();

            this.EndPoint = "/RentalCarBookings";
            this.FormTitle = "Jadwal Rental Kendaraan (Dokumen)";

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

                    string select = "Id,Time,StartDate,EndDate,Trip,TotalPrice,PickupAddress,DeliveryAddress";
                    string expand = "Passenger($select=Id,Code,Name,PhoneNumber),Vehicle($expand=Brand,ModelUnit),RentalCarBookingEmployees($expand=Employee($select=Id,Code,Name))";

                    var rentalCarBookings = HelperRestSharp.GetListOdata<RentalCarBooking>("/RentalCarBookings", fSelect: select, fExpand: expand, OdataFilter, fOrder: "Id");

                    if (rentalCarBookings.Any())
                    {
                        // set report destination
                        rptRentalCarBookingSchedule report = new rptRentalCarBookingSchedule();
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
                        dt.Columns.Add("DetailTotalPrice", typeof(decimal));
                        dt.Columns.Add("DetailPickupAddress", typeof(string));
                        dt.Columns.Add("DetailDeliveryAddress", typeof(string));
                        dt.Columns.Add("DetailVehicleBrand", typeof(string));
                        dt.Columns.Add("DetailVehicleModel", typeof(string));
                        dt.Columns.Add("DetailVehicleColor", typeof(string));
                        dt.Columns.Add("DetailVehicleSeat", typeof(string));
                        dt.Columns.Add("DetailVehicleNumber", typeof(string));
                        dt.Columns.Add("DetailDriver", typeof(string));
                        dt.Columns.Add("DetailConductor", typeof(string));
                        dt.Columns.Add("DetailMechanic", typeof(string));

                        int loop = 0;
                        foreach (var rentalCarBooking in rentalCarBookings)
                        {
                            DataRow totalRow = dt.NewRow();
                            totalRow["DetailNo"] = $"{loop++}.";
                            totalRow["DetailPassengerName"] = rentalCarBooking.Passenger.Name;
                            totalRow["DetailPassengerPhoneNumber"] = rentalCarBooking.Passenger.PhoneNumber;

                            totalRow["DetailTime"] = rentalCarBooking.Time.ToString(@"hh\:mm");
                            totalRow["DetailRangeDate"] = $"{rentalCarBooking.StartDate.ToString("dd-MMM-yyyy")} - {rentalCarBooking.EndDate.ToString("dd-MMM-yyyy")}";
                            totalRow["DetailTrip"] = rentalCarBooking.Trip;
                            totalRow["DetailTotalPrice"] = rentalCarBooking.TotalPrice;

                            totalRow["DetailPickupAddress"] = rentalCarBooking.PickupAddress;
                            totalRow["DetailDeliveryAddress"] = rentalCarBooking.DeliveryAddress;

                            totalRow["DetailVehicleBrand"] = rentalCarBooking.Vehicle.Brand.Name;
                            totalRow["DetailVehicleModel"] = rentalCarBooking.Vehicle.ModelUnit.Name;
                            totalRow["DetailVehicleColor"] = rentalCarBooking.Vehicle.VehicleColor;
                            totalRow["DetailVehicleSeat"] = rentalCarBooking.Vehicle.Seat;
                            totalRow["DetailVehicleNumber"] = rentalCarBooking.Vehicle.VehicleNumber;

                            var driverNames = rentalCarBooking.RentalCarBookingEmployees.Where(s => s.EmployeeRole == Domain.EnumEmployeeRole.Driver).Select(s => s.Employee.Name).ToList();
                            totalRow["DetailDriver"] = string.Join("\r\n", driverNames);

                            var conductorNames = rentalCarBooking.RentalCarBookingEmployees.Where(s => s.EmployeeRole == Domain.EnumEmployeeRole.Conductor).Select(s => s.Employee.Name).ToList();
                            totalRow["DetailConductor"] = string.Join("\r\n", conductorNames);

                            var mechanicNames = rentalCarBooking.RentalCarBookingEmployees.Where(s => s.EmployeeRole == Domain.EnumEmployeeRole.Mechanic).Select(s => s.Employee.Name).ToList();
                            totalRow["DetailMechanic"] = string.Join("\r\n", mechanicNames);

                            dt.Rows.Add(totalRow);
                        }

                        report.DataSource = dt;

                        //Detail
                        report.xrDetailPassengerName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPassengerName]"));
                        report.xrDetailPassengerPhoneNumber.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPassengerPhoneNumber]"));

                        report.xrDetailPickupAddress.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPickupAddress]"));
                        report.xrDetailDeliveryAddress.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDeliveryAddress]"));


                        report.xrDetailVehicleBrand.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailVehicleBrand]"));
                        report.xrDetailVehicleModel.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailVehicleModel]"));
                        report.xrDetailVehicleColor.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailVehicleColor]"));
                        report.xrDetailVehicleSeat.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailVehicleSeat]"));
                        report.xrDetailVehicleNumber.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailVehicleNumber]"));

                        report.xrDetailDriver.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDriver]"));
                        report.xrDetailConductor.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailConductor]"));
                        report.xrDetailMechanic.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailMechanic]"));

                        report.xrDetailTime.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTime]"));
                        report.xrDetailRangeDate.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailRangeDate]"));
                        report.xrDetailTrip.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTrip]"));
                        report.xrDetailTotalPrice.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalPrice]"));

                        report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
                        report.xrPeriodeDate.Text = $"{HelperConvert.Date(FilterDate1.EditValue).ToString("dd MMMM yyyy")} - {HelperConvert.Date(FilterDate2.EditValue).ToString("dd MMMM yyyy")}";

                        report.xrUsernameFooter.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                        report.xrDateFooter.Text = $"Kota Tangerang, {DateTime.Today.ToString("dd MMMM yyyy")}";

                        report.Name = $"JadwalRentalKendaraan_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
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

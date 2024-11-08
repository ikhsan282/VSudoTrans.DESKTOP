﻿using DevExpress.XtraReports.UI;
using Domain.Entities.Rental;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using System;
using DevExpress.Drawing;
using DevExpress.XtraPrinting.Drawing;
using System.Globalization;
using System.Drawing;
using System.Data;
using System.Linq;

namespace VSudoTrans.DESKTOP.Report.Rental
{
    public partial class frmRentalCarBookingInvoiceLV : frmBaseLV
    {
        public frmRentalCarBookingInvoiceLV(int id)
        {
            InitializeComponent();

            this.EndPoint = "/RentalCarBookings";
            this.FormTitle = "DETAIL INVOICE";

            this.bbiRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            this.bbiNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ItemForGridControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;//Grid
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;//SearchControl

            InitialLoad(id);
        }

        private void InitialLoad(int id)
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                var rentalCarBooking = HelperRestSharp.GetById<RentalCarBooking>(id, "/RentalCarBookings");

                if (rentalCarBooking != null)
                {
                    var company = rentalCarBooking.Company;

                    this.Text = $"DETAIL INVOICE ({rentalCarBooking.DocumentNumber})";
                    // set report destination
                    rptRentalCarBookingInvoice report = new rptRentalCarBookingInvoice();

                    if (company.Logo != null)
                        report.companyLogo.ImageSource = HelperConvert.UrlToImageSource(company.LogoUrl);

                    if (company.Watermark != null)
                        report.companyLogo.ImageSource = HelperConvert.UrlToImageSource(company.LogoUrl);

                    if (rentalCarBooking.TotalPrice == rentalCarBooking.TotalPayment)
                    {
                        if (company.WatermarkPaid != null)
                            SetPictureWatermark(report, HelperConvert.UrlToImageSource(company.WatermarkPaidUrl));
                    }
                    else
                    {
                        if (company.WatermarkUnpaid != null)
                            SetPictureWatermark(report, HelperConvert.UrlToImageSource(company.WatermarkUnpaidUrl));
                    }

                    report.xrCompanyNameHeader.Text = company.Name;
                    report.xrCompanyAddressHeader.Text = company.Address;
                    report.xrCompanyAddressHeader2.Text = $"Telepon {company.PhoneNumber} | Web {company.Website} ";
                    CultureInfo indonesianCulture = CultureInfo.GetCultureInfo("id-ID");
                    string totalPrice = string.Format(indonesianCulture, "{0:N0}", rentalCarBooking.TotalPrice);
                    report.xrTerbilangHeader.Text = $"{HelperConvert.Terbilang(Convert.ToInt64(rentalCarBooking.RentalCarBookingPayments.Sum(s => s.Amount)))} Rupiah";

                    report.xrDocumentNumberHeader.Text = rentalCarBooking.DocumentNumber.ToString();
                    report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                    report.xrPrintTime.Text = DateTime.Now.ToString("HH:mm:ss");

                    report.xrPassengerPhoneNumberHeader.Text = rentalCarBooking.Passenger.PhoneNumber;
                    report.xrPassengerNameHeader.Text = rentalCarBooking.Passenger.Name;

                    report.xrDateHeader.Text = rentalCarBooking.Date.ToString("dd MMMM yyyy");
                    report.xrTimeHeader.Text = rentalCarBooking.Time.ToString(@"hh\:mm");
                    report.xrTotalPriceHeader.Text = totalPrice;

                    report.xrPickupAddress.Text = rentalCarBooking.PickupAddress;
                    report.xrDeliveryAddress.Text = rentalCarBooking.DeliveryAddress;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("PaymentMethodDetail", typeof(string));
                    dt.Columns.Add("DateDetail", typeof(string));
                    dt.Columns.Add("AmountDetail", typeof(decimal));

                    foreach (var rentalCarBookingPayments in rentalCarBooking.RentalCarBookingPayments)
                    {
                        DataRow r = dt.NewRow();
                        r["PaymentMethodDetail"] = EnumHelper.EnumPaymentMethodToString(rentalCarBookingPayments.PaymentMethod);
                        r["DateDetail"] = rentalCarBookingPayments.Date.ToString("dd-MMM-yyyy");
                        r["AmountDetail"] = rentalCarBookingPayments.Amount;

                        dt.Rows.Add(r);
                    }

                    report.DataSource = dt;

                    //Detail
                    report.xrPaymentMethodDetail.ExpressionBindings.Add(new ExpressionBinding("Text", "[PaymentMethodDetail]"));
                    report.xrDateDetail.ExpressionBindings.Add(new ExpressionBinding("Text", "[DateDetail]"));
                    report.xrAmountDetail.ExpressionBindings.Add(new ExpressionBinding("Text", "[AmountDetail]"));

                    report.xrUsernameFooter.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDateFooter.Text = $"Kota Tangerang, {DateTime.Today.ToString("dd MMMM yyyy")}";

                    report.DisplayName = this.Text;
                    report.PrinterName = this.Text;
                    report.Name = this.Text;

                    string path = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + $"{this.Text}.pdf";
                    _DocumentViewer.DocumentSource = report;
                    _DocumentViewer.InitiateDocumentCreation();

                    //documentViewer1.PrintingSystem.ExportOptions.PrintPreview.ShowOptionsBeforeExport = true;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
            finally
            {
                MessageHelper.WaitFormClose();
            }
        }

        public void SetTextWatermark(XtraReport report)
        {
            Watermark textWatermark = new Watermark();
            textWatermark.Text = "NTM";
            textWatermark.TextDirection = DirectionMode.ForwardDiagonal;
            textWatermark.Font = new DXFont(textWatermark.Font.Name, 40);
            textWatermark.ShowBehind = false;
            report.Watermark.CopyFrom(textWatermark);
        }

        public void SetPictureWatermark(XtraReport report, ImageSource imageSource)
        {
            Watermark pictureWatermark = new Watermark();
            pictureWatermark.ImageSource = imageSource;
            pictureWatermark.ImageAlign = ContentAlignment.BottomRight;
            pictureWatermark.ImageTiling = false;
            pictureWatermark.ImageViewMode = ImageViewMode.Clip;
            pictureWatermark.ImageTransparency = 150;
            pictureWatermark.ShowBehind = true;
            pictureWatermark.PageRange = "1,2,3,4,5";
            report.Watermark.CopyFrom(pictureWatermark);
        }
    }
}

using DevExpress.XtraReports.UI;
using Domain.Entities.Travel;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using System;
using DevExpress.Drawing;
using DevExpress.XtraPrinting.Drawing;
using System.Globalization;
using System.Drawing;
using System.Linq;

namespace VSudoTrans.DESKTOP.Report.Travel
{
    public partial class frmESPJTripScheduleLV : frmBaseFilterLV
    {
        public frmESPJTripScheduleLV(int id)
        {
            InitializeComponent();

            this.EndPoint = "/TripSchedules";
            this.FormTitle = "E-SPJ";

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
                var tripSchedule = HelperRestSharp.GetOdata<TripSchedule>("/TripSchedules", "DocumentNumber,Date,StartTime,EndTime,TotalDuration", "TripScheduleDetails($expand=TravelTicketBooking($select=TotalPrice,TotalTicket)),Company,Employee,Vehicle($select=VehicleNumber;$expand=Brand($select=name),ModelUnit($select=name)),PickupPointCity($select=name),DeliveryPointCity($select=name)", $"Id eq {id}");
                var travelTicketBookings = HelperRestSharp.GetListOdata<TravelTicketBooking>("/TravelTicketBookings", "*", "TravelTicketBookingDetails,PickupPointCity($select=name),DeliveryPointCity($select=name)", $"Id in ({string.Join(",", tripSchedule.TripScheduleDetails.Select(s => s.TravelTicketBookingId).ToList())})");

                if (tripSchedule != null)
                {
                    this.Text = $"Print E-SPJ ({tripSchedule.DocumentNumber})";
                    // set report destination
                    rptESPJTripSchedule report = new rptESPJTripSchedule();

                    //if (tripSchedule.Company.Watermark != null)
                    //    SetPictureWatermark(report, HelperConvert.ConvertBytesToImageSource(tripSchedule.Company.Watermark));

                    //if (tripSchedule.Company.Logo != null)
                    //    report.companyLogo.ImageSource = HelperConvert.ConvertBytesToImageSource(tripSchedule.Company.Logo);

                    CultureInfo indonesianCulture = CultureInfo.GetCultureInfo("id-ID");
                    string totalPrice = string.Format(indonesianCulture, "{0:N0}", tripSchedule.TripScheduleDetails.Sum(s => s.TravelTicketBooking.TotalPrice));

                    report.xrEmployeeNameHeader.Text = $"{tripSchedule.Employee.Code} - {tripSchedule.Employee.Name}";
                    report.xrEmployeeNameFooter.Text = tripSchedule.Employee.Name;
                    report.xrVehicleHeader.Text = $"{tripSchedule.Vehicle.VehicleNumber} - {tripSchedule.Vehicle.Brand.Name} - {tripSchedule.Vehicle.ModelUnit.Name}";

                    report.xrRuteAwalHeader.Text = $"{tripSchedule.PickupPointCity.Name} - {tripSchedule.DeliveryPointCity.Name}";
                    report.xrDocumentNumberHeader.Text = tripSchedule.DocumentNumber.ToString();
                    report.xrDateHeader.Text = tripSchedule.Date.ToString("dd MMMM yyyy");
                    report.xrStartTimeHeader.Text = tripSchedule.StartTime.ToString(@"hh\:mm");
                    report.xrEndTimeHeader.Text = tripSchedule.EndTime.ToString(@"hh\:mm");
                    report.xrTotalPriceHeader.Text = totalPrice;
                    report.xrTotalTicketHeader.Text = tripSchedule.TripScheduleDetails.Sum(s => s.TravelTicketBooking.TotalTicket).ToString();

                    //report.xrPickupAddress.Text = travel.PickupAddress;
                    //report.xrDeliveryAddress.Text = travel.DeliveryAddress;


                    report.detailTable.BeginInit();
                    report.detailTable.Rows.Clear();

                    XRTableRow dataRow = new XRTableRow();

                    XRTableCell noCell = new XRTableCell();
                    noCell.BackColor = Color.Transparent;
                    noCell.Text = "#";
                    noCell.WidthF = 10F;
                    noCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    noCell.Font = new DevExpress.Drawing.DXFont("Segoe UI", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    noCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    dataRow.Cells.Add(noCell);

                    XRTableCell noPickupCell = new XRTableCell();
                    noPickupCell.BackColor = Color.Transparent;
                    noPickupCell.Text = "No Jemput";
                    noPickupCell.WidthF = 50F;
                    noPickupCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    noPickupCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(noPickupCell);

                    XRTableCell timePickupCell = new XRTableCell();
                    timePickupCell.BackColor = Color.Transparent;
                    timePickupCell.Text = "Jam Jemput";
                    timePickupCell.WidthF = 60F;
                    timePickupCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    timePickupCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(timePickupCell);

                    XRTableCell noDeliveryCell = new XRTableCell();
                    noDeliveryCell.BackColor = Color.Transparent;
                    noDeliveryCell.Text = "No Antar";
                    noDeliveryCell.WidthF = 50F;
                    noDeliveryCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    noDeliveryCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(noDeliveryCell);

                    XRTableCell ruteCell = new XRTableCell();
                    ruteCell.BackColor = Color.Transparent;
                    ruteCell.Text = "Rute";
                    ruteCell.HeightF = 130F;
                    ruteCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    ruteCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(ruteCell);

                    XRTableCell paymentTypeCell = new XRTableCell();
                    paymentTypeCell.BackColor = Color.Transparent;
                    paymentTypeCell.Text = "Pembayaran";
                    paymentTypeCell.WidthF = 60F;
                    paymentTypeCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    paymentTypeCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(paymentTypeCell);

                    XRTableCell ticketCell = new XRTableCell();
                    ticketCell.BackColor = Color.Transparent;
                    ticketCell.Text = "Jumlah Tiket";
                    ticketCell.WidthF = 60F;
                    ticketCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    ticketCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(ticketCell);

                    XRTableCell noteCell = new XRTableCell();
                    noteCell.BackColor = Color.Transparent;
                    noteCell.Text = "Keterangan";
                    noteCell.WidthF = 80F;
                    noteCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    noteCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(noteCell);

                    XRTableCell priceCell = new XRTableCell();
                    priceCell.BackColor = Color.Transparent;
                    priceCell.Text = "Harga";
                    priceCell.WidthF = 80F;
                    priceCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    priceCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    priceCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    dataRow.Cells.Add(priceCell);

                    report.detailTable.Rows.Add(dataRow);

                    int loop = 0;
                    // Populate the table with passenger data
                    foreach (var detail in tripSchedule.TripScheduleDetails.OrderBy(s => s.LineNumberPickup).ToList())
                    {
                        loop++;

                        detail.TravelTicketBooking = travelTicketBookings.Where(s => s.Id == detail.TravelTicketBookingId).FirstOrDefault();

                        dataRow = new XRTableRow();

                        noCell = new XRTableCell();
                        noCell.BackColor = Color.Transparent;
                        noCell.Text = loop.ToString();
                        noCell.WidthF = 10F;
                        noCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        noCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                        dataRow.Cells.Add(noCell);

                        noPickupCell = new XRTableCell();
                        noPickupCell.BackColor = Color.Transparent;
                        noPickupCell.Text = detail.LineNumberPickup.ToString();//EnumHelper.EnumPassengerTypeToString(passenger.PassengerType);
                        noPickupCell.WidthF = 50F;
                        noPickupCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(noPickupCell);

                        timePickupCell = new XRTableCell();
                        timePickupCell.BackColor = Color.Transparent;
                        timePickupCell.Text = detail.TravelTicketBooking.Time.ToString(@"hh\:mm");
                        timePickupCell.WidthF = 60F;
                        timePickupCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(timePickupCell);

                        noDeliveryCell = new XRTableCell();
                        noDeliveryCell.BackColor = Color.Transparent;
                        noDeliveryCell.WidthF = 50F;
                        noDeliveryCell.Text = detail.LineNumberDelivery.ToString();//passenger.Passenger.Name;
                        noDeliveryCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(noDeliveryCell);

                        ruteCell = new XRTableCell();
                        ruteCell.BackColor = Color.Transparent;
                        ruteCell.HeightF = 130F;
                        ruteCell.Text = $"{detail.TravelTicketBooking.PickupPointCity.Name} - {detail.TravelTicketBooking.DeliveryPointCity.Name}";//passenger.Passenger.PhoneNumber.ToString();
                        ruteCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(ruteCell);

                        paymentTypeCell = new XRTableCell();
                        paymentTypeCell.BackColor = Color.Transparent;
                        paymentTypeCell.Text = EnumHelper.EnumPaymentTypeToString(detail.TravelTicketBooking.PaymentType);//passenger.Passenger.Name;
                        paymentTypeCell.WidthF = 60F;
                        paymentTypeCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(paymentTypeCell);

                        ticketCell = new XRTableCell();
                        ticketCell.BackColor = Color.Transparent;
                        ticketCell.Text = detail.TravelTicketBooking.TotalTicket.ToString();
                        ticketCell.WidthF = 60F;
                        ticketCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(ticketCell);

                        noteCell = new XRTableCell();
                        noteCell.BackColor = Color.Transparent;
                        noteCell.WidthF = 80F;
                        noteCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(noteCell);
                        foreach (var item in detail.TravelTicketBooking.TravelTicketBookingDetails.GroupBy(s => s.PassengerType))
                        {
                            noteCell.Text += $"{item.Count()} {EnumHelper.EnumPassengerTypeToString(item.Key)} ";
                        }

                        priceCell = new XRTableCell();
                        priceCell.BackColor = Color.Transparent;
                        priceCell.Text = string.Format(indonesianCulture, "{0:N0}", detail.TravelTicketBooking.TotalPrice);
                        priceCell.WidthF = 80F;
                        priceCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        priceCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                        dataRow.Cells.Add(priceCell);

                        report.detailTable.Rows.Add(dataRow);
                    }
                    report.detailTable.EndInit();

                    dataRow = new XRTableRow();

                    priceCell = new XRTableCell();
                    priceCell.BackColor = Color.Transparent;
                    priceCell.Text = totalPrice;
                    priceCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    priceCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    priceCell.Font = new DevExpress.Drawing.DXFont("Verdana", 12F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(priceCell);

                    report.detailTable.Rows.Add(dataRow);

                    report.xrUsername.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDate.Text = DateTime.Today.ToString("dd MMMM yyyy");

                    report.DisplayName = $"E-SPJ {tripSchedule.Company.Name} ({tripSchedule.DocumentNumber})";
                    report.PrinterName = $"E-SPJ {tripSchedule.Company.Name} ({tripSchedule.DocumentNumber})";
                    report.Name = $"E-SPJ {tripSchedule.Company.Name} ({tripSchedule.DocumentNumber})";
                    documentViewer1.DocumentSource = report;
                    documentViewer1.InitiateDocumentCreation();

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

        public void SetPictureWatermark(XtraReport report, ImageSource imageSource, ContentAlignment contentAlignment = ContentAlignment.BottomRight, ImageViewMode imageViewMode = ImageViewMode.Clip)
        {
            Watermark pictureWatermark = new Watermark();
            pictureWatermark.ImageSource = imageSource;
            pictureWatermark.ImageAlign = contentAlignment;
            pictureWatermark.ImageTiling = false;
            pictureWatermark.ImageViewMode = imageViewMode;
            pictureWatermark.ImageTransparency = 150;
            pictureWatermark.ShowBehind = true;
            pictureWatermark.PageRange = "1,2,3,4,5";
            report.Watermark.CopyFrom(pictureWatermark);
        }
    }
}

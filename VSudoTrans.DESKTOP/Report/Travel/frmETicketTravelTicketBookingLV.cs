using DevExpress.XtraReports.UI;
using Domain.Entities.Travel;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using System;
using DevExpress.Drawing;
using DevExpress.XtraPrinting.Drawing;
using System.Globalization;
using System.Drawing;

namespace VSudoTrans.DESKTOP.Report.Travel
{
    public partial class frmETicketTravelTicketBookingLV : frmBaseLV
    {
        public frmETicketTravelTicketBookingLV(int id)
        {
            InitializeComponent();

            this.EndPoint = "/TravelTicketBookings";
            this.FormTitle = "E-Tiket Perjalanan";

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
                var travel = HelperRestSharp.GetById<TravelTicketBooking>(id, "/TravelTicketBookings");

                if (travel != null)
                {
                    this.Text = $"Print E-Tiket ({travel.DocumentNumber})";
                    // set report destination
                    rptETicketTravelTicketBooking report = new rptETicketTravelTicketBooking();

                    //if (travel.Company.Watermark != null)
                    //    SetPictureWatermark(report, HelperConvert.ConvertBytesToImageSource(travel.Company.Watermark));

                    //if (travel.Company.Logo != null)
                    //    report.companyLogo.ImageSource = HelperConvert.ConvertBytesToImageSource(travel.Company.Logo);

                    report.xrCompanyNameHeader.Text = travel.Company.Name;
                    report.xrCompanyAddressHeader.Text = travel.Company.Address;
                    CultureInfo indonesianCulture = CultureInfo.GetCultureInfo("id-ID");
                    string totalPrice = string.Format(indonesianCulture, "{0:N0}", travel.TotalPrice);

                    //report.xrRuteHeader.Text = $"{travel.Rute.PickupPointCity.Name} - {travel.Rute.DeliveryPointCity.Name}";
                    report.xrDocumentNumberHeader.Text = travel.DocumentNumber.ToString();
                    report.xrDateHeader.Text = travel.Date.ToString("dd MMMM yyyy");
                    report.xrTimeHeader.Text = travel.Time.ToString(@"hh\:mm");
                    report.xrTotalPriceHeader.Text = totalPrice;
                    report.xrTotalTicketHeader.Text = travel.TotalTicket.ToString();

                    report.xrPickupAddress.Text = travel.PickupAddress;
                    report.xrDeliveryAddress.Text = travel.DeliveryAddress;


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

                    XRTableCell typeCell = new XRTableCell();
                    typeCell.BackColor = Color.Transparent;
                    typeCell.Text = "Tipe";
                    typeCell.WidthF = 50F;
                    typeCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    typeCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(typeCell);

                    XRTableCell nameCell = new XRTableCell();
                    nameCell.BackColor = Color.Transparent;
                    nameCell.Text = "Nama";
                    nameCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    nameCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(nameCell);

                    XRTableCell phoneNumberCell = new XRTableCell();
                    phoneNumberCell.BackColor = Color.Transparent;
                    phoneNumberCell.Text = "Nomor Telepon";
                    phoneNumberCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    phoneNumberCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    dataRow.Cells.Add(phoneNumberCell);

                    XRTableCell priceCell = new XRTableCell();
                    priceCell.BackColor = Color.Transparent;
                    priceCell.Text = "Harga";
                    priceCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                    priceCell.Font = new DevExpress.Drawing.DXFont("Verdana", 10F, DevExpress.Drawing.DXFontStyle.Bold);
                    priceCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    dataRow.Cells.Add(priceCell);

                    report.detailTable.Rows.Add(dataRow);

                    int loop = 0;
                    // Populate the table with passenger data
                    foreach (var passenger in travel.TravelTicketBookingDetails)
                    {
                        loop++;

                        dataRow = new XRTableRow();

                        noCell = new XRTableCell();
                        noCell.BackColor = Color.Transparent;
                        noCell.Text = loop.ToString();
                        noCell.WidthF = 10F;
                        noCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        noCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                        dataRow.Cells.Add(noCell);

                        typeCell = new XRTableCell();
                        typeCell.BackColor = Color.Transparent;
                        typeCell.WidthF = 50F;
                        typeCell.Text = EnumHelper.EnumPassengerTypeToString(passenger.PassengerType);
                        typeCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(typeCell);

                        nameCell = new XRTableCell();
                        nameCell.BackColor = Color.Transparent;
                        nameCell.Text = passenger.Passenger.Name;
                        nameCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(nameCell);

                        phoneNumberCell = new XRTableCell();
                        phoneNumberCell.BackColor = Color.Transparent;
                        phoneNumberCell.Text = passenger.Passenger.PhoneNumber.ToString();
                        phoneNumberCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
                        dataRow.Cells.Add(phoneNumberCell);

                        priceCell = new XRTableCell();
                        priceCell.BackColor = Color.Transparent;
                        priceCell.Text = string.Format(indonesianCulture, "{0:N0}", passenger.Price);
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

                    report.DisplayName = $"E-Tiket {travel.Company.Name} ({travel.DocumentNumber})";
                    report.PrinterName = $"E-Tiket {travel.Company.Name} ({travel.DocumentNumber})";
                    report.Name = $"E-Tiket {travel.Company.Name} ({travel.DocumentNumber})";
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

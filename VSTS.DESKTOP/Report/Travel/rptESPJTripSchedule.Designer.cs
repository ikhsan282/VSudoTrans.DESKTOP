namespace VSTS.DESKTOP.Report.Travel
{
    partial class rptESPJTripSchedule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptESPJTripSchedule));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.detailTable = new DevExpress.XtraReports.UI.XRTable();
            this.detailTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.passengerName = new DevExpress.XtraReports.UI.XRTableCell();
            this.passengerPhoneNumber = new DevExpress.XtraReports.UI.XRTableCell();
            this.passengerPrice = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDateCaption = new DevExpress.XtraReports.UI.XRLabel();
            this.xrUsername = new DevExpress.XtraReports.UI.XRLabel();
            this.xrUsernameCaption = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrCaptionTotalTicketHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTotalTicketHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionEmployeeNameHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrEmployeeNameHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrVehicleHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionVehicleHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionPriceHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTotalPriceHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDurationHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionDurationHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionEndTimeHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrEndTimeHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionRuteAkhirHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRuteAkhirHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRuteAwalHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionRuteAwalHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDetailPenumpangCaption = new DevExpress.XtraReports.UI.XRLabel();
            this.xrStartTimeHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionStartTimeHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionDocumentNumberHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.companyLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrETicket = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCaptionDateHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDateHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrDocumentNumberHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.baseControlStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.evenDetailStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.oddDetailStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupFooter = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrEmployeeNameFooter = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPickupAddress = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.detailTable});
            this.Detail.HeightF = 47.35396F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "baseControlStyle";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // detailTable
            // 
            this.detailTable.BorderColor = System.Drawing.Color.Gray;
            this.detailTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.detailTable.BorderWidth = 1F;
            this.detailTable.EvenStyleName = "evenDetailStyle";
            this.detailTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.detailTable.Name = "detailTable";
            this.detailTable.OddStyleName = "oddDetailStyle";
            this.detailTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.detailTableRow1});
            this.detailTable.SizeF = new System.Drawing.SizeF(1069F, 39.99998F);
            this.detailTable.StyleName = "evenDetailStyle";
            this.detailTable.StylePriority.UseBorderColor = false;
            this.detailTable.StylePriority.UseBorders = false;
            this.detailTable.StylePriority.UseBorderWidth = false;
            this.detailTable.StylePriority.UseFont = false;
            // 
            // detailTableRow1
            // 
            this.detailTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.passengerName,
            this.passengerPhoneNumber,
            this.passengerPrice});
            this.detailTableRow1.Name = "detailTableRow1";
            this.detailTableRow1.Weight = 11.948091758995535D;
            // 
            // passengerName
            // 
            this.passengerName.BackColor = System.Drawing.Color.Transparent;
            this.passengerName.BorderColor = System.Drawing.Color.White;
            this.passengerName.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.passengerName.BorderWidth = 1F;
            this.passengerName.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.passengerName.Name = "passengerName";
            this.passengerName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 0, 100F);
            this.passengerName.StylePriority.UseBackColor = false;
            this.passengerName.StylePriority.UseBorderColor = false;
            this.passengerName.StylePriority.UseBorders = false;
            this.passengerName.StylePriority.UseBorderWidth = false;
            this.passengerName.StylePriority.UseFont = false;
            this.passengerName.StylePriority.UsePadding = false;
            this.passengerName.StylePriority.UseTextAlignment = false;
            this.passengerName.Text = "Penumpang1";
            this.passengerName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.passengerName.Weight = 1.6310034282815615D;
            // 
            // passengerPhoneNumber
            // 
            this.passengerPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.passengerPhoneNumber.BorderColor = System.Drawing.Color.White;
            this.passengerPhoneNumber.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.passengerPhoneNumber.BorderWidth = 5F;
            this.passengerPhoneNumber.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.passengerPhoneNumber.Multiline = true;
            this.passengerPhoneNumber.Name = "passengerPhoneNumber";
            this.passengerPhoneNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 0, 100F);
            this.passengerPhoneNumber.StylePriority.UseBackColor = false;
            this.passengerPhoneNumber.StylePriority.UseBorderColor = false;
            this.passengerPhoneNumber.StylePriority.UseBorders = false;
            this.passengerPhoneNumber.StylePriority.UseBorderWidth = false;
            this.passengerPhoneNumber.StylePriority.UseFont = false;
            this.passengerPhoneNumber.StylePriority.UsePadding = false;
            this.passengerPhoneNumber.StylePriority.UseTextAlignment = false;
            this.passengerPhoneNumber.Text = "6281398461650";
            this.passengerPhoneNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.passengerPhoneNumber.Weight = 0.71345747653443259D;
            // 
            // passengerPrice
            // 
            this.passengerPrice.BackColor = System.Drawing.Color.Transparent;
            this.passengerPrice.BorderColor = System.Drawing.Color.White;
            this.passengerPrice.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.passengerPrice.BorderWidth = 5F;
            this.passengerPrice.Name = "passengerPrice";
            this.passengerPrice.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.passengerPrice.RowSpan = 2;
            this.passengerPrice.StylePriority.UseBackColor = false;
            this.passengerPrice.StylePriority.UseBorderColor = false;
            this.passengerPrice.StylePriority.UseBorders = false;
            this.passengerPrice.StylePriority.UseBorderWidth = false;
            this.passengerPrice.StylePriority.UseFont = false;
            this.passengerPrice.StylePriority.UseForeColor = false;
            this.passengerPrice.StylePriority.UsePadding = false;
            this.passengerPrice.StylePriority.UseTextAlignment = false;
            this.passengerPrice.Text = "Rp 0.00";
            this.passengerPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.passengerPrice.TextFormatString = "{0:$0.00}";
            this.passengerPrice.Weight = 0.53848876790748612D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.StylePriority.UseBackColor = false;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrDate,
            this.xrDateCaption,
            this.xrUsername,
            this.xrUsernameCaption});
            this.BottomMargin.HeightF = 140F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.StyleName = "baseControlStyle";
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrDate
            // 
            this.xrDate.BackColor = System.Drawing.Color.Transparent;
            this.xrDate.BorderColor = System.Drawing.Color.Black;
            this.xrDate.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrDate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrDate.BorderWidth = 1F;
            this.xrDate.CanShrink = true;
            this.xrDate.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrDate.ForeColor = System.Drawing.Color.Black;
            this.xrDate.LocationFloat = new DevExpress.Utils.PointFloat(353.4196F, 77.36113F);
            this.xrDate.Name = "xrDate";
            this.xrDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrDate.SizeF = new System.Drawing.SizeF(207.0307F, 20.00002F);
            this.xrDate.StylePriority.UseBackColor = false;
            this.xrDate.StylePriority.UseBorderColor = false;
            this.xrDate.StylePriority.UseBorderDashStyle = false;
            this.xrDate.StylePriority.UseBorders = false;
            this.xrDate.StylePriority.UseBorderWidth = false;
            this.xrDate.StylePriority.UseFont = false;
            this.xrDate.StylePriority.UseForeColor = false;
            this.xrDate.StylePriority.UsePadding = false;
            this.xrDate.StylePriority.UseTextAlignment = false;
            this.xrDate.Text = "17 September 2023";
            this.xrDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrDateCaption
            // 
            this.xrDateCaption.BackColor = System.Drawing.Color.Transparent;
            this.xrDateCaption.BorderColor = System.Drawing.Color.Black;
            this.xrDateCaption.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrDateCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrDateCaption.BorderWidth = 1F;
            this.xrDateCaption.CanShrink = true;
            this.xrDateCaption.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F);
            this.xrDateCaption.ForeColor = System.Drawing.Color.Black;
            this.xrDateCaption.LocationFloat = new DevExpress.Utils.PointFloat(281.753F, 77.36113F);
            this.xrDateCaption.Name = "xrDateCaption";
            this.xrDateCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrDateCaption.SizeF = new System.Drawing.SizeF(71.66663F, 20.00002F);
            this.xrDateCaption.StylePriority.UseBackColor = false;
            this.xrDateCaption.StylePriority.UseBorderColor = false;
            this.xrDateCaption.StylePriority.UseBorderDashStyle = false;
            this.xrDateCaption.StylePriority.UseBorders = false;
            this.xrDateCaption.StylePriority.UseBorderWidth = false;
            this.xrDateCaption.StylePriority.UseFont = false;
            this.xrDateCaption.StylePriority.UseForeColor = false;
            this.xrDateCaption.StylePriority.UsePadding = false;
            this.xrDateCaption.StylePriority.UseTextAlignment = false;
            this.xrDateCaption.Text = "pada tanggal";
            this.xrDateCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrUsername
            // 
            this.xrUsername.BackColor = System.Drawing.Color.Transparent;
            this.xrUsername.BorderColor = System.Drawing.Color.Black;
            this.xrUsername.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrUsername.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrUsername.BorderWidth = 1F;
            this.xrUsername.CanShrink = true;
            this.xrUsername.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrUsername.ForeColor = System.Drawing.Color.Black;
            this.xrUsername.LocationFloat = new DevExpress.Utils.PointFloat(81.66663F, 77.36113F);
            this.xrUsername.Name = "xrUsername";
            this.xrUsername.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrUsername.SizeF = new System.Drawing.SizeF(200.0863F, 20.00002F);
            this.xrUsername.StylePriority.UseBackColor = false;
            this.xrUsername.StylePriority.UseBorderColor = false;
            this.xrUsername.StylePriority.UseBorderDashStyle = false;
            this.xrUsername.StylePriority.UseBorders = false;
            this.xrUsername.StylePriority.UseBorderWidth = false;
            this.xrUsername.StylePriority.UseFont = false;
            this.xrUsername.StylePriority.UseForeColor = false;
            this.xrUsername.StylePriority.UsePadding = false;
            this.xrUsername.StylePriority.UseTextAlignment = false;
            this.xrUsername.Text = "Dibuat oleh";
            this.xrUsername.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrUsernameCaption
            // 
            this.xrUsernameCaption.BackColor = System.Drawing.Color.Transparent;
            this.xrUsernameCaption.BorderColor = System.Drawing.Color.Black;
            this.xrUsernameCaption.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrUsernameCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrUsernameCaption.BorderWidth = 1F;
            this.xrUsernameCaption.CanShrink = true;
            this.xrUsernameCaption.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F);
            this.xrUsernameCaption.ForeColor = System.Drawing.Color.Black;
            this.xrUsernameCaption.LocationFloat = new DevExpress.Utils.PointFloat(9.999996F, 77.36113F);
            this.xrUsernameCaption.Name = "xrUsernameCaption";
            this.xrUsernameCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrUsernameCaption.SizeF = new System.Drawing.SizeF(71.66663F, 20.00002F);
            this.xrUsernameCaption.StylePriority.UseBackColor = false;
            this.xrUsernameCaption.StylePriority.UseBorderColor = false;
            this.xrUsernameCaption.StylePriority.UseBorderDashStyle = false;
            this.xrUsernameCaption.StylePriority.UseBorders = false;
            this.xrUsernameCaption.StylePriority.UseBorderWidth = false;
            this.xrUsernameCaption.StylePriority.UseFont = false;
            this.xrUsernameCaption.StylePriority.UseForeColor = false;
            this.xrUsernameCaption.StylePriority.UsePadding = false;
            this.xrUsernameCaption.StylePriority.UseTextAlignment = false;
            this.xrUsernameCaption.Text = "Dibuat oleh";
            this.xrUsernameCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader
            // 
            this.GroupHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrCaptionTotalTicketHeader,
            this.xrTotalTicketHeader,
            this.xrCaptionEmployeeNameHeader,
            this.xrEmployeeNameHeader,
            this.xrVehicleHeader,
            this.xrCaptionVehicleHeader,
            this.xrCaptionPriceHeader,
            this.xrTotalPriceHeader,
            this.xrDurationHeader,
            this.xrCaptionDurationHeader,
            this.xrCaptionEndTimeHeader,
            this.xrEndTimeHeader,
            this.xrCaptionRuteAkhirHeader,
            this.xrRuteAkhirHeader,
            this.xrRuteAwalHeader,
            this.xrCaptionRuteAwalHeader,
            this.xrDetailPenumpangCaption,
            this.xrStartTimeHeader,
            this.xrCaptionStartTimeHeader,
            this.xrCaptionDocumentNumberHeader,
            this.companyLogo,
            this.xrETicket,
            this.xrCaptionDateHeader,
            this.xrDateHeader,
            this.xrDocumentNumberHeader});
            this.GroupHeader.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("InvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader.HeightF = 239.9724F;
            this.GroupHeader.Level = 1;
            this.GroupHeader.Name = "GroupHeader";
            this.GroupHeader.StyleName = "baseControlStyle";
            this.GroupHeader.StylePriority.UseBackColor = false;
            // 
            // xrCaptionTotalTicketHeader
            // 
            this.xrCaptionTotalTicketHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionTotalTicketHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionTotalTicketHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionTotalTicketHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionTotalTicketHeader.BorderWidth = 1F;
            this.xrCaptionTotalTicketHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionTotalTicketHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionTotalTicketHeader.LocationFloat = new DevExpress.Utils.PointFloat(655.3129F, 163.8335F);
            this.xrCaptionTotalTicketHeader.Name = "xrCaptionTotalTicketHeader";
            this.xrCaptionTotalTicketHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionTotalTicketHeader.SizeF = new System.Drawing.SizeF(97.27274F, 20F);
            this.xrCaptionTotalTicketHeader.StylePriority.UseBackColor = false;
            this.xrCaptionTotalTicketHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionTotalTicketHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionTotalTicketHeader.StylePriority.UseBorders = false;
            this.xrCaptionTotalTicketHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionTotalTicketHeader.StylePriority.UseFont = false;
            this.xrCaptionTotalTicketHeader.StylePriority.UseForeColor = false;
            this.xrCaptionTotalTicketHeader.StylePriority.UsePadding = false;
            this.xrCaptionTotalTicketHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionTotalTicketHeader.Text = "TOTAL TIKET";
            this.xrCaptionTotalTicketHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTotalTicketHeader
            // 
            this.xrTotalTicketHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrTotalTicketHeader.BorderColor = System.Drawing.Color.Black;
            this.xrTotalTicketHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrTotalTicketHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTotalTicketHeader.BorderWidth = 1F;
            this.xrTotalTicketHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTotalTicketHeader.ForeColor = System.Drawing.Color.Black;
            this.xrTotalTicketHeader.LocationFloat = new DevExpress.Utils.PointFloat(752.5859F, 163.8335F);
            this.xrTotalTicketHeader.Name = "xrTotalTicketHeader";
            this.xrTotalTicketHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTotalTicketHeader.SizeF = new System.Drawing.SizeF(306.4136F, 20F);
            this.xrTotalTicketHeader.StylePriority.UseBackColor = false;
            this.xrTotalTicketHeader.StylePriority.UseBorderColor = false;
            this.xrTotalTicketHeader.StylePriority.UseBorderDashStyle = false;
            this.xrTotalTicketHeader.StylePriority.UseBorders = false;
            this.xrTotalTicketHeader.StylePriority.UseBorderWidth = false;
            this.xrTotalTicketHeader.StylePriority.UseFont = false;
            this.xrTotalTicketHeader.StylePriority.UseForeColor = false;
            this.xrTotalTicketHeader.StylePriority.UsePadding = false;
            this.xrTotalTicketHeader.StylePriority.UseTextAlignment = false;
            this.xrTotalTicketHeader.Text = "0";
            this.xrTotalTicketHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTotalTicketHeader.TextFormatString = "{0:#.00}";
            // 
            // xrCaptionEmployeeNameHeader
            // 
            this.xrCaptionEmployeeNameHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionEmployeeNameHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionEmployeeNameHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionEmployeeNameHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionEmployeeNameHeader.BorderWidth = 1F;
            this.xrCaptionEmployeeNameHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionEmployeeNameHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionEmployeeNameHeader.LocationFloat = new DevExpress.Utils.PointFloat(9.999996F, 83.83337F);
            this.xrCaptionEmployeeNameHeader.Name = "xrCaptionEmployeeNameHeader";
            this.xrCaptionEmployeeNameHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionEmployeeNameHeader.SizeF = new System.Drawing.SizeF(108.6812F, 19.99999F);
            this.xrCaptionEmployeeNameHeader.StylePriority.UseBackColor = false;
            this.xrCaptionEmployeeNameHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionEmployeeNameHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionEmployeeNameHeader.StylePriority.UseBorders = false;
            this.xrCaptionEmployeeNameHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionEmployeeNameHeader.StylePriority.UseFont = false;
            this.xrCaptionEmployeeNameHeader.StylePriority.UseForeColor = false;
            this.xrCaptionEmployeeNameHeader.StylePriority.UsePadding = false;
            this.xrCaptionEmployeeNameHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionEmployeeNameHeader.Text = "PENGEMUDI";
            this.xrCaptionEmployeeNameHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrEmployeeNameHeader
            // 
            this.xrEmployeeNameHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrEmployeeNameHeader.BorderColor = System.Drawing.Color.Black;
            this.xrEmployeeNameHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrEmployeeNameHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrEmployeeNameHeader.BorderWidth = 1F;
            this.xrEmployeeNameHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrEmployeeNameHeader.ForeColor = System.Drawing.Color.Black;
            this.xrEmployeeNameHeader.LocationFloat = new DevExpress.Utils.PointFloat(118.6812F, 83.83336F);
            this.xrEmployeeNameHeader.Name = "xrEmployeeNameHeader";
            this.xrEmployeeNameHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrEmployeeNameHeader.SizeF = new System.Drawing.SizeF(313.8723F, 19.99997F);
            this.xrEmployeeNameHeader.StylePriority.UseBackColor = false;
            this.xrEmployeeNameHeader.StylePriority.UseBorderColor = false;
            this.xrEmployeeNameHeader.StylePriority.UseBorderDashStyle = false;
            this.xrEmployeeNameHeader.StylePriority.UseBorders = false;
            this.xrEmployeeNameHeader.StylePriority.UseBorderWidth = false;
            this.xrEmployeeNameHeader.StylePriority.UseFont = false;
            this.xrEmployeeNameHeader.StylePriority.UseForeColor = false;
            this.xrEmployeeNameHeader.StylePriority.UsePadding = false;
            this.xrEmployeeNameHeader.StylePriority.UseTextAlignment = false;
            this.xrEmployeeNameHeader.Text = "Ikhsan";
            this.xrEmployeeNameHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrEmployeeNameHeader.TextFormatString = "{0:HH:mm}";
            // 
            // xrVehicleHeader
            // 
            this.xrVehicleHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrVehicleHeader.BorderColor = System.Drawing.Color.Black;
            this.xrVehicleHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrVehicleHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrVehicleHeader.BorderWidth = 1F;
            this.xrVehicleHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrVehicleHeader.ForeColor = System.Drawing.Color.Black;
            this.xrVehicleHeader.LocationFloat = new DevExpress.Utils.PointFloat(118.6812F, 103.8333F);
            this.xrVehicleHeader.Name = "xrVehicleHeader";
            this.xrVehicleHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrVehicleHeader.SizeF = new System.Drawing.SizeF(313.8723F, 19.99998F);
            this.xrVehicleHeader.StylePriority.UseBackColor = false;
            this.xrVehicleHeader.StylePriority.UseBorderColor = false;
            this.xrVehicleHeader.StylePriority.UseBorderDashStyle = false;
            this.xrVehicleHeader.StylePriority.UseBorders = false;
            this.xrVehicleHeader.StylePriority.UseBorderWidth = false;
            this.xrVehicleHeader.StylePriority.UseFont = false;
            this.xrVehicleHeader.StylePriority.UseForeColor = false;
            this.xrVehicleHeader.StylePriority.UsePadding = false;
            this.xrVehicleHeader.StylePriority.UseTextAlignment = false;
            this.xrVehicleHeader.Text = "Avanza";
            this.xrVehicleHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrVehicleHeader.TextFormatString = "{0:HH:mm}";
            // 
            // xrCaptionVehicleHeader
            // 
            this.xrCaptionVehicleHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionVehicleHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionVehicleHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionVehicleHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionVehicleHeader.BorderWidth = 1F;
            this.xrCaptionVehicleHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionVehicleHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionVehicleHeader.LocationFloat = new DevExpress.Utils.PointFloat(9.999996F, 103.8333F);
            this.xrCaptionVehicleHeader.Name = "xrCaptionVehicleHeader";
            this.xrCaptionVehicleHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionVehicleHeader.SizeF = new System.Drawing.SizeF(108.6812F, 19.99998F);
            this.xrCaptionVehicleHeader.StylePriority.UseBackColor = false;
            this.xrCaptionVehicleHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionVehicleHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionVehicleHeader.StylePriority.UseBorders = false;
            this.xrCaptionVehicleHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionVehicleHeader.StylePriority.UseFont = false;
            this.xrCaptionVehicleHeader.StylePriority.UseForeColor = false;
            this.xrCaptionVehicleHeader.StylePriority.UsePadding = false;
            this.xrCaptionVehicleHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionVehicleHeader.Text = "UNIT";
            this.xrCaptionVehicleHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrCaptionPriceHeader
            // 
            this.xrCaptionPriceHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionPriceHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionPriceHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionPriceHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionPriceHeader.BorderWidth = 1F;
            this.xrCaptionPriceHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionPriceHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionPriceHeader.LocationFloat = new DevExpress.Utils.PointFloat(655.3129F, 143.8335F);
            this.xrCaptionPriceHeader.Name = "xrCaptionPriceHeader";
            this.xrCaptionPriceHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionPriceHeader.SizeF = new System.Drawing.SizeF(97.27274F, 20F);
            this.xrCaptionPriceHeader.StylePriority.UseBackColor = false;
            this.xrCaptionPriceHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionPriceHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionPriceHeader.StylePriority.UseBorders = false;
            this.xrCaptionPriceHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionPriceHeader.StylePriority.UseFont = false;
            this.xrCaptionPriceHeader.StylePriority.UseForeColor = false;
            this.xrCaptionPriceHeader.StylePriority.UsePadding = false;
            this.xrCaptionPriceHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionPriceHeader.Text = "HARGA";
            this.xrCaptionPriceHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTotalPriceHeader
            // 
            this.xrTotalPriceHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrTotalPriceHeader.BorderColor = System.Drawing.Color.Black;
            this.xrTotalPriceHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrTotalPriceHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTotalPriceHeader.BorderWidth = 1F;
            this.xrTotalPriceHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTotalPriceHeader.ForeColor = System.Drawing.Color.Black;
            this.xrTotalPriceHeader.LocationFloat = new DevExpress.Utils.PointFloat(752.5859F, 143.8335F);
            this.xrTotalPriceHeader.Name = "xrTotalPriceHeader";
            this.xrTotalPriceHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTotalPriceHeader.SizeF = new System.Drawing.SizeF(306.4136F, 20F);
            this.xrTotalPriceHeader.StylePriority.UseBackColor = false;
            this.xrTotalPriceHeader.StylePriority.UseBorderColor = false;
            this.xrTotalPriceHeader.StylePriority.UseBorderDashStyle = false;
            this.xrTotalPriceHeader.StylePriority.UseBorders = false;
            this.xrTotalPriceHeader.StylePriority.UseBorderWidth = false;
            this.xrTotalPriceHeader.StylePriority.UseFont = false;
            this.xrTotalPriceHeader.StylePriority.UseForeColor = false;
            this.xrTotalPriceHeader.StylePriority.UsePadding = false;
            this.xrTotalPriceHeader.StylePriority.UseTextAlignment = false;
            this.xrTotalPriceHeader.Text = "Rp. 00";
            this.xrTotalPriceHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTotalPriceHeader.TextFormatString = "{0:#.00}";
            // 
            // xrDurationHeader
            // 
            this.xrDurationHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrDurationHeader.BorderColor = System.Drawing.Color.Black;
            this.xrDurationHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrDurationHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrDurationHeader.BorderWidth = 1F;
            this.xrDurationHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrDurationHeader.ForeColor = System.Drawing.Color.Black;
            this.xrDurationHeader.LocationFloat = new DevExpress.Utils.PointFloat(118.6812F, 163.8333F);
            this.xrDurationHeader.Name = "xrDurationHeader";
            this.xrDurationHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrDurationHeader.SizeF = new System.Drawing.SizeF(313.8723F, 19.99997F);
            this.xrDurationHeader.StylePriority.UseBackColor = false;
            this.xrDurationHeader.StylePriority.UseBorderColor = false;
            this.xrDurationHeader.StylePriority.UseBorderDashStyle = false;
            this.xrDurationHeader.StylePriority.UseBorders = false;
            this.xrDurationHeader.StylePriority.UseBorderWidth = false;
            this.xrDurationHeader.StylePriority.UseFont = false;
            this.xrDurationHeader.StylePriority.UseForeColor = false;
            this.xrDurationHeader.StylePriority.UsePadding = false;
            this.xrDurationHeader.StylePriority.UseTextAlignment = false;
            this.xrDurationHeader.Text = "9 Jam";
            this.xrDurationHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrDurationHeader.TextFormatString = "{0:HH:mm}";
            // 
            // xrCaptionDurationHeader
            // 
            this.xrCaptionDurationHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionDurationHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionDurationHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionDurationHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionDurationHeader.BorderWidth = 1F;
            this.xrCaptionDurationHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionDurationHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionDurationHeader.LocationFloat = new DevExpress.Utils.PointFloat(9.999996F, 163.8333F);
            this.xrCaptionDurationHeader.Name = "xrCaptionDurationHeader";
            this.xrCaptionDurationHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionDurationHeader.SizeF = new System.Drawing.SizeF(108.6814F, 19.99997F);
            this.xrCaptionDurationHeader.StylePriority.UseBackColor = false;
            this.xrCaptionDurationHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionDurationHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionDurationHeader.StylePriority.UseBorders = false;
            this.xrCaptionDurationHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionDurationHeader.StylePriority.UseFont = false;
            this.xrCaptionDurationHeader.StylePriority.UseForeColor = false;
            this.xrCaptionDurationHeader.StylePriority.UsePadding = false;
            this.xrCaptionDurationHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionDurationHeader.Text = "DURASI";
            this.xrCaptionDurationHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrCaptionEndTimeHeader
            // 
            this.xrCaptionEndTimeHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionEndTimeHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionEndTimeHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionEndTimeHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionEndTimeHeader.BorderWidth = 1F;
            this.xrCaptionEndTimeHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionEndTimeHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionEndTimeHeader.LocationFloat = new DevExpress.Utils.PointFloat(9.999996F, 143.8333F);
            this.xrCaptionEndTimeHeader.Name = "xrCaptionEndTimeHeader";
            this.xrCaptionEndTimeHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionEndTimeHeader.SizeF = new System.Drawing.SizeF(108.6814F, 19.99997F);
            this.xrCaptionEndTimeHeader.StylePriority.UseBackColor = false;
            this.xrCaptionEndTimeHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionEndTimeHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionEndTimeHeader.StylePriority.UseBorders = false;
            this.xrCaptionEndTimeHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionEndTimeHeader.StylePriority.UseFont = false;
            this.xrCaptionEndTimeHeader.StylePriority.UseForeColor = false;
            this.xrCaptionEndTimeHeader.StylePriority.UsePadding = false;
            this.xrCaptionEndTimeHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionEndTimeHeader.Text = "JAM SAMPAI";
            this.xrCaptionEndTimeHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrEndTimeHeader
            // 
            this.xrEndTimeHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrEndTimeHeader.BorderColor = System.Drawing.Color.Black;
            this.xrEndTimeHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrEndTimeHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrEndTimeHeader.BorderWidth = 1F;
            this.xrEndTimeHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrEndTimeHeader.ForeColor = System.Drawing.Color.Black;
            this.xrEndTimeHeader.LocationFloat = new DevExpress.Utils.PointFloat(118.6812F, 143.8333F);
            this.xrEndTimeHeader.Name = "xrEndTimeHeader";
            this.xrEndTimeHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrEndTimeHeader.SizeF = new System.Drawing.SizeF(313.8723F, 19.99997F);
            this.xrEndTimeHeader.StylePriority.UseBackColor = false;
            this.xrEndTimeHeader.StylePriority.UseBorderColor = false;
            this.xrEndTimeHeader.StylePriority.UseBorderDashStyle = false;
            this.xrEndTimeHeader.StylePriority.UseBorders = false;
            this.xrEndTimeHeader.StylePriority.UseBorderWidth = false;
            this.xrEndTimeHeader.StylePriority.UseFont = false;
            this.xrEndTimeHeader.StylePriority.UseForeColor = false;
            this.xrEndTimeHeader.StylePriority.UsePadding = false;
            this.xrEndTimeHeader.StylePriority.UseTextAlignment = false;
            this.xrEndTimeHeader.Text = "08:00";
            this.xrEndTimeHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrEndTimeHeader.TextFormatString = "{0:HH:mm}";
            // 
            // xrCaptionRuteAkhirHeader
            // 
            this.xrCaptionRuteAkhirHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionRuteAkhirHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionRuteAkhirHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionRuteAkhirHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionRuteAkhirHeader.BorderWidth = 1F;
            this.xrCaptionRuteAkhirHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionRuteAkhirHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionRuteAkhirHeader.LocationFloat = new DevExpress.Utils.PointFloat(655.3132F, 83.83337F);
            this.xrCaptionRuteAkhirHeader.Name = "xrCaptionRuteAkhirHeader";
            this.xrCaptionRuteAkhirHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionRuteAkhirHeader.SizeF = new System.Drawing.SizeF(97.27274F, 20F);
            this.xrCaptionRuteAkhirHeader.StylePriority.UseBackColor = false;
            this.xrCaptionRuteAkhirHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionRuteAkhirHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionRuteAkhirHeader.StylePriority.UseBorders = false;
            this.xrCaptionRuteAkhirHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionRuteAkhirHeader.StylePriority.UseFont = false;
            this.xrCaptionRuteAkhirHeader.StylePriority.UseForeColor = false;
            this.xrCaptionRuteAkhirHeader.StylePriority.UsePadding = false;
            this.xrCaptionRuteAkhirHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionRuteAkhirHeader.Text = "KOTA TUJUAN";
            this.xrCaptionRuteAkhirHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrRuteAkhirHeader
            // 
            this.xrRuteAkhirHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrRuteAkhirHeader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrRuteAkhirHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrRuteAkhirHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrRuteAkhirHeader.BorderWidth = 1F;
            this.xrRuteAkhirHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrRuteAkhirHeader.ForeColor = System.Drawing.Color.Black;
            this.xrRuteAkhirHeader.LocationFloat = new DevExpress.Utils.PointFloat(752.5859F, 83.83337F);
            this.xrRuteAkhirHeader.Name = "xrRuteAkhirHeader";
            this.xrRuteAkhirHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrRuteAkhirHeader.SizeF = new System.Drawing.SizeF(306.414F, 19.99999F);
            this.xrRuteAkhirHeader.StylePriority.UseBackColor = false;
            this.xrRuteAkhirHeader.StylePriority.UseBorderColor = false;
            this.xrRuteAkhirHeader.StylePriority.UseBorderDashStyle = false;
            this.xrRuteAkhirHeader.StylePriority.UseBorders = false;
            this.xrRuteAkhirHeader.StylePriority.UseBorderWidth = false;
            this.xrRuteAkhirHeader.StylePriority.UseFont = false;
            this.xrRuteAkhirHeader.StylePriority.UseForeColor = false;
            this.xrRuteAkhirHeader.StylePriority.UsePadding = false;
            this.xrRuteAkhirHeader.StylePriority.UseTextAlignment = false;
            this.xrRuteAkhirHeader.Text = "Jakarta - Bandung";
            this.xrRuteAkhirHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrRuteAwalHeader
            // 
            this.xrRuteAwalHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrRuteAwalHeader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrRuteAwalHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrRuteAwalHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrRuteAwalHeader.BorderWidth = 1F;
            this.xrRuteAwalHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrRuteAwalHeader.ForeColor = System.Drawing.Color.Black;
            this.xrRuteAwalHeader.LocationFloat = new DevExpress.Utils.PointFloat(752.5863F, 63.83337F);
            this.xrRuteAwalHeader.Name = "xrRuteAwalHeader";
            this.xrRuteAwalHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrRuteAwalHeader.SizeF = new System.Drawing.SizeF(306.414F, 20F);
            this.xrRuteAwalHeader.StylePriority.UseBackColor = false;
            this.xrRuteAwalHeader.StylePriority.UseBorderColor = false;
            this.xrRuteAwalHeader.StylePriority.UseBorderDashStyle = false;
            this.xrRuteAwalHeader.StylePriority.UseBorders = false;
            this.xrRuteAwalHeader.StylePriority.UseBorderWidth = false;
            this.xrRuteAwalHeader.StylePriority.UseFont = false;
            this.xrRuteAwalHeader.StylePriority.UseForeColor = false;
            this.xrRuteAwalHeader.StylePriority.UsePadding = false;
            this.xrRuteAwalHeader.StylePriority.UseTextAlignment = false;
            this.xrRuteAwalHeader.Text = "Jakarta - Bandung";
            this.xrRuteAwalHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrCaptionRuteAwalHeader
            // 
            this.xrCaptionRuteAwalHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionRuteAwalHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionRuteAwalHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionRuteAwalHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionRuteAwalHeader.BorderWidth = 1F;
            this.xrCaptionRuteAwalHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionRuteAwalHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionRuteAwalHeader.LocationFloat = new DevExpress.Utils.PointFloat(655.3135F, 63.83339F);
            this.xrCaptionRuteAwalHeader.Name = "xrCaptionRuteAwalHeader";
            this.xrCaptionRuteAwalHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionRuteAwalHeader.SizeF = new System.Drawing.SizeF(97.27274F, 20F);
            this.xrCaptionRuteAwalHeader.StylePriority.UseBackColor = false;
            this.xrCaptionRuteAwalHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionRuteAwalHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionRuteAwalHeader.StylePriority.UseBorders = false;
            this.xrCaptionRuteAwalHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionRuteAwalHeader.StylePriority.UseFont = false;
            this.xrCaptionRuteAwalHeader.StylePriority.UseForeColor = false;
            this.xrCaptionRuteAwalHeader.StylePriority.UsePadding = false;
            this.xrCaptionRuteAwalHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionRuteAwalHeader.Text = "KOTA AWAL";
            this.xrCaptionRuteAwalHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrDetailPenumpangCaption
            // 
            this.xrDetailPenumpangCaption.BackColor = System.Drawing.Color.Transparent;
            this.xrDetailPenumpangCaption.BorderColor = System.Drawing.Color.Black;
            this.xrDetailPenumpangCaption.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrDetailPenumpangCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrDetailPenumpangCaption.BorderWidth = 1F;
            this.xrDetailPenumpangCaption.CanShrink = true;
            this.xrDetailPenumpangCaption.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrDetailPenumpangCaption.ForeColor = System.Drawing.Color.Black;
            this.xrDetailPenumpangCaption.LocationFloat = new DevExpress.Utils.PointFloat(0F, 206.6817F);
            this.xrDetailPenumpangCaption.Name = "xrDetailPenumpangCaption";
            this.xrDetailPenumpangCaption.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 5, 0, 100F);
            this.xrDetailPenumpangCaption.SizeF = new System.Drawing.SizeF(250F, 23.29063F);
            this.xrDetailPenumpangCaption.StylePriority.UseBackColor = false;
            this.xrDetailPenumpangCaption.StylePriority.UseBorderColor = false;
            this.xrDetailPenumpangCaption.StylePriority.UseBorderDashStyle = false;
            this.xrDetailPenumpangCaption.StylePriority.UseBorders = false;
            this.xrDetailPenumpangCaption.StylePriority.UseBorderWidth = false;
            this.xrDetailPenumpangCaption.StylePriority.UseFont = false;
            this.xrDetailPenumpangCaption.StylePriority.UseForeColor = false;
            this.xrDetailPenumpangCaption.StylePriority.UsePadding = false;
            this.xrDetailPenumpangCaption.StylePriority.UseTextAlignment = false;
            this.xrDetailPenumpangCaption.Text = "Detail Transaksi Pemesanan Tiket";
            this.xrDetailPenumpangCaption.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrStartTimeHeader
            // 
            this.xrStartTimeHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrStartTimeHeader.BorderColor = System.Drawing.Color.Black;
            this.xrStartTimeHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrStartTimeHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrStartTimeHeader.BorderWidth = 1F;
            this.xrStartTimeHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrStartTimeHeader.ForeColor = System.Drawing.Color.Black;
            this.xrStartTimeHeader.LocationFloat = new DevExpress.Utils.PointFloat(118.6812F, 123.8333F);
            this.xrStartTimeHeader.Name = "xrStartTimeHeader";
            this.xrStartTimeHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrStartTimeHeader.SizeF = new System.Drawing.SizeF(313.8723F, 19.99998F);
            this.xrStartTimeHeader.StylePriority.UseBackColor = false;
            this.xrStartTimeHeader.StylePriority.UseBorderColor = false;
            this.xrStartTimeHeader.StylePriority.UseBorderDashStyle = false;
            this.xrStartTimeHeader.StylePriority.UseBorders = false;
            this.xrStartTimeHeader.StylePriority.UseBorderWidth = false;
            this.xrStartTimeHeader.StylePriority.UseFont = false;
            this.xrStartTimeHeader.StylePriority.UseForeColor = false;
            this.xrStartTimeHeader.StylePriority.UsePadding = false;
            this.xrStartTimeHeader.StylePriority.UseTextAlignment = false;
            this.xrStartTimeHeader.Text = "08:00";
            this.xrStartTimeHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrStartTimeHeader.TextFormatString = "{0:HH:mm}";
            // 
            // xrCaptionStartTimeHeader
            // 
            this.xrCaptionStartTimeHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionStartTimeHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionStartTimeHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionStartTimeHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionStartTimeHeader.BorderWidth = 1F;
            this.xrCaptionStartTimeHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionStartTimeHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionStartTimeHeader.LocationFloat = new DevExpress.Utils.PointFloat(9.999996F, 123.8333F);
            this.xrCaptionStartTimeHeader.Name = "xrCaptionStartTimeHeader";
            this.xrCaptionStartTimeHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionStartTimeHeader.SizeF = new System.Drawing.SizeF(108.6814F, 19.99998F);
            this.xrCaptionStartTimeHeader.StylePriority.UseBackColor = false;
            this.xrCaptionStartTimeHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionStartTimeHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionStartTimeHeader.StylePriority.UseBorders = false;
            this.xrCaptionStartTimeHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionStartTimeHeader.StylePriority.UseFont = false;
            this.xrCaptionStartTimeHeader.StylePriority.UseForeColor = false;
            this.xrCaptionStartTimeHeader.StylePriority.UsePadding = false;
            this.xrCaptionStartTimeHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionStartTimeHeader.Text = "JAM BERANGKAT";
            this.xrCaptionStartTimeHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrCaptionDocumentNumberHeader
            // 
            this.xrCaptionDocumentNumberHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionDocumentNumberHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionDocumentNumberHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionDocumentNumberHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionDocumentNumberHeader.BorderWidth = 1F;
            this.xrCaptionDocumentNumberHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionDocumentNumberHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionDocumentNumberHeader.LocationFloat = new DevExpress.Utils.PointFloat(655.3135F, 103.8334F);
            this.xrCaptionDocumentNumberHeader.Name = "xrCaptionDocumentNumberHeader";
            this.xrCaptionDocumentNumberHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionDocumentNumberHeader.SizeF = new System.Drawing.SizeF(97.27274F, 19.99999F);
            this.xrCaptionDocumentNumberHeader.StylePriority.UseBackColor = false;
            this.xrCaptionDocumentNumberHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionDocumentNumberHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionDocumentNumberHeader.StylePriority.UseBorders = false;
            this.xrCaptionDocumentNumberHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionDocumentNumberHeader.StylePriority.UseFont = false;
            this.xrCaptionDocumentNumberHeader.StylePriority.UseForeColor = false;
            this.xrCaptionDocumentNumberHeader.StylePriority.UsePadding = false;
            this.xrCaptionDocumentNumberHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionDocumentNumberHeader.Text = "NOMOR SURAT";
            this.xrCaptionDocumentNumberHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // companyLogo
            // 
            this.companyLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft;
            this.companyLogo.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("companyLogo.ImageSource"));
            this.companyLogo.LocationFloat = new DevExpress.Utils.PointFloat(10.00002F, 10.00002F);
            this.companyLogo.Name = "companyLogo";
            this.companyLogo.SizeF = new System.Drawing.SizeF(250F, 73.83331F);
            this.companyLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            this.companyLogo.StylePriority.UseBorderColor = false;
            this.companyLogo.StylePriority.UseBorders = false;
            this.companyLogo.StylePriority.UsePadding = false;
            // 
            // xrETicket
            // 
            this.xrETicket.BackColor = System.Drawing.Color.Transparent;
            this.xrETicket.BorderColor = System.Drawing.Color.LightGray;
            this.xrETicket.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrETicket.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrETicket.BorderWidth = 5F;
            this.xrETicket.Font = new DevExpress.Drawing.DXFont("Segoe UI", 32F);
            this.xrETicket.ForeColor = System.Drawing.Color.Black;
            this.xrETicket.LocationFloat = new DevExpress.Utils.PointFloat(655.3136F, 9.999978F);
            this.xrETicket.Name = "xrETicket";
            this.xrETicket.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrETicket.SizeF = new System.Drawing.SizeF(403.6863F, 53.83339F);
            this.xrETicket.StylePriority.UseBackColor = false;
            this.xrETicket.StylePriority.UseBorderColor = false;
            this.xrETicket.StylePriority.UseBorderDashStyle = false;
            this.xrETicket.StylePriority.UseBorders = false;
            this.xrETicket.StylePriority.UseBorderWidth = false;
            this.xrETicket.StylePriority.UseFont = false;
            this.xrETicket.StylePriority.UseForeColor = false;
            this.xrETicket.StylePriority.UsePadding = false;
            this.xrETicket.StylePriority.UseTextAlignment = false;
            this.xrETicket.Text = "E-SPJ";
            this.xrETicket.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrCaptionDateHeader
            // 
            this.xrCaptionDateHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrCaptionDateHeader.BorderColor = System.Drawing.Color.Black;
            this.xrCaptionDateHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCaptionDateHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCaptionDateHeader.BorderWidth = 1F;
            this.xrCaptionDateHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8.25F);
            this.xrCaptionDateHeader.ForeColor = System.Drawing.Color.Gray;
            this.xrCaptionDateHeader.LocationFloat = new DevExpress.Utils.PointFloat(655.3135F, 123.8334F);
            this.xrCaptionDateHeader.Name = "xrCaptionDateHeader";
            this.xrCaptionDateHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrCaptionDateHeader.SizeF = new System.Drawing.SizeF(97.27274F, 20F);
            this.xrCaptionDateHeader.StylePriority.UseBackColor = false;
            this.xrCaptionDateHeader.StylePriority.UseBorderColor = false;
            this.xrCaptionDateHeader.StylePriority.UseBorderDashStyle = false;
            this.xrCaptionDateHeader.StylePriority.UseBorders = false;
            this.xrCaptionDateHeader.StylePriority.UseBorderWidth = false;
            this.xrCaptionDateHeader.StylePriority.UseFont = false;
            this.xrCaptionDateHeader.StylePriority.UseForeColor = false;
            this.xrCaptionDateHeader.StylePriority.UsePadding = false;
            this.xrCaptionDateHeader.StylePriority.UseTextAlignment = false;
            this.xrCaptionDateHeader.Text = "TANGGAL";
            this.xrCaptionDateHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrDateHeader
            // 
            this.xrDateHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrDateHeader.BorderColor = System.Drawing.Color.Black;
            this.xrDateHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrDateHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrDateHeader.BorderWidth = 1F;
            this.xrDateHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrDateHeader.ForeColor = System.Drawing.Color.Black;
            this.xrDateHeader.LocationFloat = new DevExpress.Utils.PointFloat(752.5866F, 123.8334F);
            this.xrDateHeader.Name = "xrDateHeader";
            this.xrDateHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrDateHeader.SizeF = new System.Drawing.SizeF(306.4137F, 20F);
            this.xrDateHeader.StylePriority.UseBackColor = false;
            this.xrDateHeader.StylePriority.UseBorderColor = false;
            this.xrDateHeader.StylePriority.UseBorderDashStyle = false;
            this.xrDateHeader.StylePriority.UseBorders = false;
            this.xrDateHeader.StylePriority.UseBorderWidth = false;
            this.xrDateHeader.StylePriority.UseFont = false;
            this.xrDateHeader.StylePriority.UseForeColor = false;
            this.xrDateHeader.StylePriority.UsePadding = false;
            this.xrDateHeader.StylePriority.UseTextAlignment = false;
            this.xrDateHeader.Text = "19 Jun 2017";
            this.xrDateHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrDateHeader.TextFormatString = "{0:dd MMM yyyy}";
            // 
            // xrDocumentNumberHeader
            // 
            this.xrDocumentNumberHeader.BackColor = System.Drawing.Color.Transparent;
            this.xrDocumentNumberHeader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrDocumentNumberHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrDocumentNumberHeader.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrDocumentNumberHeader.BorderWidth = 1F;
            this.xrDocumentNumberHeader.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrDocumentNumberHeader.ForeColor = System.Drawing.Color.Black;
            this.xrDocumentNumberHeader.LocationFloat = new DevExpress.Utils.PointFloat(752.5863F, 103.8334F);
            this.xrDocumentNumberHeader.Name = "xrDocumentNumberHeader";
            this.xrDocumentNumberHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrDocumentNumberHeader.SizeF = new System.Drawing.SizeF(306.4139F, 19.99998F);
            this.xrDocumentNumberHeader.StylePriority.UseBackColor = false;
            this.xrDocumentNumberHeader.StylePriority.UseBorderColor = false;
            this.xrDocumentNumberHeader.StylePriority.UseBorderDashStyle = false;
            this.xrDocumentNumberHeader.StylePriority.UseBorders = false;
            this.xrDocumentNumberHeader.StylePriority.UseBorderWidth = false;
            this.xrDocumentNumberHeader.StylePriority.UseFont = false;
            this.xrDocumentNumberHeader.StylePriority.UseForeColor = false;
            this.xrDocumentNumberHeader.StylePriority.UsePadding = false;
            this.xrDocumentNumberHeader.StylePriority.UseTextAlignment = false;
            this.xrDocumentNumberHeader.Text = "000001";
            this.xrDocumentNumberHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // baseControlStyle
            // 
            this.baseControlStyle.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F);
            this.baseControlStyle.Name = "baseControlStyle";
            this.baseControlStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // evenDetailStyle
            // 
            this.evenDetailStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(234)))));
            this.evenDetailStyle.Name = "evenDetailStyle";
            this.evenDetailStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // oddDetailStyle
            // 
            this.oddDetailStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.oddDetailStyle.Name = "oddDetailStyle";
            this.oddDetailStyle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // GroupFooter
            // 
            this.GroupFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel11,
            this.xrEmployeeNameFooter,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrPickupAddress});
            this.GroupFooter.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter.HeightF = 137.1792F;
            this.GroupFooter.KeepTogether = true;
            this.GroupFooter.Name = "GroupFooter";
            this.GroupFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBandExceptLastEntry;
            this.GroupFooter.StyleName = "baseControlStyle";
            // 
            // xrLabel11
            // 
            this.xrLabel11.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrLabel11.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.BorderWidth = 1F;
            this.xrLabel11.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(826.11F, 102.6145F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(209.4468F, 20F);
            this.xrLabel11.StylePriority.UseBackColor = false;
            this.xrLabel11.StylePriority.UseBorderColor = false;
            this.xrLabel11.StylePriority.UseBorderDashStyle = false;
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseBorderWidth = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "(                                           )";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrEmployeeNameFooter
            // 
            this.xrEmployeeNameFooter.BackColor = System.Drawing.Color.Transparent;
            this.xrEmployeeNameFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrEmployeeNameFooter.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrEmployeeNameFooter.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrEmployeeNameFooter.BorderWidth = 1F;
            this.xrEmployeeNameFooter.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrEmployeeNameFooter.ForeColor = System.Drawing.Color.Black;
            this.xrEmployeeNameFooter.LocationFloat = new DevExpress.Utils.PointFloat(16.62547F, 102.6145F);
            this.xrEmployeeNameFooter.Name = "xrEmployeeNameFooter";
            this.xrEmployeeNameFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrEmployeeNameFooter.SizeF = new System.Drawing.SizeF(209.4468F, 20F);
            this.xrEmployeeNameFooter.StylePriority.UseBackColor = false;
            this.xrEmployeeNameFooter.StylePriority.UseBorderColor = false;
            this.xrEmployeeNameFooter.StylePriority.UseBorderDashStyle = false;
            this.xrEmployeeNameFooter.StylePriority.UseBorders = false;
            this.xrEmployeeNameFooter.StylePriority.UseBorderWidth = false;
            this.xrEmployeeNameFooter.StylePriority.UseFont = false;
            this.xrEmployeeNameFooter.StylePriority.UseForeColor = false;
            this.xrEmployeeNameFooter.StylePriority.UsePadding = false;
            this.xrEmployeeNameFooter.StylePriority.UseTextAlignment = false;
            this.xrEmployeeNameFooter.Text = "(                                           )";
            this.xrEmployeeNameFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrLabel9.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel9.BorderWidth = 1F;
            this.xrLabel9.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(430.2765F, 102.6145F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(209.4468F, 20F);
            this.xrLabel9.StylePriority.UseBackColor = false;
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseBorderDashStyle = false;
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseBorderWidth = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "(                                           )";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrLabel8.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.BorderWidth = 1F;
            this.xrLabel8.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(826.11F, 9.99999F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(209.4468F, 20F);
            this.xrLabel8.StylePriority.UseBackColor = false;
            this.xrLabel8.StylePriority.UseBorderColor = false;
            this.xrLabel8.StylePriority.UseBorderDashStyle = false;
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseBorderWidth = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseForeColor = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "MANAJER KEUANGAN";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrLabel7.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel7.BorderWidth = 1F;
            this.xrLabel7.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(16.62547F, 9.99999F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(209.4468F, 20F);
            this.xrLabel7.StylePriority.UseBackColor = false;
            this.xrLabel7.StylePriority.UseBorderColor = false;
            this.xrLabel7.StylePriority.UseBorderDashStyle = false;
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseBorderWidth = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseForeColor = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "PENGEMUDI";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPickupAddress
            // 
            this.xrPickupAddress.BackColor = System.Drawing.Color.Transparent;
            this.xrPickupAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrPickupAddress.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrPickupAddress.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPickupAddress.BorderWidth = 1F;
            this.xrPickupAddress.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrPickupAddress.ForeColor = System.Drawing.Color.Black;
            this.xrPickupAddress.LocationFloat = new DevExpress.Utils.PointFloat(430.2765F, 9.99999F);
            this.xrPickupAddress.Name = "xrPickupAddress";
            this.xrPickupAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPickupAddress.SizeF = new System.Drawing.SizeF(209.4468F, 20F);
            this.xrPickupAddress.StylePriority.UseBackColor = false;
            this.xrPickupAddress.StylePriority.UseBorderColor = false;
            this.xrPickupAddress.StylePriority.UseBorderDashStyle = false;
            this.xrPickupAddress.StylePriority.UseBorders = false;
            this.xrPickupAddress.StylePriority.UseBorderWidth = false;
            this.xrPickupAddress.StylePriority.UseFont = false;
            this.xrPickupAddress.StylePriority.UseForeColor = false;
            this.xrPickupAddress.StylePriority.UsePadding = false;
            this.xrPickupAddress.StylePriority.UseTextAlignment = false;
            this.xrPickupAddress.Text = "MANAJER LAPANGAN";
            this.xrPickupAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // rptESPJTripSchedule
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader,
            this.GroupFooter});
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(50F, 50F, 50F, 140F);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.baseControlStyle,
            this.evenDetailStyle,
            this.oddDetailStyle});
            this.Version = "22.2";
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        public DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        public DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        public DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader;
        public DevExpress.XtraReports.UI.XRPictureBox companyLogo;
        public DevExpress.XtraReports.UI.XRLabel xrETicket;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionDateHeader;
        public DevExpress.XtraReports.UI.XRLabel xrDateHeader;
        public DevExpress.XtraReports.UI.XRLabel xrDocumentNumberHeader;
        private DevExpress.XtraReports.UI.XRControlStyle baseControlStyle;
        private DevExpress.XtraReports.UI.XRControlStyle evenDetailStyle;
        private DevExpress.XtraReports.UI.XRControlStyle oddDetailStyle;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionDocumentNumberHeader;
        public DevExpress.XtraReports.UI.XRLabel xrStartTimeHeader;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionStartTimeHeader;
        public DevExpress.XtraReports.UI.XRTable detailTable;
        public DevExpress.XtraReports.UI.XRTableRow detailTableRow1;
        public DevExpress.XtraReports.UI.XRTableCell passengerName;
        private DevExpress.XtraReports.UI.XRTableCell passengerPhoneNumber;
        public DevExpress.XtraReports.UI.XRTableCell passengerPrice;
        public DevExpress.XtraReports.UI.XRLabel xrUsernameCaption;
        public DevExpress.XtraReports.UI.XRLabel xrUsername;
        public DevExpress.XtraReports.UI.GroupFooterBand GroupFooter;
        public DevExpress.XtraReports.UI.XRLabel xrDate;
        public DevExpress.XtraReports.UI.XRLabel xrDateCaption;
        public DevExpress.XtraReports.UI.XRLabel xrDetailPenumpangCaption;
        public DevExpress.XtraReports.UI.XRLabel xrRuteAwalHeader;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionRuteAwalHeader;
        public DevExpress.XtraReports.UI.XRLabel xrPickupAddress;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionRuteAkhirHeader;
        public DevExpress.XtraReports.UI.XRLabel xrRuteAkhirHeader;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionEndTimeHeader;
        public DevExpress.XtraReports.UI.XRLabel xrEndTimeHeader;
        public DevExpress.XtraReports.UI.XRLabel xrDurationHeader;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionDurationHeader;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionPriceHeader;
        public DevExpress.XtraReports.UI.XRLabel xrTotalPriceHeader;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionEmployeeNameHeader;
        public DevExpress.XtraReports.UI.XRLabel xrEmployeeNameHeader;
        public DevExpress.XtraReports.UI.XRLabel xrVehicleHeader;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionVehicleHeader;
        public DevExpress.XtraReports.UI.XRLabel xrLabel7;
        public DevExpress.XtraReports.UI.XRLabel xrLabel8;
        public DevExpress.XtraReports.UI.XRLabel xrLabel9;
        public DevExpress.XtraReports.UI.XRLabel xrLabel11;
        public DevExpress.XtraReports.UI.XRLabel xrEmployeeNameFooter;
        public DevExpress.XtraReports.UI.XRLabel xrCaptionTotalTicketHeader;
        public DevExpress.XtraReports.UI.XRLabel xrTotalTicketHeader;
    }
}
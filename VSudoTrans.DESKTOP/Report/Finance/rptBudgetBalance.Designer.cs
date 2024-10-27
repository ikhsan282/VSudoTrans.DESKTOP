namespace VSudoTrans.DESKTOP.Report.Finance
{
    partial class rptBudgetBalance
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
            DevExpress.XtraReports.UI.XRWatermark xrWatermark1 = new DevExpress.XtraReports.UI.XRWatermark();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTransactionDate = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCategory = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPenerimaan = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPengeluaran = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrSaldo = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrPrintTime = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPrintDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrHeader2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCompanyName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrCaptionNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrHeader1 = new DevExpress.XtraReports.UI.XRLabel();
            this.baseControlStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.evenDetailStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.oddDetailStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupFooter = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 25F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "baseControlStyle";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(727.0001F, 25F);
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrNo,
            this.xrTransactionDate,
            this.xrCategory,
            this.xrPenerimaan,
            this.xrPengeluaran,
            this.xrSaldo});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrNo
            // 
            this.xrNo.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DataSource.CurrentRowIndex] + 1 + \'.\'\n")});
            this.xrNo.Multiline = true;
            this.xrNo.Name = "xrNo";
            this.xrNo.Text = "xrNo";
            this.xrNo.Weight = 0.65147136989148524D;
            // 
            // xrTransactionDate
            // 
            this.xrTransactionDate.Multiline = true;
            this.xrTransactionDate.Name = "xrTransactionDate";
            this.xrTransactionDate.StylePriority.UseTextAlignment = false;
            this.xrTransactionDate.Text = "xrTransactionDate";
            this.xrTransactionDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTransactionDate.Weight = 1.8797694758306061D;
            // 
            // xrCategory
            // 
            this.xrCategory.Multiline = true;
            this.xrCategory.Name = "xrCategory";
            this.xrCategory.StylePriority.UseTextAlignment = false;
            this.xrCategory.Text = "xrCategory";
            this.xrCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrCategory.Weight = 6.2584957826730987D;
            // 
            // xrPenerimaan
            // 
            this.xrPenerimaan.Multiline = true;
            this.xrPenerimaan.Name = "xrPenerimaan";
            this.xrPenerimaan.StylePriority.UseTextAlignment = false;
            this.xrPenerimaan.Text = "xrPenerimaan";
            this.xrPenerimaan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrPenerimaan.TextFormatString = "{0:N0}";
            this.xrPenerimaan.Weight = 2.3964688581742086D;
            // 
            // xrPengeluaran
            // 
            this.xrPengeluaran.Multiline = true;
            this.xrPengeluaran.Name = "xrPengeluaran";
            this.xrPengeluaran.StylePriority.UseTextAlignment = false;
            this.xrPengeluaran.Text = "xrPengeluaran";
            this.xrPengeluaran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrPengeluaran.TextFormatString = "{0:N0}";
            this.xrPengeluaran.Weight = 2.6057286895645451D;
            // 
            // xrSaldo
            // 
            this.xrSaldo.Multiline = true;
            this.xrSaldo.Name = "xrSaldo";
            this.xrSaldo.StylePriority.UseTextAlignment = false;
            this.xrSaldo.Text = "xrSaldo";
            this.xrSaldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrSaldo.TextFormatString = "{0:N0}";
            this.xrSaldo.Weight = 2.1788545048084105D;
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
            this.BottomMargin.HeightF = 50F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.StyleName = "baseControlStyle";
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader
            // 
            this.GroupHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPrintTime,
            this.xrPrintDate,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel12,
            this.xrLabel11,
            this.xrHeader2,
            this.xrTable4,
            this.xrCompanyName,
            this.xrTable2,
            this.xrHeader1});
            this.GroupHeader.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("InvoiceNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader.HeightF = 198.0833F;
            this.GroupHeader.Level = 1;
            this.GroupHeader.Name = "GroupHeader";
            this.GroupHeader.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry;
            this.GroupHeader.StyleName = "baseControlStyle";
            this.GroupHeader.StylePriority.UseBackColor = false;
            // 
            // xrPrintTime
            // 
            this.xrPrintTime.BackColor = System.Drawing.Color.Transparent;
            this.xrPrintTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrPrintTime.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrPrintTime.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPrintTime.BorderWidth = 1F;
            this.xrPrintTime.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.xrPrintTime.ForeColor = System.Drawing.Color.Black;
            this.xrPrintTime.LocationFloat = new DevExpress.Utils.PointFloat(123.708F, 125.941F);
            this.xrPrintTime.Name = "xrPrintTime";
            this.xrPrintTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPrintTime.SizeF = new System.Drawing.SizeF(136.297F, 19.99998F);
            this.xrPrintTime.StylePriority.UseBackColor = false;
            this.xrPrintTime.StylePriority.UseBorderColor = false;
            this.xrPrintTime.StylePriority.UseBorderDashStyle = false;
            this.xrPrintTime.StylePriority.UseBorders = false;
            this.xrPrintTime.StylePriority.UseBorderWidth = false;
            this.xrPrintTime.StylePriority.UseFont = false;
            this.xrPrintTime.StylePriority.UseForeColor = false;
            this.xrPrintTime.StylePriority.UsePadding = false;
            this.xrPrintTime.StylePriority.UseTextAlignment = false;
            this.xrPrintTime.Text = "18:43:25";
            this.xrPrintTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPrintDate
            // 
            this.xrPrintDate.BackColor = System.Drawing.Color.Transparent;
            this.xrPrintDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(203)))), ((int)(((byte)(200)))));
            this.xrPrintDate.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrPrintDate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPrintDate.BorderWidth = 1F;
            this.xrPrintDate.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.xrPrintDate.ForeColor = System.Drawing.Color.Black;
            this.xrPrintDate.LocationFloat = new DevExpress.Utils.PointFloat(123.7079F, 105.9411F);
            this.xrPrintDate.Name = "xrPrintDate";
            this.xrPrintDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPrintDate.SizeF = new System.Drawing.SizeF(136.297F, 19.99998F);
            this.xrPrintDate.StylePriority.UseBackColor = false;
            this.xrPrintDate.StylePriority.UseBorderColor = false;
            this.xrPrintDate.StylePriority.UseBorderDashStyle = false;
            this.xrPrintDate.StylePriority.UseBorders = false;
            this.xrPrintDate.StylePriority.UseBorderWidth = false;
            this.xrPrintDate.StylePriority.UseFont = false;
            this.xrPrintDate.StylePriority.UseForeColor = false;
            this.xrPrintDate.StylePriority.UsePadding = false;
            this.xrPrintDate.StylePriority.UseTextAlignment = false;
            this.xrPrintDate.Text = "10 Juli 2024";
            this.xrPrintDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel15.BorderColor = System.Drawing.Color.Black;
            this.xrLabel15.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel15.BorderWidth = 1F;
            this.xrLabel15.Font = new DevExpress.Drawing.DXFont("Arial", 7F);
            this.xrLabel15.ForeColor = System.Drawing.Color.Black;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(110F, 125.941F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(13.70787F, 19.99998F);
            this.xrLabel15.StylePriority.UseBackColor = false;
            this.xrLabel15.StylePriority.UseBorderColor = false;
            this.xrLabel15.StylePriority.UseBorderDashStyle = false;
            this.xrLabel15.StylePriority.UseBorders = false;
            this.xrLabel15.StylePriority.UseBorderWidth = false;
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseForeColor = false;
            this.xrLabel15.StylePriority.UsePadding = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = ":";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel14.BorderColor = System.Drawing.Color.Black;
            this.xrLabel14.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel14.BorderWidth = 1F;
            this.xrLabel14.Font = new DevExpress.Drawing.DXFont("Arial", 7F);
            this.xrLabel14.ForeColor = System.Drawing.Color.Black;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(110F, 105.941F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(13.70787F, 19.99998F);
            this.xrLabel14.StylePriority.UseBackColor = false;
            this.xrLabel14.StylePriority.UseBorderColor = false;
            this.xrLabel14.StylePriority.UseBorderDashStyle = false;
            this.xrLabel14.StylePriority.UseBorders = false;
            this.xrLabel14.StylePriority.UseBorderWidth = false;
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseForeColor = false;
            this.xrLabel14.StylePriority.UsePadding = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = ":";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel12.BorderColor = System.Drawing.Color.Black;
            this.xrLabel12.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel12.BorderWidth = 1F;
            this.xrLabel12.Font = new DevExpress.Drawing.DXFont("Arial", 7F);
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 125.9409F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(99.99996F, 20F);
            this.xrLabel12.StylePriority.UseBackColor = false;
            this.xrLabel12.StylePriority.UseBorderColor = false;
            this.xrLabel12.StylePriority.UseBorderDashStyle = false;
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseBorderWidth = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "JAM CETAK";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel11.BorderColor = System.Drawing.Color.Black;
            this.xrLabel11.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.BorderWidth = 1F;
            this.xrLabel11.Font = new DevExpress.Drawing.DXFont("Arial", 7F);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(9.999999F, 105.941F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(99.99999F, 20.00001F);
            this.xrLabel11.StylePriority.UseBackColor = false;
            this.xrLabel11.StylePriority.UseBorderColor = false;
            this.xrLabel11.StylePriority.UseBorderDashStyle = false;
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseBorderWidth = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "TANGGAL CETAK";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrHeader2
            // 
            this.xrHeader2.BackColor = System.Drawing.Color.Transparent;
            this.xrHeader2.BorderColor = System.Drawing.Color.Black;
            this.xrHeader2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrHeader2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrHeader2.BorderWidth = 1F;
            this.xrHeader2.CanShrink = true;
            this.xrHeader2.Font = new DevExpress.Drawing.DXFont("Arial", 7F);
            this.xrHeader2.ForeColor = System.Drawing.Color.Black;
            this.xrHeader2.LocationFloat = new DevExpress.Utils.PointFloat(135.5136F, 50.00002F);
            this.xrHeader2.Name = "xrHeader2";
            this.xrHeader2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrHeader2.SizeF = new System.Drawing.SizeF(461.1111F, 19.99999F);
            this.xrHeader2.StylePriority.UseBackColor = false;
            this.xrHeader2.StylePriority.UseBorderColor = false;
            this.xrHeader2.StylePriority.UseBorderDashStyle = false;
            this.xrHeader2.StylePriority.UseBorders = false;
            this.xrHeader2.StylePriority.UseBorderWidth = false;
            this.xrHeader2.StylePriority.UseFont = false;
            this.xrHeader2.StylePriority.UseForeColor = false;
            this.xrHeader2.StylePriority.UsePadding = false;
            this.xrHeader2.StylePriority.UseTextAlignment = false;
            this.xrHeader2.Text = "UNTUK SELAMA BULAN JULI 2024";
            this.xrHeader2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 70.00001F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(727F, 25F);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.BorderWidth = 1F;
            this.xrTableCell3.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseBorderWidth = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "RINCIAN KAS";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 2D;
            // 
            // xrCompanyName
            // 
            this.xrCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.xrCompanyName.BorderColor = System.Drawing.Color.Black;
            this.xrCompanyName.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrCompanyName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrCompanyName.BorderWidth = 1F;
            this.xrCompanyName.CanShrink = true;
            this.xrCompanyName.Font = new DevExpress.Drawing.DXFont("Segoe UI", 13F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrCompanyName.ForeColor = System.Drawing.Color.Black;
            this.xrCompanyName.LocationFloat = new DevExpress.Utils.PointFloat(200.9722F, 0F);
            this.xrCompanyName.Multiline = true;
            this.xrCompanyName.Name = "xrCompanyName";
            this.xrCompanyName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrCompanyName.SizeF = new System.Drawing.SizeF(326.6801F, 30F);
            this.xrCompanyName.StylePriority.UseBackColor = false;
            this.xrCompanyName.StylePriority.UseBorderColor = false;
            this.xrCompanyName.StylePriority.UseBorderDashStyle = false;
            this.xrCompanyName.StylePriority.UseBorders = false;
            this.xrCompanyName.StylePriority.UseBorderWidth = false;
            this.xrCompanyName.StylePriority.UseFont = false;
            this.xrCompanyName.StylePriority.UseForeColor = false;
            this.xrCompanyName.StylePriority.UsePadding = false;
            this.xrCompanyName.StylePriority.UseTextAlignment = false;
            this.xrCompanyName.Text = "SMK PANCAKARYA";
            this.xrCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.Transparent;
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.BorderWidth = 1F;
            this.xrTable2.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 159.8888F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(727.0001F, 38.19444F);
            this.xrTable2.StylePriority.UseBackColor = false;
            this.xrTable2.StylePriority.UseBorderColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseBorderWidth = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrCaptionNo,
            this.xrTableCell7,
            this.xrTableCell5,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell9});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrCaptionNo
            // 
            this.xrCaptionNo.Multiline = true;
            this.xrCaptionNo.Name = "xrCaptionNo";
            this.xrCaptionNo.Text = "No";
            this.xrCaptionNo.Weight = 1.3218452730192927D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Tanggal";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 3.8140802195649384D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "Keterangan";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell5.Weight = 12.698582986171106D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "Penerimaan";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell10.Weight = 4.8624712586311D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "Pengeluaran";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell11.Weight = 5.2111935867923806D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "Saldo";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 4.4967903768862749D;
            // 
            // xrHeader1
            // 
            this.xrHeader1.BackColor = System.Drawing.Color.Transparent;
            this.xrHeader1.BorderColor = System.Drawing.Color.Black;
            this.xrHeader1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrHeader1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrHeader1.BorderWidth = 1F;
            this.xrHeader1.CanShrink = true;
            this.xrHeader1.Font = new DevExpress.Drawing.DXFont("Segoe UI", 10F);
            this.xrHeader1.ForeColor = System.Drawing.Color.Black;
            this.xrHeader1.LocationFloat = new DevExpress.Utils.PointFloat(135.5136F, 30.00001F);
            this.xrHeader1.Name = "xrHeader1";
            this.xrHeader1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrHeader1.SizeF = new System.Drawing.SizeF(461.1111F, 20F);
            this.xrHeader1.StylePriority.UseBackColor = false;
            this.xrHeader1.StylePriority.UseBorderColor = false;
            this.xrHeader1.StylePriority.UseBorderDashStyle = false;
            this.xrHeader1.StylePriority.UseBorders = false;
            this.xrHeader1.StylePriority.UseBorderWidth = false;
            this.xrHeader1.StylePriority.UseFont = false;
            this.xrHeader1.StylePriority.UseForeColor = false;
            this.xrHeader1.StylePriority.UsePadding = false;
            this.xrHeader1.StylePriority.UseTextAlignment = false;
            this.xrHeader1.Text = "BUKU KAS";
            this.xrHeader1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            this.GroupFooter.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter.HeightF = 193.4423F;
            this.GroupFooter.KeepTogether = true;
            this.GroupFooter.Name = "GroupFooter";
            this.GroupFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            this.GroupFooter.StyleName = "baseControlStyle";
            // 
            // rptBudgetBalance
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader,
            this.GroupFooter});
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Margins = new DevExpress.Drawing.DXMargins(50F, 50F, 50F, 50F);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.baseControlStyle,
            this.evenDetailStyle,
            this.oddDetailStyle});
            this.Version = "23.2";
            xrWatermark1.Id = "Watermark1";
            this.Watermarks.Add(xrWatermark1);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        public DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        public DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        public DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader;
        public DevExpress.XtraReports.UI.XRLabel xrHeader1;
        public DevExpress.XtraReports.UI.GroupFooterBand GroupFooter;
        public DevExpress.XtraReports.UI.XRTable xrTable1;
        public DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        public DevExpress.XtraReports.UI.XRTableCell xrNo;
        public DevExpress.XtraReports.UI.XRTableCell xrCategory;
        public DevExpress.XtraReports.UI.XRTable xrTable2;
        public DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        public DevExpress.XtraReports.UI.XRTableCell xrCaptionNo;
        public DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        public DevExpress.XtraReports.UI.XRLabel xrCompanyName;
        public DevExpress.XtraReports.UI.XRTable xrTable4;
        public DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        public DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        public DevExpress.XtraReports.UI.XRLabel xrHeader2;
        public DevExpress.XtraReports.UI.XRLabel xrPrintTime;
        public DevExpress.XtraReports.UI.XRLabel xrPrintDate;
        public DevExpress.XtraReports.UI.XRLabel xrLabel15;
        public DevExpress.XtraReports.UI.XRLabel xrLabel14;
        public DevExpress.XtraReports.UI.XRLabel xrLabel12;
        public DevExpress.XtraReports.UI.XRLabel xrLabel11;
        public DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        public DevExpress.XtraReports.UI.XRTableCell xrTransactionDate;
        public DevExpress.XtraReports.UI.XRTableCell xrSaldo;
        public DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        public DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        public DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        public DevExpress.XtraReports.UI.XRTableCell xrPenerimaan;
        public DevExpress.XtraReports.UI.XRTableCell xrPengeluaran;
        private DevExpress.XtraReports.UI.XRControlStyle baseControlStyle;
        private DevExpress.XtraReports.UI.XRControlStyle evenDetailStyle;
        private DevExpress.XtraReports.UI.XRControlStyle oddDetailStyle;
    }
}
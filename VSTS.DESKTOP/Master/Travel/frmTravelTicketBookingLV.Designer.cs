namespace VSTS.DESKTOP.Master.Travel
{
    partial class frmTravelTicketBookingLV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTravelTicketBookingLV));
            this._GridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPassengerType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassengerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassengerPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTicket = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bbiPrintETicket = new DevExpress.XtraBars.BarButtonItem();
            this.colPickupPointCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryPointCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DockManager)).BeginInit();
            this._DockPanelRight.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).BeginInit();
            this.dataLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPopUp3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiPrintETicket});
            this.ribbonControl.MaxItemId = 21;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.AccessibleName = "Search Item";
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(1080, 254);
            // 
            // rpgTasks
            // 
            this.rpgTasks.ItemLinks.Add(this.bbiPrintETicket);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiRefresh.ImageOptions.SvgImage")));
            // 
            // bbiNew
            // 
            this.bbiNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiNew.ImageOptions.SvgImage")));
            // 
            // bbiEdit
            // 
            this.bbiEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiEdit.ImageOptions.SvgImage")));
            // 
            // bbiDelete
            // 
            this.bbiDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiDelete.ImageOptions.SvgImage")));
            // 
            // bbiCopy
            // 
            this.bbiCopy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiCopy.ImageOptions.SvgImage")));
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPrintPreview.ImageOptions.SvgImage")));
            // 
            // bbiExport
            // 
            this.bbiExport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExport.ImageOptions.SvgImage")));
            // 
            // bbiExportCsv
            // 
            this.bbiExportCsv.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportCsv.ImageOptions.SvgImage")));
            // 
            // bbiExportPdf
            // 
            this.bbiExportPdf.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportPdf.ImageOptions.SvgImage")));
            // 
            // bbiExportHtml
            // 
            this.bbiExportHtml.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportHtml.ImageOptions.SvgImage")));
            // 
            // bbiExportXls
            // 
            this.bbiExportXls.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportXls.ImageOptions.SvgImage")));
            // 
            // bbiExportXlsx
            // 
            this.bbiExportXlsx.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportXlsx.ImageOptions.SvgImage")));
            // 
            // bbiExportDoc
            // 
            this.bbiExportDoc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportDoc.ImageOptions.SvgImage")));
            // 
            // bbiExportDocX
            // 
            this.bbiExportDocX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportDocX.ImageOptions.SvgImage")));
            // 
            // bbiClose
            // 
            this.bbiClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiClose.ImageOptions.SvgImage")));
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Size = new System.Drawing.Size(761, 376);
            this.dataLayoutControl1.Controls.SetChildIndex(this._GridControl, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this._SearchControl, 0);
            // 
            // _GridControl
            // 
            this._GridControl.DataSource = this._BindingSource;
            this._GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.First.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.Last.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode1.LevelTemplate = this._GridViewDetail;
            gridLevelNode1.RelationName = "TravelTicketBookingDetails";
            this._GridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this._GridControl.Size = new System.Drawing.Size(739, 290);
            this._GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewDetail});
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompanyName,
            this.colDate,
            this.colTime,
            this.colPaymentType,
            this.colStatus,
            this.colTotalTicket,
            this.colTotalPrice,
            this.colPickupPointCityName,
            this.colDeliveryPointCityName});
            this._GridView.OptionsBehavior.Editable = false;
            this._GridView.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this._GridView.OptionsCustomization.AllowFilter = false;
            this._GridView.OptionsCustomization.AllowGroup = false;
            this._GridView.OptionsFind.AllowFindPanel = false;
            this._GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this._GridView.OptionsSelection.MultiSelect = true;
            this._GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this._GridView.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(761, 376);
            // 
            // layoutControlItem1
            // 
            this.ItemForGridControl.Size = new System.Drawing.Size(743, 294);
            // 
            // _SearchControl
            // 
            this._SearchControl.Size = new System.Drawing.Size(739, 34);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(743, 64);
            // 
            // _DockPanelRight
            // 
            this._DockPanelRight.Location = new System.Drawing.Point(761, 254);
            this._DockPanelRight.OriginalSize = new System.Drawing.Size(319, 200);
            this._DockPanelRight.Size = new System.Drawing.Size(319, 376);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Size = new System.Drawing.Size(308, 325);
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Size = new System.Drawing.Size(308, 325);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterPopUp3, 0);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterDate1, 0);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterDate2, 0);
            // 
            // FilterDate1
            // 
            this.FilterDate1.EditValue = null;
            this.FilterDate1.Size = new System.Drawing.Size(286, 34);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(308, 325);
            // 
            // _LayoutControlItemFilter1
            // 
            this._LayoutControlItemFilter1.Size = new System.Drawing.Size(290, 64);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Size = new System.Drawing.Size(290, 115);
            // 
            // FilterDate2
            // 
            this.FilterDate2.EditValue = null;
            this.FilterDate2.Size = new System.Drawing.Size(286, 34);
            // 
            // _LayoutControlItemFilter2
            // 
            this._LayoutControlItemFilter2.Size = new System.Drawing.Size(290, 64);
            // 
            // _LayoutControlItemFilter3
            // 
            this._LayoutControlItemFilter3.Size = new System.Drawing.Size(290, 64);
            // 
            // _BindingSource
            // 
            this._BindingSource.DataSource = typeof(Domain.Entities.Travel.TravelTicketBooking);
            // 
            // FilterPopUp3
            // 
            this.FilterPopUp3.Properties.Appearance.Options.UseTextOptions = true;
            this.FilterPopUp3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.FilterPopUp3.Size = new System.Drawing.Size(286, 34);
            // 
            // _GridViewDetail
            // 
            this._GridViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPassengerType,
            this.colPassengerName,
            this.colPassengerPhone,
            this.colPrice});
            this._GridViewDetail.GridControl = this._GridControl;
            this._GridViewDetail.Name = "_GridViewDetail";
            // 
            // colPassengerType
            // 
            this.colPassengerType.Caption = "Tipe";
            this.colPassengerType.FieldName = "PassengerType";
            this.colPassengerType.MinWidth = 30;
            this.colPassengerType.Name = "colPassengerType";
            this.colPassengerType.Visible = true;
            this.colPassengerType.VisibleIndex = 0;
            this.colPassengerType.Width = 148;
            // 
            // colPassengerName
            // 
            this.colPassengerName.Caption = "Nama Penumpang";
            this.colPassengerName.FieldName = "Passenger.Name";
            this.colPassengerName.MinWidth = 30;
            this.colPassengerName.Name = "colPassengerName";
            this.colPassengerName.Visible = true;
            this.colPassengerName.VisibleIndex = 1;
            this.colPassengerName.Width = 554;
            // 
            // colPassengerPhone
            // 
            this.colPassengerPhone.Caption = "No Penumpang";
            this.colPassengerPhone.FieldName = "Passenger.PhoneNumber";
            this.colPassengerPhone.MinWidth = 30;
            this.colPassengerPhone.Name = "colPassengerPhone";
            this.colPassengerPhone.Visible = true;
            this.colPassengerPhone.VisibleIndex = 2;
            this.colPassengerPhone.Width = 259;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Harga";
            this.colPrice.FieldName = "Price";
            this.colPrice.MinWidth = 30;
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 3;
            this.colPrice.Width = 515;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "Sekolah";
            this.colCompanyName.FieldName = "Company.Name";
            this.colCompanyName.MinWidth = 30;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 0;
            this.colCompanyName.Width = 263;
            // 
            // colDate
            // 
            this.colDate.Caption = "Tanggal";
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 30;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 135;
            // 
            // colTime
            // 
            this.colTime.Caption = "Jam";
            this.colTime.FieldName = "Time";
            this.colTime.MinWidth = 30;
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 2;
            this.colTime.Width = 79;
            // 
            // colTotalTicket
            // 
            this.colTotalTicket.Caption = "Total Tiket";
            this.colTotalTicket.FieldName = "TotalTicket";
            this.colTotalTicket.MinWidth = 30;
            this.colTotalTicket.Name = "colTotalTicket";
            this.colTotalTicket.Visible = true;
            this.colTotalTicket.VisibleIndex = 5;
            this.colTotalTicket.Width = 109;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.Caption = "Total Harga";
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.MinWidth = 30;
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 6;
            this.colTotalPrice.Width = 164;
            // 
            // colPaymentType
            // 
            this.colPaymentType.Caption = "Pembayaran";
            this.colPaymentType.FieldName = "PaymentType";
            this.colPaymentType.MinWidth = 30;
            this.colPaymentType.Name = "colPaymentType";
            this.colPaymentType.Visible = true;
            this.colPaymentType.VisibleIndex = 3;
            this.colPaymentType.Width = 173;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.MinWidth = 30;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 4;
            this.colStatus.Width = 171;
            // 
            // bbiPrintETicket
            // 
            this.bbiPrintETicket.Caption = "Print E-Tiket";
            this.bbiPrintETicket.Id = 20;
            this.bbiPrintETicket.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPrintETicket.ImageOptions.SvgImage")));
            this.bbiPrintETicket.Name = "bbiPrintETicket";
            // 
            // colPickupPointCityName
            // 
            this.colPickupPointCityName.Caption = "Penjemputan";
            this.colPickupPointCityName.FieldName = "PickupPointCity.Name";
            this.colPickupPointCityName.MinWidth = 30;
            this.colPickupPointCityName.Name = "colPickupPointCityName";
            this.colPickupPointCityName.Visible = true;
            this.colPickupPointCityName.VisibleIndex = 7;
            this.colPickupPointCityName.Width = 201;
            // 
            // colDeliveryPointCityName
            // 
            this.colDeliveryPointCityName.Caption = "Pengantaran";
            this.colDeliveryPointCityName.FieldName = "DeliveryPointCity.Name";
            this.colDeliveryPointCityName.MinWidth = 30;
            this.colDeliveryPointCityName.Name = "colDeliveryPointCityName";
            this.colDeliveryPointCityName.Visible = true;
            this.colDeliveryPointCityName.VisibleIndex = 8;
            this.colDeliveryPointCityName.Width = 181;
            // 
            // frmTravelTicketBookingLV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 630);
            this.Name = "frmTravelTicketBookingLV";
            this.Text = "Pemesanan Tiket Perjalanan";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DockManager)).EndInit();
            this._DockPanelRight.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).EndInit();
            this.dataLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPopUp3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTicket;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPassengerType;
        private DevExpress.XtraGrid.Columns.GridColumn colPassengerName;
        private DevExpress.XtraGrid.Columns.GridColumn colPassengerPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentType;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraBars.BarButtonItem bbiPrintETicket;
        private DevExpress.XtraGrid.Columns.GridColumn colPickupPointCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryPointCityName;
    }
}
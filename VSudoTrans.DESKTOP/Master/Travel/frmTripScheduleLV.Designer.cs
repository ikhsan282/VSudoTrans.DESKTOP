namespace VSudoTrans.DESKTOP.Master.Travel
{
    partial class frmTripScheduleLV
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTripScheduleLV));
            this._GridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineNumberDelivery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravelTicketBookingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TravelTicketBookingTimeDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colTravelTicketBookingPickupCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravelTicketBookingPickupAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravelTicketBookingDeliveryPointCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravelTicketBookingDeliveryAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravelTicketBookingPaymentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravelTicketBooking = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravelTicketBookingTotalTicket = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTravelTicketBookingTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicleBrandName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicleModelUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicleNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickupPointCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryPointCityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bbiPrintESPJ = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelTicketBookingTimeDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelTicketBookingTimeDateEdit.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiPrintESPJ});
            this.ribbonControl.MaxItemId = 21;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.AccessibleName = "Search Item";
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(1060, 254);
            // 
            // rpgTasks
            // 
            this.rpgTasks.ItemLinks.Add(this.bbiPrintESPJ);
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
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPrintPreview.ImageOptions.SvgImage")));
            // 
            // bbiExport
            // 
            this.bbiExport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExport.ImageOptions.SvgImage")));
            // 
            // bbiClose
            // 
            this.bbiClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiClose.ImageOptions.SvgImage")));
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1060, 356);
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
            gridLevelNode2.LevelTemplate = this._GridViewDetail;
            gridLevelNode2.RelationName = "TripScheduleDetails";
            this._GridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this._GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TravelTicketBookingTimeDateEdit});
            this._GridControl.Size = new System.Drawing.Size(1038, 270);
            this._GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewDetail});
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompanyName,
            this.colEmployeeName,
            this.colDate,
            this.colStartTime,
            this.colEndTime,
            this.colVehicleBrandName,
            this.colVehicleModelUnitName,
            this.colVehicleNumber,
            this.colPickupPointCityName,
            this.colDeliveryPointCityName});
            this._GridView.OptionsBehavior.Editable = false;
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(1060, 356);
            // 
            // layoutControlItem1
            // 
            this.ItemForGridControl.Size = new System.Drawing.Size(1042, 274);
            // 
            // _SearchControl
            // 
            this._SearchControl.Size = new System.Drawing.Size(1038, 34);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(1042, 64);
            // 
            // _BindingSource
            // 
            this._BindingSource.DataSource = typeof(Domain.Entities.Travel.TripSchedule);
            // 
            // _GridViewDetail
            // 
            this._GridViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineNumber,
            this.colLineNumberDelivery,
            this.colTravelTicketBookingTime,
            this.colTravelTicketBookingPickupCityName,
            this.colTravelTicketBookingPickupAddress,
            this.colTravelTicketBookingDeliveryPointCityName,
            this.colTravelTicketBookingDeliveryAddress,
            this.colTravelTicketBookingPaymentType,
            this.colTravelTicketBooking,
            this.colTravelTicketBookingTotalTicket,
            this.colTravelTicketBookingTotalPrice});
            this._GridViewDetail.GridControl = this._GridControl;
            this._GridViewDetail.Name = "_GridViewDetail";
            // 
            // colLineNumber
            // 
            this.colLineNumber.Caption = "Urutan Penjemputan";
            this.colLineNumber.FieldName = "LineNumberPickup";
            this.colLineNumber.MinWidth = 30;
            this.colLineNumber.Name = "colLineNumber";
            this.colLineNumber.Visible = true;
            this.colLineNumber.VisibleIndex = 0;
            this.colLineNumber.Width = 161;
            // 
            // colLineNumberDelivery
            // 
            this.colLineNumberDelivery.Caption = "Urutan Pengantaran";
            this.colLineNumberDelivery.FieldName = "LineNumberDelivery";
            this.colLineNumberDelivery.MinWidth = 30;
            this.colLineNumberDelivery.Name = "colLineNumberDelivery";
            this.colLineNumberDelivery.Visible = true;
            this.colLineNumberDelivery.VisibleIndex = 1;
            this.colLineNumberDelivery.Width = 156;
            // 
            // colTravelTicketBookingTime
            // 
            this.colTravelTicketBookingTime.Caption = "Jam";
            this.colTravelTicketBookingTime.ColumnEdit = this.TravelTicketBookingTimeDateEdit;
            this.colTravelTicketBookingTime.FieldName = "TravelTicketBooking.Time";
            this.colTravelTicketBookingTime.MinWidth = 30;
            this.colTravelTicketBookingTime.Name = "colTravelTicketBookingTime";
            this.colTravelTicketBookingTime.Visible = true;
            this.colTravelTicketBookingTime.VisibleIndex = 2;
            this.colTravelTicketBookingTime.Width = 51;
            // 
            // TravelTicketBookingTimeDateEdit
            // 
            this.TravelTicketBookingTimeDateEdit.AutoHeight = false;
            this.TravelTicketBookingTimeDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TravelTicketBookingTimeDateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TravelTicketBookingTimeDateEdit.Name = "TravelTicketBookingTimeDateEdit";
            // 
            // colTravelTicketBookingPickupCityName
            // 
            this.colTravelTicketBookingPickupCityName.Caption = "Penjemputan";
            this.colTravelTicketBookingPickupCityName.FieldName = "TravelTicketBooking.PickupPointCityId";
            this.colTravelTicketBookingPickupCityName.MinWidth = 30;
            this.colTravelTicketBookingPickupCityName.Name = "colTravelTicketBookingPickupCityName";
            this.colTravelTicketBookingPickupCityName.Visible = true;
            this.colTravelTicketBookingPickupCityName.VisibleIndex = 3;
            this.colTravelTicketBookingPickupCityName.Width = 110;
            // 
            // colTravelTicketBookingPickupAddress
            // 
            this.colTravelTicketBookingPickupAddress.Caption = "Alamat Jemput";
            this.colTravelTicketBookingPickupAddress.FieldName = "TravelTicketBooking.PickupAddress";
            this.colTravelTicketBookingPickupAddress.MinWidth = 30;
            this.colTravelTicketBookingPickupAddress.Name = "colTravelTicketBookingPickupAddress";
            this.colTravelTicketBookingPickupAddress.Visible = true;
            this.colTravelTicketBookingPickupAddress.VisibleIndex = 4;
            this.colTravelTicketBookingPickupAddress.Width = 211;
            // 
            // colTravelTicketBookingDeliveryPointCityName
            // 
            this.colTravelTicketBookingDeliveryPointCityName.Caption = "Pengantaran";
            this.colTravelTicketBookingDeliveryPointCityName.FieldName = "TravelTicketBooking.DeliveryPointCityId";
            this.colTravelTicketBookingDeliveryPointCityName.MinWidth = 30;
            this.colTravelTicketBookingDeliveryPointCityName.Name = "colTravelTicketBookingDeliveryPointCityName";
            this.colTravelTicketBookingDeliveryPointCityName.Visible = true;
            this.colTravelTicketBookingDeliveryPointCityName.VisibleIndex = 5;
            this.colTravelTicketBookingDeliveryPointCityName.Width = 110;
            // 
            // colTravelTicketBookingDeliveryAddress
            // 
            this.colTravelTicketBookingDeliveryAddress.Caption = "Alamat Antar";
            this.colTravelTicketBookingDeliveryAddress.FieldName = "TravelTicketBooking.DeliveryAddress";
            this.colTravelTicketBookingDeliveryAddress.MinWidth = 30;
            this.colTravelTicketBookingDeliveryAddress.Name = "colTravelTicketBookingDeliveryAddress";
            this.colTravelTicketBookingDeliveryAddress.Visible = true;
            this.colTravelTicketBookingDeliveryAddress.VisibleIndex = 6;
            this.colTravelTicketBookingDeliveryAddress.Width = 209;
            // 
            // colTravelTicketBookingPaymentType
            // 
            this.colTravelTicketBookingPaymentType.Caption = "Pembayaran";
            this.colTravelTicketBookingPaymentType.FieldName = "TravelTicketBooking.PaymentType";
            this.colTravelTicketBookingPaymentType.MinWidth = 30;
            this.colTravelTicketBookingPaymentType.Name = "colTravelTicketBookingPaymentType";
            this.colTravelTicketBookingPaymentType.Visible = true;
            this.colTravelTicketBookingPaymentType.VisibleIndex = 7;
            this.colTravelTicketBookingPaymentType.Width = 130;
            // 
            // colTravelTicketBooking
            // 
            this.colTravelTicketBooking.Caption = "Status";
            this.colTravelTicketBooking.FieldName = "TravelTicketBooking.Status";
            this.colTravelTicketBooking.MinWidth = 30;
            this.colTravelTicketBooking.Name = "colTravelTicketBooking";
            this.colTravelTicketBooking.Visible = true;
            this.colTravelTicketBooking.VisibleIndex = 8;
            this.colTravelTicketBooking.Width = 71;
            // 
            // colTravelTicketBookingTotalTicket
            // 
            this.colTravelTicketBookingTotalTicket.Caption = "Total Tiket";
            this.colTravelTicketBookingTotalTicket.FieldName = "TravelTicketBooking.TotalTicket";
            this.colTravelTicketBookingTotalTicket.MinWidth = 30;
            this.colTravelTicketBookingTotalTicket.Name = "colTravelTicketBookingTotalTicket";
            this.colTravelTicketBookingTotalTicket.Visible = true;
            this.colTravelTicketBookingTotalTicket.VisibleIndex = 9;
            this.colTravelTicketBookingTotalTicket.Width = 90;
            // 
            // colTravelTicketBookingTotalPrice
            // 
            this.colTravelTicketBookingTotalPrice.Caption = "Total Harga";
            this.colTravelTicketBookingTotalPrice.FieldName = "TravelTicketBooking.TotalPrice";
            this.colTravelTicketBookingTotalPrice.MinWidth = 30;
            this.colTravelTicketBookingTotalPrice.Name = "colTravelTicketBookingTotalPrice";
            this.colTravelTicketBookingTotalPrice.Visible = true;
            this.colTravelTicketBookingTotalPrice.VisibleIndex = 10;
            this.colTravelTicketBookingTotalPrice.Width = 177;
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "Sekolah";
            this.colCompanyName.FieldName = "Company.Name";
            this.colCompanyName.MinWidth = 30;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 0;
            this.colCompanyName.Width = 191;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Pengemudi";
            this.colEmployeeName.FieldName = "Employee.Name";
            this.colEmployeeName.MinWidth = 30;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 192;
            // 
            // colDate
            // 
            this.colDate.Caption = "Tanggal";
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 30;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;
            this.colDate.Width = 98;
            // 
            // colStartTime
            // 
            this.colStartTime.Caption = "Berangkat";
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.MinWidth = 30;
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 3;
            this.colStartTime.Width = 79;
            // 
            // colEndTime
            // 
            this.colEndTime.Caption = "Sampai";
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.MinWidth = 30;
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 4;
            this.colEndTime.Width = 66;
            // 
            // colVehicleBrandName
            // 
            this.colVehicleBrandName.Caption = "Merek";
            this.colVehicleBrandName.FieldName = "Vehicle.Brand.Name";
            this.colVehicleBrandName.MinWidth = 30;
            this.colVehicleBrandName.Name = "colVehicleBrandName";
            this.colVehicleBrandName.Visible = true;
            this.colVehicleBrandName.VisibleIndex = 5;
            this.colVehicleBrandName.Width = 161;
            // 
            // colVehicleModelUnitName
            // 
            this.colVehicleModelUnitName.Caption = "Model Unit";
            this.colVehicleModelUnitName.FieldName = "Vehicle.ModelUnit.Name";
            this.colVehicleModelUnitName.MinWidth = 30;
            this.colVehicleModelUnitName.Name = "colVehicleModelUnitName";
            this.colVehicleModelUnitName.Visible = true;
            this.colVehicleModelUnitName.VisibleIndex = 6;
            this.colVehicleModelUnitName.Width = 217;
            // 
            // colVehicleNumber
            // 
            this.colVehicleNumber.Caption = "Plat Nomor";
            this.colVehicleNumber.FieldName = "Vehicle.VehicleNumber";
            this.colVehicleNumber.MinWidth = 30;
            this.colVehicleNumber.Name = "colVehicleNumber";
            this.colVehicleNumber.Visible = true;
            this.colVehicleNumber.VisibleIndex = 7;
            this.colVehicleNumber.Width = 172;
            // 
            // colPickupPointCityName
            // 
            this.colPickupPointCityName.Caption = "Penjemputan";
            this.colPickupPointCityName.FieldName = "PickupPointCity.Name";
            this.colPickupPointCityName.MinWidth = 30;
            this.colPickupPointCityName.Name = "colPickupPointCityName";
            this.colPickupPointCityName.Visible = true;
            this.colPickupPointCityName.VisibleIndex = 8;
            this.colPickupPointCityName.Width = 161;
            // 
            // colDeliveryPointCityName
            // 
            this.colDeliveryPointCityName.Caption = "Pengantaran";
            this.colDeliveryPointCityName.FieldName = "DeliveryPointCity.Name";
            this.colDeliveryPointCityName.MinWidth = 30;
            this.colDeliveryPointCityName.Name = "colDeliveryPointCityName";
            this.colDeliveryPointCityName.Visible = true;
            this.colDeliveryPointCityName.VisibleIndex = 9;
            this.colDeliveryPointCityName.Width = 139;
            // 
            // bbiPrintESPJ
            // 
            this.bbiPrintESPJ.Caption = "Print E-SPJ";
            this.bbiPrintESPJ.Id = 20;
            this.bbiPrintESPJ.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPrintESPJ.ImageOptions.SvgImage")));
            this.bbiPrintESPJ.Name = "bbiPrintESPJ";
            // 
            // frmTripScheduleLV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 610);
            this.Name = "frmTripScheduleLV";
            this.Text = "Surat Perintah Jalan";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelTicketBookingTimeDateEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TravelTicketBookingTimeDateEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colVehicleBrandName;
        private DevExpress.XtraGrid.Columns.GridColumn colVehicleModelUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colVehicleNumber;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colLineNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colTravelTicketBookingTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTravelTicketBookingTotalTicket;
        private DevExpress.XtraGrid.Columns.GridColumn colTravelTicketBookingTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTravelTicketBookingPickupAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colTravelTicketBookingDeliveryAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colTravelTicketBookingPaymentType;
        private DevExpress.XtraGrid.Columns.GridColumn colTravelTicketBooking;
        private DevExpress.XtraGrid.Columns.GridColumn colPickupPointCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryPointCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colTravelTicketBookingPickupCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colTravelTicketBookingDeliveryPointCityName;
        private DevExpress.XtraGrid.Columns.GridColumn colLineNumberDelivery;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit TravelTicketBookingTimeDateEdit;
        private DevExpress.XtraBars.BarButtonItem bbiPrintESPJ;
    }
}
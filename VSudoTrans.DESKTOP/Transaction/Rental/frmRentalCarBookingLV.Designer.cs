namespace VSudoTrans.DESKTOP.Transaction.Rental
{
    partial class frmRentalCarBookingLV
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRentalCarBookingLV));
            this._GridViewEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this._GridViewPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatePayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicleNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassengerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassengerPhoneNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickupPointCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryPointCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalOperationalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bbiPrintInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.colBBM = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this._GridViewEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiPrintInvoice});
            this.ribbonControl.MaxItemId = 23;
            this.ribbonControl.Size = new System.Drawing.Size(1071, 254);
            // 
            // rpgTasks
            // 
            this.rpgTasks.ItemLinks.Add(this.bbiPrintInvoice, true);
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
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dataLayoutControl1.Size = new System.Drawing.Size(749, 412);
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
            gridLevelNode1.LevelTemplate = this._GridViewEmployee;
            gridLevelNode1.RelationName = "RentalCarBookingEmployees";
            gridLevelNode2.LevelTemplate = this._GridViewPayment;
            gridLevelNode2.RelationName = "RentalCarBookingPayments";
            this._GridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this._GridControl.Size = new System.Drawing.Size(727, 326);
            this._GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewEmployee,
            this._GridViewPayment});
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVehicleNumber,
            this.colPassengerName,
            this.colPassengerPhoneNumber,
            this.colDate,
            this.colTime,
            this.colPickupPointCity,
            this.colDeliveryPointCity,
            this.colBBM,
            this.colTotalPrice,
            this.colTotalOperationalCost,
            this.colTotalPayment});
            this._GridView.OptionsBehavior.Editable = false;
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(749, 412);
            // 
            // ItemForGridControl
            // 
            this.ItemForGridControl.Size = new System.Drawing.Size(731, 330);
            // 
            // _SearchControl
            // 
            this._SearchControl.Size = new System.Drawing.Size(727, 34);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(731, 64);
            // 
            // _DockPanelRight
            // 
            this._DockPanelRight.Location = new System.Drawing.Point(749, 254);
            this._DockPanelRight.Size = new System.Drawing.Size(322, 412);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Size = new System.Drawing.Size(311, 361);
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.dataLayoutControl2.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.dataLayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.dataLayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.dataLayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.dataLayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dataLayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dataLayoutControl2.Size = new System.Drawing.Size(311, 361);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterPopUp3, 0);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterDate1, 0);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterDate2, 0);
            // 
            // FilterDate1
            // 
            this.FilterDate1.EditValue = null;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Size = new System.Drawing.Size(311, 361);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Size = new System.Drawing.Size(293, 151);
            // 
            // FilterDate2
            // 
            this.FilterDate2.EditValue = null;
            // 
            // _BindingSource
            // 
            this._BindingSource.DataSource = typeof(Domain.Entities.Rental.RentalCarBooking);
            // 
            // FilterPopUp3
            // 
            this.FilterPopUp3.Properties.Appearance.Options.UseTextOptions = true;
            this.FilterPopUp3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            // 
            // bbiImport
            // 
            this.bbiImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiImport.ImageOptions.SvgImage")));
            // 
            // bbiTemplateImport
            // 
            this.bbiTemplateImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiTemplateImport.ImageOptions.SvgImage")));
            // 
            // bbiImportData
            // 
            this.bbiImportData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiImportData.ImageOptions.SvgImage")));
            // 
            // _GridViewEmployee
            // 
            this._GridViewEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeCode,
            this.colEmployeeName,
            this.colAmount});
            this._GridViewEmployee.GridControl = this._GridControl;
            this._GridViewEmployee.Name = "_GridViewEmployee";
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Caption = "Kode Karyawan";
            this.colEmployeeCode.FieldName = "Employee.Code";
            this.colEmployeeCode.MinWidth = 30;
            this.colEmployeeCode.Name = "colEmployeeCode";
            this.colEmployeeCode.Visible = true;
            this.colEmployeeCode.VisibleIndex = 0;
            this.colEmployeeCode.Width = 273;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Nama Karyawan";
            this.colEmployeeName.FieldName = "Employee.Name";
            this.colEmployeeName.MinWidth = 30;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 601;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Jumlah";
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 30;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 2;
            this.colAmount.Width = 602;
            // 
            // _GridViewPayment
            // 
            this._GridViewPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentMethod,
            this.colDatePayment,
            this.colAmountPayment});
            this._GridViewPayment.GridControl = this._GridControl;
            this._GridViewPayment.Name = "_GridViewPayment";
            // 
            // colPaymentMethod
            // 
            this.colPaymentMethod.Caption = "Metode Pembayaran";
            this.colPaymentMethod.FieldName = "PaymentMethod";
            this.colPaymentMethod.MinWidth = 30;
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.Visible = true;
            this.colPaymentMethod.VisibleIndex = 0;
            this.colPaymentMethod.Width = 338;
            // 
            // colDatePayment
            // 
            this.colDatePayment.Caption = "Tanggal";
            this.colDatePayment.FieldName = "Date";
            this.colDatePayment.MinWidth = 30;
            this.colDatePayment.Name = "colDatePayment";
            this.colDatePayment.Visible = true;
            this.colDatePayment.VisibleIndex = 1;
            this.colDatePayment.Width = 457;
            // 
            // colAmountPayment
            // 
            this.colAmountPayment.Caption = "Jumlah";
            this.colAmountPayment.FieldName = "Amount";
            this.colAmountPayment.MinWidth = 30;
            this.colAmountPayment.Name = "colAmountPayment";
            this.colAmountPayment.Visible = true;
            this.colAmountPayment.VisibleIndex = 2;
            this.colAmountPayment.Width = 681;
            // 
            // colVehicleNumber
            // 
            this.colVehicleNumber.Caption = "Kendaraan";
            this.colVehicleNumber.FieldName = "Vehicle.VehicleNumber";
            this.colVehicleNumber.MinWidth = 30;
            this.colVehicleNumber.Name = "colVehicleNumber";
            this.colVehicleNumber.Visible = true;
            this.colVehicleNumber.VisibleIndex = 0;
            this.colVehicleNumber.Width = 129;
            // 
            // colPassengerName
            // 
            this.colPassengerName.Caption = "Nama";
            this.colPassengerName.FieldName = "Passenger.Name";
            this.colPassengerName.MinWidth = 30;
            this.colPassengerName.Name = "colPassengerName";
            this.colPassengerName.Visible = true;
            this.colPassengerName.VisibleIndex = 1;
            this.colPassengerName.Width = 117;
            // 
            // colPassengerPhoneNumber
            // 
            this.colPassengerPhoneNumber.Caption = "Nomor Telepon";
            this.colPassengerPhoneNumber.FieldName = "Passenger.PhoneNumber";
            this.colPassengerPhoneNumber.MinWidth = 30;
            this.colPassengerPhoneNumber.Name = "colPassengerPhoneNumber";
            this.colPassengerPhoneNumber.Visible = true;
            this.colPassengerPhoneNumber.VisibleIndex = 2;
            this.colPassengerPhoneNumber.Width = 135;
            // 
            // colDate
            // 
            this.colDate.Caption = "Tanggal";
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 30;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 4;
            this.colDate.Width = 92;
            // 
            // colPickupPointCity
            // 
            this.colPickupPointCity.Caption = "Penjemputan";
            this.colPickupPointCity.FieldName = "PickupPointCity.Name";
            this.colPickupPointCity.MinWidth = 30;
            this.colPickupPointCity.Name = "colPickupPointCity";
            this.colPickupPointCity.Visible = true;
            this.colPickupPointCity.VisibleIndex = 5;
            this.colPickupPointCity.Width = 167;
            // 
            // colDeliveryPointCity
            // 
            this.colDeliveryPointCity.Caption = "Pengantaran";
            this.colDeliveryPointCity.FieldName = "DeliveryPointCity.Name";
            this.colDeliveryPointCity.MinWidth = 30;
            this.colDeliveryPointCity.Name = "colDeliveryPointCity";
            this.colDeliveryPointCity.Visible = true;
            this.colDeliveryPointCity.VisibleIndex = 6;
            this.colDeliveryPointCity.Width = 169;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.Caption = "Total Harga";
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.MinWidth = 30;
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 8;
            this.colTotalPrice.Width = 136;
            // 
            // colTime
            // 
            this.colTime.Caption = "Jam";
            this.colTime.FieldName = "Time";
            this.colTime.MinWidth = 30;
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 3;
            this.colTime.Width = 49;
            // 
            // colTotalPayment
            // 
            this.colTotalPayment.Caption = "Total Pembayaran";
            this.colTotalPayment.FieldName = "TotalPayment";
            this.colTotalPayment.MinWidth = 30;
            this.colTotalPayment.Name = "colTotalPayment";
            this.colTotalPayment.Visible = true;
            this.colTotalPayment.VisibleIndex = 10;
            this.colTotalPayment.Width = 198;
            // 
            // colTotalOperationalCost
            // 
            this.colTotalOperationalCost.Caption = "Total Biaya Operasional";
            this.colTotalOperationalCost.FieldName = "TotalOperationalCost";
            this.colTotalOperationalCost.MinWidth = 30;
            this.colTotalOperationalCost.Name = "colTotalOperationalCost";
            this.colTotalOperationalCost.Visible = true;
            this.colTotalOperationalCost.VisibleIndex = 9;
            this.colTotalOperationalCost.Width = 185;
            // 
            // bbiPrintInvoice
            // 
            this.bbiPrintInvoice.Caption = "Print Invoice";
            this.bbiPrintInvoice.Id = 22;
            this.bbiPrintInvoice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPrintInvoice.ImageOptions.SvgImage")));
            this.bbiPrintInvoice.Name = "bbiPrintInvoice";
            // 
            // colBBM
            // 
            this.colBBM.FieldName = "BBM";
            this.colBBM.MinWidth = 30;
            this.colBBM.Name = "colBBM";
            this.colBBM.Visible = true;
            this.colBBM.VisibleIndex = 7;
            this.colBBM.Width = 99;
            // 
            // frmRentalCarBookingLV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 666);
            this.Name = "frmRentalCarBookingLV";
            this.Text = "frmRentalCarBookingLV";
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
            ((System.ComponentModel.ISupportInitialize)(this._GridViewEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn colVehicleNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPassengerName;
        private DevExpress.XtraGrid.Columns.GridColumn colPassengerPhoneNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPickupPointCity;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryPointCity;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalOperationalCost;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPayment;
        private DevExpress.XtraBars.BarButtonItem bbiPrintInvoice;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colDatePayment;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colBBM;
    }
}
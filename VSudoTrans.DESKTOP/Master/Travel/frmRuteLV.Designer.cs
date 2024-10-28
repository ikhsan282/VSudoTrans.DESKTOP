namespace VSudoTrans.DESKTOP.Master.Travel
{
    partial class frmRuteLV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRuteLV));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            this._GridViewPickup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._GridViewDelivery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._GridViewRuteSchedule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._GridViewTravelPrice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartCapacitySeat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndCapacitySeat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDistrictNamePickup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDistrictNameDelivery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScheduleName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewRuteSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewTravelPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Size = new System.Drawing.Size(904, 254);
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
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 254);
            this.dataLayoutControl1.Size = new System.Drawing.Size(904, 416);
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
            gridLevelNode1.LevelTemplate = this._GridViewPickup;
            gridLevelNode1.RelationName = "PickupPointDistricts";
            gridLevelNode2.LevelTemplate = this._GridViewDelivery;
            gridLevelNode2.RelationName = "DeliveryPointDistricts";
            gridLevelNode3.LevelTemplate = this._GridViewTravelPrice;
            gridLevelNode3.RelationName = "TravelPrices";
            gridLevelNode4.LevelTemplate = this._GridViewRuteSchedule;
            gridLevelNode4.RelationName = "RuteSchedules";
            this._GridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3,
            gridLevelNode4});
            this._GridControl.Size = new System.Drawing.Size(882, 330);
            this._GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewPickup,
            this._GridViewDelivery,
            this._GridViewRuteSchedule,
            this._GridViewTravelPrice});
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompanyName,
            this.colCode,
            this.colName});
            this._GridView.OptionsBehavior.Editable = false;
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(904, 416);
            // 
            // ItemForGridControl
            // 
            this.ItemForGridControl.Size = new System.Drawing.Size(886, 334);
            // 
            // _SearchControl
            // 
            this._SearchControl.Size = new System.Drawing.Size(882, 34);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(886, 64);
            // 
            // _BindingSource
            // 
            this._BindingSource.DataSource = typeof(Domain.Entities.Travel.Rute);
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
            // _GridViewPickup
            // 
            this._GridViewPickup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDistrictNamePickup});
            this._GridViewPickup.GridControl = this._GridControl;
            this._GridViewPickup.Name = "_GridViewPickup";
            // 
            // _GridViewDelivery
            // 
            this._GridViewDelivery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDistrictNameDelivery});
            this._GridViewDelivery.GridControl = this._GridControl;
            this._GridViewDelivery.Name = "_GridViewDelivery";
            // 
            // _GridViewRuteSchedule
            // 
            this._GridViewRuteSchedule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colScheduleName});
            this._GridViewRuteSchedule.GridControl = this._GridControl;
            this._GridViewRuteSchedule.Name = "_GridViewRuteSchedule";
            // 
            // _GridViewTravelPrice
            // 
            this._GridViewTravelPrice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPriceType,
            this.colPrice,
            this.colStartCapacitySeat,
            this.colEndCapacitySeat});
            this._GridViewTravelPrice.GridControl = this._GridControl;
            this._GridViewTravelPrice.Name = "_GridViewTravelPrice";
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "Perusahaan";
            this.colCompanyName.FieldName = "Company.Name";
            this.colCompanyName.MinWidth = 30;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 0;
            this.colCompanyName.Width = 355;
            // 
            // colCode
            // 
            this.colCode.Caption = "Kode";
            this.colCode.FieldName = "Code";
            this.colCode.MinWidth = 30;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 314;
            // 
            // colName
            // 
            this.colName.Caption = "Nama";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 30;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 807;
            // 
            // colPriceType
            // 
            this.colPriceType.Caption = "Tipe Harga";
            this.colPriceType.FieldName = "PriceType";
            this.colPriceType.MinWidth = 30;
            this.colPriceType.Name = "colPriceType";
            this.colPriceType.Visible = true;
            this.colPriceType.VisibleIndex = 0;
            this.colPriceType.Width = 112;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Harga";
            this.colPrice.FieldName = "Price";
            this.colPrice.MinWidth = 30;
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 1;
            this.colPrice.Width = 112;
            // 
            // colStartCapacitySeat
            // 
            this.colStartCapacitySeat.Caption = "Kapasitas Minimum";
            this.colStartCapacitySeat.FieldName = "StartCapacitySeat";
            this.colStartCapacitySeat.MinWidth = 30;
            this.colStartCapacitySeat.Name = "colStartCapacitySeat";
            this.colStartCapacitySeat.Visible = true;
            this.colStartCapacitySeat.VisibleIndex = 2;
            this.colStartCapacitySeat.Width = 112;
            // 
            // colEndCapacitySeat
            // 
            this.colEndCapacitySeat.Caption = "Kapasitas Maksimum";
            this.colEndCapacitySeat.FieldName = "EndCapacitySeat";
            this.colEndCapacitySeat.MinWidth = 30;
            this.colEndCapacitySeat.Name = "colEndCapacitySeat";
            this.colEndCapacitySeat.Visible = true;
            this.colEndCapacitySeat.VisibleIndex = 3;
            this.colEndCapacitySeat.Width = 112;
            // 
            // colDistrictNamePickup
            // 
            this.colDistrictNamePickup.Caption = "Kecamatan";
            this.colDistrictNamePickup.FieldName = "District.Name";
            this.colDistrictNamePickup.MinWidth = 30;
            this.colDistrictNamePickup.Name = "colDistrictNamePickup";
            this.colDistrictNamePickup.Visible = true;
            this.colDistrictNamePickup.VisibleIndex = 0;
            this.colDistrictNamePickup.Width = 112;
            // 
            // colDistrictNameDelivery
            // 
            this.colDistrictNameDelivery.Caption = "Kecamatan";
            this.colDistrictNameDelivery.FieldName = "District.Name";
            this.colDistrictNameDelivery.MinWidth = 30;
            this.colDistrictNameDelivery.Name = "colDistrictNameDelivery";
            this.colDistrictNameDelivery.Visible = true;
            this.colDistrictNameDelivery.VisibleIndex = 0;
            this.colDistrictNameDelivery.Width = 112;
            // 
            // colScheduleName
            // 
            this.colScheduleName.Caption = "Jadwal";
            this.colScheduleName.FieldName = "Schedule.Name";
            this.colScheduleName.MinWidth = 30;
            this.colScheduleName.Name = "colScheduleName";
            this.colScheduleName.Visible = true;
            this.colScheduleName.VisibleIndex = 0;
            this.colScheduleName.Width = 112;
            // 
            // frmRuteLV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 670);
            this.Name = "frmRuteLV";
            this.Text = "frmRuteLV";
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
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewRuteSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewTravelPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewPickup;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewDelivery;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewRuteSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewTravelPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDistrictNamePickup;
        private DevExpress.XtraGrid.Columns.GridColumn colDistrictNameDelivery;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceType;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colStartCapacitySeat;
        private DevExpress.XtraGrid.Columns.GridColumn colEndCapacitySeat;
        private DevExpress.XtraGrid.Columns.GridColumn colScheduleName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
    }
}
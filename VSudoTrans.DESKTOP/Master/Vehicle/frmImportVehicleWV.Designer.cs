namespace VSudoTrans.DESKTOP.Master.Vehicle
{
    partial class frmImportVehicleWV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportVehicleWV));
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFailureDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBrandCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModelCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeEngineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrameNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductionYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicleNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicleColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOwnership = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // _BindingSource
            // 
            this._BindingSource.DataSource = typeof(Contract.Vehicle.ImportVehicleModel);
            // 
            // layoutControl1
            // 
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(945, 268, 975, 600);
            this.layoutControl1.Controls.SetChildIndex(this._GridControl, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnOK, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnCancel, 0);
            this.layoutControl1.Controls.SetChildIndex(this._SearchControl, 0);
            // 
            // _GridControl
            // 
            this._GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.First.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.Last.Visible = false;
            this._GridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatusImport,
            this.colCompanyCode,
            this.colBrandCode,
            this.colModelCode,
            this.colTypeEngineCode,
            this.colFrameNumber,
            this.colMachineNumber,
            this.colSeat,
            this.colProductionYear,
            this.colVehicleColor,
            this.colVehicleNumber,
            this.colOwnership,
            this.colNote,
            this.colFailureDescription});
            this._GridView.OptionsBehavior.Editable = false;
            this._GridView.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this._GridView.OptionsCustomization.AllowFilter = false;
            this._GridView.OptionsCustomization.AllowGroup = false;
            this._GridView.OptionsFind.AllowFindPanel = false;
            this._GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this._GridView.OptionsSelection.MultiSelect = true;
            this._GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this._GridView.OptionsView.ColumnAutoWidth = false;
            this._GridView.OptionsView.ShowAutoFilterRow = true;
            this._GridView.OptionsView.ShowGroupPanel = false;
            // 
            // _SearchControl
            // 
            // 
            // colNote
            // 
            this.colNote.Caption = "Catatan";
            this.colNote.FieldName = "Note";
            this.colNote.MinWidth = 30;
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 12;
            this.colNote.Width = 298;
            // 
            // colFailureDescription
            // 
            this.colFailureDescription.Caption = "Deskripsi Kegagalan";
            this.colFailureDescription.FieldName = "FailureDescription";
            this.colFailureDescription.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colFailureDescription.MinWidth = 30;
            this.colFailureDescription.Name = "colFailureDescription";
            this.colFailureDescription.Visible = true;
            this.colFailureDescription.VisibleIndex = 13;
            this.colFailureDescription.Width = 311;
            // 
            // colStatusImport
            // 
            this.colStatusImport.Caption = "Status";
            this.colStatusImport.FieldName = "StatusImport";
            this.colStatusImport.MinWidth = 30;
            this.colStatusImport.Name = "colStatusImport";
            this.colStatusImport.Visible = true;
            this.colStatusImport.VisibleIndex = 0;
            this.colStatusImport.Width = 97;
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.Caption = "Kode Perusahaan";
            this.colCompanyCode.FieldName = "CompanyCode";
            this.colCompanyCode.MinWidth = 30;
            this.colCompanyCode.Name = "colCompanyCode";
            this.colCompanyCode.Visible = true;
            this.colCompanyCode.VisibleIndex = 1;
            this.colCompanyCode.Width = 138;
            // 
            // colBrandCode
            // 
            this.colBrandCode.Caption = "Kode Merek";
            this.colBrandCode.FieldName = "BrandCode";
            this.colBrandCode.MinWidth = 30;
            this.colBrandCode.Name = "colBrandCode";
            this.colBrandCode.Visible = true;
            this.colBrandCode.VisibleIndex = 2;
            this.colBrandCode.Width = 126;
            // 
            // colModelCode
            // 
            this.colModelCode.Caption = "Kode Model";
            this.colModelCode.FieldName = "ModelCode";
            this.colModelCode.MinWidth = 30;
            this.colModelCode.Name = "colModelCode";
            this.colModelCode.Visible = true;
            this.colModelCode.VisibleIndex = 3;
            this.colModelCode.Width = 123;
            // 
            // colTypeEngineCode
            // 
            this.colTypeEngineCode.Caption = "Kode Tipe Mesin";
            this.colTypeEngineCode.FieldName = "TypeEngineCode";
            this.colTypeEngineCode.MinWidth = 30;
            this.colTypeEngineCode.Name = "colTypeEngineCode";
            this.colTypeEngineCode.Visible = true;
            this.colTypeEngineCode.VisibleIndex = 4;
            this.colTypeEngineCode.Width = 132;
            // 
            // colFrameNumber
            // 
            this.colFrameNumber.Caption = "Nomor Rangka";
            this.colFrameNumber.FieldName = "FrameNumber";
            this.colFrameNumber.MinWidth = 30;
            this.colFrameNumber.Name = "colFrameNumber";
            this.colFrameNumber.Visible = true;
            this.colFrameNumber.VisibleIndex = 5;
            this.colFrameNumber.Width = 147;
            // 
            // colMachineNumber
            // 
            this.colMachineNumber.Caption = "Nomor Mesin";
            this.colMachineNumber.FieldName = "MachineNumber";
            this.colMachineNumber.MinWidth = 30;
            this.colMachineNumber.Name = "colMachineNumber";
            this.colMachineNumber.Visible = true;
            this.colMachineNumber.VisibleIndex = 6;
            this.colMachineNumber.Width = 137;
            // 
            // colSeat
            // 
            this.colSeat.Caption = "Jumlah Bangku";
            this.colSeat.FieldName = "Seat";
            this.colSeat.MinWidth = 30;
            this.colSeat.Name = "colSeat";
            this.colSeat.Visible = true;
            this.colSeat.VisibleIndex = 7;
            this.colSeat.Width = 124;
            // 
            // colProductionYear
            // 
            this.colProductionYear.Caption = "Tahun Pembuatan";
            this.colProductionYear.FieldName = "ProductionYear";
            this.colProductionYear.MinWidth = 30;
            this.colProductionYear.Name = "colProductionYear";
            this.colProductionYear.Visible = true;
            this.colProductionYear.VisibleIndex = 8;
            this.colProductionYear.Width = 144;
            // 
            // colVehicleNumber
            // 
            this.colVehicleNumber.Caption = "Nomor Kendaraan (Plat)";
            this.colVehicleNumber.FieldName = "VehicleNumber";
            this.colVehicleNumber.MinWidth = 30;
            this.colVehicleNumber.Name = "colVehicleNumber";
            this.colVehicleNumber.Visible = true;
            this.colVehicleNumber.VisibleIndex = 9;
            this.colVehicleNumber.Width = 186;
            // 
            // colVehicleColor
            // 
            this.colVehicleColor.Caption = "Warna";
            this.colVehicleColor.FieldName = "VehicleColor";
            this.colVehicleColor.MinWidth = 30;
            this.colVehicleColor.Name = "colVehicleColor";
            this.colVehicleColor.Visible = true;
            this.colVehicleColor.VisibleIndex = 10;
            this.colVehicleColor.Width = 157;
            // 
            // colOwnership
            // 
            this.colOwnership.Caption = "Kepemilikan";
            this.colOwnership.FieldName = "Ownership";
            this.colOwnership.MinWidth = 30;
            this.colOwnership.Name = "colOwnership";
            this.colOwnership.Visible = true;
            this.colOwnership.VisibleIndex = 11;
            this.colOwnership.Width = 110;
            // 
            // frmImportVehicleWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 756);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmImportVehicleWV.IconOptions.Image")));
            this.Name = "frmImportVehicleWV";
            this.Text = "frmImportVehicleWV";
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colStatusImport;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colFailureDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBrandCode;
        private DevExpress.XtraGrid.Columns.GridColumn colModelCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeEngineCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFrameNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSeat;
        private DevExpress.XtraGrid.Columns.GridColumn colProductionYear;
        private DevExpress.XtraGrid.Columns.GridColumn colVehicleColor;
        private DevExpress.XtraGrid.Columns.GridColumn colVehicleNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOwnership;
    }
}
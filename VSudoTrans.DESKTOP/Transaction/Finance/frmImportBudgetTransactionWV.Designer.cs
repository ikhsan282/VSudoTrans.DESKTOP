namespace VSudoTrans.DESKTOP.Transaction.Finance
{
    partial class frmImportBudgetTransactionWV
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
            this.colUnitMeasureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFailureDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndicator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this._BindingSource.DataSource = typeof(Contract.Finance.ImportBudgetTransactionModel);
            // 
            // layoutControl1
            // 
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(945, 268, 975, 600);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.colIndicator,
            this.colUnitMeasureCode,
            this.colCategoryCode,
            this.colDocumentNumber,
            this.colQuantity,
            this.colAmount,
            this.colTransactionDate,
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
            // colUnitMeasureCode
            // 
            this.colUnitMeasureCode.Caption = "Satuan Ukuran";
            this.colUnitMeasureCode.FieldName = "UnitMeasureCode";
            this.colUnitMeasureCode.MinWidth = 30;
            this.colUnitMeasureCode.Name = "colUnitMeasureCode";
            this.colUnitMeasureCode.Visible = true;
            this.colUnitMeasureCode.VisibleIndex = 3;
            this.colUnitMeasureCode.Width = 122;
            // 
            // colCategoryCode
            // 
            this.colCategoryCode.Caption = "Kode Kategori";
            this.colCategoryCode.FieldName = "CategoryCode";
            this.colCategoryCode.MinWidth = 30;
            this.colCategoryCode.Name = "colCategoryCode";
            this.colCategoryCode.Visible = true;
            this.colCategoryCode.VisibleIndex = 4;
            this.colCategoryCode.Width = 165;
            // 
            // colNote
            // 
            this.colNote.Caption = "Catatan";
            this.colNote.FieldName = "Note";
            this.colNote.MinWidth = 30;
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 9;
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
            this.colFailureDescription.VisibleIndex = 10;
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
            this.colCompanyCode.Width = 112;
            // 
            // colIndicator
            // 
            this.colIndicator.Caption = "Indikator";
            this.colIndicator.FieldName = "Indicator";
            this.colIndicator.MinWidth = 30;
            this.colIndicator.Name = "colIndicator";
            this.colIndicator.Visible = true;
            this.colIndicator.VisibleIndex = 2;
            this.colIndicator.Width = 85;
            // 
            // colTransactionDate
            // 
            this.colTransactionDate.Caption = "Tanggal Transaksi";
            this.colTransactionDate.FieldName = "TransactionDate";
            this.colTransactionDate.MinWidth = 30;
            this.colTransactionDate.Name = "colTransactionDate";
            this.colTransactionDate.Visible = true;
            this.colTransactionDate.VisibleIndex = 8;
            this.colTransactionDate.Width = 142;
            // 
            // colDocumentNumber
            // 
            this.colDocumentNumber.Caption = "Nomor Dokumen";
            this.colDocumentNumber.FieldName = "DocumentNumber";
            this.colDocumentNumber.MinWidth = 30;
            this.colDocumentNumber.Name = "colDocumentNumber";
            this.colDocumentNumber.Visible = true;
            this.colDocumentNumber.VisibleIndex = 5;
            this.colDocumentNumber.Width = 145;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Kuantitas";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 30;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 6;
            this.colQuantity.Width = 81;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Nominal";
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 30;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 7;
            this.colAmount.Width = 152;
            // 
            // frmImportBudgetTransactionWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 756);
            this.Name = "frmImportBudgetTransactionWV";
            this.Text = "frmImportBudgetTransactionWV";
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
        private DevExpress.XtraGrid.Columns.GridColumn colUnitMeasureCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colFailureDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIndicator;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionDate;
    }
}
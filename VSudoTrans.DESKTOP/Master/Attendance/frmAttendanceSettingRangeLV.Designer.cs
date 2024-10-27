namespace VSudoTrans.DESKTOP.Master.Attendance
{
    partial class frmAttendanceSettingRangeLV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendanceSettingRangeLV));
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeforeIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAfterIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeforeOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAfterOut = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.OptionsMenuMinWidth = 297;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.AccessibleName = "Search Item";
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(1255, 254);
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
            this.dataLayoutControl1.Size = new System.Drawing.Size(1255, 408);
            this.dataLayoutControl1.Controls.SetChildIndex(this._GridControl, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this._SearchControl, 0);
            // 
            // _GridControl
            // 
            this._GridControl.DataSource = this._BindingSource;
            this._GridControl.Size = new System.Drawing.Size(1233, 322);
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompanyName,
            this.colBeforeIn,
            this.colAfterIn,
            this.colBeforeOut,
            this.colAfterOut});
            this._GridView.DetailHeight = 294;
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
            this.Root.Size = new System.Drawing.Size(1255, 408);
            // 
            // layoutControlItem1
            // 
            this.ItemForGridControl.Size = new System.Drawing.Size(1237, 326);
            // 
            // _SearchControl
            // 
            this._SearchControl.Size = new System.Drawing.Size(1233, 34);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(1237, 64);
            // 
            // _BindingSource
            // 
            this._BindingSource.DataSource = typeof(Domain.Entities.Attendance.AttendanceSettingRange);
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "Perusahaan";
            this.colCompanyName.FieldName = "Company.Name";
            this.colCompanyName.MinWidth = 30;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 0;
            this.colCompanyName.Width = 112;
            // 
            // colBeforeIn
            // 
            this.colBeforeIn.Caption = "Sebelum Jam Masuk";
            this.colBeforeIn.FieldName = "BeforeIn";
            this.colBeforeIn.MinWidth = 30;
            this.colBeforeIn.Name = "colBeforeIn";
            this.colBeforeIn.Visible = true;
            this.colBeforeIn.VisibleIndex = 1;
            this.colBeforeIn.Width = 112;
            // 
            // colAfterIn
            // 
            this.colAfterIn.Caption = "Sesudah Jam Masuk";
            this.colAfterIn.FieldName = "AfterIn";
            this.colAfterIn.MinWidth = 30;
            this.colAfterIn.Name = "colAfterIn";
            this.colAfterIn.Visible = true;
            this.colAfterIn.VisibleIndex = 2;
            this.colAfterIn.Width = 112;
            // 
            // colBeforeOut
            // 
            this.colBeforeOut.Caption = "Sebelum Jam Keluar";
            this.colBeforeOut.FieldName = "BeforeOut";
            this.colBeforeOut.MinWidth = 30;
            this.colBeforeOut.Name = "colBeforeOut";
            this.colBeforeOut.Visible = true;
            this.colBeforeOut.VisibleIndex = 3;
            this.colBeforeOut.Width = 112;
            // 
            // colAfterOut
            // 
            this.colAfterOut.Caption = "Sesudah Jam Keluar";
            this.colAfterOut.FieldName = "AfterOut";
            this.colAfterOut.MinWidth = 30;
            this.colAfterOut.Name = "colAfterOut";
            this.colAfterOut.Visible = true;
            this.colAfterOut.VisibleIndex = 4;
            this.colAfterOut.Width = 112;
            // 
            // frmAttendanceSettingRangeLV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 662);
            this.Name = "frmAttendanceSettingRangeLV";
            this.Text = "Toleransi Absensi";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colBeforeIn;
        private DevExpress.XtraGrid.Columns.GridColumn colAfterIn;
        private DevExpress.XtraGrid.Columns.GridColumn colBeforeOut;
        private DevExpress.XtraGrid.Columns.GridColumn colAfterOut;
    }
}
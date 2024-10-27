namespace VSTS.DESKTOP.BaseForm
{
    partial class frmBaseTLV
    {

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseTLV));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCopy = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarSubItem();
            this.bbiExportCsv = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportPdf = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportHtml = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportXls = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportDoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportDocX = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTasks = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this._TreeList = new DevExpress.XtraTreeList.TreeList();
            this._SearchControl = new DevExpress.XtraEditors.SearchControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTreeList = new DevExpress.XtraLayout.LayoutControlItem();
            this._BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiRefresh,
            this.bbiNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiCopy,
            this.bbiPrintPreview,
            this.bbiExport,
            this.bbiExportCsv,
            this.bbiExportPdf,
            this.bbiExportHtml,
            this.bbiExportXls,
            this.bbiExportXlsx,
            this.bbiExportDoc,
            this.bbiExportDocX,
            this.bbiClose,
            this.skinPaletteRibbonGalleryBarItem1});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1212, 254);
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.CausesValidation = true;
            this.bbiRefresh.Id = 1;
            this.bbiRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiRefresh.ImageOptions.SvgImage")));
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "New";
            this.bbiNew.Id = 5;
            this.bbiNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiNew.ImageOptions.SvgImage")));
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Edit";
            this.bbiEdit.Id = 6;
            this.bbiEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiEdit.ImageOptions.SvgImage")));
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 7;
            this.bbiDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiDelete.ImageOptions.SvgImage")));
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiCopy
            // 
            this.bbiCopy.Caption = "Copy";
            this.bbiCopy.Id = 8;
            this.bbiCopy.Name = "bbiCopy";
            this.bbiCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCopy_ItemClick);
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 9;
            this.bbiPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPrintPreview.ImageOptions.SvgImage")));
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintPreview_ItemClick);
            // 
            // bbiExport
            // 
            this.bbiExport.Caption = "Export";
            this.bbiExport.Id = 10;
            this.bbiExport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExport.ImageOptions.SvgImage")));
            this.bbiExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiExportCsv, DevExpress.XtraBars.BarItemPaintStyle.Standard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportPdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportHtml),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportXls),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportXlsx),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportDoc),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportDocX)});
            this.bbiExport.Name = "bbiExport";
            // 
            // bbiExportCsv
            // 
            this.bbiExportCsv.Caption = "CSV";
            this.bbiExportCsv.Id = 11;
            this.bbiExportCsv.Name = "bbiExportCsv";
            this.bbiExportCsv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportCsv_ItemClick);
            // 
            // bbiExportPdf
            // 
            this.bbiExportPdf.Caption = "PDF";
            this.bbiExportPdf.Id = 12;
            this.bbiExportPdf.Name = "bbiExportPdf";
            this.bbiExportPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportPdf_ItemClick);
            // 
            // bbiExportHtml
            // 
            this.bbiExportHtml.Caption = "HTML";
            this.bbiExportHtml.Id = 13;
            this.bbiExportHtml.Name = "bbiExportHtml";
            this.bbiExportHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportHtml_ItemClick);
            // 
            // bbiExportXls
            // 
            this.bbiExportXls.Caption = "Excel (*.xls)";
            this.bbiExportXls.Id = 14;
            this.bbiExportXls.Name = "bbiExportXls";
            this.bbiExportXls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportXls_ItemClick);
            // 
            // bbiExportXlsx
            // 
            this.bbiExportXlsx.Caption = "Excel (*.xlsx)";
            this.bbiExportXlsx.Id = 15;
            this.bbiExportXlsx.Name = "bbiExportXlsx";
            this.bbiExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportXlsx_ItemClick);
            // 
            // bbiExportDoc
            // 
            this.bbiExportDoc.Caption = "Word (*.doc)";
            this.bbiExportDoc.Id = 16;
            this.bbiExportDoc.Name = "bbiExportDoc";
            this.bbiExportDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportDoc_ItemClick);
            // 
            // bbiExportDocX
            // 
            this.bbiExportDocX.Caption = "Word (*.docx)";
            this.bbiExportDocX.Id = 17;
            this.bbiExportDocX.Name = "bbiExportDocX";
            this.bbiExportDocX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportDocX_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 18;
            this.bbiClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiClose.ImageOptions.SvgImage")));
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // skinPaletteRibbonGalleryBarItem1
            // 
            this.skinPaletteRibbonGalleryBarItem1.Caption = "skinPaletteRibbonGalleryBarItem1";
            this.skinPaletteRibbonGalleryBarItem1.Id = 19;
            this.skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
            // 
            // ribbonPage
            // 
            this.ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgTasks,
            this.rpgClose});
            this.ribbonPage.MergeOrder = 0;
            this.ribbonPage.Name = "ribbonPage";
            this.ribbonPage.Text = "Beranda";
            // 
            // rpgTasks
            // 
            this.rpgTasks.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.rpgTasks.ItemLinks.Add(this.bbiRefresh);
            this.rpgTasks.ItemLinks.Add(this.bbiNew, true);
            this.rpgTasks.ItemLinks.Add(this.bbiEdit);
            this.rpgTasks.ItemLinks.Add(this.bbiDelete);
            this.rpgTasks.ItemLinks.Add(this.bbiPrintPreview, true);
            this.rpgTasks.ItemLinks.Add(this.bbiExport);
            this.rpgTasks.MergeOrder = 0;
            this.rpgTasks.Name = "rpgTasks";
            this.rpgTasks.Text = "Tasks";
            // 
            // rpgClose
            // 
            this.rpgClose.ItemLinks.Add(this.bbiClose);
            this.rpgClose.MergeOrder = 0;
            this.rpgClose.Name = "rpgClose";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this._TreeList);
            this.dataLayoutControl1.Controls.Add(this._SearchControl);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 254);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1212, 394);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // _TreeList
            // 
            this._TreeList.KeyFieldName = "Id";
            this._TreeList.Location = new System.Drawing.Point(11, 75);
            this._TreeList.MenuManager = this.ribbonControl;
            this._TreeList.Name = "_TreeList";
            this._TreeList.ParentFieldName = "ParentId";
            this._TreeList.Size = new System.Drawing.Size(1190, 308);
            this._TreeList.TabIndex = 6;
            // 
            // _SearchControl
            // 
            this._SearchControl.Client = this._TreeList;
            this._SearchControl.Location = new System.Drawing.Point(11, 37);
            this._SearchControl.MenuManager = this.ribbonControl;
            this._SearchControl.Name = "_SearchControl";
            this._SearchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this._SearchControl.Properties.Client = this._TreeList;
            this._SearchControl.Size = new System.Drawing.Size(1190, 34);
            this._SearchControl.StyleController = this.dataLayoutControl1;
            this._SearchControl.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.ItemForTreeList});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1212, 394);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this._SearchControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1194, 64);
            this.layoutControlItem2.Text = "Pencarian Cepat";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(112, 21);
            // 
            // ItemForTreeList
            // 
            this.ItemForTreeList.Control = this._TreeList;
            this.ItemForTreeList.Location = new System.Drawing.Point(0, 64);
            this.ItemForTreeList.Name = "ItemForTreeList";
            this.ItemForTreeList.Size = new System.Drawing.Size(1194, 312);
            this.ItemForTreeList.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForTreeList.TextVisible = false;
            // 
            // frmBaseTLV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 648);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "frmBaseTLV";
            this.Ribbon = this.ribbonControl;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        public DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTasks;
        public DevExpress.XtraBars.BarButtonItem bbiRefresh;
        public DevExpress.XtraBars.BarButtonItem bbiNew;
        public DevExpress.XtraBars.BarButtonItem bbiEdit;
        public DevExpress.XtraBars.BarButtonItem bbiDelete;
        public DevExpress.XtraBars.BarButtonItem bbiCopy;
        public DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        public DevExpress.XtraBars.BarSubItem bbiExport;
        public DevExpress.XtraBars.BarButtonItem bbiExportCsv;
        public DevExpress.XtraBars.BarButtonItem bbiExportPdf;
        public DevExpress.XtraBars.BarButtonItem bbiExportHtml;
        public DevExpress.XtraBars.BarButtonItem bbiExportXls;
        public DevExpress.XtraBars.BarButtonItem bbiExportXlsx;
        public DevExpress.XtraBars.BarButtonItem bbiExportDoc;
        public DevExpress.XtraBars.BarButtonItem bbiExportDocX;
        public DevExpress.XtraBars.BarButtonItem bbiClose;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgClose;
        public DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        public DevExpress.XtraLayout.LayoutControlGroup Root;
        public DevExpress.XtraEditors.SearchControl _SearchControl;
        public DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        public System.Windows.Forms.BindingSource _BindingSource;
        public DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        public DevExpress.XtraTreeList.TreeList _TreeList;
        public DevExpress.XtraLayout.LayoutControlItem ItemForTreeList;
        private System.ComponentModel.IContainer components;
    }
}
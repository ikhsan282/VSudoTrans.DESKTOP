using VSTS.DESKTOP.Descendant;

namespace VSTS.DESKTOP.BaseForm
{
    partial class frmBaseFilterTLV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseFilterTLV));
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
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTasks = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this._SearchControl = new DevExpress.XtraEditors.SearchControl();
            this._TreeList = new DevExpress.XtraTreeList.TreeList();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTreeList = new DevExpress.XtraLayout.LayoutControlItem();
            this._DockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this._DockPanelRight = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dataLayoutControl2 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.FilterDate2 = new DevExpress.XtraEditors.DateEdit();
            this.FilterDate1 = new DevExpress.XtraEditors.DateEdit();
            this.FilterPopUp3 = new VSTS.DESKTOP.Descendant.PopupContainerEditOwn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this._LayoutControlItemFilter1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this._LayoutControlItemFilter2 = new DevExpress.XtraLayout.LayoutControlItem();
            this._LayoutControlItemFilter3 = new DevExpress.XtraLayout.LayoutControlItem();
            this._BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._DxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.bbiImport = new DevExpress.XtraBars.BarSubItem();
            this.bbiTemplateImport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImportData = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DockManager)).BeginInit();
            this._DockPanelRight.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).BeginInit();
            this.dataLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPopUp3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
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
            this.bbiImport,
            this.bbiTemplateImport,
            this.bbiImportData});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 22;
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
            this.bbiCopy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiCopy.ImageOptions.SvgImage")));
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
            this.bbiExportCsv.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportCsv.ImageOptions.SvgImage")));
            this.bbiExportCsv.Name = "bbiExportCsv";
            this.bbiExportCsv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportCsv_ItemClick);
            // 
            // bbiExportPdf
            // 
            this.bbiExportPdf.Caption = "PDF";
            this.bbiExportPdf.Id = 12;
            this.bbiExportPdf.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportPdf.ImageOptions.SvgImage")));
            this.bbiExportPdf.Name = "bbiExportPdf";
            this.bbiExportPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportPdf_ItemClick);
            // 
            // bbiExportHtml
            // 
            this.bbiExportHtml.Caption = "HTML";
            this.bbiExportHtml.Id = 13;
            this.bbiExportHtml.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportHtml.ImageOptions.SvgImage")));
            this.bbiExportHtml.Name = "bbiExportHtml";
            this.bbiExportHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportHtml_ItemClick);
            // 
            // bbiExportXls
            // 
            this.bbiExportXls.Caption = "Excel (*.xls)";
            this.bbiExportXls.Id = 14;
            this.bbiExportXls.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportXls.ImageOptions.SvgImage")));
            this.bbiExportXls.Name = "bbiExportXls";
            this.bbiExportXls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportXls_ItemClick);
            // 
            // bbiExportXlsx
            // 
            this.bbiExportXlsx.Caption = "Excel (*.xlsx)";
            this.bbiExportXlsx.Id = 15;
            this.bbiExportXlsx.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportXlsx.ImageOptions.SvgImage")));
            this.bbiExportXlsx.Name = "bbiExportXlsx";
            this.bbiExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportXlsx_ItemClick);
            // 
            // bbiExportDoc
            // 
            this.bbiExportDoc.Caption = "Word (*.doc)";
            this.bbiExportDoc.Id = 16;
            this.bbiExportDoc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportDoc.ImageOptions.SvgImage")));
            this.bbiExportDoc.Name = "bbiExportDoc";
            this.bbiExportDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportDoc_ItemClick);
            // 
            // bbiExportDocX
            // 
            this.bbiExportDocX.Caption = "Word (*.docx)";
            this.bbiExportDocX.Id = 17;
            this.bbiExportDocX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExportDocX.ImageOptions.SvgImage")));
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
            this.rpgTasks.ItemLinks.Add(this.bbiImport);
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
            this.dataLayoutControl1.Controls.Add(this._SearchControl);
            this.dataLayoutControl1.Controls.Add(this._TreeList);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 254);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(890, 394);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
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
            this._SearchControl.Size = new System.Drawing.Size(868, 34);
            this._SearchControl.StyleController = this.dataLayoutControl1;
            this._SearchControl.TabIndex = 5;
            // 
            // _TreeList
            // 
            this._TreeList.KeyFieldName = "Id";
            this._TreeList.Location = new System.Drawing.Point(11, 75);
            this._TreeList.Name = "_TreeList";
            this._TreeList.ParentFieldName = "ParentId";
            this._TreeList.Size = new System.Drawing.Size(868, 308);
            this._TreeList.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.ItemForTreeList});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(890, 394);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this._SearchControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(872, 64);
            this.layoutControlItem2.Text = "Pencarian Cepat";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(112, 21);
            // 
            // ItemForTreeList
            // 
            this.ItemForTreeList.Control = this._TreeList;
            this.ItemForTreeList.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForTreeList.CustomizationFormText = "ItemForTreeList";
            this.ItemForTreeList.Location = new System.Drawing.Point(0, 64);
            this.ItemForTreeList.Name = "ItemForTreeList";
            this.ItemForTreeList.Size = new System.Drawing.Size(872, 312);
            this.ItemForTreeList.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForTreeList.TextVisible = false;
            // 
            // _DockManager
            // 
            this._DockManager.Form = this;
            this._DockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this._DockPanelRight});
            this._DockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // _DockPanelRight
            // 
            this._DockPanelRight.Controls.Add(this.dockPanel1_Container);
            this._DockPanelRight.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this._DockPanelRight.ID = new System.Guid("d531d5a3-2a07-4ae4-95fb-ad35ce61584d");
            this._DockPanelRight.Location = new System.Drawing.Point(890, 254);
            this._DockPanelRight.Name = "_DockPanelRight";
            this._DockPanelRight.OriginalSize = new System.Drawing.Size(322, 200);
            this._DockPanelRight.Size = new System.Drawing.Size(322, 394);
            this._DockPanelRight.Text = "Filter";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.dataLayoutControl2);
            this.dockPanel1_Container.Location = new System.Drawing.Point(7, 47);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(311, 343);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Controls.Add(this.FilterDate2);
            this.dataLayoutControl2.Controls.Add(this.FilterDate1);
            this.dataLayoutControl2.Controls.Add(this.FilterPopUp3);
            this.dataLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl2.Name = "dataLayoutControl2";
            this.dataLayoutControl2.Root = this.layoutControlGroup1;
            this.dataLayoutControl2.Size = new System.Drawing.Size(311, 343);
            this.dataLayoutControl2.TabIndex = 0;
            this.dataLayoutControl2.Text = "dataLayoutControl2";
            // 
            // FilterDate2
            // 
            this.FilterDate2.EditValue = null;
            this.FilterDate2.Location = new System.Drawing.Point(11, 101);
            this.FilterDate2.MenuManager = this.ribbonControl;
            this.FilterDate2.Name = "FilterDate2";
            this.FilterDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FilterDate2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FilterDate2.Size = new System.Drawing.Size(289, 34);
            this.FilterDate2.StyleController = this.dataLayoutControl2;
            this.FilterDate2.TabIndex = 2;
            // 
            // FilterDate1
            // 
            this.FilterDate1.EditValue = null;
            this.FilterDate1.Location = new System.Drawing.Point(11, 37);
            this.FilterDate1.MenuManager = this.ribbonControl;
            this.FilterDate1.Name = "FilterDate1";
            this.FilterDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FilterDate1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FilterDate1.Size = new System.Drawing.Size(289, 34);
            this.FilterDate1.StyleController = this.dataLayoutControl2;
            this.FilterDate1.TabIndex = 0;
            // 
            // FilterPopUp3
            // 
            this.FilterPopUp3.Location = new System.Drawing.Point(11, 165);
            this.FilterPopUp3.MenuManager = this.ribbonControl;
            this.FilterPopUp3.Name = "FilterPopUp3";
            this.FilterPopUp3.ObjectId = null;
            this.FilterPopUp3.OptionsCascadeControl = null;
            this.FilterPopUp3.OptionsCascadeMember = null;
            this.FilterPopUp3.OptionsChildControl = null;
            this.FilterPopUp3.OptionsDataSource = null;
            this.FilterPopUp3.OptionsDataType = null;
            this.FilterPopUp3.OptionsDisplayCaption = null;
            this.FilterPopUp3.OptionsDisplayColumns = null;
            this.FilterPopUp3.OptionsDisplayText = null;
            this.FilterPopUp3.OptionsDisplayTitle = null;
            this.FilterPopUp3.OptionsDisplayWidth = null;
            this.FilterPopUp3.OptionsFilterColumns = null;
            this.FilterPopUp3.OptionsSortColumns = null;
            this.FilterPopUp3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FilterPopUp3.Properties.NullText = "[EditValue is null]";
            this.FilterPopUp3.Properties.ObjectId = null;
            this.FilterPopUp3.Properties.OptionsCascadeControl = null;
            this.FilterPopUp3.Properties.OptionsCascadeMember = "";
            this.FilterPopUp3.Properties.OptionsChildControl = null;
            this.FilterPopUp3.Properties.OptionsDataSource = null;
            this.FilterPopUp3.Properties.OptionsDataType = VSTS.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.FilterPopUp3.Properties.OptionsDisplayCaption = "";
            this.FilterPopUp3.Properties.OptionsDisplayColumns = "";
            this.FilterPopUp3.Properties.OptionsDisplayFormat = "";
            this.FilterPopUp3.Properties.OptionsDisplayText = "";
            this.FilterPopUp3.Properties.OptionsDisplayTitle = "";
            this.FilterPopUp3.Properties.OptionsDisplayWidth = "";
            this.FilterPopUp3.Properties.OptionsFilterColumns = "";
            this.FilterPopUp3.Properties.OptionsSortColumns = "";
            this.FilterPopUp3.Size = new System.Drawing.Size(289, 34);
            this.FilterPopUp3.StyleController = this.dataLayoutControl2;
            this.FilterPopUp3.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this._LayoutControlItemFilter1,
            this.emptySpaceItem1,
            this._LayoutControlItemFilter2,
            this._LayoutControlItemFilter3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(311, 343);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // _LayoutControlItemFilter1
            // 
            this._LayoutControlItemFilter1.Control = this.FilterDate1;
            this._LayoutControlItemFilter1.Location = new System.Drawing.Point(0, 0);
            this._LayoutControlItemFilter1.Name = "_LayoutControlItemFilter1";
            this._LayoutControlItemFilter1.Size = new System.Drawing.Size(293, 64);
            this._LayoutControlItemFilter1.TextLocation = DevExpress.Utils.Locations.Top;
            this._LayoutControlItemFilter1.TextSize = new System.Drawing.Size(181, 21);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 192);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(293, 133);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // _LayoutControlItemFilter2
            // 
            this._LayoutControlItemFilter2.Control = this.FilterDate2;
            this._LayoutControlItemFilter2.Location = new System.Drawing.Point(0, 64);
            this._LayoutControlItemFilter2.Name = "_LayoutControlItemFilter2";
            this._LayoutControlItemFilter2.Size = new System.Drawing.Size(293, 64);
            this._LayoutControlItemFilter2.TextLocation = DevExpress.Utils.Locations.Top;
            this._LayoutControlItemFilter2.TextSize = new System.Drawing.Size(181, 21);
            // 
            // _LayoutControlItemFilter3
            // 
            this._LayoutControlItemFilter3.Control = this.FilterPopUp3;
            this._LayoutControlItemFilter3.Location = new System.Drawing.Point(0, 128);
            this._LayoutControlItemFilter3.Name = "_LayoutControlItemFilter3";
            this._LayoutControlItemFilter3.Size = new System.Drawing.Size(293, 64);
            this._LayoutControlItemFilter3.TextLocation = DevExpress.Utils.Locations.Top;
            this._LayoutControlItemFilter3.TextSize = new System.Drawing.Size(181, 21);
            // 
            // bbiImport
            // 
            this.bbiImport.Caption = "Import";
            this.bbiImport.Id = 19;
            this.bbiImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiImport.ImageOptions.SvgImage")));
            this.bbiImport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiTemplateImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiImportData)});
            this.bbiImport.Name = "bbiImport";
            // 
            // bbiTemplateImport
            // 
            this.bbiTemplateImport.Caption = "Template Import";
            this.bbiTemplateImport.Id = 20;
            this.bbiTemplateImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiTemplateImport.ImageOptions.SvgImage")));
            this.bbiTemplateImport.Name = "bbiTemplateImport";
            // 
            // bbiImportData
            // 
            this.bbiImportData.Caption = "Import Data";
            this.bbiImportData.Id = 21;
            this.bbiImportData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiImportData.ImageOptions.SvgImage")));
            this.bbiImportData.Name = "bbiImportData";
            // 
            // frmBaseFilterTLV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 648);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this._DockPanelRight);
            this.Controls.Add(this.ribbonControl);
            this.Name = "frmBaseFilterTLV";
            this.Ribbon = this.ribbonControl;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DockManager)).EndInit();
            this._DockPanelRight.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).EndInit();
            this.dataLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPopUp3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
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
        public DevExpress.XtraBars.Docking.DockManager _DockManager;
        public DevExpress.XtraBars.Docking.DockPanel _DockPanelRight;
        public DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        public DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl2;
        public DevExpress.XtraEditors.DateEdit FilterDate1;
        public DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        public DevExpress.XtraLayout.LayoutControlItem _LayoutControlItemFilter1;
        public DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        public DevExpress.XtraEditors.DateEdit FilterDate2;
        public DevExpress.XtraLayout.LayoutControlItem _LayoutControlItemFilter2;
        public DevExpress.XtraLayout.LayoutControlItem _LayoutControlItemFilter3;
        public System.Windows.Forms.BindingSource _BindingSource;
        public PopupContainerEditOwn FilterPopUp3;
        public DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider _DxValidationProvider;
        public DevExpress.XtraTreeList.TreeList _TreeList;
        public DevExpress.XtraLayout.LayoutControlItem ItemForTreeList;
        public DevExpress.XtraBars.BarSubItem bbiImport;
        public System.ComponentModel.IContainer components;
        public DevExpress.XtraBars.BarButtonItem bbiTemplateImport;
        public DevExpress.XtraBars.BarButtonItem bbiImportData;
    }
}
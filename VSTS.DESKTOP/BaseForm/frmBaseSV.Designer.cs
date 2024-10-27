using VSTS.DESKTOP.Descendant;

namespace VSTS.DESKTOP.BaseForm
{
    partial class frmBaseSV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseSV));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTasks = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this._BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
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
            this._DxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this._spreadsheetControl = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.ItemForSpreetshead = new DevExpress.XtraLayout.LayoutControlItem();
            this.spreadsheetBarController1 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController(this.components);
            this.commonRibbonPageGroup1 = new DevExpress.XtraSpreadsheet.UI.CommonRibbonPageGroup();
            this.fileRibbonPage1 = new DevExpress.XtraSpreadsheet.UI.FileRibbonPage();
            this.spreadsheetCommandBarButtonItem1 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem2 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem3 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem4 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem5 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem6 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem7 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem8 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem9 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.infoRibbonPageGroup1 = new DevExpress.XtraSpreadsheet.UI.InfoRibbonPageGroup();
            this.spreadsheetCommandBarButtonItem10 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            this.spreadsheetCommandBarButtonItem11 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSpreetshead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetBarController1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiRefresh,
            this.bbiPrintPreview,
            this.bbiClose,
            this.spreadsheetCommandBarButtonItem1,
            this.spreadsheetCommandBarButtonItem2,
            this.spreadsheetCommandBarButtonItem3,
            this.spreadsheetCommandBarButtonItem4,
            this.spreadsheetCommandBarButtonItem5,
            this.spreadsheetCommandBarButtonItem6,
            this.spreadsheetCommandBarButtonItem7,
            this.spreadsheetCommandBarButtonItem8,
            this.spreadsheetCommandBarButtonItem9,
            this.spreadsheetCommandBarButtonItem10,
            this.spreadsheetCommandBarButtonItem11});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 30;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage,
            this.fileRibbonPage1});
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
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 9;
            this.bbiPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPrintPreview.ImageOptions.SvgImage")));
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintPreview_ItemClick);
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
            this.rpgTasks.ItemLinks.Add(this.bbiPrintPreview, true);
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
            this.dataLayoutControl1.Controls.Add(this._spreadsheetControl);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 254);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(890, 394);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSpreetshead});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(890, 394);
            this.Root.TextVisible = false;
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
            // _spreadsheetControl
            // 
            this._spreadsheetControl.Location = new System.Drawing.Point(23, 11);
            this._spreadsheetControl.MenuManager = this.ribbonControl;
            this._spreadsheetControl.Name = "_spreadsheetControl";
            this._spreadsheetControl.Size = new System.Drawing.Size(856, 372);
            this._spreadsheetControl.TabIndex = 4;
            this._spreadsheetControl.Text = "spreadsheetControl1";
            // 
            // ItemForSpreetshead
            // 
            this.ItemForSpreetshead.Control = this._spreadsheetControl;
            this.ItemForSpreetshead.Location = new System.Drawing.Point(0, 0);
            this.ItemForSpreetshead.Name = "ItemForSpreetshead";
            this.ItemForSpreetshead.Size = new System.Drawing.Size(872, 376);
            this.ItemForSpreetshead.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForSpreetshead.TextVisible = false;
            // 
            // spreadsheetBarController1
            // 
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem1);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem2);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem3);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem4);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem5);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem6);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem7);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem8);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem9);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem10);
            this.spreadsheetBarController1.BarItems.Add(this.spreadsheetCommandBarButtonItem11);
            this.spreadsheetBarController1.Control = this._spreadsheetControl;
            // 
            // commonRibbonPageGroup1
            // 
            this.commonRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.commonRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem1);
            this.commonRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem2);
            this.commonRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem3);
            this.commonRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem4);
            this.commonRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem5);
            this.commonRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem6);
            this.commonRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem7);
            this.commonRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem8);
            this.commonRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem9);
            this.commonRibbonPageGroup1.Name = "commonRibbonPageGroup1";
            // 
            // fileRibbonPage1
            // 
            this.fileRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.commonRibbonPageGroup1,
            this.infoRibbonPageGroup1});
            this.fileRibbonPage1.Name = "fileRibbonPage1";
            // 
            // spreadsheetCommandBarButtonItem1
            // 
            this.spreadsheetCommandBarButtonItem1.CommandName = "FileNew";
            this.spreadsheetCommandBarButtonItem1.Id = 19;
            this.spreadsheetCommandBarButtonItem1.Name = "spreadsheetCommandBarButtonItem1";
            // 
            // spreadsheetCommandBarButtonItem2
            // 
            this.spreadsheetCommandBarButtonItem2.CommandName = "FileOpen";
            this.spreadsheetCommandBarButtonItem2.Id = 20;
            this.spreadsheetCommandBarButtonItem2.Name = "spreadsheetCommandBarButtonItem2";
            // 
            // spreadsheetCommandBarButtonItem3
            // 
            this.spreadsheetCommandBarButtonItem3.CommandName = "FileSave";
            this.spreadsheetCommandBarButtonItem3.Id = 21;
            this.spreadsheetCommandBarButtonItem3.Name = "spreadsheetCommandBarButtonItem3";
            // 
            // spreadsheetCommandBarButtonItem4
            // 
            this.spreadsheetCommandBarButtonItem4.CommandName = "FileSaveAs";
            this.spreadsheetCommandBarButtonItem4.Id = 22;
            this.spreadsheetCommandBarButtonItem4.Name = "spreadsheetCommandBarButtonItem4";
            // 
            // spreadsheetCommandBarButtonItem5
            // 
            this.spreadsheetCommandBarButtonItem5.CommandName = "FileQuickPrint";
            this.spreadsheetCommandBarButtonItem5.Id = 23;
            this.spreadsheetCommandBarButtonItem5.Name = "spreadsheetCommandBarButtonItem5";
            // 
            // spreadsheetCommandBarButtonItem6
            // 
            this.spreadsheetCommandBarButtonItem6.CommandName = "FilePrint";
            this.spreadsheetCommandBarButtonItem6.Id = 24;
            this.spreadsheetCommandBarButtonItem6.Name = "spreadsheetCommandBarButtonItem6";
            // 
            // spreadsheetCommandBarButtonItem7
            // 
            this.spreadsheetCommandBarButtonItem7.CommandName = "FilePrintPreview";
            this.spreadsheetCommandBarButtonItem7.Id = 25;
            this.spreadsheetCommandBarButtonItem7.Name = "spreadsheetCommandBarButtonItem7";
            // 
            // spreadsheetCommandBarButtonItem8
            // 
            this.spreadsheetCommandBarButtonItem8.CommandName = "FileUndo";
            this.spreadsheetCommandBarButtonItem8.Id = 26;
            this.spreadsheetCommandBarButtonItem8.Name = "spreadsheetCommandBarButtonItem8";
            // 
            // spreadsheetCommandBarButtonItem9
            // 
            this.spreadsheetCommandBarButtonItem9.CommandName = "FileRedo";
            this.spreadsheetCommandBarButtonItem9.Id = 27;
            this.spreadsheetCommandBarButtonItem9.Name = "spreadsheetCommandBarButtonItem9";
            // 
            // infoRibbonPageGroup1
            // 
            this.infoRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.infoRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem10);
            this.infoRibbonPageGroup1.ItemLinks.Add(this.spreadsheetCommandBarButtonItem11);
            this.infoRibbonPageGroup1.Name = "infoRibbonPageGroup1";
            // 
            // spreadsheetCommandBarButtonItem10
            // 
            this.spreadsheetCommandBarButtonItem10.CommandName = "FileEncrypt";
            this.spreadsheetCommandBarButtonItem10.Id = 28;
            this.spreadsheetCommandBarButtonItem10.Name = "spreadsheetCommandBarButtonItem10";
            // 
            // spreadsheetCommandBarButtonItem11
            // 
            this.spreadsheetCommandBarButtonItem11.CommandName = "FileShowDocumentProperties";
            this.spreadsheetCommandBarButtonItem11.Id = 29;
            this.spreadsheetCommandBarButtonItem11.Name = "spreadsheetCommandBarButtonItem11";
            // 
            // frmBaseSV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 648);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this._DockPanelRight);
            this.Controls.Add(this.ribbonControl);
            this.Name = "frmBaseSV";
            this.Ribbon = this.ribbonControl;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSpreetshead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetBarController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        public DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTasks;
        public DevExpress.XtraBars.BarButtonItem bbiRefresh;
        public DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        public DevExpress.XtraBars.BarButtonItem bbiClose;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgClose;
        public DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        public DevExpress.XtraLayout.LayoutControlGroup Root;
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
        public System.ComponentModel.IContainer components;
        public DevExpress.XtraSpreadsheet.SpreadsheetControl _spreadsheetControl;
        public DevExpress.XtraLayout.LayoutControlItem ItemForSpreetshead;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem1;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem2;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem3;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem4;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem5;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem6;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem7;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem8;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem9;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem10;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetCommandBarButtonItem spreadsheetCommandBarButtonItem11;
        public DevExpress.XtraSpreadsheet.UI.FileRibbonPage fileRibbonPage1;
        public DevExpress.XtraSpreadsheet.UI.CommonRibbonPageGroup commonRibbonPageGroup1;
        public DevExpress.XtraSpreadsheet.UI.InfoRibbonPageGroup infoRibbonPageGroup1;
        public DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController spreadsheetBarController1;
    }
}
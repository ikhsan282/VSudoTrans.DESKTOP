namespace VSTS.DESKTOP
{
    partial class frmMainMDI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMDI));
            this._RibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bsiDateTime = new DevExpress.XtraBars.BarStaticItem();
            this.bsiVersion = new DevExpress.XtraBars.BarStaticItem();
            this.skinDropDownButtonItem = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.skinPaletteRibbonGalleryBarItem = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.bsiRole = new DevExpress.XtraBars.BarStaticItem();
            this.bbiExitApp = new DevExpress.XtraBars.BarButtonItem();
            this.bsiCompany = new DevExpress.XtraBars.BarStaticItem();
            this.btnRestart = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUrl = new DevExpress.XtraBars.BarButtonItem();
            this.bciNavigationTree = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupRight = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this._DockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelNavigationTree = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this._NavigationTreeAccordion = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DockManager)).BeginInit();
            this.dockPanelNavigationTree.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._NavigationTreeAccordion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // _RibbonControl
            // 
            this._RibbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(45, 49, 45, 49);
            this._RibbonControl.ExpandCollapseItem.Id = 0;
            this._RibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this._RibbonControl.ExpandCollapseItem,
            this.barSubItem1,
            this.bsiDateTime,
            this.bsiVersion,
            this.skinDropDownButtonItem,
            this.skinPaletteRibbonGalleryBarItem,
            this.bsiUser,
            this.bsiRole,
            this.bbiExitApp,
            this.bsiCompany,
            this.btnRestart,
            this.bsiUrl,
            this.bciNavigationTree});
            this._RibbonControl.Location = new System.Drawing.Point(0, 0);
            this._RibbonControl.Margin = new System.Windows.Forms.Padding(4);
            this._RibbonControl.MaxItemId = 19;
            this._RibbonControl.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this._RibbonControl.Name = "_RibbonControl";
            this._RibbonControl.OptionsMenuMinWidth = 495;
            this._RibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage,
            this.ribbonPage1});
            this._RibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this._RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this._RibbonControl.Size = new System.Drawing.Size(1212, 254);
            this._RibbonControl.StatusBar = this.ribbonStatusBar1;
            this._RibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this._RibbonControl.Merge += new DevExpress.XtraBars.Ribbon.RibbonMergeEventHandler(this._RibbonControl_Merge);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Navigation";
            this.barSubItem1.Id = 2;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bsiDateTime
            // 
            this.bsiDateTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiDateTime.Caption = "Tanggal :";
            this.bsiDateTime.Id = 4;
            this.bsiDateTime.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsiDateTime.ImageOptions.SvgImage")));
            this.bsiDateTime.Name = "bsiDateTime";
            this.bsiDateTime.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bsiVersion
            // 
            this.bsiVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiVersion.Caption = "Versi : 1.0.0.0";
            this.bsiVersion.Id = 5;
            this.bsiVersion.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsiVersion.ImageOptions.SvgImage")));
            this.bsiVersion.Name = "bsiVersion";
            this.bsiVersion.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // skinDropDownButtonItem
            // 
            this.skinDropDownButtonItem.Id = 7;
            this.skinDropDownButtonItem.Name = "skinDropDownButtonItem";
            // 
            // skinPaletteRibbonGalleryBarItem
            // 
            this.skinPaletteRibbonGalleryBarItem.Caption = "Skin Palette";
            this.skinPaletteRibbonGalleryBarItem.Id = 9;
            this.skinPaletteRibbonGalleryBarItem.Name = "skinPaletteRibbonGalleryBarItem";
            // 
            // bsiUser
            // 
            this.bsiUser.Caption = "Pengguna :";
            this.bsiUser.Id = 11;
            this.bsiUser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsiUser.ImageOptions.SvgImage")));
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bsiRole
            // 
            this.bsiRole.Caption = "Peran :";
            this.bsiRole.Id = 12;
            this.bsiRole.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsiRole.ImageOptions.SvgImage")));
            this.bsiRole.Name = "bsiRole";
            this.bsiRole.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiExitApp
            // 
            this.bbiExitApp.Caption = "Exit Application";
            this.bbiExitApp.Id = 13;
            this.bbiExitApp.Name = "bbiExitApp";
            this.bbiExitApp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExitApp_ItemClick);
            // 
            // bsiCompany
            // 
            this.bsiCompany.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiCompany.Caption = "Sekolah :";
            this.bsiCompany.Id = 14;
            this.bsiCompany.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsiCompany.ImageOptions.SvgImage")));
            this.bsiCompany.Name = "bsiCompany";
            this.bsiCompany.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnRestart
            // 
            this.btnRestart.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnRestart.Caption = "Restart";
            this.btnRestart.Id = 15;
            this.btnRestart.ItemAppearance.Disabled.BackColor = System.Drawing.Color.Red;
            this.btnRestart.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.White;
            this.btnRestart.ItemAppearance.Disabled.Options.UseBackColor = true;
            this.btnRestart.ItemAppearance.Disabled.Options.UseForeColor = true;
            this.btnRestart.ItemAppearance.Normal.BackColor = System.Drawing.Color.Red;
            this.btnRestart.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.btnRestart.ItemAppearance.Normal.Options.UseBackColor = true;
            this.btnRestart.ItemAppearance.Normal.Options.UseForeColor = true;
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiUrl
            // 
            this.bsiUrl.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUrl.Caption = "Url :";
            this.bsiUrl.Id = 16;
            this.bsiUrl.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsiUrl.ImageOptions.SvgImage")));
            this.bsiUrl.Name = "bsiUrl";
            // 
            // bciNavigationTree
            // 
            this.bciNavigationTree.BindableChecked = true;
            this.bciNavigationTree.Caption = "Navigation Tree";
            this.bciNavigationTree.Checked = true;
            this.bciNavigationTree.Id = 18;
            this.bciNavigationTree.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bciNavigationTree.ImageOptions.SvgImage")));
            this.bciNavigationTree.Name = "bciNavigationTree";
            // 
            // ribbonPage
            // 
            this.ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupRight});
            this.ribbonPage.Name = "ribbonPage";
            this.ribbonPage.Text = "Beranda";
            // 
            // ribbonPageGroupRight
            // 
            this.ribbonPageGroupRight.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroupRight.ItemLinks.Add(this.bciNavigationTree);
            this.ribbonPageGroupRight.MergeOrder = 10;
            this.ribbonPageGroupRight.Name = "ribbonPageGroupRight";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Tema";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.skinDropDownButtonItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.skinPaletteRibbonGalleryBarItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Penampilan";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUrl);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiCompany);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiDateTime);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiVersion);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiRole);
            this.ribbonStatusBar1.ItemLinks.Add(this.btnRestart);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 721);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this._RibbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1212, 47);
            // 
            // _DockManager
            // 
            this._DockManager.Form = this;
            this._DockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelNavigationTree});
            this._DockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockPanelNavigationTree
            // 
            this.dockPanelNavigationTree.Controls.Add(this.dockPanel1_Container);
            this.dockPanelNavigationTree.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelNavigationTree.ID = new System.Guid("da17be96-1c96-4d7c-8892-23b4aeb90ce5");
            this.dockPanelNavigationTree.Location = new System.Drawing.Point(0, 254);
            this.dockPanelNavigationTree.Name = "dockPanelNavigationTree";
            this.dockPanelNavigationTree.OriginalSize = new System.Drawing.Size(341, 200);
            this.dockPanelNavigationTree.Size = new System.Drawing.Size(341, 467);
            this.dockPanelNavigationTree.Text = "Navigasi";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this._NavigationTreeAccordion);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 47);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(330, 416);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // _NavigationTreeAccordion
            // 
            this._NavigationTreeAccordion.Dock = System.Windows.Forms.DockStyle.Fill;
            this._NavigationTreeAccordion.Location = new System.Drawing.Point(0, 0);
            this._NavigationTreeAccordion.Name = "_NavigationTreeAccordion";
            this._NavigationTreeAccordion.Size = new System.Drawing.Size(330, 416);
            this._NavigationTreeAccordion.TabIndex = 5;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmMainMDI
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 768);
            this.Controls.Add(this.dockPanelNavigationTree);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this._RibbonControl);
            this.IconOptions.ColorizeInactiveIcon = DevExpress.Utils.DefaultBoolean.True;
            this.IconOptions.Image = global::VSTS.DESKTOP.Properties.Resources.logo_panca;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMainMDI";
            this.Ribbon = this._RibbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Sistem Keuangan Pancakarya";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainMDI_Load);
            ((System.ComponentModel.ISupportInitialize)(this._RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DockManager)).EndInit();
            this.dockPanelNavigationTree.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._NavigationTreeAccordion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl _RibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Docking.DockManager _DockManager;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem bsiDateTime;
        private DevExpress.XtraBars.BarStaticItem bsiVersion;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelNavigationTree;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Navigation.AccordionControl _NavigationTreeAccordion;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarStaticItem bsiRole;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupRight;
        private DevExpress.XtraBars.BarButtonItem bbiExitApp;
        private DevExpress.XtraBars.BarStaticItem bsiCompany;
        private DevExpress.XtraBars.BarButtonItem btnRestart;
        private DevExpress.XtraBars.BarButtonItem bsiUrl;
        private DevExpress.XtraBars.BarCheckItem bciNavigationTree;
    }
}


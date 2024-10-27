namespace VSTS.DESKTOP.Transaction.Attendance
{
    partial class frmRosterLV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRosterLV));
            this._BandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this._PopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbiChangeShift = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDetailRoster = new DevExpress.XtraBars.BarButtonItem();
            this.FilterSearchLookUp4 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._LayoutControlItemFilter4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bbiPollingAttendance = new DevExpress.XtraBars.BarButtonItem();
            this.FilterPopUp4 = new VSTS.DESKTOP.Descendant.PopupContainerEditOwn();
            this._LayoutControlItemFilter5 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this._BandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._PopupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterSearchLookUp4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPopUp4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter5)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(30, 27, 30, 27);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiPollingAttendance,
            this.bbiDetailRoster,
            this.bbiChangeShift});
            this.ribbonControl.MaxItemId = 22;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.AccessibleName = "Search Item";
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(1211, 254);
            // 
            // rpgTasks
            // 
            this.rpgTasks.ItemLinks.Add(this.bbiPollingAttendance);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiRefresh.ImageOptions.SvgImage")));
            // 
            // bbiNew
            // 
            this.bbiNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiNew.ImageOptions.SvgImage")));
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
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
            this.dataLayoutControl1.Size = new System.Drawing.Size(889, 420);
            this.dataLayoutControl1.Controls.SetChildIndex(this._GridControl, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this._SearchControl, 0);
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
            this._GridControl.MainView = this._BandedGridView;
            this._GridControl.Size = new System.Drawing.Size(867, 334);
            this._GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._BandedGridView});
            // 
            // _GridView
            // 
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
            this.Root.Size = new System.Drawing.Size(889, 420);
            // 
            // layoutControlItem1
            // 
            this.ItemForGridControl.Size = new System.Drawing.Size(871, 338);
            // 
            // _SearchControl
            // 
            this._SearchControl.Size = new System.Drawing.Size(867, 34);
            this._SearchControl.TabIndex = 0;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(871, 64);
            // 
            // _DockPanelRight
            // 
            this._DockPanelRight.Location = new System.Drawing.Point(889, 254);
            this._DockPanelRight.Size = new System.Drawing.Size(322, 420);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Size = new System.Drawing.Size(311, 369);
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Controls.Add(this.FilterPopUp4);
            this.dataLayoutControl2.Size = new System.Drawing.Size(311, 369);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterPopUp3, 0);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterDate1, 0);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterDate2, 0);
            this.dataLayoutControl2.Controls.SetChildIndex(this.FilterPopUp4, 0);
            // 
            // FilterDate1
            // 
            this.FilterDate1.EditValue = null;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this._LayoutControlItemFilter5});
            this.layoutControlGroup1.Size = new System.Drawing.Size(311, 369);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 256);
            this.emptySpaceItem1.Size = new System.Drawing.Size(293, 95);
            // 
            // FilterDate2
            // 
            this.FilterDate2.EditValue = null;
            // 
            // FilterPopUp3
            // 
            this.FilterPopUp3.Properties.Appearance.Options.UseTextOptions = true;
            this.FilterPopUp3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            // 
            // _BandedGridView
            // 
            this._BandedGridView.DetailHeight = 428;
            this._BandedGridView.GridControl = this._GridControl;
            this._BandedGridView.Name = "_BandedGridView";
            this._BandedGridView.OptionsBehavior.Editable = false;
            this._BandedGridView.OptionsFind.AllowFindPanel = false;
            this._BandedGridView.OptionsSelection.MultiSelect = true;
            this._BandedGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this._BandedGridView.OptionsView.ColumnAutoWidth = false;
            this._BandedGridView.OptionsView.ShowGroupPanel = false;
            // 
            // _PopupMenu
            // 
            this._PopupMenu.ItemLinks.Add(this.bbiChangeShift);
            this._PopupMenu.ItemLinks.Add(this.bbiDetailRoster);
            this._PopupMenu.Name = "_PopupMenu";
            this._PopupMenu.Ribbon = this.ribbonControl;
            // 
            // bbiChangeShift
            // 
            this.bbiChangeShift.Caption = "Ubah Shift";
            this.bbiChangeShift.Id = 21;
            this.bbiChangeShift.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiChangeShift.ImageOptions.SvgImage")));
            this.bbiChangeShift.Name = "bbiChangeShift";
            // 
            // bbiDetailRoster
            // 
            this.bbiDetailRoster.Caption = "Detail Kehadiran";
            this.bbiDetailRoster.Id = 20;
            this.bbiDetailRoster.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiDetailRoster.ImageOptions.SvgImage")));
            this.bbiDetailRoster.Name = "bbiDetailRoster";
            // 
            // FilterSearchLookUp4
            // 
            this.FilterSearchLookUp4.Location = new System.Drawing.Point(11, 101);
            this.FilterSearchLookUp4.MenuManager = this.ribbonControl;
            this.FilterSearchLookUp4.Name = "FilterSearchLookUp4";
            this.FilterSearchLookUp4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FilterSearchLookUp4.Properties.NullText = " ";
            this.FilterSearchLookUp4.Properties.PopupView = this.gridView1;
            this.FilterSearchLookUp4.Size = new System.Drawing.Size(299, 34);
            this.FilterSearchLookUp4.TabIndex = 4;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // _LayoutControlItemFilter4
            // 
            this._LayoutControlItemFilter4.Control = this.FilterSearchLookUp4;
            this._LayoutControlItemFilter4.Location = new System.Drawing.Point(0, 64);
            this._LayoutControlItemFilter4.Name = "_LayoutControlItemFilter4";
            this._LayoutControlItemFilter4.Size = new System.Drawing.Size(303, 64);
            this._LayoutControlItemFilter4.Text = "Jabatan";
            this._LayoutControlItemFilter4.TextLocation = DevExpress.Utils.Locations.Top;
            this._LayoutControlItemFilter4.TextSize = new System.Drawing.Size(107, 21);
            // 
            // bbiPollingAttendance
            // 
            this.bbiPollingAttendance.Caption = "Penarikan Data Kehadiran";
            this.bbiPollingAttendance.CausesValidation = true;
            this.bbiPollingAttendance.Id = 19;
            this.bbiPollingAttendance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPollingAttendance.ImageOptions.SvgImage")));
            this.bbiPollingAttendance.Name = "bbiPollingAttendance";
            // 
            // FilterPopUp4
            // 
            this.FilterPopUp4.Location = new System.Drawing.Point(11, 229);
            this.FilterPopUp4.MenuManager = this.ribbonControl;
            this.FilterPopUp4.Name = "FilterPopUp4";
            this.FilterPopUp4.ObjectId = null;
            this.FilterPopUp4.OptionsCascadeControl = null;
            this.FilterPopUp4.OptionsCascadeMember = null;
            this.FilterPopUp4.OptionsChildControl = null;
            this.FilterPopUp4.OptionsDataSource = null;
            this.FilterPopUp4.OptionsDataType = null;
            this.FilterPopUp4.OptionsDisplayCaption = null;
            this.FilterPopUp4.OptionsDisplayColumns = null;
            this.FilterPopUp4.OptionsDisplayText = null;
            this.FilterPopUp4.OptionsDisplayTitle = null;
            this.FilterPopUp4.OptionsDisplayWidth = null;
            this.FilterPopUp4.OptionsFilterColumns = null;
            this.FilterPopUp4.OptionsSortColumns = null;
            this.FilterPopUp4.Properties.Appearance.Options.UseTextOptions = true;
            this.FilterPopUp4.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.FilterPopUp4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FilterPopUp4.Properties.ObjectId = "";
            this.FilterPopUp4.Properties.OptionsCascadeControl = null;
            this.FilterPopUp4.Properties.OptionsCascadeMember = "";
            this.FilterPopUp4.Properties.OptionsChildControl = null;
            this.FilterPopUp4.Properties.OptionsDataSource = null;
            this.FilterPopUp4.Properties.OptionsDataType = VSTS.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.FilterPopUp4.Properties.OptionsDisplayCaption = "";
            this.FilterPopUp4.Properties.OptionsDisplayColumns = "";
            this.FilterPopUp4.Properties.OptionsDisplayFormat = "";
            this.FilterPopUp4.Properties.OptionsDisplayText = "";
            this.FilterPopUp4.Properties.OptionsDisplayTitle = "";
            this.FilterPopUp4.Properties.OptionsDisplayWidth = "";
            this.FilterPopUp4.Properties.OptionsFilterColumns = "";
            this.FilterPopUp4.Properties.OptionsSortColumns = "";
            this.FilterPopUp4.Size = new System.Drawing.Size(289, 34);
            this.FilterPopUp4.StyleController = this.dataLayoutControl2;
            this.FilterPopUp4.TabIndex = 4;
            // 
            // _LayoutControlItemFilter5
            // 
            this._LayoutControlItemFilter5.Control = this.FilterPopUp4;
            this._LayoutControlItemFilter5.Location = new System.Drawing.Point(0, 192);
            this._LayoutControlItemFilter5.Name = "_LayoutControlItemFilter5";
            this._LayoutControlItemFilter5.Size = new System.Drawing.Size(293, 64);
            this._LayoutControlItemFilter5.TextLocation = DevExpress.Utils.Locations.Top;
            this._LayoutControlItemFilter5.TextSize = new System.Drawing.Size(181, 21);
            // 
            // frmRosterLV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 674);
            this.Name = "frmRosterLV";
            this.Text = "Daftar Kehadiran";
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
            ((System.ComponentModel.ISupportInitialize)(this._BandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._PopupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterSearchLookUp4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterPopUp4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._LayoutControlItemFilter5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.Views.BandedGrid.BandedGridView _BandedGridView;
        private DevExpress.XtraBars.PopupMenu _PopupMenu;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraEditors.SearchLookUpEdit FilterSearchLookUp4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem _LayoutControlItemFilter4;
        private DevExpress.XtraBars.BarButtonItem bbiPollingAttendance;
        private DevExpress.XtraBars.BarButtonItem bbiDetailRoster;
        private DevExpress.XtraBars.BarButtonItem bbiChangeShift;
        private Descendant.PopupContainerEditOwn FilterPopUp4;
        private DevExpress.XtraLayout.LayoutControlItem _LayoutControlItemFilter5;
    }
}
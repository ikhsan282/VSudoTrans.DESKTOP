namespace VSTS.DESKTOP.Master.Travel
{
    partial class frmRuteDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRuteDV));
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this._GridControlSchedule = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceRuteSchedules = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewSchedule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSchedule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SchedulePopUp = new VSTS.DESKTOP.Descendant.RepositoryItemPopupContainerEditOwn();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.CodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoteMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.groupPickup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPickupProvince = new DevExpress.XtraLayout.LayoutControlItem();
            this.PickupProvincePopUp = new VSTS.DESKTOP.Descendant.PopupContainerEditOwn();
            this.ItemForPickupCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.PickupCityPopUp = new VSTS.DESKTOP.Descendant.PopupContainerEditOwn();
            this.groupDelivery = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDeliveryProvince = new DevExpress.XtraLayout.LayoutControlItem();
            this.DeliveryProvincePopUp = new VSTS.DESKTOP.Descendant.PopupContainerEditOwn();
            this.ItemForDeliveryCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.DeliveryCityPopUp = new VSTS.DESKTOP.Descendant.PopupContainerEditOwn();
            this.ItemForCompany = new DevExpress.XtraLayout.LayoutControlItem();
            this.CompanyPopUp = new VSTS.DESKTOP.Descendant.PopupContainerEditOwn();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this._GridControlPickupDistrict = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceDistrictPickup = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewPickupDistrict = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdPickup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCityNamePickup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNamePickup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this._SearchControlPickupDistrict = new DevExpress.XtraEditors.SearchControl();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this._GridControlPickupDistrictSelect = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceDistrictPickupSelect = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewPickupDistrictSelect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdPickupSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCityNamePickupSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNamePickupSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchControl2 = new DevExpress.XtraEditors.SearchControl();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnAddPickup = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnRemovePickup = new DevExpress.XtraEditors.SimpleButton();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this._GridControlDeliveryDistrict = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceDistrictDelivery = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewDeliveryDistrict = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdDelivery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCityNameDelivery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameDelivery = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this._GridControlDeliveryDistrictSelect = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceDistrictDeliverySelect = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewDeliveryDistrictSelect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdDeliverySelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCityNameDeliverySelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameDeliverySelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchControl3 = new DevExpress.XtraEditors.SearchControl();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnAddDelivery = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnRemoveDelivery = new DevExpress.XtraEditors.SimpleButton();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup7 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this._GridControlTravelPrice = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceTravelPrice = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewTravelPrice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPriceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MinPriceSpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PriceSpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colMaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaxPriceSpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colStartCapacitySeat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StartCapacitySpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colEndCapacitySeat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EndCapacitySpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCreatedUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.CreatedUserTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCreatedDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.CreatedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForModifiedUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.ModifiedUserTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ModifiedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.PriceTypeSearchLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl)).BeginInit();
            this._DataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceRuteSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulePopUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupProvincePopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupCityPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryProvincePopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryCityPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlPickupDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDistrictPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPickupDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControlPickupDistrict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlPickupDistrictSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDistrictPickupSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPickupDistrictSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlDeliveryDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDistrictDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDeliveryDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlDeliveryDistrictSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDistrictDeliverySelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDeliveryDistrictSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlTravelPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceTravelPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewTravelPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPriceSpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceSpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPriceSpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartCapacitySpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndCapacitySpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedUserTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUserTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTypeSearchLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // _DataLayoutControl
            // 
            this._DataLayoutControl.Controls.Add(this.DeliveryCityPopUp);
            this._DataLayoutControl.Controls.Add(this.DeliveryProvincePopUp);
            this._DataLayoutControl.Controls.Add(this.PickupCityPopUp);
            this._DataLayoutControl.Controls.Add(this.PickupProvincePopUp);
            this._DataLayoutControl.Controls.Add(this.CompanyPopUp);
            this._DataLayoutControl.Controls.Add(this._GridControlTravelPrice);
            this._DataLayoutControl.Controls.Add(this._GridControlSchedule);
            this._DataLayoutControl.Controls.Add(this.btnRemoveDelivery);
            this._DataLayoutControl.Controls.Add(this.btnAddDelivery);
            this._DataLayoutControl.Controls.Add(this.searchControl3);
            this._DataLayoutControl.Controls.Add(this._GridControlDeliveryDistrictSelect);
            this._DataLayoutControl.Controls.Add(this.btnRemovePickup);
            this._DataLayoutControl.Controls.Add(this.btnAddPickup);
            this._DataLayoutControl.Controls.Add(this.searchControl2);
            this._DataLayoutControl.Controls.Add(this._GridControlPickupDistrictSelect);
            this._DataLayoutControl.Controls.Add(this.searchControl1);
            this._DataLayoutControl.Controls.Add(this._GridControlDeliveryDistrict);
            this._DataLayoutControl.Controls.Add(this._SearchControlPickupDistrict);
            this._DataLayoutControl.Controls.Add(this._GridControlPickupDistrict);
            this._DataLayoutControl.Controls.Add(this.CodeTextEdit);
            this._DataLayoutControl.Controls.Add(this.NameTextEdit);
            this._DataLayoutControl.Controls.Add(this.NoteMemoEdit);
            this._DataLayoutControl.Controls.Add(this.CreatedUserTextEdit);
            this._DataLayoutControl.Controls.Add(this.CreatedDateDateEdit);
            this._DataLayoutControl.Controls.Add(this.ModifiedUserTextEdit);
            this._DataLayoutControl.Controls.Add(this.ModifiedDateDateEdit);
            this._DataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(945, 213, 975, 600);
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this._DataLayoutControl.Size = new System.Drawing.Size(1440, 413);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.lcgRoot.Size = new System.Drawing.Size(1440, 413);
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(1135, 1295, 1135, 1295);
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Margin = new System.Windows.Forms.Padding(108, 113, 108, 113);
            // 
            // 
            // 
            this.mainRibbonControl.SearchEditItem.AccessibleName = "Search Item";
            this.mainRibbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.mainRibbonControl.SearchEditItem.EditWidth = 150;
            this.mainRibbonControl.SearchEditItem.Id = -5000;
            this.mainRibbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.mainRibbonControl.Size = new System.Drawing.Size(1440, 254);
            // 
            // bbiSave
            // 
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiSave.ImageOptions.SvgImage")));
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiSaveAndClose.ImageOptions.SvgImage")));
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiSaveAndNew.ImageOptions.SvgImage")));
            // 
            // bbiReset
            // 
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            // 
            // bbiClose
            // 
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiClose.ImageOptions.SvgImage")));
            // 
            // _BindingSource
            // 
            this._BindingSource.DataSource = typeof(Domain.Entities.Travel.Rute);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1422, 395);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1422, 395);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup4,
            this.layoutControlGroup5,
            this.layoutControlGroup6,
            this.layoutControlGroup7,
            this.layoutControlGroup3});
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem13});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(1398, 339);
            this.layoutControlGroup6.Text = "Jadwal";
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this._GridControlSchedule;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(1398, 339);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // _GridControlSchedule
            // 
            this._GridControlSchedule.DataSource = this._BindingSourceRuteSchedules;
            this._GridControlSchedule.Location = new System.Drawing.Point(23, 55);
            this._GridControlSchedule.MainView = this._GridViewSchedule;
            this._GridControlSchedule.MenuManager = this.mainRibbonControl;
            this._GridControlSchedule.Name = "_GridControlSchedule";
            this._GridControlSchedule.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.SchedulePopUp});
            this._GridControlSchedule.Size = new System.Drawing.Size(1394, 335);
            this._GridControlSchedule.TabIndex = 26;
            this._GridControlSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewSchedule});
            // 
            // _BindingSourceRuteSchedules
            // 
            this._BindingSourceRuteSchedules.DataSource = typeof(Domain.Entities.Travel.RuteSchedule);
            // 
            // _GridViewSchedule
            // 
            this._GridViewSchedule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSchedule});
            this._GridViewSchedule.GridControl = this._GridControlSchedule;
            this._GridViewSchedule.Name = "_GridViewSchedule";
            // 
            // colSchedule
            // 
            this.colSchedule.Caption = "Jadwal";
            this.colSchedule.ColumnEdit = this.SchedulePopUp;
            this.colSchedule.FieldName = "Schedule";
            this.colSchedule.MinWidth = 30;
            this.colSchedule.Name = "colSchedule";
            this.colSchedule.Visible = true;
            this.colSchedule.VisibleIndex = 0;
            this.colSchedule.Width = 112;
            // 
            // SchedulePopUp
            // 
            this.SchedulePopUp.Appearance.Options.UseTextOptions = true;
            this.SchedulePopUp.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SchedulePopUp.AutoHeight = false;
            this.SchedulePopUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SchedulePopUp.Name = "SchedulePopUp";
            this.SchedulePopUp.ObjectId = null;
            this.SchedulePopUp.OptionsCascadeControl = null;
            this.SchedulePopUp.OptionsCascadeMember = "";
            this.SchedulePopUp.OptionsChildControl = null;
            this.SchedulePopUp.OptionsDataSource = null;
            this.SchedulePopUp.OptionsDataType = VSTS.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.SchedulePopUp.OptionsDisplayCaption = "";
            this.SchedulePopUp.OptionsDisplayColumns = "";
            this.SchedulePopUp.OptionsDisplayFormat = "";
            this.SchedulePopUp.OptionsDisplayText = "";
            this.SchedulePopUp.OptionsDisplayTitle = "";
            this.SchedulePopUp.OptionsDisplayWidth = "";
            this.SchedulePopUp.OptionsFilterColumns = "";
            this.SchedulePopUp.OptionsSortColumns = "";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCode,
            this.ItemForName,
            this.ItemForNote,
            this.groupPickup,
            this.groupDelivery,
            this.ItemForCompany});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1398, 339);
            this.layoutControlGroup2.Text = "Detail";
            // 
            // ItemForCode
            // 
            this.ItemForCode.Control = this.CodeTextEdit;
            this.ItemForCode.Location = new System.Drawing.Point(0, 38);
            this.ItemForCode.Name = "ItemForCode";
            this.ItemForCode.Size = new System.Drawing.Size(1398, 38);
            this.ItemForCode.Text = "Kode";
            this.ItemForCode.TextSize = new System.Drawing.Size(98, 21);
            // 
            // CodeTextEdit
            // 
            this.CodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Code", true));
            this.CodeTextEdit.Location = new System.Drawing.Point(133, 93);
            this.CodeTextEdit.MenuManager = this.mainRibbonControl;
            this.CodeTextEdit.Name = "CodeTextEdit";
            this.CodeTextEdit.Size = new System.Drawing.Size(1284, 34);
            this.CodeTextEdit.StyleController = this._DataLayoutControl;
            this.CodeTextEdit.TabIndex = 7;
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 76);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(1398, 38);
            this.ItemForName.Text = "Nama";
            this.ItemForName.TextSize = new System.Drawing.Size(98, 21);
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Name", true));
            this.NameTextEdit.Location = new System.Drawing.Point(133, 131);
            this.NameTextEdit.MenuManager = this.mainRibbonControl;
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Size = new System.Drawing.Size(1284, 34);
            this.NameTextEdit.StyleController = this._DataLayoutControl;
            this.NameTextEdit.TabIndex = 8;
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteMemoEdit;
            this.ItemForNote.Location = new System.Drawing.Point(0, 244);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(1398, 95);
            this.ItemForNote.StartNewLine = true;
            this.ItemForNote.Text = "Note";
            this.ItemForNote.TextSize = new System.Drawing.Size(98, 21);
            // 
            // NoteMemoEdit
            // 
            this.NoteMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Note", true));
            this.NoteMemoEdit.Location = new System.Drawing.Point(133, 299);
            this.NoteMemoEdit.MenuManager = this.mainRibbonControl;
            this.NoteMemoEdit.Name = "NoteMemoEdit";
            this.NoteMemoEdit.Size = new System.Drawing.Size(1284, 91);
            this.NoteMemoEdit.StyleController = this._DataLayoutControl;
            this.NoteMemoEdit.TabIndex = 9;
            // 
            // groupPickup
            // 
            this.groupPickup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPickupProvince,
            this.ItemForPickupCity});
            this.groupPickup.Location = new System.Drawing.Point(0, 114);
            this.groupPickup.Name = "groupPickup";
            this.groupPickup.Size = new System.Drawing.Size(699, 130);
            this.groupPickup.Text = "Penjemputan";
            // 
            // ItemForPickupProvince
            // 
            this.ItemForPickupProvince.Control = this.PickupProvincePopUp;
            this.ItemForPickupProvince.Location = new System.Drawing.Point(0, 0);
            this.ItemForPickupProvince.Name = "ItemForPickupProvince";
            this.ItemForPickupProvince.Size = new System.Drawing.Size(675, 38);
            this.ItemForPickupProvince.Text = "Provinsi";
            this.ItemForPickupProvince.TextSize = new System.Drawing.Size(98, 21);
            // 
            // PickupProvincePopUp
            // 
            this.PickupProvincePopUp.Location = new System.Drawing.Point(145, 211);
            this.PickupProvincePopUp.MenuManager = this.mainRibbonControl;
            this.PickupProvincePopUp.Name = "PickupProvincePopUp";
            this.PickupProvincePopUp.ObjectId = null;
            this.PickupProvincePopUp.OptionsCascadeControl = null;
            this.PickupProvincePopUp.OptionsCascadeMember = null;
            this.PickupProvincePopUp.OptionsChildControl = null;
            this.PickupProvincePopUp.OptionsDataSource = null;
            this.PickupProvincePopUp.OptionsDataType = null;
            this.PickupProvincePopUp.OptionsDisplayCaption = null;
            this.PickupProvincePopUp.OptionsDisplayColumns = null;
            this.PickupProvincePopUp.OptionsDisplayText = null;
            this.PickupProvincePopUp.OptionsDisplayTitle = null;
            this.PickupProvincePopUp.OptionsDisplayWidth = null;
            this.PickupProvincePopUp.OptionsFilterColumns = null;
            this.PickupProvincePopUp.OptionsSortColumns = null;
            this.PickupProvincePopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.PickupProvincePopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PickupProvincePopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PickupProvincePopUp.Properties.ObjectId = "";
            this.PickupProvincePopUp.Properties.OptionsCascadeControl = null;
            this.PickupProvincePopUp.Properties.OptionsCascadeMember = "";
            this.PickupProvincePopUp.Properties.OptionsChildControl = null;
            this.PickupProvincePopUp.Properties.OptionsDataSource = null;
            this.PickupProvincePopUp.Properties.OptionsDataType = VSTS.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.PickupProvincePopUp.Properties.OptionsDisplayCaption = "";
            this.PickupProvincePopUp.Properties.OptionsDisplayColumns = "";
            this.PickupProvincePopUp.Properties.OptionsDisplayFormat = "";
            this.PickupProvincePopUp.Properties.OptionsDisplayText = "";
            this.PickupProvincePopUp.Properties.OptionsDisplayTitle = "";
            this.PickupProvincePopUp.Properties.OptionsDisplayWidth = "";
            this.PickupProvincePopUp.Properties.OptionsFilterColumns = "";
            this.PickupProvincePopUp.Properties.OptionsSortColumns = "";
            this.PickupProvincePopUp.Size = new System.Drawing.Size(561, 34);
            this.PickupProvincePopUp.StyleController = this._DataLayoutControl;
            this.PickupProvincePopUp.TabIndex = 31;
            // 
            // ItemForPickupCity
            // 
            this.ItemForPickupCity.Control = this.PickupCityPopUp;
            this.ItemForPickupCity.Location = new System.Drawing.Point(0, 38);
            this.ItemForPickupCity.Name = "ItemForPickupCity";
            this.ItemForPickupCity.Size = new System.Drawing.Size(675, 38);
            this.ItemForPickupCity.Text = "Kota";
            this.ItemForPickupCity.TextSize = new System.Drawing.Size(98, 21);
            // 
            // PickupCityPopUp
            // 
            this.PickupCityPopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "PickupPointCity", true));
            this.PickupCityPopUp.Location = new System.Drawing.Point(145, 249);
            this.PickupCityPopUp.MenuManager = this.mainRibbonControl;
            this.PickupCityPopUp.Name = "PickupCityPopUp";
            this.PickupCityPopUp.ObjectId = null;
            this.PickupCityPopUp.OptionsCascadeControl = null;
            this.PickupCityPopUp.OptionsCascadeMember = null;
            this.PickupCityPopUp.OptionsChildControl = null;
            this.PickupCityPopUp.OptionsDataSource = null;
            this.PickupCityPopUp.OptionsDataType = null;
            this.PickupCityPopUp.OptionsDisplayCaption = null;
            this.PickupCityPopUp.OptionsDisplayColumns = null;
            this.PickupCityPopUp.OptionsDisplayText = null;
            this.PickupCityPopUp.OptionsDisplayTitle = null;
            this.PickupCityPopUp.OptionsDisplayWidth = null;
            this.PickupCityPopUp.OptionsFilterColumns = null;
            this.PickupCityPopUp.OptionsSortColumns = null;
            this.PickupCityPopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.PickupCityPopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PickupCityPopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PickupCityPopUp.Properties.ObjectId = "";
            this.PickupCityPopUp.Properties.OptionsCascadeControl = null;
            this.PickupCityPopUp.Properties.OptionsCascadeMember = "";
            this.PickupCityPopUp.Properties.OptionsChildControl = null;
            this.PickupCityPopUp.Properties.OptionsDataSource = null;
            this.PickupCityPopUp.Properties.OptionsDataType = VSTS.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.PickupCityPopUp.Properties.OptionsDisplayCaption = "";
            this.PickupCityPopUp.Properties.OptionsDisplayColumns = "";
            this.PickupCityPopUp.Properties.OptionsDisplayFormat = "";
            this.PickupCityPopUp.Properties.OptionsDisplayText = "";
            this.PickupCityPopUp.Properties.OptionsDisplayTitle = "";
            this.PickupCityPopUp.Properties.OptionsDisplayWidth = "";
            this.PickupCityPopUp.Properties.OptionsFilterColumns = "";
            this.PickupCityPopUp.Properties.OptionsSortColumns = "";
            this.PickupCityPopUp.Size = new System.Drawing.Size(561, 34);
            this.PickupCityPopUp.StyleController = this._DataLayoutControl;
            this.PickupCityPopUp.TabIndex = 32;
            // 
            // groupDelivery
            // 
            this.groupDelivery.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDeliveryProvince,
            this.ItemForDeliveryCity});
            this.groupDelivery.Location = new System.Drawing.Point(699, 114);
            this.groupDelivery.Name = "groupDelivery";
            this.groupDelivery.Size = new System.Drawing.Size(699, 130);
            this.groupDelivery.Text = "Pengantaran";
            // 
            // ItemForDeliveryProvince
            // 
            this.ItemForDeliveryProvince.Control = this.DeliveryProvincePopUp;
            this.ItemForDeliveryProvince.Location = new System.Drawing.Point(0, 0);
            this.ItemForDeliveryProvince.Name = "ItemForDeliveryProvince";
            this.ItemForDeliveryProvince.Size = new System.Drawing.Size(675, 38);
            this.ItemForDeliveryProvince.Text = "Provinsi";
            this.ItemForDeliveryProvince.TextSize = new System.Drawing.Size(98, 21);
            // 
            // DeliveryProvincePopUp
            // 
            this.DeliveryProvincePopUp.Location = new System.Drawing.Point(844, 211);
            this.DeliveryProvincePopUp.MenuManager = this.mainRibbonControl;
            this.DeliveryProvincePopUp.Name = "DeliveryProvincePopUp";
            this.DeliveryProvincePopUp.ObjectId = null;
            this.DeliveryProvincePopUp.OptionsCascadeControl = null;
            this.DeliveryProvincePopUp.OptionsCascadeMember = null;
            this.DeliveryProvincePopUp.OptionsChildControl = null;
            this.DeliveryProvincePopUp.OptionsDataSource = null;
            this.DeliveryProvincePopUp.OptionsDataType = null;
            this.DeliveryProvincePopUp.OptionsDisplayCaption = null;
            this.DeliveryProvincePopUp.OptionsDisplayColumns = null;
            this.DeliveryProvincePopUp.OptionsDisplayText = null;
            this.DeliveryProvincePopUp.OptionsDisplayTitle = null;
            this.DeliveryProvincePopUp.OptionsDisplayWidth = null;
            this.DeliveryProvincePopUp.OptionsFilterColumns = null;
            this.DeliveryProvincePopUp.OptionsSortColumns = null;
            this.DeliveryProvincePopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.DeliveryProvincePopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.DeliveryProvincePopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DeliveryProvincePopUp.Properties.ObjectId = "";
            this.DeliveryProvincePopUp.Properties.OptionsCascadeControl = null;
            this.DeliveryProvincePopUp.Properties.OptionsCascadeMember = "";
            this.DeliveryProvincePopUp.Properties.OptionsChildControl = null;
            this.DeliveryProvincePopUp.Properties.OptionsDataSource = null;
            this.DeliveryProvincePopUp.Properties.OptionsDataType = VSTS.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.DeliveryProvincePopUp.Properties.OptionsDisplayCaption = "";
            this.DeliveryProvincePopUp.Properties.OptionsDisplayColumns = "";
            this.DeliveryProvincePopUp.Properties.OptionsDisplayFormat = "";
            this.DeliveryProvincePopUp.Properties.OptionsDisplayText = "";
            this.DeliveryProvincePopUp.Properties.OptionsDisplayTitle = "";
            this.DeliveryProvincePopUp.Properties.OptionsDisplayWidth = "";
            this.DeliveryProvincePopUp.Properties.OptionsFilterColumns = "";
            this.DeliveryProvincePopUp.Properties.OptionsSortColumns = "";
            this.DeliveryProvincePopUp.Size = new System.Drawing.Size(561, 34);
            this.DeliveryProvincePopUp.StyleController = this._DataLayoutControl;
            this.DeliveryProvincePopUp.TabIndex = 33;
            // 
            // ItemForDeliveryCity
            // 
            this.ItemForDeliveryCity.Control = this.DeliveryCityPopUp;
            this.ItemForDeliveryCity.Location = new System.Drawing.Point(0, 38);
            this.ItemForDeliveryCity.Name = "ItemForDeliveryCity";
            this.ItemForDeliveryCity.Size = new System.Drawing.Size(675, 38);
            this.ItemForDeliveryCity.Text = "Kota";
            this.ItemForDeliveryCity.TextSize = new System.Drawing.Size(98, 21);
            // 
            // DeliveryCityPopUp
            // 
            this.DeliveryCityPopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "DeliveryPointCity", true));
            this.DeliveryCityPopUp.Location = new System.Drawing.Point(844, 249);
            this.DeliveryCityPopUp.MenuManager = this.mainRibbonControl;
            this.DeliveryCityPopUp.Name = "DeliveryCityPopUp";
            this.DeliveryCityPopUp.ObjectId = null;
            this.DeliveryCityPopUp.OptionsCascadeControl = null;
            this.DeliveryCityPopUp.OptionsCascadeMember = null;
            this.DeliveryCityPopUp.OptionsChildControl = null;
            this.DeliveryCityPopUp.OptionsDataSource = null;
            this.DeliveryCityPopUp.OptionsDataType = null;
            this.DeliveryCityPopUp.OptionsDisplayCaption = null;
            this.DeliveryCityPopUp.OptionsDisplayColumns = null;
            this.DeliveryCityPopUp.OptionsDisplayText = null;
            this.DeliveryCityPopUp.OptionsDisplayTitle = null;
            this.DeliveryCityPopUp.OptionsDisplayWidth = null;
            this.DeliveryCityPopUp.OptionsFilterColumns = null;
            this.DeliveryCityPopUp.OptionsSortColumns = null;
            this.DeliveryCityPopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.DeliveryCityPopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.DeliveryCityPopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DeliveryCityPopUp.Properties.ObjectId = "";
            this.DeliveryCityPopUp.Properties.OptionsCascadeControl = null;
            this.DeliveryCityPopUp.Properties.OptionsCascadeMember = "";
            this.DeliveryCityPopUp.Properties.OptionsChildControl = null;
            this.DeliveryCityPopUp.Properties.OptionsDataSource = null;
            this.DeliveryCityPopUp.Properties.OptionsDataType = VSTS.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.DeliveryCityPopUp.Properties.OptionsDisplayCaption = "";
            this.DeliveryCityPopUp.Properties.OptionsDisplayColumns = "";
            this.DeliveryCityPopUp.Properties.OptionsDisplayFormat = "";
            this.DeliveryCityPopUp.Properties.OptionsDisplayText = "";
            this.DeliveryCityPopUp.Properties.OptionsDisplayTitle = "";
            this.DeliveryCityPopUp.Properties.OptionsDisplayWidth = "";
            this.DeliveryCityPopUp.Properties.OptionsFilterColumns = "";
            this.DeliveryCityPopUp.Properties.OptionsSortColumns = "";
            this.DeliveryCityPopUp.Size = new System.Drawing.Size(561, 34);
            this.DeliveryCityPopUp.StyleController = this._DataLayoutControl;
            this.DeliveryCityPopUp.TabIndex = 34;
            // 
            // ItemForCompany
            // 
            this.ItemForCompany.Control = this.CompanyPopUp;
            this.ItemForCompany.Location = new System.Drawing.Point(0, 0);
            this.ItemForCompany.Name = "ItemForCompany";
            this.ItemForCompany.Size = new System.Drawing.Size(1398, 38);
            this.ItemForCompany.Text = "Sekolah";
            this.ItemForCompany.TextSize = new System.Drawing.Size(98, 21);
            // 
            // CompanyPopUp
            // 
            this.CompanyPopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Company", true));
            this.CompanyPopUp.Location = new System.Drawing.Point(133, 55);
            this.CompanyPopUp.MenuManager = this.mainRibbonControl;
            this.CompanyPopUp.Name = "CompanyPopUp";
            this.CompanyPopUp.ObjectId = null;
            this.CompanyPopUp.OptionsCascadeControl = null;
            this.CompanyPopUp.OptionsCascadeMember = null;
            this.CompanyPopUp.OptionsChildControl = null;
            this.CompanyPopUp.OptionsDataSource = null;
            this.CompanyPopUp.OptionsDataType = null;
            this.CompanyPopUp.OptionsDisplayCaption = null;
            this.CompanyPopUp.OptionsDisplayColumns = null;
            this.CompanyPopUp.OptionsDisplayText = null;
            this.CompanyPopUp.OptionsDisplayTitle = null;
            this.CompanyPopUp.OptionsDisplayWidth = null;
            this.CompanyPopUp.OptionsFilterColumns = null;
            this.CompanyPopUp.OptionsSortColumns = null;
            this.CompanyPopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.CompanyPopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CompanyPopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CompanyPopUp.Properties.ObjectId = "";
            this.CompanyPopUp.Properties.OptionsCascadeControl = null;
            this.CompanyPopUp.Properties.OptionsCascadeMember = "";
            this.CompanyPopUp.Properties.OptionsChildControl = null;
            this.CompanyPopUp.Properties.OptionsDataSource = null;
            this.CompanyPopUp.Properties.OptionsDataType = VSTS.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.CompanyPopUp.Properties.OptionsDisplayCaption = "";
            this.CompanyPopUp.Properties.OptionsDisplayColumns = "";
            this.CompanyPopUp.Properties.OptionsDisplayFormat = "";
            this.CompanyPopUp.Properties.OptionsDisplayText = "";
            this.CompanyPopUp.Properties.OptionsDisplayTitle = "";
            this.CompanyPopUp.Properties.OptionsDisplayWidth = "";
            this.CompanyPopUp.Properties.OptionsFilterColumns = "";
            this.CompanyPopUp.Properties.OptionsSortColumns = "";
            this.CompanyPopUp.Size = new System.Drawing.Size(1284, 34);
            this.CompanyPopUp.StyleController = this._DataLayoutControl;
            this.CompanyPopUp.TabIndex = 30;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(1398, 339);
            this.layoutControlGroup4.Text = "Radius Penjemputan";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this._GridControlPickupDistrict;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 38);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(662, 301);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // _GridControlPickupDistrict
            // 
            this._GridControlPickupDistrict.DataSource = this._BindingSourceDistrictPickup;
            this._GridControlPickupDistrict.Location = new System.Drawing.Point(23, 93);
            this._GridControlPickupDistrict.MainView = this._GridViewPickupDistrict;
            this._GridControlPickupDistrict.MenuManager = this.mainRibbonControl;
            this._GridControlPickupDistrict.Name = "_GridControlPickupDistrict";
            this._GridControlPickupDistrict.Size = new System.Drawing.Size(658, 297);
            this._GridControlPickupDistrict.TabIndex = 14;
            this._GridControlPickupDistrict.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewPickupDistrict});
            // 
            // _BindingSourceDistrictPickup
            // 
            this._BindingSourceDistrictPickup.DataSource = typeof(Domain.Entities.Demography.District);
            // 
            // _GridViewPickupDistrict
            // 
            this._GridViewPickupDistrict.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdPickup,
            this.colCityNamePickup,
            this.colNamePickup});
            this._GridViewPickupDistrict.GridControl = this._GridControlPickupDistrict;
            this._GridViewPickupDistrict.Name = "_GridViewPickupDistrict";
            // 
            // colIdPickup
            // 
            this.colIdPickup.FieldName = "Id";
            this.colIdPickup.MinWidth = 30;
            this.colIdPickup.Name = "colIdPickup";
            this.colIdPickup.Visible = true;
            this.colIdPickup.VisibleIndex = 0;
            this.colIdPickup.Width = 112;
            // 
            // colCityNamePickup
            // 
            this.colCityNamePickup.Caption = "Kota";
            this.colCityNamePickup.FieldName = "City.Name";
            this.colCityNamePickup.MinWidth = 30;
            this.colCityNamePickup.Name = "colCityNamePickup";
            this.colCityNamePickup.Visible = true;
            this.colCityNamePickup.VisibleIndex = 1;
            this.colCityNamePickup.Width = 492;
            // 
            // colNamePickup
            // 
            this.colNamePickup.Caption = "Kecamatan";
            this.colNamePickup.FieldName = "Name";
            this.colNamePickup.MinWidth = 30;
            this.colNamePickup.Name = "colNamePickup";
            this.colNamePickup.Visible = true;
            this.colNamePickup.VisibleIndex = 2;
            this.colNamePickup.Width = 762;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this._SearchControlPickupDistrict;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(662, 38);
            this.layoutControlItem2.Text = "Pencarian";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(98, 21);
            // 
            // _SearchControlPickupDistrict
            // 
            this._SearchControlPickupDistrict.Client = this._GridControlPickupDistrict;
            this._SearchControlPickupDistrict.Location = new System.Drawing.Point(133, 55);
            this._SearchControlPickupDistrict.MenuManager = this.mainRibbonControl;
            this._SearchControlPickupDistrict.Name = "_SearchControlPickupDistrict";
            this._SearchControlPickupDistrict.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this._SearchControlPickupDistrict.Properties.Client = this._GridControlPickupDistrict;
            this._SearchControlPickupDistrict.Size = new System.Drawing.Size(548, 34);
            this._SearchControlPickupDistrict.StyleController = this._DataLayoutControl;
            this._SearchControlPickupDistrict.TabIndex = 15;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this._GridControlPickupDistrictSelect;
            this.layoutControlItem5.Location = new System.Drawing.Point(816, 38);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(582, 301);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // _GridControlPickupDistrictSelect
            // 
            this._GridControlPickupDistrictSelect.DataSource = this._BindingSourceDistrictPickupSelect;
            this._GridControlPickupDistrictSelect.Location = new System.Drawing.Point(839, 93);
            this._GridControlPickupDistrictSelect.MainView = this._GridViewPickupDistrictSelect;
            this._GridControlPickupDistrictSelect.MenuManager = this.mainRibbonControl;
            this._GridControlPickupDistrictSelect.Name = "_GridControlPickupDistrictSelect";
            this._GridControlPickupDistrictSelect.Size = new System.Drawing.Size(578, 297);
            this._GridControlPickupDistrictSelect.TabIndex = 18;
            this._GridControlPickupDistrictSelect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewPickupDistrictSelect});
            // 
            // _BindingSourceDistrictPickupSelect
            // 
            this._BindingSourceDistrictPickupSelect.DataSource = typeof(Domain.Entities.Demography.District);
            // 
            // _GridViewPickupDistrictSelect
            // 
            this._GridViewPickupDistrictSelect.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdPickupSelect,
            this.colCityNamePickupSelect,
            this.colNamePickupSelect});
            this._GridViewPickupDistrictSelect.GridControl = this._GridControlPickupDistrictSelect;
            this._GridViewPickupDistrictSelect.Name = "_GridViewPickupDistrictSelect";
            // 
            // colIdPickupSelect
            // 
            this.colIdPickupSelect.FieldName = "Id";
            this.colIdPickupSelect.MinWidth = 30;
            this.colIdPickupSelect.Name = "colIdPickupSelect";
            this.colIdPickupSelect.Visible = true;
            this.colIdPickupSelect.VisibleIndex = 0;
            this.colIdPickupSelect.Width = 112;
            // 
            // colCityNamePickupSelect
            // 
            this.colCityNamePickupSelect.Caption = "Kota";
            this.colCityNamePickupSelect.FieldName = "City.Name";
            this.colCityNamePickupSelect.MinWidth = 30;
            this.colCityNamePickupSelect.Name = "colCityNamePickupSelect";
            this.colCityNamePickupSelect.Visible = true;
            this.colCityNamePickupSelect.VisibleIndex = 1;
            this.colCityNamePickupSelect.Width = 492;
            // 
            // colNamePickupSelect
            // 
            this.colNamePickupSelect.Caption = "Kecamatan";
            this.colNamePickupSelect.FieldName = "Name";
            this.colNamePickupSelect.MinWidth = 30;
            this.colNamePickupSelect.Name = "colNamePickupSelect";
            this.colNamePickupSelect.Visible = true;
            this.colNamePickupSelect.VisibleIndex = 2;
            this.colNamePickupSelect.Width = 751;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.searchControl2;
            this.layoutControlItem6.Location = new System.Drawing.Point(816, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(582, 38);
            this.layoutControlItem6.Text = "Pencarian";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(98, 21);
            // 
            // searchControl2
            // 
            this.searchControl2.Client = this._GridControlPickupDistrictSelect;
            this.searchControl2.Location = new System.Drawing.Point(949, 55);
            this.searchControl2.MenuManager = this.mainRibbonControl;
            this.searchControl2.Name = "searchControl2";
            this.searchControl2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl2.Properties.Client = this._GridControlPickupDistrictSelect;
            this.searchControl2.Size = new System.Drawing.Size(468, 34);
            this.searchControl2.StyleController = this._DataLayoutControl;
            this.searchControl2.TabIndex = 19;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnAddPickup;
            this.layoutControlItem7.Location = new System.Drawing.Point(662, 126);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(154, 36);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // btnAddPickup
            // 
            this.btnAddPickup.Location = new System.Drawing.Point(685, 181);
            this.btnAddPickup.Name = "btnAddPickup";
            this.btnAddPickup.Size = new System.Drawing.Size(150, 32);
            this.btnAddPickup.StyleController = this._DataLayoutControl;
            this.btnAddPickup.TabIndex = 20;
            this.btnAddPickup.Text = "Add";
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnRemovePickup;
            this.layoutControlItem8.Location = new System.Drawing.Point(662, 162);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(154, 36);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // btnRemovePickup
            // 
            this.btnRemovePickup.Location = new System.Drawing.Point(685, 217);
            this.btnRemovePickup.Name = "btnRemovePickup";
            this.btnRemovePickup.Size = new System.Drawing.Size(150, 32);
            this.btnRemovePickup.StyleController = this._DataLayoutControl;
            this.btnRemovePickup.TabIndex = 21;
            this.btnRemovePickup.Text = "Remove";
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(662, 198);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(154, 141);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(662, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(154, 126);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.emptySpaceItem4,
            this.emptySpaceItem3});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(1398, 339);
            this.layoutControlGroup5.Text = "Radius Pengantaran";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this._GridControlDeliveryDistrict;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 38);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(662, 301);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // _GridControlDeliveryDistrict
            // 
            this._GridControlDeliveryDistrict.DataSource = this._BindingSourceDistrictDelivery;
            this._GridControlDeliveryDistrict.Location = new System.Drawing.Point(23, 93);
            this._GridControlDeliveryDistrict.MainView = this._GridViewDeliveryDistrict;
            this._GridControlDeliveryDistrict.MenuManager = this.mainRibbonControl;
            this._GridControlDeliveryDistrict.Name = "_GridControlDeliveryDistrict";
            this._GridControlDeliveryDistrict.Size = new System.Drawing.Size(658, 297);
            this._GridControlDeliveryDistrict.TabIndex = 16;
            this._GridControlDeliveryDistrict.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewDeliveryDistrict});
            // 
            // _BindingSourceDistrictDelivery
            // 
            this._BindingSourceDistrictDelivery.DataSource = typeof(Domain.Entities.Demography.District);
            // 
            // _GridViewDeliveryDistrict
            // 
            this._GridViewDeliveryDistrict.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdDelivery,
            this.colCityNameDelivery,
            this.colNameDelivery});
            this._GridViewDeliveryDistrict.GridControl = this._GridControlDeliveryDistrict;
            this._GridViewDeliveryDistrict.Name = "_GridViewDeliveryDistrict";
            // 
            // colIdDelivery
            // 
            this.colIdDelivery.FieldName = "Id";
            this.colIdDelivery.MinWidth = 30;
            this.colIdDelivery.Name = "colIdDelivery";
            this.colIdDelivery.Visible = true;
            this.colIdDelivery.VisibleIndex = 0;
            this.colIdDelivery.Width = 129;
            // 
            // colCityNameDelivery
            // 
            this.colCityNameDelivery.Caption = "Kota";
            this.colCityNameDelivery.FieldName = "City.Name";
            this.colCityNameDelivery.MinWidth = 30;
            this.colCityNameDelivery.Name = "colCityNameDelivery";
            this.colCityNameDelivery.Visible = true;
            this.colCityNameDelivery.VisibleIndex = 1;
            this.colCityNameDelivery.Width = 673;
            // 
            // colNameDelivery
            // 
            this.colNameDelivery.Caption = "Kecamatan";
            this.colNameDelivery.FieldName = "Name";
            this.colNameDelivery.MinWidth = 30;
            this.colNameDelivery.Name = "colNameDelivery";
            this.colNameDelivery.Visible = true;
            this.colNameDelivery.VisibleIndex = 2;
            this.colNameDelivery.Width = 674;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.searchControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(662, 38);
            this.layoutControlItem4.Text = "Pencarian";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(98, 21);
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this._GridControlDeliveryDistrict;
            this.searchControl1.Location = new System.Drawing.Point(133, 55);
            this.searchControl1.MenuManager = this.mainRibbonControl;
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this._GridControlDeliveryDistrict;
            this.searchControl1.Size = new System.Drawing.Size(548, 34);
            this.searchControl1.StyleController = this._DataLayoutControl;
            this.searchControl1.TabIndex = 17;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this._GridControlDeliveryDistrictSelect;
            this.layoutControlItem9.Location = new System.Drawing.Point(812, 38);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(586, 301);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // _GridControlDeliveryDistrictSelect
            // 
            this._GridControlDeliveryDistrictSelect.DataSource = this._BindingSourceDistrictDeliverySelect;
            this._GridControlDeliveryDistrictSelect.Location = new System.Drawing.Point(835, 93);
            this._GridControlDeliveryDistrictSelect.MainView = this._GridViewDeliveryDistrictSelect;
            this._GridControlDeliveryDistrictSelect.MenuManager = this.mainRibbonControl;
            this._GridControlDeliveryDistrictSelect.Name = "_GridControlDeliveryDistrictSelect";
            this._GridControlDeliveryDistrictSelect.Size = new System.Drawing.Size(582, 297);
            this._GridControlDeliveryDistrictSelect.TabIndex = 22;
            this._GridControlDeliveryDistrictSelect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewDeliveryDistrictSelect});
            // 
            // _BindingSourceDistrictDeliverySelect
            // 
            this._BindingSourceDistrictDeliverySelect.DataSource = typeof(Domain.Entities.Demography.District);
            // 
            // _GridViewDeliveryDistrictSelect
            // 
            this._GridViewDeliveryDistrictSelect.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdDeliverySelect,
            this.colCityNameDeliverySelect,
            this.colNameDeliverySelect});
            this._GridViewDeliveryDistrictSelect.GridControl = this._GridControlDeliveryDistrictSelect;
            this._GridViewDeliveryDistrictSelect.Name = "_GridViewDeliveryDistrictSelect";
            // 
            // colIdDeliverySelect
            // 
            this.colIdDeliverySelect.FieldName = "Id";
            this.colIdDeliverySelect.MinWidth = 30;
            this.colIdDeliverySelect.Name = "colIdDeliverySelect";
            this.colIdDeliverySelect.Visible = true;
            this.colIdDeliverySelect.VisibleIndex = 0;
            this.colIdDeliverySelect.Width = 90;
            // 
            // colCityNameDeliverySelect
            // 
            this.colCityNameDeliverySelect.Caption = "Kota";
            this.colCityNameDeliverySelect.FieldName = "City.Name";
            this.colCityNameDeliverySelect.MinWidth = 30;
            this.colCityNameDeliverySelect.Name = "colCityNameDeliverySelect";
            this.colCityNameDeliverySelect.Visible = true;
            this.colCityNameDeliverySelect.VisibleIndex = 1;
            this.colCityNameDeliverySelect.Width = 693;
            // 
            // colNameDeliverySelect
            // 
            this.colNameDeliverySelect.Caption = "Kecamatan";
            this.colNameDeliverySelect.FieldName = "Name";
            this.colNameDeliverySelect.MinWidth = 30;
            this.colNameDeliverySelect.Name = "colNameDeliverySelect";
            this.colNameDeliverySelect.Visible = true;
            this.colNameDeliverySelect.VisibleIndex = 2;
            this.colNameDeliverySelect.Width = 693;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.searchControl3;
            this.layoutControlItem10.Location = new System.Drawing.Point(812, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(586, 38);
            this.layoutControlItem10.Text = "Pencarian";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(98, 21);
            // 
            // searchControl3
            // 
            this.searchControl3.Client = this._GridControlDeliveryDistrictSelect;
            this.searchControl3.Location = new System.Drawing.Point(945, 55);
            this.searchControl3.MenuManager = this.mainRibbonControl;
            this.searchControl3.Name = "searchControl3";
            this.searchControl3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl3.Properties.Client = this._GridControlDeliveryDistrictSelect;
            this.searchControl3.Size = new System.Drawing.Size(472, 34);
            this.searchControl3.StyleController = this._DataLayoutControl;
            this.searchControl3.TabIndex = 23;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnAddDelivery;
            this.layoutControlItem11.Location = new System.Drawing.Point(662, 123);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(150, 36);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // btnAddDelivery
            // 
            this.btnAddDelivery.Location = new System.Drawing.Point(685, 178);
            this.btnAddDelivery.Name = "btnAddDelivery";
            this.btnAddDelivery.Size = new System.Drawing.Size(146, 32);
            this.btnAddDelivery.StyleController = this._DataLayoutControl;
            this.btnAddDelivery.TabIndex = 24;
            this.btnAddDelivery.Text = "Add";
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.btnRemoveDelivery;
            this.layoutControlItem12.Location = new System.Drawing.Point(662, 159);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(150, 36);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // btnRemoveDelivery
            // 
            this.btnRemoveDelivery.Location = new System.Drawing.Point(685, 214);
            this.btnRemoveDelivery.Name = "btnRemoveDelivery";
            this.btnRemoveDelivery.Size = new System.Drawing.Size(146, 32);
            this.btnRemoveDelivery.StyleController = this._DataLayoutControl;
            this.btnRemoveDelivery.TabIndex = 25;
            this.btnRemoveDelivery.Text = "Remove";
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(662, 195);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(150, 144);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(662, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(150, 123);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup7
            // 
            this.layoutControlGroup7.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem14});
            this.layoutControlGroup7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup7.Name = "layoutControlGroup7";
            this.layoutControlGroup7.Size = new System.Drawing.Size(1398, 339);
            this.layoutControlGroup7.Text = "Harga";
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this._GridControlTravelPrice;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(1398, 339);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // _GridControlTravelPrice
            // 
            this._GridControlTravelPrice.DataSource = this._BindingSourceTravelPrice;
            this._GridControlTravelPrice.Location = new System.Drawing.Point(23, 55);
            this._GridControlTravelPrice.MainView = this._GridViewTravelPrice;
            this._GridControlTravelPrice.MenuManager = this.mainRibbonControl;
            this._GridControlTravelPrice.Name = "_GridControlTravelPrice";
            this._GridControlTravelPrice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.StartCapacitySpinEdit,
            this.EndCapacitySpinEdit,
            this.MinPriceSpinEdit,
            this.PriceSpinEdit,
            this.MaxPriceSpinEdit,
            this.PriceTypeSearchLookUpEdit});
            this._GridControlTravelPrice.Size = new System.Drawing.Size(1394, 335);
            this._GridControlTravelPrice.TabIndex = 27;
            this._GridControlTravelPrice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewTravelPrice});
            // 
            // _BindingSourceTravelPrice
            // 
            this._BindingSourceTravelPrice.DataSource = typeof(Domain.Entities.Travel.TravelPrice);
            // 
            // _GridViewTravelPrice
            // 
            this._GridViewTravelPrice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPriceType,
            this.colMinPrice,
            this.colPrice,
            this.colMaxPrice,
            this.colStartCapacitySeat,
            this.colEndCapacitySeat});
            this._GridViewTravelPrice.GridControl = this._GridControlTravelPrice;
            this._GridViewTravelPrice.Name = "_GridViewTravelPrice";
            // 
            // colPriceType
            // 
            this.colPriceType.Caption = "Tipe";
            this.colPriceType.ColumnEdit = this.PriceTypeSearchLookUpEdit;
            this.colPriceType.FieldName = "PriceType";
            this.colPriceType.MinWidth = 30;
            this.colPriceType.Name = "colPriceType";
            this.colPriceType.Visible = true;
            this.colPriceType.VisibleIndex = 0;
            this.colPriceType.Width = 246;
            // 
            // colMinPrice
            // 
            this.colMinPrice.Caption = "Harga Minimum";
            this.colMinPrice.ColumnEdit = this.MinPriceSpinEdit;
            this.colMinPrice.FieldName = "MinPrice";
            this.colMinPrice.MinWidth = 30;
            this.colMinPrice.Name = "colMinPrice";
            this.colMinPrice.Visible = true;
            this.colMinPrice.VisibleIndex = 1;
            this.colMinPrice.Width = 246;
            // 
            // MinPriceSpinEdit
            // 
            this.MinPriceSpinEdit.AutoHeight = false;
            this.MinPriceSpinEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.MinPriceSpinEdit.Name = "MinPriceSpinEdit";
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Harga Normal";
            this.colPrice.ColumnEdit = this.PriceSpinEdit;
            this.colPrice.FieldName = "Price";
            this.colPrice.MinWidth = 30;
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            this.colPrice.Width = 246;
            // 
            // PriceSpinEdit
            // 
            this.PriceSpinEdit.AutoHeight = false;
            this.PriceSpinEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PriceSpinEdit.Name = "PriceSpinEdit";
            // 
            // colMaxPrice
            // 
            this.colMaxPrice.Caption = "Harga Maksimum";
            this.colMaxPrice.ColumnEdit = this.MaxPriceSpinEdit;
            this.colMaxPrice.FieldName = "MaxPrice";
            this.colMaxPrice.MinWidth = 30;
            this.colMaxPrice.Name = "colMaxPrice";
            this.colMaxPrice.Visible = true;
            this.colMaxPrice.VisibleIndex = 3;
            this.colMaxPrice.Width = 246;
            // 
            // MaxPriceSpinEdit
            // 
            this.MaxPriceSpinEdit.AutoHeight = false;
            this.MaxPriceSpinEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.MaxPriceSpinEdit.Name = "MaxPriceSpinEdit";
            // 
            // colStartCapacitySeat
            // 
            this.colStartCapacitySeat.Caption = "Kapasitas Minimum";
            this.colStartCapacitySeat.ColumnEdit = this.StartCapacitySpinEdit;
            this.colStartCapacitySeat.FieldName = "StartCapacitySeat";
            this.colStartCapacitySeat.MinWidth = 30;
            this.colStartCapacitySeat.Name = "colStartCapacitySeat";
            this.colStartCapacitySeat.Visible = true;
            this.colStartCapacitySeat.VisibleIndex = 4;
            this.colStartCapacitySeat.Width = 256;
            // 
            // StartCapacitySpinEdit
            // 
            this.StartCapacitySpinEdit.AutoHeight = false;
            this.StartCapacitySpinEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StartCapacitySpinEdit.Name = "StartCapacitySpinEdit";
            // 
            // colEndCapacitySeat
            // 
            this.colEndCapacitySeat.Caption = "Kapasitas Maksimum";
            this.colEndCapacitySeat.ColumnEdit = this.EndCapacitySpinEdit;
            this.colEndCapacitySeat.FieldName = "EndCapacitySeat";
            this.colEndCapacitySeat.MinWidth = 30;
            this.colEndCapacitySeat.Name = "colEndCapacitySeat";
            this.colEndCapacitySeat.Visible = true;
            this.colEndCapacitySeat.VisibleIndex = 5;
            this.colEndCapacitySeat.Width = 112;
            // 
            // EndCapacitySpinEdit
            // 
            this.EndCapacitySpinEdit.AutoHeight = false;
            this.EndCapacitySpinEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EndCapacitySpinEdit.Name = "EndCapacitySpinEdit";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCreatedUser,
            this.ItemForCreatedDate,
            this.ItemForModifiedUser,
            this.ItemForModifiedDate});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1398, 339);
            this.layoutControlGroup3.Text = "Audit Trail";
            // 
            // ItemForCreatedUser
            // 
            this.ItemForCreatedUser.Control = this.CreatedUserTextEdit;
            this.ItemForCreatedUser.Location = new System.Drawing.Point(0, 0);
            this.ItemForCreatedUser.Name = "ItemForCreatedUser";
            this.ItemForCreatedUser.Size = new System.Drawing.Size(1398, 38);
            this.ItemForCreatedUser.Text = "Created User";
            this.ItemForCreatedUser.TextSize = new System.Drawing.Size(98, 21);
            // 
            // CreatedUserTextEdit
            // 
            this.CreatedUserTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "CreatedUser", true));
            this.CreatedUserTextEdit.Location = new System.Drawing.Point(133, 55);
            this.CreatedUserTextEdit.MenuManager = this.mainRibbonControl;
            this.CreatedUserTextEdit.Name = "CreatedUserTextEdit";
            this.CreatedUserTextEdit.Size = new System.Drawing.Size(1284, 34);
            this.CreatedUserTextEdit.StyleController = this._DataLayoutControl;
            this.CreatedUserTextEdit.TabIndex = 10;
            // 
            // ItemForCreatedDate
            // 
            this.ItemForCreatedDate.Control = this.CreatedDateDateEdit;
            this.ItemForCreatedDate.Location = new System.Drawing.Point(0, 38);
            this.ItemForCreatedDate.Name = "ItemForCreatedDate";
            this.ItemForCreatedDate.Size = new System.Drawing.Size(1398, 38);
            this.ItemForCreatedDate.Text = "Created Date";
            this.ItemForCreatedDate.TextSize = new System.Drawing.Size(98, 21);
            // 
            // CreatedDateDateEdit
            // 
            this.CreatedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "CreatedDate", true));
            this.CreatedDateDateEdit.EditValue = null;
            this.CreatedDateDateEdit.Location = new System.Drawing.Point(133, 93);
            this.CreatedDateDateEdit.MenuManager = this.mainRibbonControl;
            this.CreatedDateDateEdit.Name = "CreatedDateDateEdit";
            this.CreatedDateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CreatedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatedDateDateEdit.Size = new System.Drawing.Size(1284, 34);
            this.CreatedDateDateEdit.StyleController = this._DataLayoutControl;
            this.CreatedDateDateEdit.TabIndex = 11;
            // 
            // ItemForModifiedUser
            // 
            this.ItemForModifiedUser.Control = this.ModifiedUserTextEdit;
            this.ItemForModifiedUser.Location = new System.Drawing.Point(0, 76);
            this.ItemForModifiedUser.Name = "ItemForModifiedUser";
            this.ItemForModifiedUser.Size = new System.Drawing.Size(1398, 38);
            this.ItemForModifiedUser.Text = "Modified User";
            this.ItemForModifiedUser.TextSize = new System.Drawing.Size(98, 21);
            // 
            // ModifiedUserTextEdit
            // 
            this.ModifiedUserTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "ModifiedUser", true));
            this.ModifiedUserTextEdit.Location = new System.Drawing.Point(133, 131);
            this.ModifiedUserTextEdit.MenuManager = this.mainRibbonControl;
            this.ModifiedUserTextEdit.Name = "ModifiedUserTextEdit";
            this.ModifiedUserTextEdit.Size = new System.Drawing.Size(1284, 34);
            this.ModifiedUserTextEdit.StyleController = this._DataLayoutControl;
            this.ModifiedUserTextEdit.TabIndex = 12;
            // 
            // ItemForModifiedDate
            // 
            this.ItemForModifiedDate.Control = this.ModifiedDateDateEdit;
            this.ItemForModifiedDate.Location = new System.Drawing.Point(0, 114);
            this.ItemForModifiedDate.Name = "ItemForModifiedDate";
            this.ItemForModifiedDate.Size = new System.Drawing.Size(1398, 225);
            this.ItemForModifiedDate.Text = "Modified Date";
            this.ItemForModifiedDate.TextSize = new System.Drawing.Size(98, 21);
            // 
            // ModifiedDateDateEdit
            // 
            this.ModifiedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "ModifiedDate", true));
            this.ModifiedDateDateEdit.EditValue = null;
            this.ModifiedDateDateEdit.Location = new System.Drawing.Point(133, 169);
            this.ModifiedDateDateEdit.MenuManager = this.mainRibbonControl;
            this.ModifiedDateDateEdit.Name = "ModifiedDateDateEdit";
            this.ModifiedDateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ModifiedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ModifiedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ModifiedDateDateEdit.Size = new System.Drawing.Size(1284, 34);
            this.ModifiedDateDateEdit.StyleController = this._DataLayoutControl;
            this.ModifiedDateDateEdit.TabIndex = 13;
            // 
            // PriceTypeSearchLookUpEdit
            // 
            this.PriceTypeSearchLookUpEdit.AutoHeight = false;
            this.PriceTypeSearchLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PriceTypeSearchLookUpEdit.Name = "PriceTypeSearchLookUpEdit";
            this.PriceTypeSearchLookUpEdit.PopupView = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frmRuteDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 667);
            this.Name = "frmRuteDV";
            this.Text = "Konfigurasi Rute";
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl)).EndInit();
            this._DataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceRuteSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulePopUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupProvincePopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupCityPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryProvincePopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryCityPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlPickupDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDistrictPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPickupDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControlPickupDistrict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlPickupDistrictSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDistrictPickupSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPickupDistrictSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlDeliveryDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDistrictDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDeliveryDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlDeliveryDistrictSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDistrictDeliverySelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDeliveryDistrictSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlTravelPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceTravelPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewTravelPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPriceSpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceSpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPriceSpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartCapacitySpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndCapacitySpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedUserTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedUserTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModifiedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceTypeSearchLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit CodeTextEdit;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.MemoEdit NoteMemoEdit;
        private DevExpress.XtraEditors.TextEdit CreatedUserTextEdit;
        private DevExpress.XtraEditors.DateEdit CreatedDateDateEdit;
        private DevExpress.XtraEditors.TextEdit ModifiedUserTextEdit;
        private DevExpress.XtraEditors.DateEdit ModifiedDateDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedUser;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedUser;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraGrid.GridControl _GridControlPickupDistrict;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewPickupDistrict;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SearchControl _SearchControlPickupDistrict;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource _BindingSourceDistrictPickup;
        private DevExpress.XtraGrid.Columns.GridColumn colCityNamePickup;
        private DevExpress.XtraGrid.Columns.GridColumn colNamePickup;
        private DevExpress.XtraGrid.GridControl _GridControlPickupDistrictSelect;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewPickupDistrictSelect;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraGrid.GridControl _GridControlDeliveryDistrict;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewDeliveryDistrict;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SearchControl searchControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnRemovePickup;
        private DevExpress.XtraEditors.SimpleButton btnAddPickup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource _BindingSourceDistrictPickupSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colCityNamePickupSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colNamePickupSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colIdPickupSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colIdPickup;
        private DevExpress.XtraGrid.GridControl _GridControlDeliveryDistrictSelect;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewDeliveryDistrictSelect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.SearchControl searchControl3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.SimpleButton btnRemoveDelivery;
        private DevExpress.XtraEditors.SimpleButton btnAddDelivery;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.BindingSource _BindingSourceDistrictDelivery;
        private System.Windows.Forms.BindingSource _BindingSourceDistrictDeliverySelect;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDelivery;
        private DevExpress.XtraGrid.Columns.GridColumn colCityNameDelivery;
        private DevExpress.XtraGrid.Columns.GridColumn colNameDelivery;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDeliverySelect;
        private DevExpress.XtraGrid.Columns.GridColumn colCityNameDeliverySelect;
        private DevExpress.XtraGrid.Columns.GridColumn colNameDeliverySelect;
        private DevExpress.XtraGrid.GridControl _GridControlSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewSchedule;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraGrid.Columns.GridColumn colSchedule;
        private System.Windows.Forms.BindingSource _BindingSourceRuteSchedules;
        private DevExpress.XtraGrid.GridControl _GridControlTravelPrice;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewTravelPrice;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private System.Windows.Forms.BindingSource _BindingSourceTravelPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceType;
        private DevExpress.XtraGrid.Columns.GridColumn colMinPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colStartCapacitySeat;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit MinPriceSpinEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit PriceSpinEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit MaxPriceSpinEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit StartCapacitySpinEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit EndCapacitySpinEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colEndCapacitySeat;
        private DevExpress.XtraLayout.LayoutControlGroup groupPickup;
        private DevExpress.XtraLayout.LayoutControlGroup groupDelivery;
        private Descendant.PopupContainerEditOwn CompanyPopUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCompany;
        private Descendant.PopupContainerEditOwn DeliveryCityPopUp;
        private Descendant.PopupContainerEditOwn DeliveryProvincePopUp;
        private Descendant.PopupContainerEditOwn PickupCityPopUp;
        private Descendant.PopupContainerEditOwn PickupProvincePopUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPickupProvince;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPickupCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeliveryProvince;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeliveryCity;
        private Descendant.RepositoryItemPopupContainerEditOwn SchedulePopUp;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit PriceTypeSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
    }
}
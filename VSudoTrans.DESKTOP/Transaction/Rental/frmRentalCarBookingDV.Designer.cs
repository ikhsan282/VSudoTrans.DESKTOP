using VSudoTrans.DESKTOP.Descendant;

namespace VSudoTrans.DESKTOP.Transaction.Rental
{
    partial class frmRentalCarBookingDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRentalCarBookingDV));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCompanyId = new DevExpress.XtraLayout.LayoutControlItem();
            this.CompanyPopUp = new VSudoTrans.DESKTOP.Descendant.PopupContainerEditOwn();
            this.groupPickup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPickupAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.PickupAddressMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ItemForPickupProvince = new DevExpress.XtraLayout.LayoutControlItem();
            this.PickupProvinceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForPickupCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.PickupCityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForPickupDistrict = new DevExpress.XtraLayout.LayoutControlItem();
            this.PickupDistrictPopUp = new VSudoTrans.DESKTOP.Descendant.PopupContainerEditOwn();
            this.groupDelivery = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDeliveryAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.DeliveryAddressMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ItemForDeliveryProvince = new DevExpress.XtraLayout.LayoutControlItem();
            this.DeliveryProvinceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForDeliveryCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.DeliveryCityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForDeliveryDistrict = new DevExpress.XtraLayout.LayoutControlItem();
            this.DeliveryDistrictPopUp = new VSudoTrans.DESKTOP.Descendant.PopupContainerEditOwn();
            this.ItemForTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.TimeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.DateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.groupPassenger = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForPassenger = new DevExpress.XtraLayout.LayoutControlItem();
            this.PassengerPopUp = new VSudoTrans.DESKTOP.Descendant.PopupContainerEditOwn();
            this.ItemForStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.StatusSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemForCategoryVehicle = new DevExpress.XtraLayout.LayoutControlItem();
            this.CategoryVehiclePopUp = new VSudoTrans.DESKTOP.Descendant.PopupContainerEditOwn();
            this.ItemForPassengerType = new DevExpress.XtraLayout.LayoutControlItem();
            this.PassengerTypeSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemForTotalPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.TotalPriceSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ItemForVehicle = new DevExpress.XtraLayout.LayoutControlItem();
            this.VehiclePopUp = new VSudoTrans.DESKTOP.Descendant.PopupContainerEditOwn();
            this.layoutControlGroupEmployee = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForGridEmployee = new DevExpress.XtraLayout.LayoutControlItem();
            this._GridControlEmployee = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceEmployee = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmployeePopUp = new VSudoTrans.DESKTOP.Descendant.RepositoryItemPopupContainerEditOwn();
            this.colEmployeeJobPositionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeOrganizationStructureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AmountEmployeeSpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.ItemForBBM = new DevExpress.XtraLayout.LayoutControlItem();
            this.BBMSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ItemForTotalOperationalCost = new DevExpress.XtraLayout.LayoutControlItem();
            this.TotalOperationalCostSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroupPayment = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForGridPayment = new DevExpress.XtraLayout.LayoutControlItem();
            this._GridControlPayment = new DevExpress.XtraGrid.GridControl();
            this._BindingSourcePayment = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaymentMethodSearchLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmountPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AmountPaymentSpinEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.ItemForTotalPayment = new DevExpress.XtraLayout.LayoutControlItem();
            this.TotalPaymentSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroupNote = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoteMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCreatedUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.CreatedUserTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCreatedDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.CreatedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForModifiedUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.ModifiedUserTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ModifiedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForDocumentNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.DocumentNumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl)).BeginInit();
            this._DataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPickup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupAddressMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupProvinceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupCityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupDistrictPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryAddressMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryProvinceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryCityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryDistrict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryDistrictPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPassenger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPassenger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassengerPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryVehiclePopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPassengerType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassengerTypeSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPriceSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VehiclePopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePopUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountEmployeeSpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBBM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBMSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalOperationalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalOperationalCostSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourcePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentMethodSearchLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountPaymentSpinEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPaymentSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentNumberTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _DataLayoutControl
            // 
            this._DataLayoutControl.Controls.Add(this.TotalPaymentSpinEdit);
            this._DataLayoutControl.Controls.Add(this.TotalOperationalCostSpinEdit);
            this._DataLayoutControl.Controls.Add(this.BBMSpinEdit);
            this._DataLayoutControl.Controls.Add(this.VehiclePopUp);
            this._DataLayoutControl.Controls.Add(this._GridControlPayment);
            this._DataLayoutControl.Controls.Add(this._GridControlEmployee);
            this._DataLayoutControl.Controls.Add(this.TotalPriceSpinEdit);
            this._DataLayoutControl.Controls.Add(this.PassengerTypeSearchLookUpEdit);
            this._DataLayoutControl.Controls.Add(this.CategoryVehiclePopUp);
            this._DataLayoutControl.Controls.Add(this.PassengerPopUp);
            this._DataLayoutControl.Controls.Add(this.DeliveryDistrictPopUp);
            this._DataLayoutControl.Controls.Add(this.PickupDistrictPopUp);
            this._DataLayoutControl.Controls.Add(this.DocumentNumberTextEdit);
            this._DataLayoutControl.Controls.Add(this.DateDateEdit);
            this._DataLayoutControl.Controls.Add(this.CreatedUserTextEdit);
            this._DataLayoutControl.Controls.Add(this.CreatedDateDateEdit);
            this._DataLayoutControl.Controls.Add(this.ModifiedUserTextEdit);
            this._DataLayoutControl.Controls.Add(this.ModifiedDateDateEdit);
            this._DataLayoutControl.Controls.Add(this.PickupAddressMemoEdit);
            this._DataLayoutControl.Controls.Add(this.DeliveryAddressMemoEdit);
            this._DataLayoutControl.Controls.Add(this.NoteMemoEdit);
            this._DataLayoutControl.Controls.Add(this.TimeDateEdit);
            this._DataLayoutControl.Controls.Add(this.CompanyPopUp);
            this._DataLayoutControl.Controls.Add(this.StatusSearchLookUpEdit);
            this._DataLayoutControl.Controls.Add(this.PickupProvinceTextEdit);
            this._DataLayoutControl.Controls.Add(this.PickupCityTextEdit);
            this._DataLayoutControl.Controls.Add(this.DeliveryProvinceTextEdit);
            this._DataLayoutControl.Controls.Add(this.DeliveryCityTextEdit);
            this._DataLayoutControl.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDocumentNumber});
            this._DataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(945, 213, 975, 600);
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this._DataLayoutControl.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this._DataLayoutControl.Size = new System.Drawing.Size(1167, 407);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.lcgRoot.Name = "Root";
            this.lcgRoot.Size = new System.Drawing.Size(1141, 742);
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(1135, 1233, 1135, 1233);
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Size = new System.Drawing.Size(1167, 254);
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
            this._BindingSource.DataSource = typeof(Domain.Entities.Rental.RentalCarBooking);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1123, 724);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1123, 724);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroupEmployee,
            this.layoutControlGroupPayment,
            this.layoutControlGroupNote,
            this.layoutControlGroup3});
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCompanyId,
            this.groupPickup,
            this.groupDelivery,
            this.ItemForTime,
            this.ItemForDate,
            this.groupPassenger,
            this.ItemForStatus,
            this.ItemForCategoryVehicle,
            this.ItemForPassengerType,
            this.ItemForTotalPrice,
            this.ItemForVehicle});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1099, 668);
            this.layoutControlGroup2.Text = "Detail";
            // 
            // ItemForCompanyId
            // 
            this.ItemForCompanyId.Control = this.CompanyPopUp;
            this.ItemForCompanyId.Location = new System.Drawing.Point(0, 0);
            this.ItemForCompanyId.Name = "ItemForCompanyId";
            this.ItemForCompanyId.Size = new System.Drawing.Size(1099, 38);
            this.ItemForCompanyId.Text = "Perusahaan";
            this.ItemForCompanyId.TextSize = new System.Drawing.Size(187, 21);
            // 
            // CompanyPopUp
            // 
            this.CompanyPopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Company", true));
            this.CompanyPopUp.Location = new System.Drawing.Point(222, 55);
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
            this.CompanyPopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CompanyPopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CompanyPopUp.Properties.ObjectId = null;
            this.CompanyPopUp.Properties.OptionsCascadeControl = null;
            this.CompanyPopUp.Properties.OptionsCascadeMember = "";
            this.CompanyPopUp.Properties.OptionsChildControl = null;
            this.CompanyPopUp.Properties.OptionsDataSource = null;
            this.CompanyPopUp.Properties.OptionsDataType = VSudoTrans.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.CompanyPopUp.Properties.OptionsDisplayCaption = "";
            this.CompanyPopUp.Properties.OptionsDisplayColumns = "";
            this.CompanyPopUp.Properties.OptionsDisplayFormat = "";
            this.CompanyPopUp.Properties.OptionsDisplayText = "";
            this.CompanyPopUp.Properties.OptionsDisplayTitle = "";
            this.CompanyPopUp.Properties.OptionsDisplayWidth = "";
            this.CompanyPopUp.Properties.OptionsFilterColumns = "";
            this.CompanyPopUp.Properties.OptionsSortColumns = "";
            this.CompanyPopUp.Size = new System.Drawing.Size(896, 34);
            this.CompanyPopUp.StyleController = this._DataLayoutControl;
            this.CompanyPopUp.TabIndex = 4;
            // 
            // groupPickup
            // 
            this.groupPickup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPickupAddress,
            this.ItemForPickupProvince,
            this.ItemForPickupCity,
            this.ItemForPickupDistrict});
            this.groupPickup.Location = new System.Drawing.Point(0, 396);
            this.groupPickup.Name = "groupPickup";
            this.groupPickup.Size = new System.Drawing.Size(549, 272);
            this.groupPickup.Text = "Penjemputan";
            // 
            // ItemForPickupAddress
            // 
            this.ItemForPickupAddress.Control = this.PickupAddressMemoEdit;
            this.ItemForPickupAddress.Location = new System.Drawing.Point(0, 114);
            this.ItemForPickupAddress.Name = "ItemForPickupAddress";
            this.ItemForPickupAddress.Size = new System.Drawing.Size(525, 104);
            this.ItemForPickupAddress.Text = "Detail Alamat";
            this.ItemForPickupAddress.TextSize = new System.Drawing.Size(187, 21);
            // 
            // PickupAddressMemoEdit
            // 
            this.PickupAddressMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "PickupAddress", true));
            this.PickupAddressMemoEdit.Location = new System.Drawing.Point(234, 607);
            this.PickupAddressMemoEdit.MenuManager = this.mainRibbonControl;
            this.PickupAddressMemoEdit.MinimumSize = new System.Drawing.Size(0, 100);
            this.PickupAddressMemoEdit.Name = "PickupAddressMemoEdit";
            this.PickupAddressMemoEdit.Size = new System.Drawing.Size(322, 100);
            this.PickupAddressMemoEdit.StyleController = this._DataLayoutControl;
            this.PickupAddressMemoEdit.TabIndex = 23;
            // 
            // ItemForPickupProvince
            // 
            this.ItemForPickupProvince.Control = this.PickupProvinceTextEdit;
            this.ItemForPickupProvince.Location = new System.Drawing.Point(0, 0);
            this.ItemForPickupProvince.Name = "ItemForPickupProvince";
            this.ItemForPickupProvince.Size = new System.Drawing.Size(525, 38);
            this.ItemForPickupProvince.Text = "Provinsi";
            this.ItemForPickupProvince.TextSize = new System.Drawing.Size(187, 21);
            // 
            // PickupProvinceTextEdit
            // 
            this.PickupProvinceTextEdit.Location = new System.Drawing.Point(234, 493);
            this.PickupProvinceTextEdit.MenuManager = this.mainRibbonControl;
            this.PickupProvinceTextEdit.Name = "PickupProvinceTextEdit";
            this.PickupProvinceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PickupProvinceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PickupProvinceTextEdit.Properties.ReadOnly = true;
            this.PickupProvinceTextEdit.Size = new System.Drawing.Size(322, 34);
            this.PickupProvinceTextEdit.StyleController = this._DataLayoutControl;
            this.PickupProvinceTextEdit.TabIndex = 37;
            // 
            // ItemForPickupCity
            // 
            this.ItemForPickupCity.Control = this.PickupCityTextEdit;
            this.ItemForPickupCity.Location = new System.Drawing.Point(0, 38);
            this.ItemForPickupCity.Name = "ItemForPickupCity";
            this.ItemForPickupCity.Size = new System.Drawing.Size(525, 38);
            this.ItemForPickupCity.Text = "Kota";
            this.ItemForPickupCity.TextSize = new System.Drawing.Size(187, 21);
            // 
            // PickupCityTextEdit
            // 
            this.PickupCityTextEdit.Location = new System.Drawing.Point(234, 531);
            this.PickupCityTextEdit.MenuManager = this.mainRibbonControl;
            this.PickupCityTextEdit.Name = "PickupCityTextEdit";
            this.PickupCityTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.PickupCityTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PickupCityTextEdit.Properties.ReadOnly = true;
            this.PickupCityTextEdit.Size = new System.Drawing.Size(322, 34);
            this.PickupCityTextEdit.StyleController = this._DataLayoutControl;
            this.PickupCityTextEdit.TabIndex = 38;
            // 
            // ItemForPickupDistrict
            // 
            this.ItemForPickupDistrict.Control = this.PickupDistrictPopUp;
            this.ItemForPickupDistrict.Location = new System.Drawing.Point(0, 76);
            this.ItemForPickupDistrict.Name = "ItemForPickupDistrict";
            this.ItemForPickupDistrict.Size = new System.Drawing.Size(525, 38);
            this.ItemForPickupDistrict.Text = "Kecamatan";
            this.ItemForPickupDistrict.TextSize = new System.Drawing.Size(187, 21);
            // 
            // PickupDistrictPopUp
            // 
            this.PickupDistrictPopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "PickupPointDistrict", true));
            this.PickupDistrictPopUp.Location = new System.Drawing.Point(234, 569);
            this.PickupDistrictPopUp.MenuManager = this.mainRibbonControl;
            this.PickupDistrictPopUp.Name = "PickupDistrictPopUp";
            this.PickupDistrictPopUp.ObjectId = null;
            this.PickupDistrictPopUp.OptionsCascadeControl = null;
            this.PickupDistrictPopUp.OptionsCascadeMember = null;
            this.PickupDistrictPopUp.OptionsChildControl = null;
            this.PickupDistrictPopUp.OptionsDataSource = null;
            this.PickupDistrictPopUp.OptionsDataType = null;
            this.PickupDistrictPopUp.OptionsDisplayCaption = null;
            this.PickupDistrictPopUp.OptionsDisplayColumns = null;
            this.PickupDistrictPopUp.OptionsDisplayText = null;
            this.PickupDistrictPopUp.OptionsDisplayTitle = null;
            this.PickupDistrictPopUp.OptionsDisplayWidth = null;
            this.PickupDistrictPopUp.OptionsFilterColumns = null;
            this.PickupDistrictPopUp.OptionsSortColumns = null;
            this.PickupDistrictPopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.PickupDistrictPopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PickupDistrictPopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PickupDistrictPopUp.Properties.ObjectId = "";
            this.PickupDistrictPopUp.Properties.OptionsCascadeControl = null;
            this.PickupDistrictPopUp.Properties.OptionsCascadeMember = "";
            this.PickupDistrictPopUp.Properties.OptionsChildControl = null;
            this.PickupDistrictPopUp.Properties.OptionsDataSource = null;
            this.PickupDistrictPopUp.Properties.OptionsDataType = VSudoTrans.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.PickupDistrictPopUp.Properties.OptionsDisplayCaption = "";
            this.PickupDistrictPopUp.Properties.OptionsDisplayColumns = "";
            this.PickupDistrictPopUp.Properties.OptionsDisplayFormat = "";
            this.PickupDistrictPopUp.Properties.OptionsDisplayText = "";
            this.PickupDistrictPopUp.Properties.OptionsDisplayTitle = "";
            this.PickupDistrictPopUp.Properties.OptionsDisplayWidth = "";
            this.PickupDistrictPopUp.Properties.OptionsFilterColumns = "";
            this.PickupDistrictPopUp.Properties.OptionsSortColumns = "";
            this.PickupDistrictPopUp.Size = new System.Drawing.Size(322, 34);
            this.PickupDistrictPopUp.StyleController = this._DataLayoutControl;
            this.PickupDistrictPopUp.TabIndex = 39;
            // 
            // groupDelivery
            // 
            this.groupDelivery.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDeliveryAddress,
            this.ItemForDeliveryProvince,
            this.ItemForDeliveryCity,
            this.ItemForDeliveryDistrict});
            this.groupDelivery.Location = new System.Drawing.Point(549, 396);
            this.groupDelivery.Name = "groupDelivery";
            this.groupDelivery.Size = new System.Drawing.Size(550, 272);
            this.groupDelivery.Text = "Pengantaran";
            // 
            // ItemForDeliveryAddress
            // 
            this.ItemForDeliveryAddress.Control = this.DeliveryAddressMemoEdit;
            this.ItemForDeliveryAddress.Location = new System.Drawing.Point(0, 114);
            this.ItemForDeliveryAddress.Name = "ItemForDeliveryAddress";
            this.ItemForDeliveryAddress.Size = new System.Drawing.Size(526, 104);
            this.ItemForDeliveryAddress.Text = "Detail Alamat";
            this.ItemForDeliveryAddress.TextSize = new System.Drawing.Size(187, 21);
            // 
            // DeliveryAddressMemoEdit
            // 
            this.DeliveryAddressMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "DeliveryAddress", true));
            this.DeliveryAddressMemoEdit.Location = new System.Drawing.Point(783, 607);
            this.DeliveryAddressMemoEdit.MenuManager = this.mainRibbonControl;
            this.DeliveryAddressMemoEdit.MinimumSize = new System.Drawing.Size(0, 100);
            this.DeliveryAddressMemoEdit.Name = "DeliveryAddressMemoEdit";
            this.DeliveryAddressMemoEdit.Size = new System.Drawing.Size(323, 100);
            this.DeliveryAddressMemoEdit.StyleController = this._DataLayoutControl;
            this.DeliveryAddressMemoEdit.TabIndex = 24;
            // 
            // ItemForDeliveryProvince
            // 
            this.ItemForDeliveryProvince.Control = this.DeliveryProvinceTextEdit;
            this.ItemForDeliveryProvince.Location = new System.Drawing.Point(0, 0);
            this.ItemForDeliveryProvince.Name = "ItemForDeliveryProvince";
            this.ItemForDeliveryProvince.Size = new System.Drawing.Size(526, 38);
            this.ItemForDeliveryProvince.Text = "Provinsi";
            this.ItemForDeliveryProvince.TextSize = new System.Drawing.Size(187, 21);
            // 
            // DeliveryProvinceTextEdit
            // 
            this.DeliveryProvinceTextEdit.Location = new System.Drawing.Point(783, 493);
            this.DeliveryProvinceTextEdit.MenuManager = this.mainRibbonControl;
            this.DeliveryProvinceTextEdit.Name = "DeliveryProvinceTextEdit";
            this.DeliveryProvinceTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DeliveryProvinceTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.DeliveryProvinceTextEdit.Properties.ReadOnly = true;
            this.DeliveryProvinceTextEdit.Size = new System.Drawing.Size(323, 34);
            this.DeliveryProvinceTextEdit.StyleController = this._DataLayoutControl;
            this.DeliveryProvinceTextEdit.TabIndex = 40;
            // 
            // ItemForDeliveryCity
            // 
            this.ItemForDeliveryCity.Control = this.DeliveryCityTextEdit;
            this.ItemForDeliveryCity.Location = new System.Drawing.Point(0, 38);
            this.ItemForDeliveryCity.Name = "ItemForDeliveryCity";
            this.ItemForDeliveryCity.Size = new System.Drawing.Size(526, 38);
            this.ItemForDeliveryCity.Text = "Kota";
            this.ItemForDeliveryCity.TextSize = new System.Drawing.Size(187, 21);
            // 
            // DeliveryCityTextEdit
            // 
            this.DeliveryCityTextEdit.Location = new System.Drawing.Point(783, 531);
            this.DeliveryCityTextEdit.MenuManager = this.mainRibbonControl;
            this.DeliveryCityTextEdit.Name = "DeliveryCityTextEdit";
            this.DeliveryCityTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DeliveryCityTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.DeliveryCityTextEdit.Properties.ReadOnly = true;
            this.DeliveryCityTextEdit.Size = new System.Drawing.Size(323, 34);
            this.DeliveryCityTextEdit.StyleController = this._DataLayoutControl;
            this.DeliveryCityTextEdit.TabIndex = 41;
            // 
            // ItemForDeliveryDistrict
            // 
            this.ItemForDeliveryDistrict.Control = this.DeliveryDistrictPopUp;
            this.ItemForDeliveryDistrict.Location = new System.Drawing.Point(0, 76);
            this.ItemForDeliveryDistrict.Name = "ItemForDeliveryDistrict";
            this.ItemForDeliveryDistrict.Size = new System.Drawing.Size(526, 38);
            this.ItemForDeliveryDistrict.Text = "Kecamatan";
            this.ItemForDeliveryDistrict.TextSize = new System.Drawing.Size(187, 21);
            // 
            // DeliveryDistrictPopUp
            // 
            this.DeliveryDistrictPopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "DeliveryPointDistrict", true));
            this.DeliveryDistrictPopUp.Location = new System.Drawing.Point(783, 569);
            this.DeliveryDistrictPopUp.MenuManager = this.mainRibbonControl;
            this.DeliveryDistrictPopUp.Name = "DeliveryDistrictPopUp";
            this.DeliveryDistrictPopUp.ObjectId = null;
            this.DeliveryDistrictPopUp.OptionsCascadeControl = null;
            this.DeliveryDistrictPopUp.OptionsCascadeMember = null;
            this.DeliveryDistrictPopUp.OptionsChildControl = null;
            this.DeliveryDistrictPopUp.OptionsDataSource = null;
            this.DeliveryDistrictPopUp.OptionsDataType = null;
            this.DeliveryDistrictPopUp.OptionsDisplayCaption = null;
            this.DeliveryDistrictPopUp.OptionsDisplayColumns = null;
            this.DeliveryDistrictPopUp.OptionsDisplayText = null;
            this.DeliveryDistrictPopUp.OptionsDisplayTitle = null;
            this.DeliveryDistrictPopUp.OptionsDisplayWidth = null;
            this.DeliveryDistrictPopUp.OptionsFilterColumns = null;
            this.DeliveryDistrictPopUp.OptionsSortColumns = null;
            this.DeliveryDistrictPopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.DeliveryDistrictPopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.DeliveryDistrictPopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DeliveryDistrictPopUp.Properties.ObjectId = "";
            this.DeliveryDistrictPopUp.Properties.OptionsCascadeControl = null;
            this.DeliveryDistrictPopUp.Properties.OptionsCascadeMember = "";
            this.DeliveryDistrictPopUp.Properties.OptionsChildControl = null;
            this.DeliveryDistrictPopUp.Properties.OptionsDataSource = null;
            this.DeliveryDistrictPopUp.Properties.OptionsDataType = VSudoTrans.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.DeliveryDistrictPopUp.Properties.OptionsDisplayCaption = "";
            this.DeliveryDistrictPopUp.Properties.OptionsDisplayColumns = "";
            this.DeliveryDistrictPopUp.Properties.OptionsDisplayFormat = "";
            this.DeliveryDistrictPopUp.Properties.OptionsDisplayText = "";
            this.DeliveryDistrictPopUp.Properties.OptionsDisplayTitle = "";
            this.DeliveryDistrictPopUp.Properties.OptionsDisplayWidth = "";
            this.DeliveryDistrictPopUp.Properties.OptionsFilterColumns = "";
            this.DeliveryDistrictPopUp.Properties.OptionsSortColumns = "";
            this.DeliveryDistrictPopUp.Size = new System.Drawing.Size(323, 34);
            this.DeliveryDistrictPopUp.StyleController = this._DataLayoutControl;
            this.DeliveryDistrictPopUp.TabIndex = 42;
            // 
            // ItemForTime
            // 
            this.ItemForTime.Control = this.TimeDateEdit;
            this.ItemForTime.Location = new System.Drawing.Point(0, 76);
            this.ItemForTime.Name = "ItemForTime";
            this.ItemForTime.Size = new System.Drawing.Size(1099, 38);
            this.ItemForTime.Text = "Jam";
            this.ItemForTime.TextSize = new System.Drawing.Size(187, 21);
            // 
            // TimeDateEdit
            // 
            this.TimeDateEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            this.TimeDateEdit.Location = new System.Drawing.Point(222, 131);
            this.TimeDateEdit.MenuManager = this.mainRibbonControl;
            this.TimeDateEdit.Name = "TimeDateEdit";
            this.TimeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TimeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TimeDateEdit.Properties.DisplayFormat.FormatString = "";
            this.TimeDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TimeDateEdit.Properties.EditFormat.FormatString = "";
            this.TimeDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TimeDateEdit.Properties.MaskSettings.Set("mask", "");
            this.TimeDateEdit.Size = new System.Drawing.Size(896, 34);
            this.TimeDateEdit.StyleController = this._DataLayoutControl;
            this.TimeDateEdit.TabIndex = 7;
            // 
            // ItemForDate
            // 
            this.ItemForDate.Control = this.DateDateEdit;
            this.ItemForDate.Location = new System.Drawing.Point(0, 38);
            this.ItemForDate.Name = "ItemForDate";
            this.ItemForDate.Size = new System.Drawing.Size(1099, 38);
            this.ItemForDate.Text = "Tanggal";
            this.ItemForDate.TextSize = new System.Drawing.Size(187, 21);
            // 
            // DateDateEdit
            // 
            this.DateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Date", true));
            this.DateDateEdit.EditValue = null;
            this.DateDateEdit.Location = new System.Drawing.Point(222, 93);
            this.DateDateEdit.MenuManager = this.mainRibbonControl;
            this.DateDateEdit.Name = "DateDateEdit";
            this.DateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateDateEdit.Size = new System.Drawing.Size(896, 34);
            this.DateDateEdit.StyleController = this._DataLayoutControl;
            this.DateDateEdit.TabIndex = 6;
            // 
            // groupPassenger
            // 
            buttonImageOptions1.SvgImageSize = new System.Drawing.Size(12, 12);
            this.groupPassenger.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton(" Tambah Penumpang Baru", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.groupPassenger.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.groupPassenger.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPassenger});
            this.groupPassenger.Location = new System.Drawing.Point(0, 304);
            this.groupPassenger.Name = "groupPassenger";
            this.groupPassenger.Size = new System.Drawing.Size(1099, 92);
            this.groupPassenger.Text = "Penumpang";
            // 
            // ItemForPassenger
            // 
            this.ItemForPassenger.Control = this.PassengerPopUp;
            this.ItemForPassenger.Location = new System.Drawing.Point(0, 0);
            this.ItemForPassenger.Name = "ItemForPassenger";
            this.ItemForPassenger.Size = new System.Drawing.Size(1075, 38);
            this.ItemForPassenger.Text = "Penumpang";
            this.ItemForPassenger.TextSize = new System.Drawing.Size(187, 21);
            // 
            // PassengerPopUp
            // 
            this.PassengerPopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Passenger", true));
            this.PassengerPopUp.Location = new System.Drawing.Point(234, 401);
            this.PassengerPopUp.MenuManager = this.mainRibbonControl;
            this.PassengerPopUp.Name = "PassengerPopUp";
            this.PassengerPopUp.ObjectId = null;
            this.PassengerPopUp.OptionsCascadeControl = null;
            this.PassengerPopUp.OptionsCascadeMember = null;
            this.PassengerPopUp.OptionsChildControl = null;
            this.PassengerPopUp.OptionsDataSource = null;
            this.PassengerPopUp.OptionsDataType = null;
            this.PassengerPopUp.OptionsDisplayCaption = null;
            this.PassengerPopUp.OptionsDisplayColumns = null;
            this.PassengerPopUp.OptionsDisplayText = null;
            this.PassengerPopUp.OptionsDisplayTitle = null;
            this.PassengerPopUp.OptionsDisplayWidth = null;
            this.PassengerPopUp.OptionsFilterColumns = null;
            this.PassengerPopUp.OptionsSortColumns = null;
            this.PassengerPopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.PassengerPopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PassengerPopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PassengerPopUp.Properties.ObjectId = "";
            this.PassengerPopUp.Properties.OptionsCascadeControl = null;
            this.PassengerPopUp.Properties.OptionsCascadeMember = "";
            this.PassengerPopUp.Properties.OptionsChildControl = null;
            this.PassengerPopUp.Properties.OptionsDataSource = null;
            this.PassengerPopUp.Properties.OptionsDataType = VSudoTrans.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.PassengerPopUp.Properties.OptionsDisplayCaption = "";
            this.PassengerPopUp.Properties.OptionsDisplayColumns = "";
            this.PassengerPopUp.Properties.OptionsDisplayFormat = "";
            this.PassengerPopUp.Properties.OptionsDisplayText = "";
            this.PassengerPopUp.Properties.OptionsDisplayTitle = "";
            this.PassengerPopUp.Properties.OptionsDisplayWidth = "";
            this.PassengerPopUp.Properties.OptionsFilterColumns = "";
            this.PassengerPopUp.Properties.OptionsSortColumns = "";
            this.PassengerPopUp.Size = new System.Drawing.Size(872, 34);
            this.PassengerPopUp.StyleController = this._DataLayoutControl;
            this.PassengerPopUp.TabIndex = 44;
            // 
            // ItemForStatus
            // 
            this.ItemForStatus.Control = this.StatusSearchLookUpEdit;
            this.ItemForStatus.Location = new System.Drawing.Point(0, 266);
            this.ItemForStatus.Name = "ItemForStatus";
            this.ItemForStatus.Size = new System.Drawing.Size(1099, 38);
            this.ItemForStatus.Text = "Status";
            this.ItemForStatus.TextSize = new System.Drawing.Size(187, 21);
            // 
            // StatusSearchLookUpEdit
            // 
            this.StatusSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Status", true));
            this.StatusSearchLookUpEdit.Location = new System.Drawing.Point(222, 321);
            this.StatusSearchLookUpEdit.MenuManager = this.mainRibbonControl;
            this.StatusSearchLookUpEdit.Name = "StatusSearchLookUpEdit";
            this.StatusSearchLookUpEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.StatusSearchLookUpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.StatusSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatusSearchLookUpEdit.Properties.NullText = "";
            this.StatusSearchLookUpEdit.Properties.PopupSizeable = false;
            this.StatusSearchLookUpEdit.Properties.PopupView = this.gridView3;
            this.StatusSearchLookUpEdit.Size = new System.Drawing.Size(896, 34);
            this.StatusSearchLookUpEdit.StyleController = this._DataLayoutControl;
            this.StatusSearchLookUpEdit.TabIndex = 17;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // ItemForCategoryVehicle
            // 
            this.ItemForCategoryVehicle.Control = this.CategoryVehiclePopUp;
            this.ItemForCategoryVehicle.Location = new System.Drawing.Point(0, 114);
            this.ItemForCategoryVehicle.Name = "ItemForCategoryVehicle";
            this.ItemForCategoryVehicle.Size = new System.Drawing.Size(1099, 38);
            this.ItemForCategoryVehicle.Text = "Kategori";
            this.ItemForCategoryVehicle.TextSize = new System.Drawing.Size(187, 21);
            // 
            // CategoryVehiclePopUp
            // 
            this.CategoryVehiclePopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "CategoryVehicle", true));
            this.CategoryVehiclePopUp.Location = new System.Drawing.Point(222, 169);
            this.CategoryVehiclePopUp.MenuManager = this.mainRibbonControl;
            this.CategoryVehiclePopUp.Name = "CategoryVehiclePopUp";
            this.CategoryVehiclePopUp.ObjectId = null;
            this.CategoryVehiclePopUp.OptionsCascadeControl = null;
            this.CategoryVehiclePopUp.OptionsCascadeMember = null;
            this.CategoryVehiclePopUp.OptionsChildControl = null;
            this.CategoryVehiclePopUp.OptionsDataSource = null;
            this.CategoryVehiclePopUp.OptionsDataType = null;
            this.CategoryVehiclePopUp.OptionsDisplayCaption = null;
            this.CategoryVehiclePopUp.OptionsDisplayColumns = null;
            this.CategoryVehiclePopUp.OptionsDisplayText = null;
            this.CategoryVehiclePopUp.OptionsDisplayTitle = null;
            this.CategoryVehiclePopUp.OptionsDisplayWidth = null;
            this.CategoryVehiclePopUp.OptionsFilterColumns = null;
            this.CategoryVehiclePopUp.OptionsSortColumns = null;
            this.CategoryVehiclePopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.CategoryVehiclePopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CategoryVehiclePopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CategoryVehiclePopUp.Properties.ObjectId = "";
            this.CategoryVehiclePopUp.Properties.OptionsCascadeControl = null;
            this.CategoryVehiclePopUp.Properties.OptionsCascadeMember = "";
            this.CategoryVehiclePopUp.Properties.OptionsChildControl = null;
            this.CategoryVehiclePopUp.Properties.OptionsDataSource = null;
            this.CategoryVehiclePopUp.Properties.OptionsDataType = VSudoTrans.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.CategoryVehiclePopUp.Properties.OptionsDisplayCaption = "";
            this.CategoryVehiclePopUp.Properties.OptionsDisplayColumns = "";
            this.CategoryVehiclePopUp.Properties.OptionsDisplayFormat = "";
            this.CategoryVehiclePopUp.Properties.OptionsDisplayText = "";
            this.CategoryVehiclePopUp.Properties.OptionsDisplayTitle = "";
            this.CategoryVehiclePopUp.Properties.OptionsDisplayWidth = "";
            this.CategoryVehiclePopUp.Properties.OptionsFilterColumns = "";
            this.CategoryVehiclePopUp.Properties.OptionsSortColumns = "";
            this.CategoryVehiclePopUp.Size = new System.Drawing.Size(896, 34);
            this.CategoryVehiclePopUp.StyleController = this._DataLayoutControl;
            this.CategoryVehiclePopUp.TabIndex = 45;
            // 
            // ItemForPassengerType
            // 
            this.ItemForPassengerType.Control = this.PassengerTypeSearchLookUpEdit;
            this.ItemForPassengerType.Location = new System.Drawing.Point(0, 190);
            this.ItemForPassengerType.Name = "ItemForPassengerType";
            this.ItemForPassengerType.Size = new System.Drawing.Size(1099, 38);
            this.ItemForPassengerType.Text = "Tipe";
            this.ItemForPassengerType.TextSize = new System.Drawing.Size(187, 21);
            // 
            // PassengerTypeSearchLookUpEdit
            // 
            this.PassengerTypeSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "PassengerType", true));
            this.PassengerTypeSearchLookUpEdit.Location = new System.Drawing.Point(222, 245);
            this.PassengerTypeSearchLookUpEdit.MenuManager = this.mainRibbonControl;
            this.PassengerTypeSearchLookUpEdit.Name = "PassengerTypeSearchLookUpEdit";
            this.PassengerTypeSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PassengerTypeSearchLookUpEdit.Properties.NullText = "";
            this.PassengerTypeSearchLookUpEdit.Properties.PopupView = this.gridView1;
            this.PassengerTypeSearchLookUpEdit.Size = new System.Drawing.Size(896, 34);
            this.PassengerTypeSearchLookUpEdit.StyleController = this._DataLayoutControl;
            this.PassengerTypeSearchLookUpEdit.TabIndex = 46;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ItemForTotalPrice
            // 
            this.ItemForTotalPrice.Control = this.TotalPriceSpinEdit;
            this.ItemForTotalPrice.Location = new System.Drawing.Point(0, 228);
            this.ItemForTotalPrice.Name = "ItemForTotalPrice";
            this.ItemForTotalPrice.Size = new System.Drawing.Size(1099, 38);
            this.ItemForTotalPrice.Text = "Harga";
            this.ItemForTotalPrice.TextSize = new System.Drawing.Size(187, 21);
            // 
            // TotalPriceSpinEdit
            // 
            this.TotalPriceSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TotalPriceSpinEdit.Location = new System.Drawing.Point(222, 283);
            this.TotalPriceSpinEdit.MenuManager = this.mainRibbonControl;
            this.TotalPriceSpinEdit.Name = "TotalPriceSpinEdit";
            this.TotalPriceSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TotalPriceSpinEdit.Size = new System.Drawing.Size(896, 34);
            this.TotalPriceSpinEdit.StyleController = this._DataLayoutControl;
            this.TotalPriceSpinEdit.TabIndex = 47;
            // 
            // ItemForVehicle
            // 
            this.ItemForVehicle.Control = this.VehiclePopUp;
            this.ItemForVehicle.Location = new System.Drawing.Point(0, 152);
            this.ItemForVehicle.Name = "ItemForVehicle";
            this.ItemForVehicle.Size = new System.Drawing.Size(1099, 38);
            this.ItemForVehicle.Text = "Kendaraan";
            this.ItemForVehicle.TextSize = new System.Drawing.Size(187, 21);
            // 
            // VehiclePopUp
            // 
            this.VehiclePopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Vehicle", true));
            this.VehiclePopUp.Location = new System.Drawing.Point(222, 207);
            this.VehiclePopUp.MenuManager = this.mainRibbonControl;
            this.VehiclePopUp.Name = "VehiclePopUp";
            this.VehiclePopUp.ObjectId = null;
            this.VehiclePopUp.OptionsCascadeControl = null;
            this.VehiclePopUp.OptionsCascadeMember = null;
            this.VehiclePopUp.OptionsChildControl = null;
            this.VehiclePopUp.OptionsDataSource = null;
            this.VehiclePopUp.OptionsDataType = null;
            this.VehiclePopUp.OptionsDisplayCaption = null;
            this.VehiclePopUp.OptionsDisplayColumns = null;
            this.VehiclePopUp.OptionsDisplayText = null;
            this.VehiclePopUp.OptionsDisplayTitle = null;
            this.VehiclePopUp.OptionsDisplayWidth = null;
            this.VehiclePopUp.OptionsFilterColumns = null;
            this.VehiclePopUp.OptionsSortColumns = null;
            this.VehiclePopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.VehiclePopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.VehiclePopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.VehiclePopUp.Properties.ObjectId = "";
            this.VehiclePopUp.Properties.OptionsCascadeControl = null;
            this.VehiclePopUp.Properties.OptionsCascadeMember = "";
            this.VehiclePopUp.Properties.OptionsChildControl = null;
            this.VehiclePopUp.Properties.OptionsDataSource = null;
            this.VehiclePopUp.Properties.OptionsDataType = VSudoTrans.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.VehiclePopUp.Properties.OptionsDisplayCaption = "";
            this.VehiclePopUp.Properties.OptionsDisplayColumns = "";
            this.VehiclePopUp.Properties.OptionsDisplayFormat = "";
            this.VehiclePopUp.Properties.OptionsDisplayText = "";
            this.VehiclePopUp.Properties.OptionsDisplayTitle = "";
            this.VehiclePopUp.Properties.OptionsDisplayWidth = "";
            this.VehiclePopUp.Properties.OptionsFilterColumns = "";
            this.VehiclePopUp.Properties.OptionsSortColumns = "";
            this.VehiclePopUp.Size = new System.Drawing.Size(896, 34);
            this.VehiclePopUp.StyleController = this._DataLayoutControl;
            this.VehiclePopUp.TabIndex = 50;
            // 
            // layoutControlGroupEmployee
            // 
            this.layoutControlGroupEmployee.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForGridEmployee,
            this.ItemForBBM,
            this.ItemForTotalOperationalCost});
            this.layoutControlGroupEmployee.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupEmployee.Name = "layoutControlGroupEmployee";
            this.layoutControlGroupEmployee.Size = new System.Drawing.Size(1099, 668);
            this.layoutControlGroupEmployee.Text = "Sopir/Kernet/Montir";
            // 
            // ItemForGridEmployee
            // 
            this.ItemForGridEmployee.Control = this._GridControlEmployee;
            this.ItemForGridEmployee.Location = new System.Drawing.Point(0, 76);
            this.ItemForGridEmployee.Name = "ItemForGridEmployee";
            this.ItemForGridEmployee.Size = new System.Drawing.Size(1099, 592);
            this.ItemForGridEmployee.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForGridEmployee.TextVisible = false;
            // 
            // _GridControlEmployee
            // 
            this._GridControlEmployee.DataSource = this._BindingSourceEmployee;
            this._GridControlEmployee.Location = new System.Drawing.Point(23, 131);
            this._GridControlEmployee.MainView = this._GridViewEmployee;
            this._GridControlEmployee.MenuManager = this.mainRibbonControl;
            this._GridControlEmployee.Name = "_GridControlEmployee";
            this._GridControlEmployee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.EmployeePopUp,
            this.AmountEmployeeSpinEdit});
            this._GridControlEmployee.Size = new System.Drawing.Size(1095, 588);
            this._GridControlEmployee.TabIndex = 48;
            this._GridControlEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewEmployee});
            // 
            // _BindingSourceEmployee
            // 
            this._BindingSourceEmployee.DataSource = typeof(Domain.Entities.Rental.RentalCarBookingEmployee);
            // 
            // _GridViewEmployee
            // 
            this._GridViewEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployee,
            this.colEmployeeJobPositionName,
            this.colEmployeeOrganizationStructureName,
            this.colAmountEmployee});
            this._GridViewEmployee.GridControl = this._GridControlEmployee;
            this._GridViewEmployee.Name = "_GridViewEmployee";
            // 
            // colEmployee
            // 
            this.colEmployee.Caption = "Karyawan";
            this.colEmployee.ColumnEdit = this.EmployeePopUp;
            this.colEmployee.FieldName = "Employee";
            this.colEmployee.MinWidth = 30;
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.Visible = true;
            this.colEmployee.VisibleIndex = 0;
            this.colEmployee.Width = 112;
            // 
            // EmployeePopUp
            // 
            this.EmployeePopUp.Appearance.Options.UseTextOptions = true;
            this.EmployeePopUp.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.EmployeePopUp.AutoHeight = false;
            this.EmployeePopUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EmployeePopUp.Name = "EmployeePopUp";
            this.EmployeePopUp.ObjectId = null;
            this.EmployeePopUp.OptionsCascadeControl = null;
            this.EmployeePopUp.OptionsCascadeMember = "";
            this.EmployeePopUp.OptionsChildControl = null;
            this.EmployeePopUp.OptionsDataSource = null;
            this.EmployeePopUp.OptionsDataType = VSudoTrans.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.EmployeePopUp.OptionsDisplayCaption = "";
            this.EmployeePopUp.OptionsDisplayColumns = "";
            this.EmployeePopUp.OptionsDisplayFormat = "";
            this.EmployeePopUp.OptionsDisplayText = "";
            this.EmployeePopUp.OptionsDisplayTitle = "";
            this.EmployeePopUp.OptionsDisplayWidth = "";
            this.EmployeePopUp.OptionsFilterColumns = "";
            this.EmployeePopUp.OptionsSortColumns = "";
            // 
            // colEmployeeJobPositionName
            // 
            this.colEmployeeJobPositionName.Caption = "Organisasi";
            this.colEmployeeJobPositionName.FieldName = "Employee.JobPosition.Name";
            this.colEmployeeJobPositionName.MinWidth = 30;
            this.colEmployeeJobPositionName.Name = "colEmployeeJobPositionName";
            this.colEmployeeJobPositionName.OptionsColumn.ReadOnly = true;
            this.colEmployeeJobPositionName.Visible = true;
            this.colEmployeeJobPositionName.VisibleIndex = 1;
            this.colEmployeeJobPositionName.Width = 112;
            // 
            // colEmployeeOrganizationStructureName
            // 
            this.colEmployeeOrganizationStructureName.Caption = "Posisi";
            this.colEmployeeOrganizationStructureName.FieldName = "Employee.OrganizationStructure.Name";
            this.colEmployeeOrganizationStructureName.MinWidth = 30;
            this.colEmployeeOrganizationStructureName.Name = "colEmployeeOrganizationStructureName";
            this.colEmployeeOrganizationStructureName.OptionsColumn.ReadOnly = true;
            this.colEmployeeOrganizationStructureName.Visible = true;
            this.colEmployeeOrganizationStructureName.VisibleIndex = 2;
            this.colEmployeeOrganizationStructureName.Width = 112;
            // 
            // colAmountEmployee
            // 
            this.colAmountEmployee.Caption = "Nominal";
            this.colAmountEmployee.ColumnEdit = this.AmountEmployeeSpinEdit;
            this.colAmountEmployee.FieldName = "Amount";
            this.colAmountEmployee.MinWidth = 30;
            this.colAmountEmployee.Name = "colAmountEmployee";
            this.colAmountEmployee.Visible = true;
            this.colAmountEmployee.VisibleIndex = 3;
            this.colAmountEmployee.Width = 112;
            // 
            // AmountEmployeeSpinEdit
            // 
            this.AmountEmployeeSpinEdit.AutoHeight = false;
            this.AmountEmployeeSpinEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AmountEmployeeSpinEdit.Name = "AmountEmployeeSpinEdit";
            // 
            // ItemForBBM
            // 
            this.ItemForBBM.Control = this.BBMSpinEdit;
            this.ItemForBBM.Location = new System.Drawing.Point(0, 38);
            this.ItemForBBM.Name = "ItemForBBM";
            this.ItemForBBM.Size = new System.Drawing.Size(1099, 38);
            this.ItemForBBM.Text = "Bahan Bakar Minyak (BBM)";
            this.ItemForBBM.TextSize = new System.Drawing.Size(187, 21);
            // 
            // BBMSpinEdit
            // 
            this.BBMSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "BBM", true));
            this.BBMSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BBMSpinEdit.Location = new System.Drawing.Point(222, 93);
            this.BBMSpinEdit.MenuManager = this.mainRibbonControl;
            this.BBMSpinEdit.Name = "BBMSpinEdit";
            this.BBMSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.BBMSpinEdit.Size = new System.Drawing.Size(896, 34);
            this.BBMSpinEdit.StyleController = this._DataLayoutControl;
            this.BBMSpinEdit.TabIndex = 51;
            // 
            // ItemForTotalOperationalCost
            // 
            this.ItemForTotalOperationalCost.Control = this.TotalOperationalCostSpinEdit;
            this.ItemForTotalOperationalCost.Location = new System.Drawing.Point(0, 0);
            this.ItemForTotalOperationalCost.Name = "ItemForTotalOperationalCost";
            this.ItemForTotalOperationalCost.Size = new System.Drawing.Size(1099, 38);
            this.ItemForTotalOperationalCost.Text = "Total Biaya Operasional";
            this.ItemForTotalOperationalCost.TextSize = new System.Drawing.Size(187, 21);
            // 
            // TotalOperationalCostSpinEdit
            // 
            this.TotalOperationalCostSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TotalOperationalCostSpinEdit.Location = new System.Drawing.Point(222, 55);
            this.TotalOperationalCostSpinEdit.MenuManager = this.mainRibbonControl;
            this.TotalOperationalCostSpinEdit.Name = "TotalOperationalCostSpinEdit";
            this.TotalOperationalCostSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TotalOperationalCostSpinEdit.Properties.ReadOnly = true;
            this.TotalOperationalCostSpinEdit.Size = new System.Drawing.Size(896, 34);
            this.TotalOperationalCostSpinEdit.StyleController = this._DataLayoutControl;
            this.TotalOperationalCostSpinEdit.TabIndex = 52;
            // 
            // layoutControlGroupPayment
            // 
            this.layoutControlGroupPayment.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForGridPayment,
            this.ItemForTotalPayment});
            this.layoutControlGroupPayment.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupPayment.Name = "layoutControlGroupPayment";
            this.layoutControlGroupPayment.Size = new System.Drawing.Size(1099, 668);
            this.layoutControlGroupPayment.Text = "Pembayaran Sewa";
            // 
            // ItemForGridPayment
            // 
            this.ItemForGridPayment.Control = this._GridControlPayment;
            this.ItemForGridPayment.Location = new System.Drawing.Point(0, 38);
            this.ItemForGridPayment.Name = "ItemForGridPayment";
            this.ItemForGridPayment.Size = new System.Drawing.Size(1099, 630);
            this.ItemForGridPayment.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForGridPayment.TextVisible = false;
            // 
            // _GridControlPayment
            // 
            this._GridControlPayment.DataMember = null;
            this._GridControlPayment.DataSource = this._BindingSourcePayment;
            this._GridControlPayment.Location = new System.Drawing.Point(23, 93);
            this._GridControlPayment.MainView = this._GridViewPayment;
            this._GridControlPayment.MenuManager = this.mainRibbonControl;
            this._GridControlPayment.Name = "_GridControlPayment";
            this._GridControlPayment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PaymentMethodSearchLookUpEdit,
            this.AmountPaymentSpinEdit});
            this._GridControlPayment.Size = new System.Drawing.Size(1095, 626);
            this._GridControlPayment.TabIndex = 49;
            this._GridControlPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewPayment});
            // 
            // _BindingSourcePayment
            // 
            this._BindingSourcePayment.DataSource = typeof(Domain.Entities.Rental.RentalCarBookingPayment);
            // 
            // _GridViewPayment
            // 
            this._GridViewPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentMethod,
            this.colDate,
            this.colAmountPayment});
            this._GridViewPayment.GridControl = this._GridControlPayment;
            this._GridViewPayment.Name = "_GridViewPayment";
            // 
            // colPaymentMethod
            // 
            this.colPaymentMethod.Caption = "Metode Pembayaran";
            this.colPaymentMethod.ColumnEdit = this.PaymentMethodSearchLookUpEdit;
            this.colPaymentMethod.FieldName = "PaymentMethod";
            this.colPaymentMethod.MinWidth = 30;
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.Visible = true;
            this.colPaymentMethod.VisibleIndex = 0;
            this.colPaymentMethod.Width = 112;
            // 
            // PaymentMethodSearchLookUpEdit
            // 
            this.PaymentMethodSearchLookUpEdit.AutoHeight = false;
            this.PaymentMethodSearchLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PaymentMethodSearchLookUpEdit.Name = "PaymentMethodSearchLookUpEdit";
            this.PaymentMethodSearchLookUpEdit.NullText = "";
            this.PaymentMethodSearchLookUpEdit.PopupView = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colDate
            // 
            this.colDate.Caption = "Tanggal";
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 30;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 112;
            // 
            // colAmountPayment
            // 
            this.colAmountPayment.Caption = "Nominal";
            this.colAmountPayment.ColumnEdit = this.AmountPaymentSpinEdit;
            this.colAmountPayment.FieldName = "Amount";
            this.colAmountPayment.MinWidth = 30;
            this.colAmountPayment.Name = "colAmountPayment";
            this.colAmountPayment.Visible = true;
            this.colAmountPayment.VisibleIndex = 2;
            this.colAmountPayment.Width = 112;
            // 
            // AmountPaymentSpinEdit
            // 
            this.AmountPaymentSpinEdit.AutoHeight = false;
            this.AmountPaymentSpinEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AmountPaymentSpinEdit.Name = "AmountPaymentSpinEdit";
            // 
            // ItemForTotalPayment
            // 
            this.ItemForTotalPayment.Control = this.TotalPaymentSpinEdit;
            this.ItemForTotalPayment.Location = new System.Drawing.Point(0, 0);
            this.ItemForTotalPayment.Name = "ItemForTotalPayment";
            this.ItemForTotalPayment.Size = new System.Drawing.Size(1099, 38);
            this.ItemForTotalPayment.Text = "Total Pembayaran";
            this.ItemForTotalPayment.TextSize = new System.Drawing.Size(187, 21);
            // 
            // TotalPaymentSpinEdit
            // 
            this.TotalPaymentSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TotalPaymentSpinEdit.Location = new System.Drawing.Point(222, 55);
            this.TotalPaymentSpinEdit.MenuManager = this.mainRibbonControl;
            this.TotalPaymentSpinEdit.Name = "TotalPaymentSpinEdit";
            this.TotalPaymentSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TotalPaymentSpinEdit.Properties.ReadOnly = true;
            this.TotalPaymentSpinEdit.Size = new System.Drawing.Size(896, 34);
            this.TotalPaymentSpinEdit.StyleController = this._DataLayoutControl;
            this.TotalPaymentSpinEdit.TabIndex = 53;
            // 
            // layoutControlGroupNote
            // 
            this.layoutControlGroupNote.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForNote});
            this.layoutControlGroupNote.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupNote.Name = "layoutControlGroupNote";
            this.layoutControlGroupNote.Size = new System.Drawing.Size(1099, 668);
            this.layoutControlGroupNote.Text = "Keterangan";
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteMemoEdit;
            this.ItemForNote.Location = new System.Drawing.Point(0, 0);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(1099, 668);
            this.ItemForNote.Text = "Catatan";
            this.ItemForNote.TextSize = new System.Drawing.Size(187, 21);
            // 
            // NoteMemoEdit
            // 
            this.NoteMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Note", true));
            this.NoteMemoEdit.Location = new System.Drawing.Point(222, 55);
            this.NoteMemoEdit.MenuManager = this.mainRibbonControl;
            this.NoteMemoEdit.MinimumSize = new System.Drawing.Size(0, 100);
            this.NoteMemoEdit.Name = "NoteMemoEdit";
            this.NoteMemoEdit.Size = new System.Drawing.Size(896, 664);
            this.NoteMemoEdit.StyleController = this._DataLayoutControl;
            this.NoteMemoEdit.TabIndex = 29;
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
            this.layoutControlGroup3.Size = new System.Drawing.Size(1099, 668);
            this.layoutControlGroup3.Text = "Audit Trail";
            // 
            // ItemForCreatedUser
            // 
            this.ItemForCreatedUser.Control = this.CreatedUserTextEdit;
            this.ItemForCreatedUser.Location = new System.Drawing.Point(0, 0);
            this.ItemForCreatedUser.Name = "ItemForCreatedUser";
            this.ItemForCreatedUser.Size = new System.Drawing.Size(1099, 38);
            this.ItemForCreatedUser.Text = "Dibuat Oleh";
            this.ItemForCreatedUser.TextSize = new System.Drawing.Size(187, 21);
            // 
            // CreatedUserTextEdit
            // 
            this.CreatedUserTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "CreatedUser", true));
            this.CreatedUserTextEdit.Location = new System.Drawing.Point(222, 55);
            this.CreatedUserTextEdit.MenuManager = this.mainRibbonControl;
            this.CreatedUserTextEdit.Name = "CreatedUserTextEdit";
            this.CreatedUserTextEdit.Size = new System.Drawing.Size(896, 34);
            this.CreatedUserTextEdit.StyleController = this._DataLayoutControl;
            this.CreatedUserTextEdit.TabIndex = 19;
            // 
            // ItemForCreatedDate
            // 
            this.ItemForCreatedDate.Control = this.CreatedDateDateEdit;
            this.ItemForCreatedDate.Location = new System.Drawing.Point(0, 38);
            this.ItemForCreatedDate.Name = "ItemForCreatedDate";
            this.ItemForCreatedDate.Size = new System.Drawing.Size(1099, 38);
            this.ItemForCreatedDate.Text = "Dibuat Tanggal";
            this.ItemForCreatedDate.TextSize = new System.Drawing.Size(187, 21);
            // 
            // CreatedDateDateEdit
            // 
            this.CreatedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "CreatedDate", true));
            this.CreatedDateDateEdit.EditValue = null;
            this.CreatedDateDateEdit.Location = new System.Drawing.Point(222, 93);
            this.CreatedDateDateEdit.MenuManager = this.mainRibbonControl;
            this.CreatedDateDateEdit.Name = "CreatedDateDateEdit";
            this.CreatedDateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CreatedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatedDateDateEdit.Size = new System.Drawing.Size(896, 34);
            this.CreatedDateDateEdit.StyleController = this._DataLayoutControl;
            this.CreatedDateDateEdit.TabIndex = 20;
            // 
            // ItemForModifiedUser
            // 
            this.ItemForModifiedUser.Control = this.ModifiedUserTextEdit;
            this.ItemForModifiedUser.Location = new System.Drawing.Point(0, 76);
            this.ItemForModifiedUser.Name = "ItemForModifiedUser";
            this.ItemForModifiedUser.Size = new System.Drawing.Size(1099, 38);
            this.ItemForModifiedUser.Text = "Diubah Oleh";
            this.ItemForModifiedUser.TextSize = new System.Drawing.Size(187, 21);
            // 
            // ModifiedUserTextEdit
            // 
            this.ModifiedUserTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "ModifiedUser", true));
            this.ModifiedUserTextEdit.Location = new System.Drawing.Point(222, 131);
            this.ModifiedUserTextEdit.MenuManager = this.mainRibbonControl;
            this.ModifiedUserTextEdit.Name = "ModifiedUserTextEdit";
            this.ModifiedUserTextEdit.Size = new System.Drawing.Size(896, 34);
            this.ModifiedUserTextEdit.StyleController = this._DataLayoutControl;
            this.ModifiedUserTextEdit.TabIndex = 21;
            // 
            // ItemForModifiedDate
            // 
            this.ItemForModifiedDate.Control = this.ModifiedDateDateEdit;
            this.ItemForModifiedDate.Location = new System.Drawing.Point(0, 114);
            this.ItemForModifiedDate.Name = "ItemForModifiedDate";
            this.ItemForModifiedDate.Size = new System.Drawing.Size(1099, 554);
            this.ItemForModifiedDate.Text = "Diubah Tanggal";
            this.ItemForModifiedDate.TextSize = new System.Drawing.Size(187, 21);
            // 
            // ModifiedDateDateEdit
            // 
            this.ModifiedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "ModifiedDate", true));
            this.ModifiedDateDateEdit.EditValue = null;
            this.ModifiedDateDateEdit.Location = new System.Drawing.Point(222, 169);
            this.ModifiedDateDateEdit.MenuManager = this.mainRibbonControl;
            this.ModifiedDateDateEdit.Name = "ModifiedDateDateEdit";
            this.ModifiedDateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ModifiedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ModifiedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ModifiedDateDateEdit.Size = new System.Drawing.Size(896, 34);
            this.ModifiedDateDateEdit.StyleController = this._DataLayoutControl;
            this.ModifiedDateDateEdit.TabIndex = 22;
            // 
            // ItemForDocumentNumber
            // 
            this.ItemForDocumentNumber.Control = this.DocumentNumberTextEdit;
            this.ItemForDocumentNumber.Location = new System.Drawing.Point(0, 0);
            this.ItemForDocumentNumber.Name = "ItemForDocumentNumber";
            this.ItemForDocumentNumber.Size = new System.Drawing.Size(1123, 38);
            this.ItemForDocumentNumber.Text = "Document Number";
            this.ItemForDocumentNumber.TextSize = new System.Drawing.Size(167, 21);
            // 
            // DocumentNumberTextEdit
            // 
            this.DocumentNumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "DocumentNumber", true));
            this.DocumentNumberTextEdit.Location = new System.Drawing.Point(190, 11);
            this.DocumentNumberTextEdit.MenuManager = this.mainRibbonControl;
            this.DocumentNumberTextEdit.Name = "DocumentNumberTextEdit";
            this.DocumentNumberTextEdit.Size = new System.Drawing.Size(940, 34);
            this.DocumentNumberTextEdit.StyleController = this._DataLayoutControl;
            this.DocumentNumberTextEdit.TabIndex = 5;
            // 
            // frmRentalCarBookingDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 661);
            this.Name = "frmRentalCarBookingDV";
            this.Text = "Pemesanan Tiket Perjalanan";
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl)).EndInit();
            this._DataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPickup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupAddressMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupProvinceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupCityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPickupDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickupDistrictPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryAddressMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryProvinceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryCityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeliveryDistrict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryDistrictPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPassenger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPassenger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassengerPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryVehiclePopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPassengerType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassengerTypeSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPriceSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VehiclePopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePopUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountEmployeeSpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBBM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBMSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalOperationalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalOperationalCostSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourcePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentMethodSearchLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountPaymentSpinEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPaymentSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDocumentNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentNumberTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit DocumentNumberTextEdit;
        private DevExpress.XtraEditors.DateEdit DateDateEdit;
        private DevExpress.XtraEditors.TextEdit CreatedUserTextEdit;
        private DevExpress.XtraEditors.DateEdit CreatedDateDateEdit;
        private DevExpress.XtraEditors.TextEdit ModifiedUserTextEdit;
        private DevExpress.XtraEditors.DateEdit ModifiedDateDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDocumentNumber;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPickupAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeliveryAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStatus;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedUser;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedUser;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedDate;
        private DevExpress.XtraEditors.MemoEdit PickupAddressMemoEdit;
        private DevExpress.XtraEditors.MemoEdit DeliveryAddressMemoEdit;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCompanyId;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup groupPickup;
        private DevExpress.XtraLayout.LayoutControlGroup groupDelivery;
        private DevExpress.XtraEditors.MemoEdit NoteMemoEdit;
        private DevExpress.XtraEditors.DateEdit TimeDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup groupPassenger;
        private PopupContainerEditOwn CompanyPopUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPickupProvince;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPickupCity;
        private PopupContainerEditOwn PickupDistrictPopUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPickupDistrict;
        private PopupContainerEditOwn DeliveryDistrictPopUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeliveryProvince;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeliveryCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeliveryDistrict;
        private DevExpress.XtraEditors.SearchLookUpEdit StatusSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private PopupContainerEditOwn PassengerPopUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPassenger;
        private PopupContainerEditOwn CategoryVehiclePopUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCategoryVehicle;
        private DevExpress.XtraEditors.SearchLookUpEdit PassengerTypeSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPassengerType;
        private DevExpress.XtraEditors.TextEdit PickupProvinceTextEdit;
        private DevExpress.XtraEditors.TextEdit PickupCityTextEdit;
        private DevExpress.XtraEditors.TextEdit DeliveryProvinceTextEdit;
        private DevExpress.XtraEditors.TextEdit DeliveryCityTextEdit;
        private DevExpress.XtraEditors.SpinEdit TotalPriceSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalPrice;
        private DevExpress.XtraGrid.GridControl _GridControlPayment;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewPayment;
        private DevExpress.XtraGrid.GridControl _GridControlEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewEmployee;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupPayment;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGridPayment;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupEmployee;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGridEmployee;
        private System.Windows.Forms.BindingSource _BindingSourcePayment;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountPayment;
        private System.Windows.Forms.BindingSource _BindingSourceEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeJobPositionName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeOrganizationStructureName;
        private DevExpress.XtraGrid.Columns.GridColumn colAmountEmployee;
        private PopupContainerEditOwn VehiclePopUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForVehicle;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit PaymentMethodSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private RepositoryItemPopupContainerEditOwn EmployeePopUp;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit AmountPaymentSpinEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit AmountEmployeeSpinEdit;
        private DevExpress.XtraEditors.SpinEdit TotalOperationalCostSpinEdit;
        private DevExpress.XtraEditors.SpinEdit BBMSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBBM;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalOperationalCost;
        private DevExpress.XtraEditors.SpinEdit TotalPaymentSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalPayment;
    }
}
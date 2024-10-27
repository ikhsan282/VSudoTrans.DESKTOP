﻿using VSudoTrans.DESKTOP.Descendant;

namespace VSudoTrans.DESKTOP.Master.EducationPayment
{
    partial class frmEducationComponentRegulationDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEducationComponentRegulationDV));
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCompany = new DevExpress.XtraLayout.LayoutControlItem();
            this.CompanyPopUp = new VSudoTrans.DESKTOP.Descendant.PopupContainerEditOwn();
            this.ItemForCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.CodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoteMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this._GridControlDetail = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEducationComponent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EducationComponentPopUp = new VSudoTrans.DESKTOP.Descendant.RepositoryItemPopupContainerEditOwn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumberOfInstallment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentPerInstallment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCreatedUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.CreatedUserTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForCreatedDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.CreatedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.ItemForModifiedUser = new DevExpress.XtraLayout.LayoutControlItem();
            this.ModifiedUserTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForModifiedDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ModifiedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl)).BeginInit();
            this._DataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EducationComponentPopUp)).BeginInit();
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
            this.SuspendLayout();
            // 
            // _DataLayoutControl
            // 
            this._DataLayoutControl.Controls.Add(this._GridControlDetail);
            this._DataLayoutControl.Controls.Add(this.CompanyPopUp);
            this._DataLayoutControl.Controls.Add(this.CodeTextEdit);
            this._DataLayoutControl.Controls.Add(this.NameTextEdit);
            this._DataLayoutControl.Controls.Add(this.NoteMemoEdit);
            this._DataLayoutControl.Controls.Add(this.CreatedUserTextEdit);
            this._DataLayoutControl.Controls.Add(this.CreatedDateDateEdit);
            this._DataLayoutControl.Controls.Add(this.ModifiedUserTextEdit);
            this._DataLayoutControl.Controls.Add(this.ModifiedDateDateEdit);
            this._DataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(945, 213, 975, 600);
            this._DataLayoutControl.Size = new System.Drawing.Size(902, 381);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.lcgRoot.Size = new System.Drawing.Size(876, 796);
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(1135, 1233, 1135, 1233);
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Size = new System.Drawing.Size(902, 254);
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
            this._BindingSource.DataSource = typeof(Domain.Entities.EducationPayment.EducationComponentRegulation);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(858, 778);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(858, 778);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCompany,
            this.ItemForCode,
            this.ItemForName,
            this.ItemForNote,
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(834, 722);
            this.layoutControlGroup2.Text = "Detail";
            // 
            // ItemForCompany
            // 
            this.ItemForCompany.Control = this.CompanyPopUp;
            this.ItemForCompany.Location = new System.Drawing.Point(0, 0);
            this.ItemForCompany.Name = "ItemForCompany";
            this.ItemForCompany.Size = new System.Drawing.Size(834, 38);
            this.ItemForCompany.Text = "Sekolah";
            this.ItemForCompany.TextSize = new System.Drawing.Size(109, 21);
            // 
            // CompanyPopUp
            // 
            this.CompanyPopUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Company", true));
            this.CompanyPopUp.Location = new System.Drawing.Point(144, -305);
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
            this.CompanyPopUp.Size = new System.Drawing.Size(709, 34);
            this.CompanyPopUp.StyleController = this._DataLayoutControl;
            this.CompanyPopUp.TabIndex = 4;
            // 
            // ItemForCode
            // 
            this.ItemForCode.Control = this.CodeTextEdit;
            this.ItemForCode.Location = new System.Drawing.Point(0, 38);
            this.ItemForCode.Name = "ItemForCode";
            this.ItemForCode.Size = new System.Drawing.Size(834, 38);
            this.ItemForCode.Text = "Kode";
            this.ItemForCode.TextSize = new System.Drawing.Size(109, 21);
            // 
            // CodeTextEdit
            // 
            this.CodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Code", true));
            this.CodeTextEdit.Location = new System.Drawing.Point(144, -267);
            this.CodeTextEdit.MenuManager = this.mainRibbonControl;
            this.CodeTextEdit.Name = "CodeTextEdit";
            this.CodeTextEdit.Size = new System.Drawing.Size(709, 34);
            this.CodeTextEdit.StyleController = this._DataLayoutControl;
            this.CodeTextEdit.TabIndex = 5;
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.Location = new System.Drawing.Point(0, 76);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(834, 38);
            this.ItemForName.Text = "Nama";
            this.ItemForName.TextSize = new System.Drawing.Size(109, 21);
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Name", true));
            this.NameTextEdit.Location = new System.Drawing.Point(144, -229);
            this.NameTextEdit.MenuManager = this.mainRibbonControl;
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Size = new System.Drawing.Size(709, 34);
            this.NameTextEdit.StyleController = this._DataLayoutControl;
            this.NameTextEdit.TabIndex = 6;
            // 
            // ItemForNote
            // 
            this.ItemForNote.Control = this.NoteMemoEdit;
            this.ItemForNote.Location = new System.Drawing.Point(0, 114);
            this.ItemForNote.Name = "ItemForNote";
            this.ItemForNote.Size = new System.Drawing.Size(834, 104);
            this.ItemForNote.StartNewLine = true;
            this.ItemForNote.Text = "Catatan";
            this.ItemForNote.TextSize = new System.Drawing.Size(109, 21);
            // 
            // NoteMemoEdit
            // 
            this.NoteMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "Note", true));
            this.NoteMemoEdit.Location = new System.Drawing.Point(144, -191);
            this.NoteMemoEdit.MenuManager = this.mainRibbonControl;
            this.NoteMemoEdit.MinimumSize = new System.Drawing.Size(0, 100);
            this.NoteMemoEdit.Name = "NoteMemoEdit";
            this.NoteMemoEdit.Size = new System.Drawing.Size(709, 100);
            this.NoteMemoEdit.StyleController = this._DataLayoutControl;
            this.NoteMemoEdit.TabIndex = 7;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this._GridControlDetail;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 218);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(834, 504);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // _GridControlDetail
            // 
            this._GridControlDetail.DataSource = this._BindingSourceDetail;
            this._GridControlDetail.Location = new System.Drawing.Point(23, -87);
            this._GridControlDetail.MainView = this._GridViewDetail;
            this._GridControlDetail.MenuManager = this.mainRibbonControl;
            this._GridControlDetail.MinimumSize = new System.Drawing.Size(0, 500);
            this._GridControlDetail.Name = "_GridControlDetail";
            this._GridControlDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.EducationComponentPopUp});
            this._GridControlDetail.Size = new System.Drawing.Size(830, 500);
            this._GridControlDetail.TabIndex = 12;
            this._GridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewDetail});
            // 
            // _BindingSourceDetail
            // 
            this._BindingSourceDetail.DataSource = typeof(Domain.Entities.EducationPayment.EducationComponentRegulationDetail);
            // 
            // _GridViewDetail
            // 
            this._GridViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEducationComponent,
            this.colAmount,
            this.colNumberOfInstallment,
            this.colPaymentPerInstallment,
            this.colPriority});
            this._GridViewDetail.GridControl = this._GridControlDetail;
            this._GridViewDetail.Name = "_GridViewDetail";
            // 
            // colEducationComponent
            // 
            this.colEducationComponent.Caption = "Mata Anggaran";
            this.colEducationComponent.ColumnEdit = this.EducationComponentPopUp;
            this.colEducationComponent.FieldName = "EducationComponent";
            this.colEducationComponent.MinWidth = 30;
            this.colEducationComponent.Name = "colEducationComponent";
            this.colEducationComponent.Visible = true;
            this.colEducationComponent.VisibleIndex = 0;
            this.colEducationComponent.Width = 570;
            // 
            // EducationComponentPopUp
            // 
            this.EducationComponentPopUp.Appearance.Options.UseTextOptions = true;
            this.EducationComponentPopUp.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.EducationComponentPopUp.AutoHeight = false;
            this.EducationComponentPopUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EducationComponentPopUp.Name = "EducationComponentPopUp";
            this.EducationComponentPopUp.ObjectId = null;
            this.EducationComponentPopUp.OptionsCascadeControl = null;
            this.EducationComponentPopUp.OptionsCascadeMember = "";
            this.EducationComponentPopUp.OptionsChildControl = null;
            this.EducationComponentPopUp.OptionsDataSource = null;
            this.EducationComponentPopUp.OptionsDataType = VSudoTrans.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.EducationComponentPopUp.OptionsDisplayCaption = "";
            this.EducationComponentPopUp.OptionsDisplayColumns = "";
            this.EducationComponentPopUp.OptionsDisplayFormat = "";
            this.EducationComponentPopUp.OptionsDisplayText = "";
            this.EducationComponentPopUp.OptionsDisplayTitle = "";
            this.EducationComponentPopUp.OptionsDisplayWidth = "";
            this.EducationComponentPopUp.OptionsFilterColumns = "";
            this.EducationComponentPopUp.OptionsSortColumns = "";
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Total Tagihan";
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 30;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 1;
            this.colAmount.Width = 299;
            // 
            // colNumberOfInstallment
            // 
            this.colNumberOfInstallment.Caption = "Angsuran";
            this.colNumberOfInstallment.FieldName = "NumberOfInstallment";
            this.colNumberOfInstallment.MinWidth = 30;
            this.colNumberOfInstallment.Name = "colNumberOfInstallment";
            this.colNumberOfInstallment.Visible = true;
            this.colNumberOfInstallment.VisibleIndex = 2;
            this.colNumberOfInstallment.Width = 139;
            // 
            // colPaymentPerInstallment
            // 
            this.colPaymentPerInstallment.Caption = "Pembayaran Per Angsuran";
            this.colPaymentPerInstallment.FieldName = "PaymentPerInstallment";
            this.colPaymentPerInstallment.MinWidth = 30;
            this.colPaymentPerInstallment.Name = "colPaymentPerInstallment";
            this.colPaymentPerInstallment.OptionsColumn.ReadOnly = true;
            this.colPaymentPerInstallment.Visible = true;
            this.colPaymentPerInstallment.VisibleIndex = 3;
            this.colPaymentPerInstallment.Width = 287;
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
            this.layoutControlGroup3.Size = new System.Drawing.Size(834, 722);
            this.layoutControlGroup3.Text = "Audit Trail";
            // 
            // ItemForCreatedUser
            // 
            this.ItemForCreatedUser.Control = this.CreatedUserTextEdit;
            this.ItemForCreatedUser.Location = new System.Drawing.Point(0, 0);
            this.ItemForCreatedUser.Name = "ItemForCreatedUser";
            this.ItemForCreatedUser.Size = new System.Drawing.Size(834, 38);
            this.ItemForCreatedUser.Text = "Dibuat Oleh";
            this.ItemForCreatedUser.TextSize = new System.Drawing.Size(109, 21);
            // 
            // CreatedUserTextEdit
            // 
            this.CreatedUserTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "CreatedUser", true));
            this.CreatedUserTextEdit.Location = new System.Drawing.Point(144, -305);
            this.CreatedUserTextEdit.MenuManager = this.mainRibbonControl;
            this.CreatedUserTextEdit.Name = "CreatedUserTextEdit";
            this.CreatedUserTextEdit.Size = new System.Drawing.Size(709, 34);
            this.CreatedUserTextEdit.StyleController = this._DataLayoutControl;
            this.CreatedUserTextEdit.TabIndex = 8;
            // 
            // ItemForCreatedDate
            // 
            this.ItemForCreatedDate.Control = this.CreatedDateDateEdit;
            this.ItemForCreatedDate.Location = new System.Drawing.Point(0, 38);
            this.ItemForCreatedDate.Name = "ItemForCreatedDate";
            this.ItemForCreatedDate.Size = new System.Drawing.Size(834, 38);
            this.ItemForCreatedDate.Text = "Dibuat Tanggal";
            this.ItemForCreatedDate.TextSize = new System.Drawing.Size(109, 21);
            // 
            // CreatedDateDateEdit
            // 
            this.CreatedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "CreatedDate", true));
            this.CreatedDateDateEdit.EditValue = null;
            this.CreatedDateDateEdit.Location = new System.Drawing.Point(144, -267);
            this.CreatedDateDateEdit.MenuManager = this.mainRibbonControl;
            this.CreatedDateDateEdit.Name = "CreatedDateDateEdit";
            this.CreatedDateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.CreatedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatedDateDateEdit.Size = new System.Drawing.Size(709, 34);
            this.CreatedDateDateEdit.StyleController = this._DataLayoutControl;
            this.CreatedDateDateEdit.TabIndex = 9;
            // 
            // ItemForModifiedUser
            // 
            this.ItemForModifiedUser.Control = this.ModifiedUserTextEdit;
            this.ItemForModifiedUser.Location = new System.Drawing.Point(0, 76);
            this.ItemForModifiedUser.Name = "ItemForModifiedUser";
            this.ItemForModifiedUser.Size = new System.Drawing.Size(834, 38);
            this.ItemForModifiedUser.Text = "Diubah Oleh";
            this.ItemForModifiedUser.TextSize = new System.Drawing.Size(109, 21);
            // 
            // ModifiedUserTextEdit
            // 
            this.ModifiedUserTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "ModifiedUser", true));
            this.ModifiedUserTextEdit.Location = new System.Drawing.Point(144, -229);
            this.ModifiedUserTextEdit.MenuManager = this.mainRibbonControl;
            this.ModifiedUserTextEdit.Name = "ModifiedUserTextEdit";
            this.ModifiedUserTextEdit.Size = new System.Drawing.Size(709, 34);
            this.ModifiedUserTextEdit.StyleController = this._DataLayoutControl;
            this.ModifiedUserTextEdit.TabIndex = 10;
            // 
            // ItemForModifiedDate
            // 
            this.ItemForModifiedDate.Control = this.ModifiedDateDateEdit;
            this.ItemForModifiedDate.Location = new System.Drawing.Point(0, 114);
            this.ItemForModifiedDate.Name = "ItemForModifiedDate";
            this.ItemForModifiedDate.Size = new System.Drawing.Size(834, 608);
            this.ItemForModifiedDate.Text = "Diubah Tanggal";
            this.ItemForModifiedDate.TextSize = new System.Drawing.Size(109, 21);
            // 
            // ModifiedDateDateEdit
            // 
            this.ModifiedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this._BindingSource, "ModifiedDate", true));
            this.ModifiedDateDateEdit.EditValue = null;
            this.ModifiedDateDateEdit.Location = new System.Drawing.Point(144, -191);
            this.ModifiedDateDateEdit.MenuManager = this.mainRibbonControl;
            this.ModifiedDateDateEdit.Name = "ModifiedDateDateEdit";
            this.ModifiedDateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ModifiedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ModifiedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ModifiedDateDateEdit.Size = new System.Drawing.Size(709, 34);
            this.ModifiedDateDateEdit.StyleController = this._DataLayoutControl;
            this.ModifiedDateDateEdit.TabIndex = 11;
            // 
            // colPriority
            // 
            this.colPriority.Caption = "Prioritas";
            this.colPriority.FieldName = "Priority";
            this.colPriority.MinWidth = 30;
            this.colPriority.Name = "colPriority";
            this.colPriority.Visible = true;
            this.colPriority.VisibleIndex = 4;
            this.colPriority.Width = 112;
            // 
            // frmEducationComponentRegulationDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 635);
            this.Name = "frmEducationComponentRegulationDV";
            this.Text = "Peraturan Mata Anggaran";
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl)).EndInit();
            this._DataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoteMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EducationComponentPopUp)).EndInit();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PopupContainerEditOwn CompanyPopUp;
        private DevExpress.XtraEditors.TextEdit CodeTextEdit;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.MemoEdit NoteMemoEdit;
        private DevExpress.XtraEditors.TextEdit CreatedUserTextEdit;
        private DevExpress.XtraEditors.DateEdit CreatedDateDateEdit;
        private DevExpress.XtraEditors.TextEdit ModifiedUserTextEdit;
        private DevExpress.XtraEditors.DateEdit ModifiedDateDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedUser;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedUser;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModifiedDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCompany;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNote;
        private DevExpress.XtraGrid.GridControl _GridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colEducationComponent;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colNumberOfInstallment;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentPerInstallment;
        private RepositoryItemPopupContainerEditOwn EducationComponentPopUp;
        private System.Windows.Forms.BindingSource _BindingSourceDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
    }
}
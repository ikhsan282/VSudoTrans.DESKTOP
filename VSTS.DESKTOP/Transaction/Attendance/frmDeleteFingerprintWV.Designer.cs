using VSTS.DESKTOP.Descendant;

namespace VSTS.DESKTOP.Transaction.Attendance
{
    partial class frmDeleteFingerprintWV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteFingerprintWV));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.CompanyPopUp = new VSTS.DESKTOP.Descendant.PopupContainerEditOwn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCompanyId = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this._SearchControlMachine = new DevExpress.XtraEditors.SearchControl();
            this._GridControl = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceMachine = new System.Windows.Forms.BindingSource(this.components);
            this._GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMacineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineIpAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this._SearchControlTeacher = new DevExpress.XtraEditors.SearchControl();
            this._GridControlTeacherTransaction = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceEmployee = new System.Windows.Forms.BindingSource(this.components);
            this._GridViewTeacherTransaction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCompanyTeacher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeTeacher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameTeacher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTeacherTransaction = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMachine = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.wizardPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControlMachine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControlTeacher.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlTeacherTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewTeacherTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTeacherTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMachine)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "Batal";
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishText = "&Selesai";
            this.wizardControl1.ImageOptions.ImageWidth = 184;
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&Lanjutkan >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< &Kembali";
            this.wizardControl1.Size = new System.Drawing.Size(1098, 714);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "Berikut ini adalah langkah langkah dalam menhapus data sidik jari Karyawan";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Untuk melanjutkan, klik Lanjutkan";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(866, 517);
            this.welcomeWizardPage1.Text = "Hapus Sidik Jari Karyawan";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.layoutControl1);
            this.wizardPage1.DescriptionText = "Pilih Karyawan yang akan diunggah data sidik jarinya";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(1050, 501);
            this.wizardPage1.Text = "Langkah Pertama - Tentukan Karyawan";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CompanyPopUp);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1050, 501);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // CompanyPopUp
            // 
            this.CompanyPopUp.Location = new System.Drawing.Point(104, 11);
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
            this.CompanyPopUp.Properties.NullText = "[EditValue is null]";
            this.CompanyPopUp.Properties.ObjectId = null;
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
            this.CompanyPopUp.Size = new System.Drawing.Size(935, 34);
            this.CompanyPopUp.StyleController = this.layoutControl1;
            this.CompanyPopUp.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCompanyId,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1050, 501);
            this.Root.TextVisible = false;
            // 
            // ItemForCompanyId
            // 
            this.ItemForCompanyId.Control = this.CompanyPopUp;
            this.ItemForCompanyId.Location = new System.Drawing.Point(0, 0);
            this.ItemForCompanyId.Name = "ItemForCompanyId";
            this.ItemForCompanyId.Size = new System.Drawing.Size(1032, 38);
            this.ItemForCompanyId.Text = "Sekolah";
            this.ItemForCompanyId.TextSize = new System.Drawing.Size(81, 21);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 38);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1032, 445);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Untuk menutup wizard ini, klik Selesai";
            this.completionWizardPage1.Size = new System.Drawing.Size(866, 517);
            this.completionWizardPage1.Text = "Berhasil Hapus Sidik Jari Karyawan";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.layoutControl2);
            this.wizardPage2.DescriptionText = "Pilih sumber mesin sidik jari yang akan diunggah, dan sesuaikan karyawan yang aka" +
    "n diunggah sidik jarinya";
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(1050, 501);
            this.wizardPage2.Text = "Langkah Kedua - Tentukan Karyawan dan Mesin";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this._SearchControlMachine);
            this.layoutControl2.Controls.Add(this._SearchControlTeacher);
            this.layoutControl2.Controls.Add(this._GridControl);
            this.layoutControl2.Controls.Add(this._GridControlTeacherTransaction);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(945, 137, 975, 600);
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(1050, 501);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // _SearchControlMachine
            // 
            this._SearchControlMachine.Client = this._GridControl;
            this._SearchControlMachine.Location = new System.Drawing.Point(135, 353);
            this._SearchControlMachine.Name = "_SearchControlMachine";
            this._SearchControlMachine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this._SearchControlMachine.Properties.Client = this._GridControl;
            this._SearchControlMachine.Size = new System.Drawing.Size(878, 34);
            this._SearchControlMachine.StyleController = this.layoutControl2;
            this._SearchControlMachine.TabIndex = 23;
            // 
            // _GridControl
            // 
            this._GridControl.DataSource = this._BindingSourceMachine;
            this._GridControl.Location = new System.Drawing.Point(11, 391);
            this._GridControl.MainView = this._GridView;
            this._GridControl.MinimumSize = new System.Drawing.Size(0, 300);
            this._GridControl.Name = "_GridControl";
            this._GridControl.Size = new System.Drawing.Size(1002, 300);
            this._GridControl.TabIndex = 21;
            this._GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridView});
            // 
            // _BindingSourceMachine
            // 
            this._BindingSourceMachine.DataSource = typeof(Domain.Entities.Attendance.Machine);
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachineCode,
            this.colMacineName,
            this.colMachineIpAddress,
            this.colCompany});
            this._GridView.DetailHeight = 351;
            this._GridView.GridControl = this._GridControl;
            this._GridView.Name = "_GridView";
            this._GridView.OptionsBehavior.Editable = false;
            this._GridView.OptionsDetail.EnableMasterViewMode = false;
            this._GridView.OptionsFind.AlwaysVisible = true;
            this._GridView.OptionsSelection.MultiSelect = true;
            this._GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this._GridView.OptionsView.ShowGroupPanel = false;
            this._GridView.OptionsView.ShowIndicator = false;
            // 
            // colMachineCode
            // 
            this.colMachineCode.Caption = "Kode Mesin";
            this.colMachineCode.FieldName = "Code";
            this.colMachineCode.MinWidth = 30;
            this.colMachineCode.Name = "colMachineCode";
            this.colMachineCode.Visible = true;
            this.colMachineCode.VisibleIndex = 3;
            this.colMachineCode.Width = 276;
            // 
            // colMacineName
            // 
            this.colMacineName.Caption = "Nama Mesin";
            this.colMacineName.FieldName = "Name";
            this.colMacineName.MinWidth = 30;
            this.colMacineName.Name = "colMacineName";
            this.colMacineName.Visible = true;
            this.colMacineName.VisibleIndex = 4;
            this.colMacineName.Width = 445;
            // 
            // colMachineIpAddress
            // 
            this.colMachineIpAddress.Caption = "Ip Address";
            this.colMachineIpAddress.FieldName = "IpAddress";
            this.colMachineIpAddress.MinWidth = 30;
            this.colMachineIpAddress.Name = "colMachineIpAddress";
            this.colMachineIpAddress.Visible = true;
            this.colMachineIpAddress.VisibleIndex = 2;
            this.colMachineIpAddress.Width = 359;
            // 
            // colCompany
            // 
            this.colCompany.Caption = "Sekolah";
            this.colCompany.FieldName = "Company.Name";
            this.colCompany.MinWidth = 30;
            this.colCompany.Name = "colCompany";
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 1;
            this.colCompany.Width = 359;
            // 
            // _SearchControlTeacher
            // 
            this._SearchControlTeacher.Client = this._GridControlTeacherTransaction;
            this._SearchControlTeacher.Location = new System.Drawing.Point(135, 11);
            this._SearchControlTeacher.Name = "_SearchControlTeacher";
            this._SearchControlTeacher.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this._SearchControlTeacher.Properties.Client = this._GridControlTeacherTransaction;
            this._SearchControlTeacher.Size = new System.Drawing.Size(878, 34);
            this._SearchControlTeacher.StyleController = this.layoutControl2;
            this._SearchControlTeacher.TabIndex = 22;
            // 
            // _GridControlTeacherTransaction
            // 
            this._GridControlTeacherTransaction.DataSource = this._BindingSourceEmployee;
            this._GridControlTeacherTransaction.Location = new System.Drawing.Point(11, 49);
            this._GridControlTeacherTransaction.MainView = this._GridViewTeacherTransaction;
            this._GridControlTeacherTransaction.MinimumSize = new System.Drawing.Size(0, 300);
            this._GridControlTeacherTransaction.Name = "_GridControlTeacherTransaction";
            this._GridControlTeacherTransaction.Size = new System.Drawing.Size(1002, 300);
            this._GridControlTeacherTransaction.TabIndex = 18;
            this._GridControlTeacherTransaction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridViewTeacherTransaction});
            // 
            // _BindingSourceEmployee
            // 
            this._BindingSourceEmployee.DataSource = typeof(Domain.Entities.HumanResource.Employee);
            // 
            // _GridViewTeacherTransaction
            // 
            this._GridViewTeacherTransaction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompanyTeacher,
            this.colCodeTeacher,
            this.colNameTeacher});
            this._GridViewTeacherTransaction.DetailHeight = 351;
            this._GridViewTeacherTransaction.GridControl = this._GridControlTeacherTransaction;
            this._GridViewTeacherTransaction.Name = "_GridViewTeacherTransaction";
            this._GridViewTeacherTransaction.OptionsBehavior.Editable = false;
            this._GridViewTeacherTransaction.OptionsDetail.EnableMasterViewMode = false;
            this._GridViewTeacherTransaction.OptionsFind.AlwaysVisible = true;
            this._GridViewTeacherTransaction.OptionsSelection.MultiSelect = true;
            this._GridViewTeacherTransaction.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this._GridViewTeacherTransaction.OptionsView.ShowGroupPanel = false;
            this._GridViewTeacherTransaction.OptionsView.ShowIndicator = false;
            // 
            // colCompanyTeacher
            // 
            this.colCompanyTeacher.Caption = "Sekolah";
            this.colCompanyTeacher.FieldName = "Company.Name";
            this.colCompanyTeacher.MinWidth = 30;
            this.colCompanyTeacher.Name = "colCompanyTeacher";
            this.colCompanyTeacher.Visible = true;
            this.colCompanyTeacher.VisibleIndex = 1;
            this.colCompanyTeacher.Width = 429;
            // 
            // colCodeTeacher
            // 
            this.colCodeTeacher.Caption = "Kode";
            this.colCodeTeacher.FieldName = "Code";
            this.colCodeTeacher.MinWidth = 30;
            this.colCodeTeacher.Name = "colCodeTeacher";
            this.colCodeTeacher.Visible = true;
            this.colCodeTeacher.VisibleIndex = 2;
            this.colCodeTeacher.Width = 305;
            // 
            // colNameTeacher
            // 
            this.colNameTeacher.Caption = "Nama";
            this.colNameTeacher.FieldName = "Name";
            this.colNameTeacher.MinWidth = 30;
            this.colNameTeacher.Name = "colNameTeacher";
            this.colNameTeacher.Visible = true;
            this.colNameTeacher.VisibleIndex = 3;
            this.colNameTeacher.Width = 705;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.ItemForTeacherTransaction,
            this.ItemForMachine});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1024, 702);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this._GridControlTeacherTransaction;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 38);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1006, 304);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this._GridControl;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 380);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1006, 304);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // ItemForTeacherTransaction
            // 
            this.ItemForTeacherTransaction.Control = this._SearchControlTeacher;
            this.ItemForTeacherTransaction.Location = new System.Drawing.Point(0, 0);
            this.ItemForTeacherTransaction.Name = "ItemForTeacherTransaction";
            this.ItemForTeacherTransaction.Size = new System.Drawing.Size(1006, 38);
            this.ItemForTeacherTransaction.Text = "Pencarian Cepat";
            this.ItemForTeacherTransaction.TextSize = new System.Drawing.Size(112, 21);
            // 
            // ItemForMachine
            // 
            this.ItemForMachine.Control = this._SearchControlMachine;
            this.ItemForMachine.Location = new System.Drawing.Point(0, 342);
            this.ItemForMachine.Name = "ItemForMachine";
            this.ItemForMachine.Size = new System.Drawing.Size(1006, 38);
            this.ItemForMachine.Text = "Pencarian Cepat";
            this.ItemForMachine.TextSize = new System.Drawing.Size(112, 21);
            // 
            // frmDeleteFingerprintWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 714);
            this.Controls.Add(this.wizardControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frmDeleteFingerprintWV.IconOptions.LargeImage")));
            this.Name = "frmDeleteFingerprintWV";
            this.Text = "Panduan Hapus Sidik Jari Karyawan";
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.wizardPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SearchControlMachine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControlTeacher.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControlTeacherTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewTeacherTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTeacherTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMachine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCompanyId;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SearchControl _SearchControlMachine;
        private DevExpress.XtraGrid.GridControl _GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridView;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMacineName;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineIpAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraEditors.SearchControl _SearchControlTeacher;
        private DevExpress.XtraGrid.GridControl _GridControlTeacherTransaction;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewTeacherTransaction;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyTeacher;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeTeacher;
        private DevExpress.XtraGrid.Columns.GridColumn colNameTeacher;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTeacherTransaction;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMachine;
        private System.Windows.Forms.BindingSource _BindingSourceEmployee;
        private System.Windows.Forms.BindingSource _BindingSourceMachine;
        private PopupContainerEditOwn CompanyPopUp;
    }
}
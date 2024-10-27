using VSTS.DESKTOP.Descendant;

namespace VSTS.DESKTOP.Transaction.Attendance
{
    partial class frmDeleteAttendanceTransactionWV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteAttendanceTransactionWV));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.dlcPage1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.CompanyPopUp = new VSTS.DESKTOP.Descendant.PopupContainerEditOwn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCompanyId = new DevExpress.XtraLayout.LayoutControlItem();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.dlcPage2 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this._SearchControl = new DevExpress.XtraEditors.SearchControl();
            this._GridControl = new DevExpress.XtraGrid.GridControl();
            this._BindingSourceMachine = new System.Windows.Forms.BindingSource(this.components);
            this._GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIpAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSearchControl = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlcPage1)).BeginInit();
            this.dlcPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyId)).BeginInit();
            this.wizardPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlcPage2)).BeginInit();
            this.dlcPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSearchControl)).BeginInit();
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
            this.wizardControl1.MinimumSize = new System.Drawing.Size(100, 99);
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
            this.welcomeWizardPage1.IntroductionText = "Berikut ini adalah langkah-langkah dalam menghapus data absensi karyawan dari mes" +
    "in sidik jari";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Untuk melanjutkan, klik Lanjutkan";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(865, 517);
            this.welcomeWizardPage1.Text = "Hapus Transaksi Absensi";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.dlcPage1);
            this.wizardPage1.DescriptionText = "Pilih kolom filter dibawah";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(1050, 501);
            this.wizardPage1.Text = "Langkah Pertama - Tentukan Sekolah";
            // 
            // dlcPage1
            // 
            this.dlcPage1.Controls.Add(this.CompanyPopUp);
            this.dlcPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlcPage1.Location = new System.Drawing.Point(0, 0);
            this.dlcPage1.Name = "dlcPage1";
            this.dlcPage1.Root = this.Root;
            this.dlcPage1.Size = new System.Drawing.Size(1050, 501);
            this.dlcPage1.TabIndex = 0;
            this.dlcPage1.Text = "dataLayoutControl1";
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
            this.CompanyPopUp.StyleController = this.dlcPage1;
            this.CompanyPopUp.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCompanyId});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1050, 501);
            this.Root.TextVisible = false;
            // 
            // ItemForCompanyId
            // 
            this.ItemForCompanyId.Control = this.CompanyPopUp;
            this.ItemForCompanyId.Location = new System.Drawing.Point(0, 0);
            this.ItemForCompanyId.Name = "ItemForCompanyId";
            this.ItemForCompanyId.Size = new System.Drawing.Size(1032, 483);
            this.ItemForCompanyId.Text = "Sekolah";
            this.ItemForCompanyId.TextSize = new System.Drawing.Size(81, 21);
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "Anda telah berhasil menyelesaikan panduan";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Untuk menutup panduan ini, klik Selesai.";
            this.completionWizardPage1.Size = new System.Drawing.Size(865, 517);
            this.completionWizardPage1.Text = "Panduan selesai";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.dlcPage2);
            this.wizardPage2.DescriptionText = "Pilih mesin sidik jari yang akan dihapus data absensinya";
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(1050, 501);
            this.wizardPage2.Text = "Langkah Kedua - Tentukan Mesin Sidik Jari";
            // 
            // dlcPage2
            // 
            this.dlcPage2.Controls.Add(this._SearchControl);
            this.dlcPage2.Controls.Add(this._GridControl);
            this.dlcPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlcPage2.Location = new System.Drawing.Point(0, 0);
            this.dlcPage2.Name = "dlcPage2";
            this.dlcPage2.Root = this.layoutControlGroup1;
            this.dlcPage2.Size = new System.Drawing.Size(1050, 501);
            this.dlcPage2.TabIndex = 0;
            this.dlcPage2.Text = "dataLayoutControl1";
            // 
            // _SearchControl
            // 
            this._SearchControl.Location = new System.Drawing.Point(135, 11);
            this._SearchControl.Name = "_SearchControl";
            this._SearchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton(),
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this._SearchControl.Size = new System.Drawing.Size(904, 34);
            this._SearchControl.StyleController = this.dlcPage2;
            this._SearchControl.TabIndex = 5;
            // 
            // _GridControl
            // 
            this._GridControl.DataSource = this._BindingSourceMachine;
            this._GridControl.Location = new System.Drawing.Point(11, 49);
            this._GridControl.MainView = this._GridView;
            this._GridControl.MinimumSize = new System.Drawing.Size(0, 300);
            this._GridControl.Name = "_GridControl";
            this._GridControl.Size = new System.Drawing.Size(1028, 441);
            this._GridControl.TabIndex = 4;
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
            this.colCompanyName,
            this.colIpAddress,
            this.colCode,
            this.colName});
            this._GridView.GridControl = this._GridControl;
            this._GridView.Name = "_GridView";
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "Sekolah";
            this.colCompanyName.FieldName = "Company.Name";
            this.colCompanyName.MinWidth = 30;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 0;
            this.colCompanyName.Width = 369;
            // 
            // colIpAddress
            // 
            this.colIpAddress.FieldName = "IpAddress";
            this.colIpAddress.MinWidth = 30;
            this.colIpAddress.Name = "colIpAddress";
            this.colIpAddress.Visible = true;
            this.colIpAddress.VisibleIndex = 1;
            this.colIpAddress.Width = 369;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.MinWidth = 30;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 2;
            this.colCode.Width = 173;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 30;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 565;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.ItemForSearchControl});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1050, 501);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this._GridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 38);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1032, 445);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForSearchControl
            // 
            this.ItemForSearchControl.Control = this._SearchControl;
            this.ItemForSearchControl.Location = new System.Drawing.Point(0, 0);
            this.ItemForSearchControl.Name = "ItemForSearchControl";
            this.ItemForSearchControl.Size = new System.Drawing.Size(1032, 38);
            this.ItemForSearchControl.Text = "Pencarian Cepat";
            this.ItemForSearchControl.TextSize = new System.Drawing.Size(112, 21);
            // 
            // frmDeleteAttendanceTransactionWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 714);
            this.Controls.Add(this.wizardControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frmDeleteAttendanceTransactionWV.IconOptions.LargeImage")));
            this.Name = "frmDeleteAttendanceTransactionWV";
            this.Text = "Panduan Hapus Transaksi Absensi";
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlcPage1)).EndInit();
            this.dlcPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCompanyId)).EndInit();
            this.wizardPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlcPage2)).EndInit();
            this.dlcPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSourceMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSearchControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraDataLayout.DataLayoutControl dlcPage1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCompanyId;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraDataLayout.DataLayoutControl dlcPage2;
        private DevExpress.XtraEditors.SearchControl _SearchControl;
        private DevExpress.XtraGrid.GridControl _GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridView;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colIpAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSearchControl;
        private System.Windows.Forms.BindingSource _BindingSourceMachine;
        private PopupContainerEditOwn CompanyPopUp;
    }
}
namespace VSTS.DESKTOP.Transaction.EducationPayment
{
    partial class frmStudentEducationDeleteWV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentEducationDeleteWV));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this._DataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this._GridControl = new DevExpress.XtraGrid.GridControl();
            this.studentEducationPaymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAmountPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StudentTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForStudent = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPaymentList = new DevExpress.XtraLayout.LayoutControlItem();
            this.wpFinish = new DevExpress.XtraWizard.CompletionWizardPage();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl1)).BeginInit();
            this._DataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentEducationPaymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.wpFinish);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.MinimumSize = new System.Drawing.Size(100, 99);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wpFinish});
            this.wizardControl1.Size = new System.Drawing.Size(1198, 856);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "Berikut ini adalah langkah langkah dalam Menghapus Penerimaan SPP";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Untuk melanjutkan, klik Lanjutkan";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(965, 659);
            this.welcomeWizardPage1.Text = "Menghapus Penerimaan SPP";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this._DataLayoutControl1);
            this.wizardPage1.DescriptionText = "Pilih Penerimaan SPP yang akan dihapus";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(1150, 643);
            this.wizardPage1.Text = "Langkah Pertama - Tentukan Penerimaan SPP";
            // 
            // _DataLayoutControl1
            // 
            this._DataLayoutControl1.Controls.Add(this._GridControl);
            this._DataLayoutControl1.Controls.Add(this.StudentTextEdit);
            this._DataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this._DataLayoutControl1.Name = "_DataLayoutControl1";
            this._DataLayoutControl1.Root = this.Root;
            this._DataLayoutControl1.Size = new System.Drawing.Size(1150, 643);
            this._DataLayoutControl1.TabIndex = 0;
            this._DataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // _GridControl
            // 
            this._GridControl.DataSource = this.studentEducationPaymentBindingSource;
            this._GridControl.Location = new System.Drawing.Point(11, 49);
            this._GridControl.MainView = this._GridView;
            this._GridControl.MinimumSize = new System.Drawing.Size(0, 400);
            this._GridControl.Name = "_GridControl";
            this._GridControl.Size = new System.Drawing.Size(1128, 583);
            this._GridControl.TabIndex = 10;
            this._GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridView});
            // 
            // studentEducationPaymentBindingSource
            // 
            this.studentEducationPaymentBindingSource.DataSource = typeof(Domain.Entities.EducationPayment.StudentEducationPayment);
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colClass,
            this.colYear,
            this.colMonth,
            this.colTotalAmount,
            this.colTotalAmountPaid});
            this._GridView.GridControl = this._GridControl;
            this._GridView.Name = "_GridView";
            // 
            // colClass
            // 
            this.colClass.Caption = "Kelas";
            this.colClass.FieldName = "Class.Name";
            this.colClass.MinWidth = 30;
            this.colClass.Name = "colClass";
            this.colClass.Visible = true;
            this.colClass.VisibleIndex = 0;
            this.colClass.Width = 112;
            // 
            // colYear
            // 
            this.colYear.Caption = "Tahun";
            this.colYear.FieldName = "Year";
            this.colYear.MinWidth = 30;
            this.colYear.Name = "colYear";
            this.colYear.Visible = true;
            this.colYear.VisibleIndex = 1;
            this.colYear.Width = 207;
            // 
            // colMonth
            // 
            this.colMonth.Caption = "Bulan";
            this.colMonth.FieldName = "Month";
            this.colMonth.MinWidth = 30;
            this.colMonth.Name = "colMonth";
            this.colMonth.Visible = true;
            this.colMonth.VisibleIndex = 2;
            this.colMonth.Width = 245;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.Caption = "Jumlah Tagihan";
            this.colTotalAmount.FieldName = "TotalAmount";
            this.colTotalAmount.MinWidth = 30;
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.Visible = true;
            this.colTotalAmount.VisibleIndex = 3;
            this.colTotalAmount.Width = 452;
            // 
            // colTotalAmountPaid
            // 
            this.colTotalAmountPaid.Caption = "Jumlah Yang Dibayar";
            this.colTotalAmountPaid.FieldName = "TotalAmountPaid";
            this.colTotalAmountPaid.MinWidth = 30;
            this.colTotalAmountPaid.Name = "colTotalAmountPaid";
            this.colTotalAmountPaid.Visible = true;
            this.colTotalAmountPaid.VisibleIndex = 4;
            this.colTotalAmountPaid.Width = 460;
            // 
            // StudentTextEdit
            // 
            this.StudentTextEdit.Location = new System.Drawing.Point(65, 11);
            this.StudentTextEdit.Name = "StudentTextEdit";
            this.StudentTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.StudentTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.StudentTextEdit.Properties.ReadOnly = true;
            this.StudentTextEdit.Size = new System.Drawing.Size(1074, 34);
            this.StudentTextEdit.StyleController = this._DataLayoutControl1;
            this.StudentTextEdit.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForStudent,
            this.ItemForPaymentList});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1150, 643);
            this.Root.TextVisible = false;
            // 
            // ItemForStudent
            // 
            this.ItemForStudent.Control = this.StudentTextEdit;
            this.ItemForStudent.Location = new System.Drawing.Point(0, 0);
            this.ItemForStudent.Name = "ItemForStudent";
            this.ItemForStudent.Size = new System.Drawing.Size(1132, 38);
            this.ItemForStudent.Text = "Murid";
            this.ItemForStudent.TextSize = new System.Drawing.Size(42, 21);
            // 
            // ItemForPaymentList
            // 
            this.ItemForPaymentList.Control = this._GridControl;
            this.ItemForPaymentList.Location = new System.Drawing.Point(0, 38);
            this.ItemForPaymentList.Name = "ItemForPaymentList";
            this.ItemForPaymentList.Size = new System.Drawing.Size(1132, 587);
            this.ItemForPaymentList.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPaymentList.TextVisible = false;
            // 
            // wpFinish
            // 
            this.wpFinish.Name = "wpFinish";
            this.wpFinish.Size = new System.Drawing.Size(965, 659);
            this.wpFinish.Text = "Berhasil menghapus Penerimaan SPP";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1150, 643);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1150, 643);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1150, 643);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // frmStudentEducationDeleteWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 856);
            this.Controls.Add(this.wizardControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frmStudentEducationDeleteWV.IconOptions.LargeImage")));
            this.Name = "frmStudentEducationDeleteWV";
            this.Text = "Panduan Menghapus Penerimaan SPP";
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl1)).EndInit();
            this._DataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentEducationPaymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraDataLayout.DataLayoutControl _DataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraWizard.CompletionWizardPage wpFinish;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStudent;
        private DevExpress.XtraGrid.GridControl _GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridView;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPaymentList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.TextEdit StudentTextEdit;
        private System.Windows.Forms.BindingSource studentEducationPaymentBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colClass;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmountPaid;
    }
}
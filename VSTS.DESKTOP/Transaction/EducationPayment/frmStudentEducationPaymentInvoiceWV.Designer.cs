namespace VSTS.DESKTOP.Transaction.EducationPayment
{
    partial class frmStudentEducationPaymentInvoiceWV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentEducationPaymentInvoiceWV));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this._DataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.PaymentAmountSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ActualDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this._GridControl = new DevExpress.XtraGrid.GridControl();
            this.studentEducationPaymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAmountPaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaymentMethodSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StudentTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForStudent = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPaymentMethod = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPaymentList = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForActualDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPayment = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.PaymentAmountSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentEducationPaymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentMethodSearchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActualDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPayment)).BeginInit();
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
            this.welcomeWizardPage1.IntroductionText = "Berikut ini adalah langkah langkah dalam Penerimaan Pembayaran Mata Anggaran pendidika" +
    "n murid";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Untuk melanjutkan, klik Lanjutkan";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(965, 659);
            this.welcomeWizardPage1.Text = "Penerimaan Pembayaran Mata Anggaran Murid";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this._DataLayoutControl1);
            this.wizardPage1.DescriptionText = "Pilih Penerimaan Pembayaran yang akan dibayar, dan pilih tipe Pembayaran";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(1150, 643);
            this.wizardPage1.Text = "Langkah Pertama - Tentukan Penerimaan Pembayaran";
            // 
            // _DataLayoutControl1
            // 
            this._DataLayoutControl1.Controls.Add(this.PaymentAmountSpinEdit);
            this._DataLayoutControl1.Controls.Add(this.ActualDateDateEdit);
            this._DataLayoutControl1.Controls.Add(this._GridControl);
            this._DataLayoutControl1.Controls.Add(this.PaymentMethodSearchLookUpEdit);
            this._DataLayoutControl1.Controls.Add(this.StudentTextEdit);
            this._DataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._DataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this._DataLayoutControl1.Name = "_DataLayoutControl1";
            this._DataLayoutControl1.Root = this.Root;
            this._DataLayoutControl1.Size = new System.Drawing.Size(1150, 643);
            this._DataLayoutControl1.TabIndex = 0;
            this._DataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // PaymentAmountSpinEdit
            // 
            this.PaymentAmountSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PaymentAmountSpinEdit.Location = new System.Drawing.Point(261, 87);
            this.PaymentAmountSpinEdit.Name = "PaymentAmountSpinEdit";
            this.PaymentAmountSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PaymentAmountSpinEdit.Size = new System.Drawing.Size(878, 34);
            this.PaymentAmountSpinEdit.StyleController = this._DataLayoutControl1;
            this.PaymentAmountSpinEdit.TabIndex = 12;
            // 
            // ActualDateDateEdit
            // 
            this.ActualDateDateEdit.EditValue = null;
            this.ActualDateDateEdit.Location = new System.Drawing.Point(261, 125);
            this.ActualDateDateEdit.Name = "ActualDateDateEdit";
            this.ActualDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ActualDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ActualDateDateEdit.Size = new System.Drawing.Size(878, 34);
            this.ActualDateDateEdit.StyleController = this._DataLayoutControl1;
            this.ActualDateDateEdit.TabIndex = 11;
            // 
            // _GridControl
            // 
            this._GridControl.DataSource = this.studentEducationPaymentBindingSource;
            this._GridControl.Location = new System.Drawing.Point(11, 163);
            this._GridControl.MainView = this._GridView;
            this._GridControl.MinimumSize = new System.Drawing.Size(0, 400);
            this._GridControl.Name = "_GridControl";
            this._GridControl.Size = new System.Drawing.Size(1128, 469);
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
            // PaymentMethodSearchLookUpEdit
            // 
            this.PaymentMethodSearchLookUpEdit.Location = new System.Drawing.Point(261, 49);
            this.PaymentMethodSearchLookUpEdit.Name = "PaymentMethodSearchLookUpEdit";
            this.PaymentMethodSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PaymentMethodSearchLookUpEdit.Properties.NullText = "";
            this.PaymentMethodSearchLookUpEdit.Properties.PopupView = this.searchLookUpEdit1View;
            this.PaymentMethodSearchLookUpEdit.Size = new System.Drawing.Size(878, 34);
            this.PaymentMethodSearchLookUpEdit.StyleController = this._DataLayoutControl1;
            this.PaymentMethodSearchLookUpEdit.TabIndex = 7;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // StudentTextEdit
            // 
            this.StudentTextEdit.Location = new System.Drawing.Point(261, 11);
            this.StudentTextEdit.Name = "StudentTextEdit";
            this.StudentTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.StudentTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.StudentTextEdit.Properties.ReadOnly = true;
            this.StudentTextEdit.Size = new System.Drawing.Size(878, 34);
            this.StudentTextEdit.StyleController = this._DataLayoutControl1;
            this.StudentTextEdit.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForStudent,
            this.ItemForPaymentMethod,
            this.ItemForPaymentList,
            this.ItemForActualDate,
            this.ItemForPayment});
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
            this.ItemForStudent.TextSize = new System.Drawing.Size(238, 21);
            // 
            // ItemForPaymentMethod
            // 
            this.ItemForPaymentMethod.Control = this.PaymentMethodSearchLookUpEdit;
            this.ItemForPaymentMethod.Location = new System.Drawing.Point(0, 38);
            this.ItemForPaymentMethod.Name = "ItemForPaymentMethod";
            this.ItemForPaymentMethod.Size = new System.Drawing.Size(1132, 38);
            this.ItemForPaymentMethod.Text = "Tipe Pembayaran";
            this.ItemForPaymentMethod.TextSize = new System.Drawing.Size(238, 21);
            // 
            // ItemForPaymentList
            // 
            this.ItemForPaymentList.Control = this._GridControl;
            this.ItemForPaymentList.Location = new System.Drawing.Point(0, 152);
            this.ItemForPaymentList.Name = "ItemForPaymentList";
            this.ItemForPaymentList.Size = new System.Drawing.Size(1132, 473);
            this.ItemForPaymentList.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPaymentList.TextVisible = false;
            // 
            // ItemForActualDate
            // 
            this.ItemForActualDate.Control = this.ActualDateDateEdit;
            this.ItemForActualDate.Location = new System.Drawing.Point(0, 114);
            this.ItemForActualDate.Name = "ItemForActualDate";
            this.ItemForActualDate.Size = new System.Drawing.Size(1132, 38);
            this.ItemForActualDate.Text = "Aktual Tanggal Slip";
            this.ItemForActualDate.TextSize = new System.Drawing.Size(238, 21);
            // 
            // ItemForPayment
            // 
            this.ItemForPayment.Control = this.PaymentAmountSpinEdit;
            this.ItemForPayment.Location = new System.Drawing.Point(0, 76);
            this.ItemForPayment.Name = "ItemForPayment";
            this.ItemForPayment.Size = new System.Drawing.Size(1132, 38);
            this.ItemForPayment.Text = "Nominal Penerimaan Pembayaran";
            this.ItemForPayment.TextSize = new System.Drawing.Size(238, 21);
            // 
            // wpFinish
            // 
            this.wpFinish.Name = "wpFinish";
            this.wpFinish.Size = new System.Drawing.Size(965, 625);
            this.wpFinish.Text = "Berhasil membuat Penerimaan Pembayaran Mata Anggaran murid";
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
            // frmStudentEducationPaymentInvoiceWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 856);
            this.Controls.Add(this.wizardControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frmStudentEducationPaymentInvoiceWV.IconOptions.LargeImage")));
            this.Name = "frmStudentEducationPaymentInvoiceWV";
            this.Text = "Panduan Penerimaan Pembayaran Mata Anggaran Murid";
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl1)).EndInit();
            this._DataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentAmountSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentEducationPaymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentMethodSearchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActualDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPayment)).EndInit();
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
        private DevExpress.XtraEditors.SearchLookUpEdit PaymentMethodSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPaymentMethod;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStudent;
        private DevExpress.XtraGrid.GridControl _GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridView;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPaymentList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.TextEdit StudentTextEdit;
        private DevExpress.XtraEditors.DateEdit ActualDateDateEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActualDate;
        private System.Windows.Forms.BindingSource studentEducationPaymentBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colClass;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmountPaid;
        private DevExpress.XtraEditors.SpinEdit PaymentAmountSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPayment;
    }
}
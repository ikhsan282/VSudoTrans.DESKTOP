namespace VSudoTrans.DESKTOP.Transaction.EducationPayment
{
    partial class frmStudentEducationDeletePaymentWV
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentEducationDeletePaymentWV));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this._DataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this._GridControl = new DevExpress.XtraGrid.GridControl();
            this.studentEducationPaymentHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.StudentTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForStudent = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPaymentList = new DevExpress.XtraLayout.LayoutControlItem();
            this.wpFinish = new DevExpress.XtraWizard.CompletionWizardPage();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.colTransactionStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrossAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this._GridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl1)).BeginInit();
            this._DataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentEducationPaymentHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDetail)).BeginInit();
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
            this.welcomeWizardPage1.IntroductionText = "Berikut ini adalah langkah langkah dalam Menghapus Penerimaan Pembayaran";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Untuk melanjutkan, klik Lanjutkan";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(965, 659);
            this.welcomeWizardPage1.Text = "Menghapus Penerimaan Pembayaran";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this._DataLayoutControl1);
            this.wizardPage1.DescriptionText = "Pilih Penerimaan Pembayaran yang akan dihapus";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(1150, 643);
            this.wizardPage1.Text = "Langkah Pertama - Tentukan Penerimaan Pembayaran";
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
            this._GridControl.DataSource = this.studentEducationPaymentHistoryBindingSource;
            gridLevelNode1.LevelTemplate = this._GridViewDetail;
            gridLevelNode1.RelationName = "StudentEducationPaymentHistoryDetails";
            this._GridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this._GridControl.Location = new System.Drawing.Point(11, 49);
            this._GridControl.MainView = this._GridView;
            this._GridControl.MinimumSize = new System.Drawing.Size(0, 400);
            this._GridControl.Name = "_GridControl";
            this._GridControl.Size = new System.Drawing.Size(1128, 583);
            this._GridControl.TabIndex = 10;
            this._GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridView,
            this._GridViewDetail});
            // 
            // studentEducationPaymentHistoryBindingSource
            // 
            this.studentEducationPaymentHistoryBindingSource.DataSource = typeof(Domain.Entities.EducationPayment.StudentEducationPaymentHistory);
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransactionStatus,
            this.colPaymentMethod,
            this.colOrderId,
            this.colGrossAmount});
            this._GridView.GridControl = this._GridControl;
            this._GridView.Name = "_GridView";
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
            this.wpFinish.Text = "Berhasil menghapus Penerimaan Pembayaran";
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
            // colTransactionStatus
            // 
            this.colTransactionStatus.Caption = "Status";
            this.colTransactionStatus.FieldName = "TransactionStatus";
            this.colTransactionStatus.MinWidth = 30;
            this.colTransactionStatus.Name = "colTransactionStatus";
            this.colTransactionStatus.Visible = true;
            this.colTransactionStatus.VisibleIndex = 0;
            this.colTransactionStatus.Width = 245;
            // 
            // colPaymentMethod
            // 
            this.colPaymentMethod.Caption = "Tipe Pembayaran";
            this.colPaymentMethod.FieldName = "PaymentMethod";
            this.colPaymentMethod.MinWidth = 30;
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.Visible = true;
            this.colPaymentMethod.VisibleIndex = 1;
            this.colPaymentMethod.Width = 291;
            // 
            // colOrderId
            // 
            this.colOrderId.Caption = "Nomor Transaksi";
            this.colOrderId.FieldName = "OrderId";
            this.colOrderId.MinWidth = 30;
            this.colOrderId.Name = "colOrderId";
            this.colOrderId.Visible = true;
            this.colOrderId.VisibleIndex = 2;
            this.colOrderId.Width = 468;
            // 
            // colGrossAmount
            // 
            this.colGrossAmount.Caption = "Jumlah";
            this.colGrossAmount.FieldName = "GrossAmount";
            this.colGrossAmount.MinWidth = 30;
            this.colGrossAmount.Name = "colGrossAmount";
            this.colGrossAmount.Visible = true;
            this.colGrossAmount.VisibleIndex = 3;
            this.colGrossAmount.Width = 472;
            // 
            // _GridViewDetail
            // 
            this._GridViewDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAmount,
            this.colNote});
            this._GridViewDetail.GridControl = this._GridControl;
            this._GridViewDetail.Name = "_GridViewDetail";
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Jumlah";
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 30;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 0;
            this.colAmount.Width = 112;
            // 
            // colNote
            // 
            this.colNote.Caption = "Catatan";
            this.colNote.FieldName = "Note";
            this.colNote.MinWidth = 30;
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 1;
            this.colNote.Width = 112;
            // 
            // frmStudentEducationDeletePaymentWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 856);
            this.Controls.Add(this.wizardControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frmStudentEducationDeletePaymentWV.IconOptions.LargeImage")));
            this.Name = "frmStudentEducationDeletePaymentWV";
            this.Text = "Panduan Menghapus Penerimaan Pembayaran";
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._DataLayoutControl1)).EndInit();
            this._DataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentEducationPaymentHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPaymentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridViewDetail)).EndInit();
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
        private System.Windows.Forms.BindingSource studentEducationPaymentHistoryBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderId;
        private DevExpress.XtraGrid.Columns.GridColumn colGrossAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
    }
}
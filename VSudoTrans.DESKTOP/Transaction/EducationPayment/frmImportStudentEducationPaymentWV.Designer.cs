namespace VSudoTrans.DESKTOP.Transaction.EducationPayment
{
    partial class frmImportStudentEducationPaymentWV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportStudentEducationPaymentWV));
            this.colFailureDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchoolCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNIS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEducationComponentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // _BindingSource
            // 
            this._BindingSource.DataSource = typeof(Contract.EducationPayment.ImportStudentEducationPaymentModel);
            // 
            // layoutControl1
            // 
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(945, 268, 975, 600);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControl1.Controls.SetChildIndex(this._GridControl, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnOK, 0);
            this.layoutControl1.Controls.SetChildIndex(this.btnCancel, 0);
            this.layoutControl1.Controls.SetChildIndex(this._SearchControl, 0);
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
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatusImport,
            this.colSchoolCode,
            this.colClassName,
            this.colNIS,
            this.colDueDate,
            this.colEducationComponentCode,
            this.colAmount,
            this.colFailureDescription});
            this._GridView.OptionsBehavior.Editable = false;
            this._GridView.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this._GridView.OptionsCustomization.AllowFilter = false;
            this._GridView.OptionsCustomization.AllowGroup = false;
            this._GridView.OptionsFind.AllowFindPanel = false;
            this._GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this._GridView.OptionsSelection.MultiSelect = true;
            this._GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this._GridView.OptionsView.ColumnAutoWidth = false;
            this._GridView.OptionsView.ShowAutoFilterRow = true;
            this._GridView.OptionsView.ShowGroupPanel = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(972, 716);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(754, 716);
            // 
            // ItemForButtonOK
            // 
            this.ItemForButtonOK.Location = new System.Drawing.Point(743, 705);
            // 
            // ItemForButtonCancel
            // 
            this.ItemForButtonCancel.Location = new System.Drawing.Point(961, 705);
            // 
            // _SearchControl
            // 
            // 
            // colFailureDescription
            // 
            this.colFailureDescription.Caption = "Deskripsi Kegagalan";
            this.colFailureDescription.FieldName = "FailureDescription";
            this.colFailureDescription.MinWidth = 30;
            this.colFailureDescription.Name = "colFailureDescription";
            this.colFailureDescription.Visible = true;
            this.colFailureDescription.VisibleIndex = 7;
            this.colFailureDescription.Width = 366;
            // 
            // colStatusImport
            // 
            this.colStatusImport.Caption = "Status";
            this.colStatusImport.FieldName = "StatusImport";
            this.colStatusImport.MinWidth = 30;
            this.colStatusImport.Name = "colStatusImport";
            this.colStatusImport.Visible = true;
            this.colStatusImport.VisibleIndex = 0;
            this.colStatusImport.Width = 112;
            // 
            // colSchoolCode
            // 
            this.colSchoolCode.Caption = "Kode Sekolah";
            this.colSchoolCode.FieldName = "SchoolCode";
            this.colSchoolCode.MinWidth = 30;
            this.colSchoolCode.Name = "colSchoolCode";
            this.colSchoolCode.Visible = true;
            this.colSchoolCode.VisibleIndex = 1;
            this.colSchoolCode.Width = 129;
            // 
            // colClassName
            // 
            this.colClassName.Caption = "Kelas";
            this.colClassName.FieldName = "ClassName";
            this.colClassName.MinWidth = 30;
            this.colClassName.Name = "colClassName";
            this.colClassName.Visible = true;
            this.colClassName.VisibleIndex = 2;
            this.colClassName.Width = 91;
            // 
            // colNIS
            // 
            this.colNIS.Caption = "NIS";
            this.colNIS.FieldName = "NIS";
            this.colNIS.MinWidth = 30;
            this.colNIS.Name = "colNIS";
            this.colNIS.Visible = true;
            this.colNIS.VisibleIndex = 3;
            this.colNIS.Width = 176;
            // 
            // colDueDate
            // 
            this.colDueDate.Caption = "Jatuh Tempo";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.MinWidth = 30;
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 4;
            this.colDueDate.Width = 140;
            // 
            // colEducationComponentCode
            // 
            this.colEducationComponentCode.Caption = "Kode Mata Anggaran";
            this.colEducationComponentCode.FieldName = "EducationComponentCode";
            this.colEducationComponentCode.MinWidth = 30;
            this.colEducationComponentCode.Name = "colEducationComponentCode";
            this.colEducationComponentCode.Visible = true;
            this.colEducationComponentCode.VisibleIndex = 5;
            this.colEducationComponentCode.Width = 161;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Jumlah";
            this.colAmount.FieldName = "Amount";
            this.colAmount.MinWidth = 30;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 6;
            this.colAmount.Width = 204;
            // 
            // frmImportStudentEducationPaymentWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 756);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmImportStudentEducationPaymentWV.IconOptions.Image")));
            this.Name = "frmImportStudentEducationPaymentWV";
            this.Text = "frmImportGroupWV";
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colStatusImport;
        private DevExpress.XtraGrid.Columns.GridColumn colFailureDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colSchoolCode;
        private DevExpress.XtraGrid.Columns.GridColumn colClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colNIS;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEducationComponentCode;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
    }
}
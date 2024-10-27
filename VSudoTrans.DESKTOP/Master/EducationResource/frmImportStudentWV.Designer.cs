namespace VSudoTrans.DESKTOP.Master.EducationResource
{
    partial class frmImportStudentWV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportStudentWV));
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFailureDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchoolCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForceYearName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNISN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJoinDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReligion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMajorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRombelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentalStatus = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this._BindingSource.DataSource = typeof(Contract.EducationResource.ImportStudentModel);
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
            this.colForceYearName,
            this.colClassName,
            this.colMajorCode,
            this.colRombelName,
            this.colNISN,
            this.colCode,
            this.colName,
            this.colJoinDate,
            this.colEndDate,
            this.colGender,
            this.colReligion,
            this.colBirthPlace,
            this.colBirthDate,
            this.colNote,
            this.colFailureDescription,
            this.colParentalStatus});
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
            // _SearchControl
            // 
            // 
            // colCode
            // 
            this.colCode.Caption = "NIS";
            this.colCode.FieldName = "Code";
            this.colCode.MinWidth = 30;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 7;
            this.colCode.Width = 214;
            // 
            // colName
            // 
            this.colName.Caption = "Nama";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 30;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 8;
            this.colName.Width = 326;
            // 
            // colNote
            // 
            this.colNote.Caption = "Catatan";
            this.colNote.FieldName = "Note";
            this.colNote.MinWidth = 30;
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 16;
            this.colNote.Width = 330;
            // 
            // colFailureDescription
            // 
            this.colFailureDescription.Caption = "Deskripsi Kegagalan";
            this.colFailureDescription.FieldName = "FailureDescription";
            this.colFailureDescription.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colFailureDescription.MinWidth = 30;
            this.colFailureDescription.Name = "colFailureDescription";
            this.colFailureDescription.Visible = true;
            this.colFailureDescription.VisibleIndex = 17;
            this.colFailureDescription.Width = 342;
            // 
            // colStatusImport
            // 
            this.colStatusImport.Caption = "Status";
            this.colStatusImport.FieldName = "StatusImport";
            this.colStatusImport.MinWidth = 30;
            this.colStatusImport.Name = "colStatusImport";
            this.colStatusImport.Visible = true;
            this.colStatusImport.VisibleIndex = 0;
            this.colStatusImport.Width = 104;
            // 
            // colSchoolCode
            // 
            this.colSchoolCode.Caption = "Kode Sekolah";
            this.colSchoolCode.FieldName = "SchoolCode";
            this.colSchoolCode.MinWidth = 30;
            this.colSchoolCode.Name = "colSchoolCode";
            this.colSchoolCode.Visible = true;
            this.colSchoolCode.VisibleIndex = 1;
            this.colSchoolCode.Width = 112;
            // 
            // colClassName
            // 
            this.colClassName.Caption = "Kelas";
            this.colClassName.FieldName = "ClassName";
            this.colClassName.MinWidth = 30;
            this.colClassName.Name = "colClassName";
            this.colClassName.Visible = true;
            this.colClassName.VisibleIndex = 3;
            this.colClassName.Width = 69;
            // 
            // colForceYearName
            // 
            this.colForceYearName.Caption = "Angkatan";
            this.colForceYearName.FieldName = "ForceYearName";
            this.colForceYearName.MinWidth = 30;
            this.colForceYearName.Name = "colForceYearName";
            this.colForceYearName.Visible = true;
            this.colForceYearName.VisibleIndex = 2;
            this.colForceYearName.Width = 93;
            // 
            // colNISN
            // 
            this.colNISN.Caption = "NISN";
            this.colNISN.FieldName = "NISN";
            this.colNISN.MinWidth = 30;
            this.colNISN.Name = "colNISN";
            this.colNISN.Visible = true;
            this.colNISN.VisibleIndex = 6;
            this.colNISN.Width = 112;
            // 
            // colJoinDate
            // 
            this.colJoinDate.Caption = "Tanggal Masuk";
            this.colJoinDate.FieldName = "JoinDate";
            this.colJoinDate.MinWidth = 30;
            this.colJoinDate.Name = "colJoinDate";
            this.colJoinDate.Visible = true;
            this.colJoinDate.VisibleIndex = 9;
            this.colJoinDate.Width = 123;
            // 
            // colGender
            // 
            this.colGender.Caption = "Jenis Kelamin";
            this.colGender.FieldName = "Gender";
            this.colGender.MinWidth = 30;
            this.colGender.Name = "colGender";
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 11;
            this.colGender.Width = 112;
            // 
            // colReligion
            // 
            this.colReligion.Caption = "Agama";
            this.colReligion.FieldName = "Religion";
            this.colReligion.MinWidth = 30;
            this.colReligion.Name = "colReligion";
            this.colReligion.Visible = true;
            this.colReligion.VisibleIndex = 12;
            this.colReligion.Width = 112;
            // 
            // colBirthPlace
            // 
            this.colBirthPlace.Caption = "Tempat Lahir";
            this.colBirthPlace.FieldName = "BirthPlace";
            this.colBirthPlace.MinWidth = 30;
            this.colBirthPlace.Name = "colBirthPlace";
            this.colBirthPlace.Visible = true;
            this.colBirthPlace.VisibleIndex = 14;
            this.colBirthPlace.Width = 112;
            // 
            // colBirthDate
            // 
            this.colBirthDate.Caption = "Tanggal Lahir";
            this.colBirthDate.FieldName = "BirthDate";
            this.colBirthDate.MinWidth = 30;
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.Visible = true;
            this.colBirthDate.VisibleIndex = 15;
            this.colBirthDate.Width = 112;
            // 
            // colMajorCode
            // 
            this.colMajorCode.Caption = "Jurusan";
            this.colMajorCode.FieldName = "MajorCode";
            this.colMajorCode.MinWidth = 30;
            this.colMajorCode.Name = "colMajorCode";
            this.colMajorCode.Visible = true;
            this.colMajorCode.VisibleIndex = 4;
            this.colMajorCode.Width = 112;
            // 
            // colRombelName
            // 
            this.colRombelName.Caption = "Rombel";
            this.colRombelName.FieldName = "RombelName";
            this.colRombelName.MinWidth = 30;
            this.colRombelName.Name = "colRombelName";
            this.colRombelName.Visible = true;
            this.colRombelName.VisibleIndex = 5;
            this.colRombelName.Width = 71;
            // 
            // colEndDate
            // 
            this.colEndDate.Caption = "Tanggal Keluar";
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.MinWidth = 30;
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 10;
            this.colEndDate.Width = 123;
            // 
            // colParentalStatus
            // 
            this.colParentalStatus.Caption = "Status Orang Tua";
            this.colParentalStatus.FieldName = "ParentalStatus";
            this.colParentalStatus.MinWidth = 30;
            this.colParentalStatus.Name = "colParentalStatus";
            this.colParentalStatus.Visible = true;
            this.colParentalStatus.VisibleIndex = 13;
            this.colParentalStatus.Width = 141;
            // 
            // frmImportStudentWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 756);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmImportStudentWV.IconOptions.Image")));
            this.Name = "frmImportStudentWV";
            this.Text = "frmImportStudentWV";
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
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colFailureDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colSchoolCode;
        private DevExpress.XtraGrid.Columns.GridColumn colClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colForceYearName;
        private DevExpress.XtraGrid.Columns.GridColumn colNISN;
        private DevExpress.XtraGrid.Columns.GridColumn colJoinDate;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colReligion;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn colMajorCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRombelName;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colParentalStatus;
    }
}
namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    partial class frmImportEmployeeWV
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
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFailureDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchoolCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrganizationStructureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobPositionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobGradeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJoinDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResignationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReligion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this._BindingSource.DataSource = typeof(Contract.HumanResource.ImportEmployeeModel);
            // 
            // layoutControl1
            // 
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(945, 268, 975, 600);
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
            this.colCode,
            this.colName,
            this.colOrganizationStructureCode,
            this.colJobPositionCode,
            this.colJobGradeCode,
            this.colJoinDate,
            this.colResignationDate,
            this.colPhoneNumber,
            this.colGender,
            this.colReligion,
            this.colBirthPlace,
            this.colBirthDate,
            this.colNote,
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
            // _SearchControl
            // 
            // 
            // colCode
            // 
            this.colCode.Caption = "Kode";
            this.colCode.FieldName = "Code";
            this.colCode.MinWidth = 30;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 2;
            this.colCode.Width = 193;
            // 
            // colName
            // 
            this.colName.Caption = "Nama";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 30;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 337;
            // 
            // colNote
            // 
            this.colNote.Caption = "Catatan";
            this.colNote.FieldName = "Note";
            this.colNote.MinWidth = 30;
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 14;
            this.colNote.Width = 298;
            // 
            // colFailureDescription
            // 
            this.colFailureDescription.Caption = "Deskripsi Kegagalan";
            this.colFailureDescription.FieldName = "FailureDescription";
            this.colFailureDescription.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colFailureDescription.MinWidth = 30;
            this.colFailureDescription.Name = "colFailureDescription";
            this.colFailureDescription.Visible = true;
            this.colFailureDescription.VisibleIndex = 15;
            this.colFailureDescription.Width = 311;
            // 
            // colStatusImport
            // 
            this.colStatusImport.Caption = "Status";
            this.colStatusImport.FieldName = "StatusImport";
            this.colStatusImport.MinWidth = 30;
            this.colStatusImport.Name = "colStatusImport";
            this.colStatusImport.Visible = true;
            this.colStatusImport.VisibleIndex = 0;
            this.colStatusImport.Width = 97;
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
            // colOrganizationStructureCode
            // 
            this.colOrganizationStructureCode.Caption = "Kode Organisasi";
            this.colOrganizationStructureCode.FieldName = "OrganizationStructureCode";
            this.colOrganizationStructureCode.MinWidth = 30;
            this.colOrganizationStructureCode.Name = "colOrganizationStructureCode";
            this.colOrganizationStructureCode.Visible = true;
            this.colOrganizationStructureCode.VisibleIndex = 4;
            this.colOrganizationStructureCode.Width = 131;
            // 
            // colJobPositionCode
            // 
            this.colJobPositionCode.Caption = "Kode Posisi";
            this.colJobPositionCode.FieldName = "JobPositionCode";
            this.colJobPositionCode.MinWidth = 30;
            this.colJobPositionCode.Name = "colJobPositionCode";
            this.colJobPositionCode.Visible = true;
            this.colJobPositionCode.VisibleIndex = 5;
            this.colJobPositionCode.Width = 112;
            // 
            // colJobGradeCode
            // 
            this.colJobGradeCode.Caption = "Kode Golongan";
            this.colJobGradeCode.FieldName = "JobGradeCode";
            this.colJobGradeCode.MinWidth = 30;
            this.colJobGradeCode.Name = "colJobGradeCode";
            this.colJobGradeCode.Visible = true;
            this.colJobGradeCode.VisibleIndex = 6;
            this.colJobGradeCode.Width = 125;
            // 
            // colJoinDate
            // 
            this.colJoinDate.Caption = "Tanggal Masuk";
            this.colJoinDate.FieldName = "JoinDate";
            this.colJoinDate.MinWidth = 30;
            this.colJoinDate.Name = "colJoinDate";
            this.colJoinDate.Visible = true;
            this.colJoinDate.VisibleIndex = 7;
            this.colJoinDate.Width = 183;
            // 
            // colResignationDate
            // 
            this.colResignationDate.Caption = "Tanggal Keluar";
            this.colResignationDate.FieldName = "ResignationDate";
            this.colResignationDate.MinWidth = 30;
            this.colResignationDate.Name = "colResignationDate";
            this.colResignationDate.Visible = true;
            this.colResignationDate.VisibleIndex = 8;
            this.colResignationDate.Width = 178;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.Caption = "Nomor Telepon";
            this.colPhoneNumber.FieldName = "PhoneNumber";
            this.colPhoneNumber.MinWidth = 30;
            this.colPhoneNumber.Name = "colPhoneNumber";
            this.colPhoneNumber.Visible = true;
            this.colPhoneNumber.VisibleIndex = 9;
            this.colPhoneNumber.Width = 194;
            // 
            // colGender
            // 
            this.colGender.Caption = "Jenis Kelamin";
            this.colGender.FieldName = "Gender";
            this.colGender.MinWidth = 30;
            this.colGender.Name = "colGender";
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 10;
            this.colGender.Width = 112;
            // 
            // colReligion
            // 
            this.colReligion.Caption = "Agama";
            this.colReligion.FieldName = "Religion";
            this.colReligion.MinWidth = 30;
            this.colReligion.Name = "colReligion";
            this.colReligion.Visible = true;
            this.colReligion.VisibleIndex = 11;
            this.colReligion.Width = 112;
            // 
            // colBirthPlace
            // 
            this.colBirthPlace.Caption = "Tempat Lahir";
            this.colBirthPlace.FieldName = "BirthPlace";
            this.colBirthPlace.MinWidth = 30;
            this.colBirthPlace.Name = "colBirthPlace";
            this.colBirthPlace.Visible = true;
            this.colBirthPlace.VisibleIndex = 12;
            this.colBirthPlace.Width = 144;
            // 
            // colBirthDate
            // 
            this.colBirthDate.Caption = "Tanggal Lahir";
            this.colBirthDate.FieldName = "BirthDate";
            this.colBirthDate.MinWidth = 30;
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.Visible = true;
            this.colBirthDate.VisibleIndex = 13;
            this.colBirthDate.Width = 206;
            // 
            // frmImportEmployeeWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 756);
            this.Name = "frmImportEmployeeWV";
            this.Text = "frmImportEmployeeWV";
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
        private DevExpress.XtraGrid.Columns.GridColumn colOrganizationStructureCode;
        private DevExpress.XtraGrid.Columns.GridColumn colJobPositionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colJobGradeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colJoinDate;
        private DevExpress.XtraGrid.Columns.GridColumn colResignationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colReligion;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
    }
}
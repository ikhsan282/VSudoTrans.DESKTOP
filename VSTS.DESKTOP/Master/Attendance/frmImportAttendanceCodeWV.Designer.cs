﻿namespace VSTS.DESKTOP.Master.Attendance
{
    partial class frmImportAttendanceCodeWV
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
            this.colGroupType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignmentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaxLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurationDay = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this._BindingSource.DataSource = typeof(Contract.Attendance.ImportAttendanceCodeModel);
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
            this.colGroupType,
            this.colAssignmentType,
            this.colGender,
            this.colMaxLeave,
            this.colDurationDay,
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
            this.colNote.VisibleIndex = 9;
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
            this.colFailureDescription.VisibleIndex = 10;
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
            // colGroupType
            // 
            this.colGroupType.Caption = "Kelompok";
            this.colGroupType.FieldName = "GroupType";
            this.colGroupType.MinWidth = 30;
            this.colGroupType.Name = "colGroupType";
            this.colGroupType.Visible = true;
            this.colGroupType.VisibleIndex = 4;
            this.colGroupType.Width = 112;
            // 
            // colAssignmentType
            // 
            this.colAssignmentType.Caption = "Jenis";
            this.colAssignmentType.FieldName = "AssignmentType";
            this.colAssignmentType.MinWidth = 30;
            this.colAssignmentType.Name = "colAssignmentType";
            this.colAssignmentType.Visible = true;
            this.colAssignmentType.VisibleIndex = 5;
            this.colAssignmentType.Width = 112;
            // 
            // colGender
            // 
            this.colGender.Caption = "Jenis Kelamin";
            this.colGender.FieldName = "Gender";
            this.colGender.MinWidth = 30;
            this.colGender.Name = "colGender";
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 6;
            this.colGender.Width = 112;
            // 
            // colMaxLeave
            // 
            this.colMaxLeave.Caption = "Maximal";
            this.colMaxLeave.FieldName = "MaxLeave";
            this.colMaxLeave.MinWidth = 30;
            this.colMaxLeave.Name = "colMaxLeave";
            this.colMaxLeave.Visible = true;
            this.colMaxLeave.VisibleIndex = 7;
            this.colMaxLeave.Width = 112;
            // 
            // colDurationDay
            // 
            this.colDurationDay.Caption = "Durasi Hari";
            this.colDurationDay.FieldName = "DurationDay";
            this.colDurationDay.MinWidth = 30;
            this.colDurationDay.Name = "colDurationDay";
            this.colDurationDay.Visible = true;
            this.colDurationDay.VisibleIndex = 8;
            this.colDurationDay.Width = 112;
            // 
            // frmImportAttendanceCodeWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 756);
            this.Name = "frmImportAttendanceCodeWV";
            this.Text = "frmImportAttendanceCodeWV";
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
        private DevExpress.XtraGrid.Columns.GridColumn colGroupType;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignmentType;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colDurationDay;
    }
}
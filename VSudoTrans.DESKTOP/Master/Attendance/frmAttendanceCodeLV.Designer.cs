﻿namespace VSudoTrans.DESKTOP.Master.Attendance
{
    partial class frmAttendanceCodeLV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendanceCodeLV));
            this.colCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignmentType = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.AccessibleName = "Search Item";
            this.ribbonControl.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(1227, 254);
            //
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 254);
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1227, 324);
            this.dataLayoutControl1.Controls.SetChildIndex(this._GridControl, 0);
            this.dataLayoutControl1.Controls.SetChildIndex(this._SearchControl, 0);
            // 
            // _GridControl
            // 
            this._GridControl.DataSource = this._BindingSource;
            this._GridControl.Location = new System.Drawing.Point(11, 75);
            this._GridControl.Size = new System.Drawing.Size(1205, 238);
            // 
            // _GridView
            // 
            this._GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompanyName,
            this.colCode,
            this.colName,
            this.colGroupType,
            this.colAssignmentType});
            this._GridView.DetailHeight = 350;
            this._GridView.OptionsBehavior.Editable = false;
            this._GridView.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this._GridView.OptionsCustomization.AllowFilter = false;
            this._GridView.OptionsCustomization.AllowGroup = false;
            this._GridView.OptionsFind.AllowFindPanel = false;
            this._GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this._GridView.OptionsSelection.MultiSelect = true;
            this._GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this._GridView.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.Size = new System.Drawing.Size(1227, 324);
            // 
            // layoutControlItem1
            // 
            this.ItemForGridControl.Location = new System.Drawing.Point(0, 64);
            this.ItemForGridControl.Size = new System.Drawing.Size(1209, 242);
            // 
            // _SearchControl
            // 
            this._SearchControl.Location = new System.Drawing.Point(11, 37);
            this._SearchControl.Size = new System.Drawing.Size(1205, 34);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Size = new System.Drawing.Size(1209, 64);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(112, 21);
            // 
            // _BindingSource
            // 
            this._BindingSource.DataSource = typeof(Domain.Entities.Attendance.AttendanceCode);
            // 
            // colCompanyName
            // 
            this.colCompanyName.Caption = "Sekolah";
            this.colCompanyName.FieldName = "Company.Name";
            this.colCompanyName.MinWidth = 30;
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.Visible = true;
            this.colCompanyName.VisibleIndex = 0;
            this.colCompanyName.Width = 295;
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.MinWidth = 30;
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 160;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 30;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 339;
            // 
            // colGroupType
            // 
            this.colGroupType.Caption = "Kategori";
            this.colGroupType.FieldName = "GroupType";
            this.colGroupType.MinWidth = 30;
            this.colGroupType.Name = "colGroupType";
            this.colGroupType.Visible = true;
            this.colGroupType.VisibleIndex = 3;
            this.colGroupType.Width = 339;
            // 
            // colAssignmentType
            // 
            this.colAssignmentType.Caption = "Tipe Kode";
            this.colAssignmentType.FieldName = "AssignmentType";
            this.colAssignmentType.MinWidth = 30;
            this.colAssignmentType.Name = "colAssignmentType";
            this.colAssignmentType.Visible = true;
            this.colAssignmentType.VisibleIndex = 4;
            this.colAssignmentType.Width = 343;
            // 
            // frmAttendanceCodeLV
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 578);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmAttendanceCodeLV";
            this.Text = "Kode Kehadiran";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupType;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignmentType;
    }
}
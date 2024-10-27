namespace VSudoTrans.DESKTOP.Transaction.Attendance
{
    partial class frmChangeShiftWV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeShiftWV));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ShiftPopUp = new VSudoTrans.DESKTOP.Descendant.PopupContainerEditOwn();
            this.ItemForShift = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftPopUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnCancel);
            this.layoutControl.Controls.Add(this.btnSave);
            this.layoutControl.Controls.Add(this.ShiftPopUp);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(623, 156);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForShift,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(25, 25, 25, 25);
            this.Root.Size = new System.Drawing.Size(623, 156);
            this.Root.TextVisible = false;
            // 
            // ShiftPopUp
            // 
            this.ShiftPopUp.Location = new System.Drawing.Point(71, 27);
            this.ShiftPopUp.Name = "ShiftPopUp";
            this.ShiftPopUp.ObjectId = null;
            this.ShiftPopUp.OptionsCascadeControl = null;
            this.ShiftPopUp.OptionsCascadeMember = null;
            this.ShiftPopUp.OptionsChildControl = null;
            this.ShiftPopUp.OptionsDataSource = null;
            this.ShiftPopUp.OptionsDataType = null;
            this.ShiftPopUp.OptionsDisplayCaption = null;
            this.ShiftPopUp.OptionsDisplayColumns = null;
            this.ShiftPopUp.OptionsDisplayText = null;
            this.ShiftPopUp.OptionsDisplayTitle = null;
            this.ShiftPopUp.OptionsDisplayWidth = null;
            this.ShiftPopUp.OptionsFilterColumns = null;
            this.ShiftPopUp.OptionsSortColumns = null;
            this.ShiftPopUp.Properties.Appearance.Options.UseTextOptions = true;
            this.ShiftPopUp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ShiftPopUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ShiftPopUp.Properties.ObjectId = "";
            this.ShiftPopUp.Properties.OptionsCascadeControl = null;
            this.ShiftPopUp.Properties.OptionsCascadeMember = "";
            this.ShiftPopUp.Properties.OptionsChildControl = null;
            this.ShiftPopUp.Properties.OptionsDataSource = null;
            this.ShiftPopUp.Properties.OptionsDataType = VSudoTrans.DESKTOP.Descendant.EnumDataSource.VirtualMode;
            this.ShiftPopUp.Properties.OptionsDisplayCaption = "";
            this.ShiftPopUp.Properties.OptionsDisplayColumns = "";
            this.ShiftPopUp.Properties.OptionsDisplayFormat = "";
            this.ShiftPopUp.Properties.OptionsDisplayText = "";
            this.ShiftPopUp.Properties.OptionsDisplayTitle = "";
            this.ShiftPopUp.Properties.OptionsDisplayWidth = "";
            this.ShiftPopUp.Properties.OptionsFilterColumns = "";
            this.ShiftPopUp.Properties.OptionsSortColumns = "";
            this.ShiftPopUp.Size = new System.Drawing.Size(525, 34);
            this.ShiftPopUp.StyleController = this.layoutControl;
            this.ShiftPopUp.TabIndex = 4;
            // 
            // ItemForShift
            // 
            this.ItemForShift.Control = this.ShiftPopUp;
            this.ItemForShift.Location = new System.Drawing.Point(0, 0);
            this.ItemForShift.Name = "ItemForShift";
            this.ItemForShift.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 12);
            this.ItemForShift.Size = new System.Drawing.Size(573, 48);
            this.ItemForShift.Text = "Shift";
            this.ItemForShift.TextSize = new System.Drawing.Size(32, 21);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(337, 58);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(364, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 32);
            this.btnSave.StyleController = this.layoutControl;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Simpan";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.Location = new System.Drawing.Point(337, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(114, 58);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(478, 75);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 32);
            this.btnCancel.StyleController = this.layoutControl;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Batal";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(451, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(122, 58);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmChangeShiftWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 156);
            this.Controls.Add(this.layoutControl);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmChangeShiftWV.IconOptions.SvgImage")));
            this.Name = "frmChangeShiftWV";
            this.Text = "Ubah Shift";
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftPopUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private Descendant.PopupContainerEditOwn ShiftPopUp;
        private DevExpress.XtraLayout.LayoutControlItem ItemForShift;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
namespace VSTS.DESKTOP.BaseForm
{
    partial class frmBaseImportWV
    {

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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this._BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this._SearchControl = new DevExpress.XtraEditors.SearchControl();
            this._GridControl = new DevExpress.XtraGrid.GridControl();
            this._GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForButtonOK = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForButtonCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroupSummary = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForGridControl = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSearch = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this._SearchControl);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOK);
            this.layoutControl1.Controls.Add(this._GridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(945, 268, 975, 600);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1198, 756);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControlImport";
            // 
            // _SearchControl
            // 
            this._SearchControl.Client = this._GridControl;
            this._SearchControl.Location = new System.Drawing.Point(103, 53);
            this._SearchControl.Name = "_SearchControl";
            this._SearchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this._SearchControl.Properties.Client = this._GridControl;
            this._SearchControl.Size = new System.Drawing.Size(1072, 34);
            this._SearchControl.StyleController = this.layoutControl1;
            this._SearchControl.TabIndex = 10;
            // 
            // _GridControl
            // 
            this._GridControl.DataSource = this._BindingSource;
            this._GridControl.Location = new System.Drawing.Point(26, 94);
            this._GridControl.MainView = this._GridView;
            this._GridControl.Name = "_GridControl";
            this._GridControl.Size = new System.Drawing.Size(1146, 600);
            this._GridControl.TabIndex = 4;
            this._GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._GridView});
            // 
            // _GridView
            // 
            this._GridView.GridControl = this._GridControl;
            this._GridView.Name = "_GridView";
            this._GridView.OptionsView.ColumnAutoWidth = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(972, 713);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(215, 32);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Batal";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(754, 713);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(214, 32);
            this.btnOK.StyleController = this.layoutControl1;
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForButtonOK,
            this.ItemForButtonCancel,
            this.emptySpaceItem1,
            this.layoutControlGroupSummary});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1198, 756);
            this.Root.TextVisible = false;
            // 
            // ItemForButtonOK
            // 
            this.ItemForButtonOK.Control = this.btnOK;
            this.ItemForButtonOK.Location = new System.Drawing.Point(743, 702);
            this.ItemForButtonOK.Name = "ItemForButtonOK";
            this.ItemForButtonOK.Size = new System.Drawing.Size(218, 36);
            this.ItemForButtonOK.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForButtonOK.TextVisible = false;
            // 
            // ItemForButtonCancel
            // 
            this.ItemForButtonCancel.Control = this.btnCancel;
            this.ItemForButtonCancel.Location = new System.Drawing.Point(961, 702);
            this.ItemForButtonCancel.Name = "ItemForButtonCancel";
            this.ItemForButtonCancel.Size = new System.Drawing.Size(219, 36);
            this.ItemForButtonCancel.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForButtonCancel.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 702);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(743, 36);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroupSummary
            // 
            this.layoutControlGroupSummary.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Total Data : 0", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, false, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Total Sukses : 0", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, false, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Total Gagal : 0", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, false, false, true, null, -1)});
            this.layoutControlGroupSummary.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutControlGroupSummary.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForGridControl,
            this.ItemForSearch});
            this.layoutControlGroupSummary.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupSummary.Name = "layoutControlGroupSummary";
            this.layoutControlGroupSummary.Size = new System.Drawing.Size(1180, 702);
            this.layoutControlGroupSummary.Text = "Ringkasan";
            // 
            // ItemForGridControl
            // 
            this.ItemForGridControl.Control = this._GridControl;
            this.ItemForGridControl.Location = new System.Drawing.Point(0, 38);
            this.ItemForGridControl.Name = "ItemForGridControl";
            this.ItemForGridControl.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.ItemForGridControl.Size = new System.Drawing.Size(1156, 610);
            this.ItemForGridControl.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForGridControl.TextVisible = false;
            // 
            // ItemForSearch
            // 
            this.ItemForSearch.Control = this._SearchControl;
            this.ItemForSearch.Location = new System.Drawing.Point(0, 0);
            this.ItemForSearch.Name = "ItemForSearch";
            this.ItemForSearch.Size = new System.Drawing.Size(1156, 38);
            this.ItemForSearch.Text = "Pencarian";
            this.ItemForSearch.TextSize = new System.Drawing.Size(68, 21);
            // 
            // frmBaseImportWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 756);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.Image = global::VSTS.DESKTOP.Properties.Resources.Logo_VsudoTech;
            this.MinimizeBox = false;
            this.Name = "frmBaseImportWV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Import";
            ((System.ComponentModel.ISupportInitialize)(this._BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SearchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.BindingSource _BindingSource;
        public DevExpress.XtraLayout.LayoutControl layoutControl1;
        public DevExpress.XtraLayout.LayoutControlGroup Root;
        public DevExpress.XtraGrid.GridControl _GridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView _GridView;
        public DevExpress.XtraLayout.LayoutControlItem ItemForGridControl;
        public DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton btnOK;
        public DevExpress.XtraLayout.LayoutControlItem ItemForButtonOK;
        public DevExpress.XtraLayout.LayoutControlItem ItemForButtonCancel;
        public DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        public DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupSummary;
        public DevExpress.XtraEditors.SearchControl _SearchControl;
        public DevExpress.XtraLayout.LayoutControlItem ItemForSearch;
        private System.ComponentModel.IContainer components;
    }
}
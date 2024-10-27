namespace VSudoTrans.DESKTOP.BaseForm
{
    partial class frmBaseWV
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
            this._DxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // frmBaseWV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 709);
            this.Name = "frmBaseWV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Wizard";
            this.Load += new System.EventHandler(this.frmBaseWV_Load);
            ((System.ComponentModel.ISupportInitialize)(this._DxValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.IContainer components;
        public DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider _DxValidationProvider;
    }
}
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonsPanelControl;
using Domain;
using System.Drawing;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.BaseForm
{
    public partial class frmBaseImportWV : XtraForm
    {
        public frmBaseImportWV()
        {
            InitializeComponent();

            GridHelper.GridViewInitializeLayout(_GridView);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControl, fNextPage: true, fNext: true, fPrev: true, fPrevPage: true);
            SearchControlHelper.InitializeSearchControl(_SearchControl);

            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;

            _GridView.RowCellStyle += _GridView_RowCellStyle;
            _GridView.OptionsView.ShowAutoFilterRow = true;

            this.FormClosing += FrmBaseImportWV_FormClosing;
        }

        private void _GridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var status = _GridView.GetRowCellValue(e.RowHandle, "StatusImport") as string;
            if (!string.IsNullOrEmpty(status))
            {
                if (status == EnumStatusImport.Success || status == EnumStatusImport.SuccessfullyValidated)
                    e.Appearance.BackColor = Color.LightGreen;
                else if (status == EnumStatusImport.Failed)
                    e.Appearance.BackColor = Color.LightPink;
                else
                    e.Appearance.BackColor = Color.LightYellow;
            }
        }

        private void FrmBaseImportWV_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.None)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public void SetSummary(int total, int success, int failed)
        {
            layoutControlGroupSummary.CustomHeaderButtons.Clear();

            GroupBoxButton groupBoxButtonTotalData = new GroupBoxButton()
            {
                Caption = $"Total Data : {total}"
            };

            layoutControlGroupSummary.CustomHeaderButtons.Add(groupBoxButtonTotalData);

            GroupBoxButton groupBoxButtonTotalSuccess = new GroupBoxButton()
            {
                Caption = $"Total Sukses : {success}"
            };

            layoutControlGroupSummary.CustomHeaderButtons.Add(groupBoxButtonTotalSuccess);

            GroupBoxButton groupBoxButtonTotalFailed = new GroupBoxButton()
            {
                Caption = $"Total Gagal : {failed}"
            };

            layoutControlGroupSummary.CustomHeaderButtons.Add(groupBoxButtonTotalFailed);
        }
    }
}

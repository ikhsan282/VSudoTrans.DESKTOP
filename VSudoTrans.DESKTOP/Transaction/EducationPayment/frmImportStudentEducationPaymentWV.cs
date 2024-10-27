using VSudoTrans.DESKTOP.BaseForm;

namespace VSudoTrans.DESKTOP.Transaction.EducationPayment
{
    public partial class frmImportStudentEducationPaymentWV : frmBaseImportWV
    {
        public frmImportStudentEducationPaymentWV()
        {
            InitializeComponent();

            this.Text = "Import Penerimaan SPP";
            _GridView.ExpandAllGroups();
            colStatusImport.Group();
        }
    }
}

using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;
using System.Collections.Generic;
using System;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using Domain.Entities.EducationResource;
using Domain.Entities.EducationPayment;
using System.Linq;
using Domain;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using Contract.EducationPayment;
using Newtonsoft.Json;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace VSudoTrans.DESKTOP.Transaction.EducationPayment
{
    public partial class frmStudentEducationDeletePaymentWV : frmBaseWV
    {
        public StudentEducationPaymentHistory _StudentEducationPaymentHistory;
        public frmStudentEducationDeletePaymentWV(Student student)
        {
            InitializeComponent();
            this.EndPoint = "/StudentEducationPayments";
            this.FormTitle = "Panduan Menghapus Penerimaan Pembayaran";

            wizardPage1.PageValidating += WizardPage1_PageValidating;

            GridHelper.GridViewInitializeLayout(_GridView);
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControl, fNext: true, fPrev: true);
            _GridView.OptionsDetail.EnableMasterViewMode = true;
            _GridView.OptionsSelection.MultiSelect = true;
            _GridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            _GridView.OptionsBehavior.Editable = false;
            _GridView.OptionsFind.FindFilterColumns = "OrderId";
            _GridView.OptionsView.ShowIndicator = false;

            _GridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;

            GridHelper.GridColumnInitializeLayout(colGrossAmount, typeof(decimal), "n2", fTotal: true);


            GridHelper.GridViewInitializeLayout(this._GridViewDetail);
            _GridViewDetail.ViewCaption = "Detail";
            _GridViewDetail.OptionsView.ShowFooter = true;
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);

            InitializeComponentAfter();

            InitializeSearchLookup();

            wizardControl1.CustomizeCommandButtons += WizardControl1_CustomizeCommandButtons;

            StudentTextEdit.EditValue = $"{student.Code} - {student.Name}";

            var studentEducationPaymentHistorys = HelperRestSharp.GetListOdata<StudentEducationPaymentHistory>("/StudentEducationPaymentHistorys", "*", "StudentEducationPaymentHistoryDetails", $"StudentId eq {student.Id} and TransactionStatus eq 'success'", fOrder: "Id");

            _GridControl.DataSource = studentEducationPaymentHistorys;

            colTransactionStatus.Group();
            _GridView.ExpandAllGroups();
        }

        private void WizardControl1_CustomizeCommandButtons(object sender, DevExpress.XtraWizard.CustomizeCommandButtonsEventArgs e)
        {
            if (e.Page == wpFinish)
            {
                e.PrevButton.Visible = false;
                e.CancelButton.Visible = false;
            }
        }

        protected override void InitializeSearchLookup()
        {

        }

        private void ValidatePage1()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StudentTextEdit, ConditionOperator.IsNotBlank);
        }

        private void WizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                ValidatePage1();
                if (!ActionValidate(_DxValidationProvider))
                {
                    e.Valid = false;
                    return;
                }

                List<StudentEducationPaymentHistory> studentEducationPaymentHistorys = GetListDataRowSelected(_GridView).OfType<StudentEducationPaymentHistory>().ToList();
                if (!studentEducationPaymentHistorys.Any())
                {
                    MessageHelper.ShowMessageError(this, "Tidak ada Penerimaan Pembayaran yang dipilih");
                    e.Valid = false;
                    return;
                }

                string msgResult = string.Empty;
                int loop = 0;

                foreach (var studentEducationPaymentHistory in studentEducationPaymentHistorys)
                {
                    loop++;
                    msgResult += $"{loop}. Penerimaan Pembayaran Nomor Transaksi {studentEducationPaymentHistory.OrderId}\r\n";
                }

                if (MessageHelper.ShowMessageQuestion($"Apakah anda yakin untuk menghapus Penerimaan Pembayaran berikut :\r\n{msgResult}", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Valid = false;
                    return;
                }

                MessageHelper.WaitFormShow(this);
                try
                {
                    var jsonString = JsonConvert.SerializeObject(studentEducationPaymentHistorys.Select(s => s.Id).ToList());
                    var result = HelperRestSharp.DeleteRange($"/StudentEducationPaymentHistorys/Multiple", jsonString);
                }
                catch (Exception)
                {

                }
                finally
                {
                    MessageHelper.WaitFormClose(this);
                }
            }
            else if (e.Direction == DevExpress.XtraWizard.Direction.Backward)
                MyValidationHelper.ClearError(_DxValidationProvider);
        }
    }
}

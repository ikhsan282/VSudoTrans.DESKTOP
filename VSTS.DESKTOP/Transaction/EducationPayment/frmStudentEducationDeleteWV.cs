using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;
using System.Collections.Generic;
using System;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using Domain.Entities.EducationResource;
using Domain.Entities.EducationPayment;
using System.Linq;
using Domain;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using Contract.EducationPayment;
using Newtonsoft.Json;

namespace VSTS.DESKTOP.Transaction.EducationPayment
{
    public partial class frmStudentEducationDeleteWV : frmBaseWV
    {
        public StudentEducationPaymentHistory _StudentEducationPaymentHistory;
        Student _Student;
        public frmStudentEducationDeleteWV(Student student)
        {
            InitializeComponent();
            this.EndPoint = "/StudentEducationPayments";
            this.FormTitle = "Panduan Menghapus Penerimaan SPP";

            wizardPage1.PageValidating += WizardPage1_PageValidating;

            GridHelper.GridViewInitializeLayout(this._GridView);
            _GridView.OptionsView.ShowFooter = true;
            SetGridViewCheckBoxRowSelect(_GridControl, _GridView, null, "Year;Month");
            _GridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;

            GridHelper.GridColumnInitializeLayout(colTotalAmount, typeof(decimal), "n2", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colTotalAmountPaid, typeof(decimal), "n2", fTotal: true);

            InitializeComponentAfter();
;
            InitializeSearchLookup();

            wizardControl1.CustomizeCommandButtons += WizardControl1_CustomizeCommandButtons;

            _GridView.RowCellStyle += _GridView_RowCellStyle;
            _GridView.CustomDrawCell += _GridView_CustomDrawCell;

            _Student = student;
            StudentTextEdit.EditValue = $"{student.Code} - {student.Name}";

            var studentEducationPayments = HelperRestSharp.GetListOdata<StudentEducationPayment>("/StudentEducationPayments", "*", "Class", $"StudentId eq {student.Id}", fOrder: "Id");

            _GridControl.DataSource = studentEducationPayments;

            colClass.Group();
            _GridView.ExpandAllGroups();

            decimal totalAmount = studentEducationPayments.Sum(s => s.TotalAmount);
            decimal totalAmountPaid = studentEducationPayments.Sum(s => s.TotalAmountPaid);
            decimal totalBill = totalAmount - totalAmountPaid;

            var studentEducationPayment = studentEducationPayments
                .Where(s => s.PaymentStatus == EnumPaymentStatus.Unpaid || s.PaymentStatus == EnumPaymentStatus.PartiallyPaid)
                .OrderBy(s => s.Class.Index)
                .ThenBy(s => s.Year)
                .ThenBy(s => s.Month).FirstOrDefault();
        }
        private void _GridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue != DBNull.Value && e.CellValue != null)
            {
                if (e.Column.FieldName.Contains("Month"))
                {
                    e.DisplayText = HelperConvert.MonthText(e.CellValue.ToString());
                }
            }
        }

        private void _GridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var amount = HelperConvert.Decimal(_GridView.GetRowCellValue(e.RowHandle, colTotalAmount));
            var amountPaid = HelperConvert.Decimal(_GridView.GetRowCellValue(e.RowHandle, colTotalAmountPaid));
            if (amountPaid >= amount)
                e.Appearance.BackColor = Color.LightGreen;
            else if (amountPaid < amount && amountPaid != 0)
                e.Appearance.BackColor = Color.LightYellow;
            else
                e.Appearance.BackColor = Color.LightPink;
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

                List<StudentEducationPayment> studentEducationPayments = GetListDataRowSelected(_GridView).OfType<StudentEducationPayment>().ToList();
                if (!studentEducationPayments.Any())
                {
                    MessageHelper.ShowMessageError(this, "Tidak ada Penerimaan SPP yang dipilih");
                    e.Valid = false;
                    return;
                }

                string msgResult = string.Empty;
                int loop = 0;

                foreach (var studentEducationPaymentPaid in studentEducationPayments)
                {
                    loop++;
                    msgResult += $"{loop}. Penerimaan SPP Kelas {studentEducationPaymentPaid.Class.Name} Bulan {studentEducationPaymentPaid.Month} Tahun {studentEducationPaymentPaid.Year}\r\n";
                }

                if (MessageHelper.ShowMessageQuestion($"Apakah anda yakin untuk menghapus Penerimaan SPP berikut :\r\n{msgResult}", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Valid = false;
                    return;
                }

                MessageHelper.WaitFormShow(this);
                try
                {
                    var jsonString = JsonConvert.SerializeObject(studentEducationPayments.Select(s => s.Id).ToList());
                    var result = HelperRestSharp.DeleteRange($"/StudentEducationPayments/Multiple", jsonString);
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

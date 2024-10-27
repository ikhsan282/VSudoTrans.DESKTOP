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
    public partial class frmStudentEducationPaymentInvoiceWV : frmBaseWV
    {
        public StudentEducationPaymentHistory _StudentEducationPaymentHistory;
        Student _Student;
        public frmStudentEducationPaymentInvoiceWV(Student student)
        {
            InitializeComponent();
            this.EndPoint = "/StudentEducationPayments";
            this.FormTitle = "Panduan Penerimaan Pembayaran Mata Anggaran Murid";

            wizardPage1.PageValidating += WizardPage1_PageValidating;

            HelperConvert.FormatSpinEdit(PaymentAmountSpinEdit, "n0", 0, 99999999);

            HelperConvert.FormatDateEdit(ActualDateDateEdit);

            GridHelper.GridViewInitializeLayout(this._GridView);
            _GridView.OptionsView.ShowFooter = true;

            GridHelper.GridColumnInitializeLayout(colTotalAmount, typeof(decimal), "n2", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colTotalAmountPaid, typeof(decimal), "n2", fTotal: true);

            InitializeComponentAfter();

            InitializeSearchLookup();

            SLUHelper.SetEnumDataSource(PaymentMethodSearchLookUpEdit, new Converter<EnumPaymentMethod, string>(EnumHelper.EnumPaymentMethodToString));

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

            if (studentEducationPayment != null)
            {
                PaymentAmountSpinEdit.EditValue = studentEducationPayment.TotalAmount;
            }

            PaymentAmountSpinEdit.ReadOnly = false;
            if (totalBill <= 0)
            {
                PaymentAmountSpinEdit.Properties.MinValue = 0;
                PaymentAmountSpinEdit.Properties.MaxValue = 0;
                PaymentAmountSpinEdit.ReadOnly = true;
            }
            else
            {
                PaymentAmountSpinEdit.Properties.MinValue = 0;
                PaymentAmountSpinEdit.Properties.MaxValue = totalBill;
            }
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
            PaymentMethodSearchLookUpEdit.EditValue = EnumPaymentMethod.Cash;
            ActualDateDateEdit.EditValue = DateTime.Today;
        }

        private void ValidatePage1()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.StudentTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PaymentMethodSearchLookUpEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.PaymentAmountSpinEdit, ConditionOperator.IsNotBlank);
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

                if (HelperConvert.Decimal(PaymentAmountSpinEdit.EditValue) <= 0)
                {
                    MessageHelper.ShowMessageError(this, "Penerimaan Pembayaran sudah lunas, tidak bisa dipilih!");
                    e.Valid = false;
                    return;
                }

                if (MessageHelper.ShowMessageQuestion($"Apakah anda yakin untuk melakukan Penerimaan Pembayaran {HelperConvert.FormatRupiah(HelperConvert.Decimal(PaymentAmountSpinEdit.EditValue))} dengan metode {EnumHelper.EnumPaymentMethodToString((EnumPaymentMethod)PaymentMethodSearchLookUpEdit.EditValue)}", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Valid = false;
                    return;
                }


                MessageHelper.WaitFormShow(this);
                try
                {
                    PaymentStudentEducationDto paymentStudentEducation = new PaymentStudentEducationDto()
                    {
                        StudentId = _Student.Id,
                        PaymentMethod = (EnumPaymentMethod)PaymentMethodSearchLookUpEdit.EditValue,
                        ActualDate = HelperConvert.Date(ActualDateDateEdit.EditValue),
                        Amount = HelperConvert.Decimal(PaymentAmountSpinEdit.EditValue),
                    };

                    var jsonString = JsonConvert.SerializeObject(paymentStudentEducation);
                    var result = HelperRestSharp.Post($"/StudentEducationPayments/Payment", jsonString);

                    if (result != null)
                        _StudentEducationPaymentHistory = JsonConvert.DeserializeObject<StudentEducationPaymentHistory>(result);
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

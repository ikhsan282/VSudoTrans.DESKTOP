using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Domain;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using Domain.Entities.SQLView.EducationPayment;
using Microsoft.Graph.Models;
using System;
using System.Drawing;
using System.Linq;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Report.EducationPayment;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Transaction.EducationPayment
{
    public partial class frmStudentEducationPaymentDV : frmBaseDV
    {
        Student _Student;
        public frmStudentEducationPaymentDV(object id, string endPoint, object copy = null)
        {
            this.EntityId = id;
            this.EndPoint = endPoint;
            this.OdataCopyId = copy;
            InitializeComponent();

            InitializeComponentAfter<Student>();

            InitializeSearchLookup();

            bbiSave.ItemClick += BbiSave_ItemClick;
            bbiSaveAndClose.ItemClick += BbiSaveAndClose_ItemClick;
            bbiSaveAndNew.ItemClick += BbiSaveAndNew_ItemClick;

            bbiEPaymentInvoice.ItemClick += BbiEPaymentInvoice_ItemClick;
            bbiPayment.ItemClick += BbiPayment_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiDeletePayment.ItemClick += BbiDeletePayment_ItemClick;

            HelperConvert.FormatDateTimeEdit(CreatedDateDateEdit);
            HelperConvert.FormatDateTimeEdit(ModifiedDateDateEdit);
            HelperConvert.FormatSpinEdit(BalanceSpinEdit, "n0", 0, 9999999999);

            bbiSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bbiSaveAndClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bbiSaveAndNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            GridHelper.GridViewInitializeLayout(_GridViewPaymentHistory);
            _GridViewPaymentHistory.OptionsView.ShowFooter = true;
            GridHelper.GridColumnInitializeLayout(colGrossAmount, typeof(decimal), "n2", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colExpiryTime, typeof(DateTime), "dd-MMM-yyyy HH:mm:ss");
            colTransactionStatus.Group();

            GridHelper.GridViewInitializeLayout(_GridViewPaymentHistoryDetail);
            this._GridViewPaymentHistoryDetail.ViewCaption = "Detail";
            _GridViewPaymentHistoryDetail.OptionsView.ShowFooter = true;
            GridHelper.GridColumnInitializeLayout(colAmount2, typeof(decimal), "n2", fTotal: true);

            tabbedControlGroupDetail.SelectedPageChanged += TabbedControlGroupDetail_SelectedPageChanged;
            bbiEPaymentInvoice.Visibility = BarItemVisibility.Never;


            GridHelper.GridViewInitializeLayout(_GridViewPayment);
            _GridViewPayment.OptionsView.ShowFooter = true;
            GridHelper.GridColumnInitializeLayout(colAmountPaid, typeof(decimal), "n2", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);

            GridHelper.GridViewInitializeLayout(_GridViewPaymentComponent);
            this._GridViewPaymentComponent.ViewCaption = "Detail Mata Anggaran";
            GridHelper.GridColumnInitializeLayout(colAmount1, typeof(decimal), "n2", fTotal: true);
            _GridViewPaymentComponent.OptionsView.ShowFooter = true;

            _GridViewPayment.RowCellStyle += _GridViewPayment_RowCellStyle;
            _GridViewPayment.CustomDrawCell += _GridViewPayment_CustomDrawCell;

            bbiPaymentBook.ItemClick += BbiPaymentBook_ItemClick;
            bbiArrearPaymentBook.ItemClick += BbiArrearPaymentBook_ItemClick;

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
        }

        private void BbiDeletePayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new frmStudentEducationDeletePaymentWV(_Student))
            {
                form.ShowDialog();

                ActionRefresh();
            }
        }

        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new frmStudentEducationDeleteWV(_Student))
            {
                form.ShowDialog();

                ActionRefresh();
            }
        }

        private void _GridViewPayment_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue != DBNull.Value && e.CellValue != null)
            {
                if (e.Column.FieldName.Contains("Month"))
                {
                    e.DisplayText = HelperConvert.MonthText(e.CellValue.ToString());
                }
            }

            if (e.Column.FieldName.Contains("Student"))
            {
                var gridView = (GridView)sender;
                if (e.Column.FieldName == "Student")
                {
                    var row = gridView.GetRow(e.RowHandle) as StudentEducationPayment;
                    if (row != null)
                    {
                        e.DisplayText = HelperConvert.FormatRupiah(row.TotalAmount - row.TotalAmountPaid).ToString();
                    }

                }
            }
        }

        private void BbiArrearPaymentBook_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_Student == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }

            string expand = "Class($select=id,name)";
            expand += ",Major($select=id,code,Name)";
            expand += ",Rombel($select=id,Name)";
            expand += ",Company";
            expand += ",StudentEducationPayments($expand=Class)";
            var student = HelperRestSharp.GetOdata<Student>("/Students", "*", expand, $"id eq {_Student.Id}");

            var formDetail = new frmEArrearPaymentBookDVV(student);

            try
            {
                if (formDetail != null)
                {
                    formDetail.MdiParent = MdiParent;
                    formDetail.Show();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
        }

        private void BbiPaymentBook_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_Student == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }

            string expand = "Class($select=id,name)";
            expand += ",Major($select=id,code,Name)";
            expand += ",Rombel($select=id,Name)";
            expand += ",Company";
            expand += ",StudentEducationPayments($expand=Class)";
            var student = HelperRestSharp.GetOdata<Student>("/Students", "*", expand, $"id eq {_Student.Id}");

            var formDetail = new frmEPaymentBookDVV(student);

            try
            {
                if (formDetail != null)
                {
                    formDetail.MdiParent = MdiParent;
                    formDetail.Show();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
        }

        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionRefresh();
        }

        private void _GridViewPayment_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var amount = HelperConvert.Decimal(_GridViewPayment.GetRowCellValue(e.RowHandle, colAmount));
            var amountPaid = HelperConvert.Decimal(_GridViewPayment.GetRowCellValue(e.RowHandle, colAmountPaid));
            if (amountPaid >= amount)
                e.Appearance.BackColor = Color.LightGreen;
            else if (amountPaid < amount && amountPaid != 0)
                e.Appearance.BackColor = Color.LightYellow;
            else
                e.Appearance.BackColor = Color.LightPink;
        }

        private void TabbedControlGroupDetail_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
        {
            bbiEPaymentInvoice.Visibility = BarItemVisibility.Never;
            if (tabbedControlGroupDetail.SelectedTabPage.Name == "layoutControlGroupHistoryPayment")
                bbiEPaymentInvoice.Visibility = BarItemVisibility.Always;
        }

        private void BbiEPaymentInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var id = GetIdOfDataRowSelected(_GridViewPaymentHistory);
            if (id == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }
            string expand = "Student($select=id,code,name;$expand=Major($select=Code,name),Rombel($select=name))";
            expand += ",Class($select=id,name)";
            expand += ",Company";
            expand += ",StudentEducationPaymentHistoryDetails";
            var studentEducationPaymentHistory = HelperRestSharp.GetOdata<StudentEducationPaymentHistory>("/StudentEducationPaymentHistorys", "*", expand, $"id eq {id}");

            var formDetail = new frmEPaymentInvoiceDVV(studentEducationPaymentHistory);

            try
            {
                if (formDetail != null)
                {
                    formDetail.MdiParent = MdiParent;
                    formDetail.Show();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
        }

        private void BbiPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new frmStudentEducationPaymentInvoiceWV(_Student))
            {
                form.ShowDialog();

                ActionRefresh();
            }
        }

        protected override void InitializeFomTitle(string fieldName = "Code")
        {
            base.InitializeFomTitle("Code;Name;Class.Name;Major.Code;Rombel.Name");
        }

        protected override void InitializeDefaultValidation()
        {

        }

        protected override void DisplayEntity<T>()
        {
            base.DisplayEntity<T>();

            _Student = OdataEntity as Student;

            ActionRefresh();
        }

        private void ActionRefresh()
        {
            if (_Student != null)
            {
                if (_Student.Company != null)
                    CompanyTextEdit.EditValue = $"{_Student.Company.Code} - {_Student.Company.Name}";

                if (_Student.Class != null)
                    ClassTextEdit.EditValue = $"{_Student.Class.Name} {_Student.Major.Code} {_Student.Rombel.Name}";

                StudentTextEdit.EditValue = $"{_Student.Code} - {_Student.Name}";

                BalanceSpinEdit.EditValue = _Student.Balance;

                var student = HelperRestSharp.GetOdata<Student>("/Students", "Balance", "", $"Id eq {_Student.Id}");

                if (student != null)
                    BalanceSpinEdit.EditValue = student.Balance;

                var studentEducationPayments = HelperRestSharp.GetListOdata<StudentEducationPayment>("/StudentEducationPayments", "*", "Class,StudentEducationPaymentComponents($select=Amount,AmountPaid;$expand=EducationComponent($select=code,name,EducationType))", $"StudentId eq {_Student.Id}", fOrder: "Id");

                #region Pemisahan formulir menjadi 1 row
                var studentEducationPaymentFormulir = new StudentEducationPayment();
                foreach (var studentEducationPayment in studentEducationPayments)
                {

                    foreach (var studentEducationPaymentComponent in studentEducationPayment.StudentEducationPaymentComponents)
                    {
                        if (studentEducationPaymentComponent.EducationComponent.EducationType == EnumEducationType.FormulirPendaftaran)
                        {
                            studentEducationPaymentFormulir.Id = studentEducationPayment.Id;
                            studentEducationPaymentFormulir.Class = studentEducationPayment.Class;
                            studentEducationPaymentFormulir.Class = studentEducationPayment.Class;
                            studentEducationPaymentFormulir.Year = studentEducationPayment.Year;
                            studentEducationPaymentFormulir.Month = studentEducationPayment.Month;
                            studentEducationPaymentFormulir.PaymentStatus = studentEducationPayment.PaymentStatus;
                            studentEducationPaymentFormulir.StudentEducationPaymentComponents = studentEducationPayment.StudentEducationPaymentComponents
                                .Where(s => s.EducationComponent.EducationType == EnumEducationType.FormulirPendaftaran)
                                .ToList();
                            studentEducationPaymentFormulir.TotalAmount = studentEducationPaymentFormulir.StudentEducationPaymentComponents.Sum(s => s.Amount);
                            studentEducationPaymentFormulir.TotalAmountPaid = studentEducationPaymentFormulir.StudentEducationPaymentComponents.Sum(s => s.AmountPaid);
                        }
                    }

                    if (studentEducationPaymentFormulir.StudentEducationPaymentComponents != null)
                    {
                        foreach (var item in studentEducationPaymentFormulir.StudentEducationPaymentComponents)
                        {
                            studentEducationPayment.StudentEducationPaymentComponents.Remove(item);
                        }
                    }

                    studentEducationPayment.TotalAmount = studentEducationPayment.StudentEducationPaymentComponents.Sum(s => s.Amount);
                    studentEducationPayment.TotalAmountPaid = studentEducationPayment.StudentEducationPaymentComponents.Sum(s => s.AmountPaid);
                }

                if (studentEducationPaymentFormulir.Id > 0)
                    studentEducationPayments.Add(studentEducationPaymentFormulir);
                #endregion

                studentEducationPayments = studentEducationPayments.OrderBy(s => s.Year).ThenBy(s => s.Month).ThenBy(s => s.TotalAmount).ToList();

                _GridControlPayment.DataSource = studentEducationPayments;

                var studentEducationPaymentHistorys = HelperRestSharp.GetListOdata<StudentEducationPaymentHistory>("/StudentEducationPaymentHistorys", "*", "StudentEducationPaymentHistoryDetails", $"StudentId eq {_Student.Id}", fOrder: "Id");

                _GridControlPaymentHistory.DataSource = studentEducationPaymentHistorys;
            }

            colClass.Group();
            _GridViewPayment.ExpandAllGroups();
        }

        protected override void InitializeSearchLookup()
        {

        }

        private void BbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveNew<StudentEducationPayment>();
        }

        private void BbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSaveClose<StudentEducationPayment>();
        }

        private void BbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ActionValidate())
            {
                return;
            }
            ActionSave<StudentEducationPayment>();
        }

        protected override void ActionEndEdit()
        {
            base.ActionEndEdit();

            _Student = new Student()
            {

            };

            OdataEntity = _Student;
        }

        protected override object CreateEntity<T>()
        {
            return base.CreateEntity<StudentEducationPayment>();
        }

        protected override object UpdateEntity<T>()
        {
            return base.UpdateEntity<StudentEducationPayment>();
        }
    }
}

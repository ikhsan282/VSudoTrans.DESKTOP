using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using Domain.Entities.Organization;
using Newtonsoft.Json;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Transaction.EducationPayment
{
    public partial class frmStudentEducationPaymentWV : frmBaseWV
    {
        List<Student> _DataStudent = new List<Student>();
        List<Student> _Student = new List<Student>();
        public frmStudentEducationPaymentWV()
        {
            InitializeComponent();
            this.EndPoint = "/StudentEducationPayments";
            this.FormTitle = "Panduan Membuat Mata Anggaran Penerimaan Pembayaran Pendidikan Murid";

            InitializeComponentAfter();

            InitializeSearchLookup();

            HelperConvert.FormatDateEdit(EffectiveDateDateEdit);

            EffectiveDateDateEdit.EditValue = DateTime.Today;

            GridHelper.GridViewInitializeLayout(this._GridViewResultStudentEducationPayment);

            GridHelper.GridViewInitializeLayout(this._GridViewStudentEducationPayments);
            _GridViewStudentEducationPayments.ViewCaption = "Mata Anggaran Penerimaan Pembayaran Pendidikan";
            GridHelper.GridColumnInitializeLayout(colTotalAmount, typeof(decimal), "n2");

            GridHelper.GridViewInitializeLayout(this._GridViewStudentEducationPaymentComponents);
            _GridViewStudentEducationPaymentComponents.ViewCaption = "Detail Mata Anggaran Penerimaan Pembayaran Pendidikan Murid";
            GridHelper.GridColumnInitializeLayout(colDate, typeof(DateTime));
            GridHelper.GridColumnInitializeLayout(colResultAmount, typeof(decimal), "n2");

            GridHelper.GridViewInitializeLayout(this._GridViewEducationComponentRegulation);
            SetGridViewCheckBoxRowSelect(_GridControlEducationComponentRegulation, _GridViewEducationComponentRegulation, _SearchControlEducationComponent, "Company.Name;Code;Name");
            this._GridViewEducationComponentRegulation.OptionsDetail.EnableMasterViewMode = true;

            GridHelper.GridViewInitializeLayout(this._GridViewEducationComponentRegulationDetail);
            this._GridViewEducationComponentRegulationDetail.ViewCaption = "Detail Peraturan Mata Anggaran";
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2");
            GridHelper.GridColumnInitializeLayout(colPaymentPerInstallment, typeof(decimal), "n2");

            GridHelper.GridViewInitializeLayout(this._GridViewStudent);
            SetGridViewCheckBoxRowSelect(_GridControlStudent, _GridViewStudent, _SearchControlStudent, "Code;Name");

            GridHelper.GridViewInitializeLayout(this._GridViewStudentSelect);
            SetGridViewCheckBoxRowSelect(_GridControlStudentSelect, _GridViewStudentSelect, _SearchControlStudentSelect, "Code;Name");
            _GridViewStudent.SelectionChanged += _GridViewStudent_SelectionChanged;
            _GridViewStudentSelect.SelectionChanged += _GridViewStudent_SelectionChanged;

            btnAdd.Click += _btnAddController_Click;
            btnRemove.Click += _btnRemoveController_Click;

            _BindingSourceStudentSelect.DataSource = _DataStudent;

            _GridViewStudent.OptionsView.ShowAutoFilterRow = true;
            _GridViewStudentSelect.OptionsView.ShowAutoFilterRow = true;
            _GridViewStudent.OptionsView.ShowViewCaption = true;
            _GridViewStudent.ViewCaption = "Daftar Murid";
            _GridViewStudentSelect.OptionsView.ShowViewCaption = true;
            _GridViewStudentSelect.ViewCaption = "Data Murid Terpilih";


            _GridViewStudent.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            _GridViewStudentSelect.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;

            wizardPage1.PageValidating += WizardPage1_PageValidating;
            wizardPage2.PageValidating += WizardPage2_PageValidating;
            wizardPage3.PageValidating += WizardPage3_PageValidating;
            wizardPage4.PageValidating += WizardPage4_PageValidating;
        }

        private void _GridViewStudent_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (e.Action == CollectionChangeAction.Add && gridView == _GridViewStudent)
            {
                _GridViewStudentSelect.ClearSelection();
            }
            else if (e.Action == CollectionChangeAction.Add && gridView == _GridViewStudentSelect)
            {
                _GridViewStudent.ClearSelection();
            }
        }

        private void _btnRemoveController_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _GridViewStudentSelect.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;

            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Murid belum ada yang terpilih !");
                return;
            }

            _GridViewStudentSelect.DeleteSelectedRows();
            _GridViewStudentSelect.BestFitColumns(true);

            _GridViewStudentSelect.RefreshData();
            _GridViewStudent.RefreshData();
        }

        private void _btnAddController_Click(object sender, EventArgs e)
        {
            var selectedEmployee = _GridViewStudent.GetSelectedRows();
            bool checkCount = selectedEmployee.Count() > 0;
            if (!checkCount)
            {
                MessageHelper.ShowMessageInformation(this, "Data Murid belum ada yang terpilih !");
                return;

            }

            foreach (var item in selectedEmployee)
            {
                var dataRow = _GridViewStudent.GetRow(item) as Student;
                if (!_DataStudent.Any(x => x.Id == dataRow.Id))
                {
                    _DataStudent.Add(dataRow);
                };
            }

            _GridViewStudentSelect.BestFitColumns(true);
            _GridViewStudent.ClearSelection();
            _GridViewStudentSelect.RefreshData();
            _GridViewStudent.RefreshData();
        }

        protected override void InitializeSearchLookup()
        {
            PopupEditHelper.Company(CompanyPopUp);
            PopupEditHelper.General<Class>(fEndPoint: "/Classes", fTitle: "Kelas", fControl: ClassPopUp, fCascade: CompanyPopUp, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fDisplayText: "Name");
        }

        private void ValidatePage1()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.CompanyPopUp, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.ClassPopUp, ConditionOperator.IsNotBlank);
        }

        private void WizardPage4_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                MessageHelper.WaitFormShow(this);
                try
                {
                    var students = _BindingSourceResultStudentEducationPayment.DataSource as List<Student>;

                    int loop = 0;
                    foreach (var student in students)
                    {
                        loop++;
                        foreach (var item in student.StudentEducationPayments)
                        {
                            item.Student = null;
                        }

                        MessageHelper.UpdateProgressWaitFormShow("", $"Proses [{student.Code} - {student.Name}] {loop}/{students.Count}");
                        var jsonString = JsonConvert.SerializeObject((student.StudentEducationPayments));
                        HelperRestSharp.Post($"/StudentEducationPayments/Multiple", jsonString);
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.WaitFormClose();
                    MessageHelper.ShowMessageError(this, ex);
                    e.Valid = false;
                    return;
                }
                finally
                {
                    MessageHelper.WaitFormClose();
                }
            }
            else if (e.Direction == DevExpress.XtraWizard.Direction.Backward)
                MyValidationHelper.ClearError(_DxValidationProvider);
        }

        private void WizardPage3_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                if (!_DataStudent.Any())
                {
                    MessageHelper.ShowMessageError(this, "Tidak ada murid yang dipilih");
                    e.Valid = false;
                    return;
                }

                List<EducationComponentRegulation> educationComponentRegulations = GetListDataRowSelected(_GridViewEducationComponentRegulation).OfType<EducationComponentRegulation>().ToList();

                MessageHelper.WaitFormShow(this);
                try
                {
                    DateTime effectiveDate = HelperConvert.Date(EffectiveDateDateEdit.EditValue);
                    var company = CompanyPopUp.EditValue as Company;
                    var classes = ClassPopUp.EditValue as Class;
                    foreach (var student in _DataStudent)
                    {
                        student.Class = classes;
                        student.ClassId = classes.Id;
                        student.StudentEducationPayments = new List<StudentEducationPayment>();
                        foreach (var educationComponentRegulation in educationComponentRegulations)
                        {
                            List<StudentEducationPaymentComponent> studentEducationPaymentComponents = new List<StudentEducationPaymentComponent>();
                            foreach (var educationComponentRegulationDetail in educationComponentRegulation.EducationComponentRegulationDetails)
                            {
                                decimal basicAmount = educationComponentRegulationDetail.PaymentPerInstallment;
                                int loop = 0;
                                for (int i = 0; i < educationComponentRegulationDetail.NumberOfInstallment; i++)
                                {
                                    loop++;
                                    var date = effectiveDate.AddMonths(loop - 1);

                                    if (loop == educationComponentRegulationDetail.NumberOfInstallment)
                                    {
                                        decimal sum = studentEducationPaymentComponents.Where(s => s.EducationComponentId == educationComponentRegulationDetail.EducationComponentId)
                                            .Sum(s => s.Amount);
                                        basicAmount = educationComponentRegulationDetail.Amount - sum;
                                    }

                                    var studentEducationPaymentComponent = new StudentEducationPaymentComponent()
                                    {
                                        EducationComponent = educationComponentRegulationDetail.EducationComponent,
                                        EducationComponentId = educationComponentRegulationDetail.EducationComponentId,
                                        Priority = educationComponentRegulationDetail.Priority,
                                        Amount = basicAmount,
                                        PaymentStatus = Domain.EnumPaymentStatus.Unpaid,
                                        Date = date
                                    };

                                    studentEducationPaymentComponents.Add(studentEducationPaymentComponent);
                                }
                            }

                            foreach (var studentEducationPaymentComponent in studentEducationPaymentComponents.GroupBy(s => s.Date).ToList())
                            {
                                var studentEducationPayment = new StudentEducationPayment()
                                {
                                    Company = company,
                                    CompanyId = company.Id,
                                    Class = classes,
                                    ClassId = classes.Id,
                                    Student = student,
                                    StudentId = student.Id,
                                    Month = studentEducationPaymentComponent.Key.Month,
                                    Year = studentEducationPaymentComponent.Key.Year,
                                    PaymentStatus = Domain.EnumPaymentStatus.Unpaid,
                                    StudentEducationPaymentComponents = studentEducationPaymentComponent.ToList(),
                                    TotalAmount = studentEducationPaymentComponent.Sum(s => s.Amount)
                                };

                                student.StudentEducationPayments.Add(studentEducationPayment);
                            }
                        }
                    }

                    _BindingSourceResultStudentEducationPayment.DataSource = _DataStudent;
                }
                catch (Exception ex)
                {
                    MessageHelper.WaitFormClose();
                    MessageHelper.ShowMessageError(this, ex);
                    e.Valid = false;
                    return;
                }
                finally
                {
                    MessageHelper.WaitFormClose();
                }
            }
            else if (e.Direction == DevExpress.XtraWizard.Direction.Backward)
                MyValidationHelper.ClearError(_DxValidationProvider);
        }

        private void WizardPage2_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            if (e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                ValidatePage1();
                if (!ActionValidate(_DxValidationProvider))
                {
                    e.Valid = false;
                    return;
                }

                List<EducationComponentRegulation> educationComponentRegulations = GetListDataRowSelected(_GridViewEducationComponentRegulation).OfType<EducationComponentRegulation>().ToList();
                if (!educationComponentRegulations.Any())
                {
                    MessageHelper.ShowMessageError(this, "Tidak ada peraturan Mata Anggaran yang dipilih");
                    e.Valid = false;
                    return;
                }
                else if (educationComponentRegulations.Count > 1)
                {
                    MessageHelper.ShowMessageError(this, "Hanya dapat memilih 1 peraturan Mata Anggaran");
                    e.Valid = false;
                    return;
                }

                MessageHelper.WaitFormShow(this);
                try
                {
                    //Filter
                    string select = "Id,Code,Name,ParentalStatus";
                    string expand = "Company($select=id,code,name)";
                    expand += ",Major($select=id,code,name)";
                    expand += ",Rombel($select=id,name)";
                    expand += ",Class($select=id,name)";
                    expand += ",ForceYear($select=id,name)";
                    string filter = $"CompanyId eq {Convert.ToInt32(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))} ";

                    var students = HelperRestSharp.GetListOdata<Student>($"/Students", select, expand, filter);
                    _BindingSourceStudent.DataSource = students;
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

                MessageHelper.WaitFormShow(this);
                try
                {
                    //Filter
                    string select = "Id,Code,Name";
                    string expand = "Company($select=id,code,name)";
                    expand += ",EducationComponentRegulationDetails($select=id,Amount,NumberOfInstallment,PaymentPerInstallment,Priority,EducationComponentId;$expand=EducationComponent($select=id,code,name))";
                    string filter = $"CompanyId eq {Convert.ToInt32(AssemblyHelper.GetValueProperty(CompanyPopUp.EditValue, "Id"))} ";

                    var educationComponentRegulations = HelperRestSharp.GetListOdata<EducationComponentRegulation>($"/EducationComponentRegulations", select, expand, filter);
                    _BindingSourceEducationComponentRegulation.DataSource = educationComponentRegulations;
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

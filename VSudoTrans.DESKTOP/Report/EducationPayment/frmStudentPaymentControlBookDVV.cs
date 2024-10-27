using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSpreadsheet.Model;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using Domain.Entities.SQLView.EducationPayment;
using Microsoft.Graph.Models;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.EducationPayment
{
    public partial class frmStudentPaymentControlBookDVV : frmBaseFilterDVV
    {
        public frmStudentPaymentControlBookDVV()
        {
            InitializeComponent();

            this.EndPoint = "/Students";
            this.FormTitle = "Buku Kontrol Penerimaan SPP (Dokumen)";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<StudentPaymentControlBookView>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;

            #region Code area for regiter the event that changed Student Lookup filter
            this.FilterPopUp4.EditValueChanged += new EventHandler(ClassMajorForceYear_EditValueChanged);
            this.FilterPopUp5.EditValueChanged += new EventHandler(ClassMajorForceYear_EditValueChanged);
            this.FilterPopUp6.EditValueChanged += new EventHandler(ClassMajorForceYear_EditValueChanged);
            #endregion
        }

        #region Code area for filtering student lookup
        // Event for Class, Major, ForceYear changed
        private void ClassMajorForceYear_EditValueChanged(object sender, EventArgs e)
        {
            InitializeFilterStudent();
        }

        private void InitializeFilterStudent()
        {
            string filter = "";
            if (FilterPopUp4.EditValue != null)
            {
                var classes = FilterPopUp4.EditValue as Class;
                if (classes != null)
                {
                    if (filter != "")
                        filter += " and ";
                    filter += "ClassId eq " + classes.Id;
                }
            }
            if (FilterPopUp5.EditValue != null)
            {
                var major = FilterPopUp5.EditValue as Major;
                if (major != null)
                {
                    if (filter != "")
                        filter += " and ";
                    filter += "MajorId eq " + major.Id;
                }
            }
            if (FilterPopUp6.EditValue != null)
            {
                var rombel = FilterPopUp6.EditValue as Rombel;
                if (rombel != null)
                {
                    if (filter != "")
                        filter += " and ";
                    filter += "RombelId eq " + rombel.Id;
                }
            }
            if (FilterPopUp7.EditValue != null)
            {
                var forceYear = FilterPopUp7.EditValue as ForceYear;
                if (forceYear != null)
                {
                    if (filter != "")
                        filter += " and ";
                    filter += "ForceYearId eq " + forceYear.Id;
                }
            }
            AssemblyHelper.SetValueProperty(FilterPopUp8.Properties.OptionsDataSource, "OdataFilter", filter);
        }

        #endregion


        protected override void InitializeParameter()
        {
            base.InitializeParameter();

            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);

            _LayoutControlItemFilter4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter4.Text = "Kelas";
            PopupEditHelper.General<Class>(fEndPoint: "/Classes", fTitle: "Kelas", fControl: FilterPopUp4, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fDisplayText: "Name");

            _LayoutControlItemFilter5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter5.Text = "Jurusan";
            PopupEditHelper.General<Major>(fEndPoint: "/Majors", fTitle: "Jurusan", fControl: FilterPopUp5, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "TypeEducation;Code;Name", fCaptionColumn: "Tipe Pendidikan;Kode;Nama", fWidthColumn: "250;100;400", fDisplayText: "TypeEducation;Code;Name");

            _LayoutControlItemFilter6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter6.Text = "Rombel";
            PopupEditHelper.General<Rombel>(fEndPoint: "/Rombels", fTitle: "Rombel", fControl: FilterPopUp6, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fDisplayText: "Name");

            _LayoutControlItemFilter7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter7.Text = "Angkatan";
            PopupEditHelper.General<ForceYear>(fEndPoint: "/ForceYears", fTitle: "Angkatan", fControl: FilterPopUp7, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Name", fCaptionColumn: "Nama", fWidthColumn: "100", fDisplayText: "Name");

            _LayoutControlItemFilter8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter8.Text = "Murid";
            PopupEditHelper.General<Student>(fEndPoint: "/Students", fTitle: "Murid", fControl: FilterPopUp8, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name;Class.Name;Major.Name;Rombel.Name;JoinDate;PhoneNumber;Email", fCaptionColumn: "Kode;Nama;Kelas;Jurusan;Rombel;Tanggal Masuk;Nomor Telepon;Email", fWidthColumn: "120;250;60;180;65;120;120;120", fDisplayText: "Code;Name", fExpand: "Class($select=name),Major($select=name),Rombel($select=name)");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp4, ConditionOperator.IsNotBlank);
        }

        protected override void ActionRefresh()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            MessageHelper.WaitFormShow(this);
            try
            {
                this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

                if (FilterPopUp4.EditValue != null)
                    OdataFilter += $" and ClassId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp4.EditValue, "Id"))} ";

                if (FilterPopUp5.EditValue != null)
                    OdataFilter += $" and MajorId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp5.EditValue, "Id"))} ";

                if (FilterPopUp6.EditValue != null)
                    OdataFilter += $" and RombelId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp6.EditValue, "Id"))} ";

                if (FilterPopUp7.EditValue != null)
                    OdataFilter += $" and ForceYearId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp7.EditValue, "Id"))} ";

                if (FilterPopUp8.EditValue != null)
                    OdataFilter += $" and Id eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp8.EditValue, "Id"))} ";

                string expand = "StudentEducationPayments($select=Id,ClassId,Month,Year,PaymentStatus,TotalAmount,TotalAmountPaid;$expand=Class($select=id,name,index),StudentEducationPaymentComponents)";
                expand += ",Major($select=Code),Class($select=Id,Name,Index),Rombel($select=Name)";

                var students = HelperRestSharp.GetListOdata<Student>("/Students", "*", fExpand: expand, OdataFilter, fOrder: "Id");
                var classes = HelperRestSharp.GetListOdata<Class>("/Classes", "*", fExpand: "", "", fOrder: "Id");

                if (students.Any())
                {
                    var studentIds = students.Select(x => x.Id).ToList();
                    expand = "StudentEducationPaymentHistory($select=Id,ActualDate)";
                    var studentEducationPaymentHistoryDetails = HelperRestSharp.GetListOdata<StudentEducationPaymentHistoryDetail>("/StudentEducationPaymentHistoryDetails", "Id,StudentEducationPaymentId,Amount", fExpand: expand, $"StudentEducationPaymentHistory/StudentId in ({string.Join(",", studentIds)})", fOrder: "Id");

                    var educationComponents = HelperRestSharp.GetListOdata<EducationComponent>("/EducationComponents", "Id,EducationType", "", fOrder: "Id");

                    this.Text = $"Buku Kontrol Murid";
                    // set report destination
                    rptPaymentControlBook report = new rptPaymentControlBook();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                    DataTable dt = new DataTable();
                    dt.TableName = "Table1";
                    dt.Columns.Add("DetailNo", typeof(string));
                    dt.Columns.Add("DetailClassName", typeof(string));
                    dt.Columns.Add("DetailStudentCode", typeof(string));
                    dt.Columns.Add("DetailStudentName", typeof(string));
                    dt.Columns.Add("DetailPayment1", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment1", typeof(string));
                    dt.Columns.Add("DetailPayment2", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment2", typeof(string));
                    dt.Columns.Add("DetailPayment3", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment3", typeof(string));
                    dt.Columns.Add("DetailPayment4", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment4", typeof(string));
                    dt.Columns.Add("DetailPayment5", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment5", typeof(string));
                    dt.Columns.Add("DetailPayment6", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment6", typeof(string));
                    dt.Columns.Add("DetailPayment7", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment7", typeof(string));
                    dt.Columns.Add("DetailPayment8", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment8", typeof(string));
                    dt.Columns.Add("DetailPayment9", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment9", typeof(string));
                    dt.Columns.Add("DetailPayment10", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment10", typeof(string));
                    dt.Columns.Add("DetailPayment11", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment11", typeof(string));
                    dt.Columns.Add("DetailPayment12", typeof(decimal));
                    dt.Columns.Add("DetailDatePayment12", typeof(string));
                    dt.Columns.Add("DetailPaymentPaid", typeof(decimal));
                    //dt.Columns.Add("DetailTotalPaymentPaid", typeof(decimal));
                    dt.Columns.Add("DetailForm", typeof(decimal));
                    dt.Columns.Add("DetailBalance", typeof(decimal));
                    foreach (var student in students)
                    {
                        foreach (var studentEducationPayments in student.StudentEducationPayments.Where(s => s.ClassId == student.ClassId).GroupBy(s => s.Class.Index).ToList())
                        {
                            var classIds = classes.Where(s => s.Index < studentEducationPayments.Key).Select(s => s.Id).ToList();// Untuk Filter Tunggakan

                            DataRow r = dt.NewRow();
                            int loop = 0;
                            foreach (var studentEducationPayment in studentEducationPayments.OrderBy(s => s.Year).ThenBy(s => s.Month).ToList())
                            {
                                loop++;
                                //var totalAmountPaid = studentEducationPayments.Sum(s => s.TotalAmountPaid);
                                r["DetailNo"] = $"{loop}.";
                                r["DetailClassName"] = $"{studentEducationPayment.Class.Name} {student.Major.Code} {student.Rombel.Name}";
                                r["DetailStudentCode"] = student.Code;
                                r["DetailStudentName"] = student.Name;
                                //r["DetailTotalPaymentPaid"] = totalAmountPaid;

                                r["DetailBalance"] = student.Balance.ToString();

                                decimal arrear = student.StudentEducationPayments.Where(s => classIds.Contains(s.ClassId)).Sum(s => s.TotalAmount) - student.StudentEducationPayments.Where(s => classIds.Contains(s.ClassId)).Sum(s => s.TotalAmountPaid);
                                
                                decimal formulir = 0;
                                foreach (var item in studentEducationPayments.ToList())
                                {
                                    foreach (var item1 in item.StudentEducationPaymentComponents)
                                    {
                                        var educationComponent = educationComponents.Where(s => s.Id == item1.EducationComponentId).FirstOrDefault();
                                        if (educationComponent != null)
                                        {
                                            if (educationComponent.EducationType == Domain.EnumEducationType.FormulirPendaftaran)
                                            {
                                                formulir += item1.AmountPaid;
                                            }

                                            if (studentEducationPayments.Key == Domain.EnumClass.Kelas12 && educationComponent.EducationType == Domain.EnumEducationType.TunggakanBiayaSekolah)
                                            {
                                                arrear += item1.Amount - item1.AmountPaid;
                                            }
                                        }
                                    }
                                }

                                if (formulir > 0)
                                {
                                    report.xrCaptionForm.Text = "Formulir";
                                    if (formulir <= 0)
                                        r["DetailForm"] = DBNull.Value;
                                    else
                                        r["DetailForm"] = formulir.ToString();
                                }
                                else
                                {
                                    report.xrCaptionForm.Text = "Tunggakan";
                                    if (arrear <= 0)
                                        r["DetailForm"] = DBNull.Value;
                                    else
                                        r["DetailForm"] = arrear.ToString();
                                }

                                if (loop <= 12)
                                {
                                    SetDetailPayment(studentEducationPaymentHistoryDetails, loop, r, studentEducationPayment, educationComponents);
                                }

                                if (loop == 12)
                                    break;
                            }
                            dt.Rows.Add(r);
                        }
                    }

                    report.DataSource = dt;

                    //Detail
                    report.xrClassName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailClassName]"));
                    report.xrStudentCode.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailStudentCode]"));
                    report.xrStudentName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailStudentName]"));

                    report.xrDetailPayment1.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment1]"));
                    report.xrDetailDatePayment1.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment1]"));
                    report.xrDetailPayment2.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment2]"));
                    report.xrDetailDatePayment2.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment2]"));
                    report.xrDetailPayment3.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment3]"));
                    report.xrDetailDatePayment3.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment3]"));
                    report.xrDetailPayment4.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment4]"));
                    report.xrDetailDatePayment4.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment4]"));
                    report.xrDetailPayment5.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment5]"));
                    report.xrDetailDatePayment5.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment5]"));
                    report.xrDetailPayment6.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment6]"));
                    report.xrDetailDatePayment6.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment6]"));
                    report.xrDetailPayment7.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment7]"));
                    report.xrDetailDatePayment7.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment7]"));
                    report.xrDetailPayment8.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment8]"));
                    report.xrDetailDatePayment8.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment8]"));
                    report.xrDetailPayment9.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment9]"));
                    report.xrDetailDatePayment9.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment9]"));
                    report.xrDetailPayment10.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment10]"));
                    report.xrDetailDatePayment10.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment10]"));
                    report.xrDetailPayment11.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment11]"));
                    report.xrDetailDatePayment11.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment11]"));
                    report.xrDetailPayment12.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment12]"));
                    report.xrDetailDatePayment12.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDatePayment12]"));

                    //report.xrPaymentPaid.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalPaymentPaid]"));
                    report.xrForm.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailForm]"));
                    report.xrBalance.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailBalance]"));

                    SetExpression(report.xrClassName);
                    SetExpression(report.xrStudentCode);
                    SetExpression(report.xrStudentName);

                    SetExpression(report.xrForm);
                    SetExpression(report.xrBalance);

                    SetExpression(report.xrPayment1);
                    SetExpression(report.xrPayment2);
                    SetExpression(report.xrPayment3);
                    SetExpression(report.xrPayment4);
                    SetExpression(report.xrPayment5);
                    SetExpression(report.xrPayment6);
                    SetExpression(report.xrPayment7);
                    SetExpression(report.xrPayment8);
                    SetExpression(report.xrPayment9);
                    SetExpression(report.xrPayment10);
                    SetExpression(report.xrPayment11);
                    SetExpression(report.xrPayment12);

                    report.xrUsername.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDate.Text = DateTime.Today.ToString("dd MMMM yyyy");

                    report.Name = $"BukuKontrolPenerimaanSPP_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                    string path = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + $"{report.Name}.pdf";
                    report.DisplayName = report.Name;
                    report.PrinterName = report.Name;

                    //set document source
                    _DocumentViewer.DocumentSource = report;
                    _DocumentViewer.InitiateDocumentCreation();
                }
                else
                {
                    _DocumentViewer.DocumentSource = null;
                    MessageHelper.ShowMessageError(this, "Data tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        private void SetExpression(XRTableCell cell)
        {
            cell.ExpressionBindings.Add(new DevExpress.XtraReports.UI.ExpressionBinding()
            {
                EventName = "BeforePrint",
                PropertyName = "BackColor",
                Expression = $"Iif([DataSource.CurrentRowIndex] % 2 == 0, '#ededed', 'White')"
            });
        }

        private static void SetDetailPayment(List<StudentEducationPaymentHistoryDetail> studentEducationPaymentHistoryDetails, int loop, DataRow r, StudentEducationPayment studentEducationPayment, List<EducationComponent> educationComponents)
        {
            if (studentEducationPayment.TotalAmountPaid <= 0)
                r["DetailPayment" + loop] = DBNull.Value;
            else
            {
                decimal totalAmountPaid = 0;
                foreach (var item1 in studentEducationPayment.StudentEducationPaymentComponents)
                {
                    var educationComponent = educationComponents.Where(s => s.Id == item1.EducationComponentId).FirstOrDefault();
                    if (educationComponent != null)
                    {
                        if (educationComponent.EducationType != Domain.EnumEducationType.FormulirPendaftaran)
                        {
                            totalAmountPaid += item1.AmountPaid;
                        }
                    }
                }
                r["DetailPayment" + loop] = totalAmountPaid;
            }

            var studentEducationPaymentHistoryDetail = studentEducationPaymentHistoryDetails.Where(s => s.StudentEducationPaymentId == studentEducationPayment.Id).FirstOrDefault();
            if (studentEducationPaymentHistoryDetail != null)
                r["DetailDatePayment" + loop] = studentEducationPaymentHistoryDetail.StudentEducationPaymentHistory.ActualDate.ToString("dd-MMM-yyyy");
            else
                r["DetailDatePayment" + loop] = DBNull.Value;
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh();
        }
    }
}

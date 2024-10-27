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
using System.Drawing;
using System.Linq;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Report.EducationPayment
{
    public partial class frmStudentArrearControlBookDVV : frmBaseFilterDVV
    {
        public frmStudentArrearControlBookDVV()
        {
            InitializeComponent();

            this.EndPoint = "/Students";
            this.FormTitle = "Buku Kontrol Tunggakan SPP (Dokumen)";

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
                    this.Text = $"Buku Kontrol Tunggakan Murid";
                    // set report destination
                    rptArrearControlBook report = new rptArrearControlBook();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                    DataTable dt = new DataTable();
                    dt.TableName = "Table1";
                    dt.Columns.Add("DetailClass", typeof(string));

                    dt.Columns.Add("DetailClassName", typeof(string));
                    dt.Columns.Add("DetailMajorCode", typeof(string));
                    dt.Columns.Add("DetailRombelName", typeof(string));

                    dt.Columns.Add("DetailStudentCode", typeof(string));
                    dt.Columns.Add("DetailStudentName", typeof(string));

                    dt.Columns.Add("DetailPayment1", typeof(decimal));
                    dt.Columns.Add("DetailPayment2", typeof(decimal));
                    dt.Columns.Add("DetailPayment3", typeof(decimal));
                    dt.Columns.Add("DetailPayment4", typeof(decimal));
                    dt.Columns.Add("DetailPayment5", typeof(decimal));
                    dt.Columns.Add("DetailPayment6", typeof(decimal));
                    dt.Columns.Add("DetailPayment7", typeof(decimal));
                    dt.Columns.Add("DetailPayment8", typeof(decimal));
                    dt.Columns.Add("DetailPayment9", typeof(decimal));
                    dt.Columns.Add("DetailPayment10", typeof(decimal));
                    dt.Columns.Add("DetailPayment11", typeof(decimal));
                    dt.Columns.Add("DetailPayment12", typeof(decimal));

                    dt.Columns.Add("DetailTotalPaid", typeof(decimal));
                    dt.Columns.Add("DetailTotalUnpaid", typeof(decimal));

                    dt.Columns.Add("DetailBalance", typeof(decimal));

                    foreach (var student in students)
                    {
                        var studentEducationPaymentClasses = student.StudentEducationPayments.GroupBy(s => s.Class.Index).ToList();
                        foreach (var studentEducationPayments in studentEducationPaymentClasses)
                        {
                            int yearMin = studentEducationPayments.Min(s => s.Year);
                            DataRow r = dt.NewRow();
                            int loopMonth = 0;
                            foreach (var studentEducationPayment in studentEducationPayments.OrderBy(s => s.Year).ThenBy(s => s.Month).ToList())
                            {
                                loopMonth++;
                                var totalAmountPaid = studentEducationPayments.Sum(s => s.TotalAmountPaid);
                                var totalAmountUnpaid = studentEducationPayments.Sum(s => s.TotalAmount);
                                r["DetailClass"] = $"{studentEducationPayment.Class.Name} {student.Major.Code} {student.Rombel.Name}";
                                r["DetailClassName"] = studentEducationPayment.Class.Name;
                                r["DetailMajorCode"] = student.Major.Code;
                                r["DetailRombelName"] = student.Rombel.Name;
                                r["DetailStudentCode"] = student.Code;
                                r["DetailStudentName"] = student.Name;

                                r["DetailTotalPaid"] = totalAmountPaid;
                                r["DetailTotalUnpaid"] = totalAmountUnpaid - totalAmountPaid;

                                r["DetailBalance"] = student.Balance.ToString();

                                if (loopMonth <= 12)
                                {
                                    SetDetailPayment(loopMonth, r, studentEducationPayment);
                                }

                                if (loopMonth == 12)
                                    break;
                            }
                            dt.Rows.Add(r);
                        }
                    }

                    report.DataSource = dt;

                    // Buat instance GroupField dan tambahkan ke band Header Grup.
                    GroupField groupField = new GroupField("DetailClass");
                    report.GroupHeader.GroupFields.Add(groupField);

                    //Detail
                    report.xrDetailTotalPaid.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalPaid]"));
                    report.xrDetailTotalUnpaid.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalUnpaid]"));

                    report.xrHeaderClassName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailClassName]"));

                    report.xrClassName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailClass]"));
                    report.xrStudentCode.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailStudentCode]"));
                    report.xrStudentName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailStudentName]"));

                    report.xrDetailPayment1.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment1]"));
                    report.xrDetailPayment2.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment2]"));
                    report.xrDetailPayment3.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment3]"));
                    report.xrDetailPayment4.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment4]"));
                    report.xrDetailPayment5.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment5]"));
                    report.xrDetailPayment6.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment6]"));
                    report.xrDetailPayment7.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment7]"));
                    report.xrDetailPayment8.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment8]"));
                    report.xrDetailPayment9.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment9]"));
                    report.xrDetailPayment10.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment10]"));
                    report.xrDetailPayment11.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment11]"));
                    report.xrDetailPayment12.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPayment12]"));

                    SetExpression(report.xrClassName);
                    SetExpression(report.xrStudentCode);
                    SetExpression(report.xrStudentName);

                    SetExpression(report.xrDetailPayment1);
                    SetExpression(report.xrDetailPayment2);
                    SetExpression(report.xrDetailPayment3);
                    SetExpression(report.xrDetailPayment4);
                    SetExpression(report.xrDetailPayment5);
                    SetExpression(report.xrDetailPayment6);
                    SetExpression(report.xrDetailPayment7);
                    SetExpression(report.xrDetailPayment8);
                    SetExpression(report.xrDetailPayment9);
                    SetExpression(report.xrDetailPayment10);
                    SetExpression(report.xrDetailPayment11);
                    SetExpression(report.xrDetailPayment12);

                    SetExpression(report.xrDetailTotalPaid);
                    SetExpression(report.xrDetailTotalUnpaid);

                    report.xrUsername.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDate.Text = DateTime.Today.ToString("dd MMMM yyyy");

                    report.Name = $"BukuKontrolTunggakanSPP_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
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

        private static void SetDetailPayment(int loop, DataRow r, StudentEducationPayment studentEducationPayment)
        {
            r["DetailPayment" + loop] = studentEducationPayment.TotalAmount - studentEducationPayment.TotalAmountPaid;
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh();
        }
    }
}

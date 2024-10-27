using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using Domain.Entities.Organization;
using Domain.Entities.SQLView.EducationPayment;
using Microsoft.Graph.Models;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Report.EducationPayment
{
    public partial class frmStudentPaymentBookDVV : frmBaseFilterDVV
    {
        public frmStudentPaymentBookDVV()
        {
            InitializeComponent();

            this.EndPoint = "/Students";
            this.FormTitle = "Buku Kontrol Murid (Dokumen)";


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

            string expand = "Class($select=id,name)";
            expand += ",Major($select=id,code,Name)";
            expand += ",Company";
            expand += ",StudentEducationPayments($expand=Class)";
            var students = HelperRestSharp.GetListOdata<Student>("/Students", "*", expand);
            InitialLoads(students);
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
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh();
        }

        protected override void ActionRefresh()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            MessageHelper.WaitFormShow(this);
            try
            {
                int companyId = HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"));
                this.OdataFilter = $"CompanyId eq {companyId} ";

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

                string expand = "StudentEducationPayments($select=Id,Month,Year,PaymentStatus,TotalAmount,TotalAmountPaid;$expand=Class($select=name))";
                expand += ",Major($select=Code),Class($select=Name)";

                var students = HelperRestSharp.GetListOdata<Student>("/Students", "*", fExpand: expand, OdataFilter, fOrder: "Id");

                if (students.Any())
                {
                    this.Text = $"Buku Kontrol Murid";
                    // set report destination
                    rptEPaymentBook report = new rptEPaymentBook();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                    report.xrTableHeader.Text = "BUKU KONTROL MURID";

                    DataTable dt = new DataTable();
                    dt.TableName = "Table1";
                    dt.Columns.Add("DetailNo", typeof(string));
                    dt.Columns.Add("HeaderStudentCode", typeof(string));
                    dt.Columns.Add("HeaderStudentName", typeof(string));
                    dt.Columns.Add("HeaderMajorCode", typeof(string));
                    dt.Columns.Add("HeaderIndex", typeof(string));
                    dt.Columns.Add("HeaderClassName", typeof(string));
                    dt.Columns.Add("HeaderBalance", typeof(decimal));
                    dt.Columns.Add("DetailClassName", typeof(string));
                    dt.Columns.Add("DetailNote", typeof(string));
                    dt.Columns.Add("DetailStatusName", typeof(string));
                    dt.Columns.Add("DetailAmount", typeof(decimal));
                    dt.Columns.Add("FooterGrandTotal", typeof(decimal));
                    foreach (var student in students)
                    {
                        int loop = 0;
                        foreach (var studentEducationPayment in student.StudentEducationPayments.OrderBy(s => s.Year).ThenBy(s => s.Month).ToList())
                        {
                            loop++;
                            DataRow r = dt.NewRow();
                            r["HeaderStudentCode"] = student.Code;
                            r["HeaderStudentName"] = student.Name;
                            r["HeaderMajorCode"] = student.Major.Code;
                            r["HeaderIndex"] = 1;//student.Index
                            r["HeaderClassName"] = student.Class.Name;
                            r["HeaderBalance"] = student.Balance;

                            r["DetailNo"] = $"{loop}.";
                            r["DetailClassName"] = studentEducationPayment.Class.Name;
                            r["DetailNote"] = $"Bulan {HelperConvert.MonthText(studentEducationPayment.Month)} Tahun {studentEducationPayment.Year}";
                            r["DetailStatusName"] = EnumHelper.EnumPaymentStatusToString(studentEducationPayment.PaymentStatus);
                            r["DetailAmount"] = studentEducationPayment.TotalAmount - studentEducationPayment.TotalAmountPaid;
                            r["FooterGrandTotal"] = student.StudentEducationPayments.Sum(s => s.TotalAmount) - student.StudentEducationPayments.Sum(s => s.TotalAmountPaid);


                            dt.Rows.Add(r);
                        }
                    }

                    report.DataSource = dt;

                    // Buat instance GroupField dan tambahkan ke band Header Grup.
                    GroupField groupField = new GroupField("HeaderStudentCode");
                    report.GroupHeader.GroupFields.Add(groupField);

                    var company = HelperRestSharp.GetOdata<Company>("/Companys", "*", "", $"Id eq {companyId}");

                    if (company != null)
                    {
                        if (company.Logo != null)
                            report.companyLogo.ImageSource = HelperConvert.UrlToImageSource(company.LogoUrl);

                        report.xrCompanyAddressHeader.Text = company.Address;
                        report.xrCompanyAddressHeader2.Text = $"Telepon {company.PhoneNumber} | Web {company.Website} ";
                    }

                    //Detail
                    report.xrStudentNISHeader.ExpressionBindings.Add(new ExpressionBinding("Text", "[HeaderStudentCode]"));
                    report.xrStudentNameHeader.ExpressionBindings.Add(new ExpressionBinding("Text", "[HeaderStudentName]"));
                    report.xrClassHeader.ExpressionBindings.Add(new ExpressionBinding("Text", "[HeaderClassName] + ' ' + [HeaderMajorCode] + ' ' + [HeaderIndex]"));

                    report.xrNo.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailNo]"));
                    report.xrClassName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailClassName]"));
                    report.xrNote.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailNote]"));
                    report.xrStatusName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailStatusName]"));
                    report.xrAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailAmount]"));

                    report.xrTotalAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[FooterGrandTotal]"));

                    report.xrUsername.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDate.Text = $"Kota Tangerang, {DateTime.Today.ToString("dd MMMM yyyy")}";
                    report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                    report.xrPrintTime.Text = DateTime.Now.ToString("HH:mm:ss");

                    report.DisplayName = this.Text;
                    report.PrinterName = this.Text;
                    report.Name = this.Text;

                    ////Add the labels to the report's bands.    
                    //report.GroupHeader.Controls.Add(report.xrStudentNISHeader);
                    //report.Detail.Controls.Add(report.xrClassName);

                    string path = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + $"{this.Text}.pdf";
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

        private void InitialLoads(List<Student> students)
        {
            MessageHelper.WaitFormShow(this);
            try
            {
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
            finally
            {
                MessageHelper.WaitFormClose();
            }
        }
    }
}

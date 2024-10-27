using DevExpress.XtraReports.UI;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using Domain.Entities.Organization;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;

namespace VSTS.DESKTOP.Report.EducationPayment
{
    public partial class frmEPaymentBookDVV : frmBaseDVV
    {
        public frmEPaymentBookDVV(Student student)
        {
            InitializeComponent();

            this.Text = "Buku Kontrol Murid";

            InitialLoad(student);


            //string expand = "Class($select=id,name)";
            //expand += ",Major($select=id,code,Name)";
            //expand += ",Company";
            //expand += ",StudentEducationPayments($expand=Class)";
            //var students = HelperRestSharp.GetListOdata<Student>("/Students", "*", expand);
            //InitialLoads(students);
        }

        private void InitialLoad(Student student)
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                var company = student.Company;
                var kelas = student.Class;


                if (company != null && kelas != null && student != null)
                {
                    this.Text = $"Buku Kontrol Murid ({student.Code} - {student.Name})";
                    // set report destination
                    rptEPaymentBook report = new rptEPaymentBook();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                    if (company.Logo != null)
                        report.companyLogo.ImageSource = HelperConvert.UrlToImageSource(company.LogoUrl);

                    //report.xrCompanyNameHeader.Text = company.Name;
                    report.xrCompanyAddressHeader.Text = company.Address;
                    report.xrCompanyAddressHeader2.Text = $"Telepon {company.PhoneNumber} | Web {company.Website} ";

                    report.xrClassHeader.Text = $"{kelas.Name} {student.Major.Code} {student.Rombel.Name}";
                    //report.xrMajorHeader.Text = $"{student.Major.Name}";
                    report.xrStudentNISHeader.Text = $"{student.Code}";
                    report.xrStudentNameHeader.Text = $"{student.Name}";
                    //report.xrPaymentHeader.Text = $"{HelperConvert.MonthText(studentEducationPaymentHistory.Month)} {studentEducationPaymentHistory.Year}";
                    //report.xrDateHeader.Text = studentEducationPaymentComponentDetails.FirstOrDefault().Date.ToString("dd MMMM yyyy");

                    report.xrTableHeader.Text = "BUKU KONTROL MURID";

                    DataTable dt = new DataTable();
                    dt.Columns.Add("ClassName", typeof(string));
                    dt.Columns.Add("Note", typeof(string));
                    dt.Columns.Add("StatusName", typeof(string));
                    dt.Columns.Add("Amount", typeof(decimal));
                    dt.Columns.Add("TotalAmount", typeof(decimal));

                    foreach (var studentEducationPayment in student.StudentEducationPayments.OrderBy(s => s.Year).ThenBy(s => s.Month).ToList())
                    {
                        DataRow r = dt.NewRow();
                        r["ClassName"] = studentEducationPayment.Class.Name;
                        r["Note"] = $"Bulan {HelperConvert.MonthText(studentEducationPayment.Month)} Tahun {studentEducationPayment.Year}";
                        r["StatusName"] = EnumHelper.EnumPaymentStatusToString(studentEducationPayment.PaymentStatus);
                        r["Amount"] = studentEducationPayment.TotalAmount - studentEducationPayment.TotalAmountPaid;
                        r["TotalAmount"] = student.StudentEducationPayments.Sum(s => s.TotalAmount) - student.StudentEducationPayments.Sum(s => s.TotalAmountPaid);

                        dt.Rows.Add(r);
                    }

                    report.DataSource = dt;

                    //Detail
                    report.xrClassName.ExpressionBindings.Add(new ExpressionBinding("Text", "[ClassName]"));
                    report.xrNote.ExpressionBindings.Add(new ExpressionBinding("Text", "[Note]"));
                    report.xrStatusName.ExpressionBindings.Add(new ExpressionBinding("Text", "[StatusName]"));
                    report.xrAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[Amount]"));

                    report.xrTotalAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[TotalAmount]"));

                    report.xrUsername.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDate.Text = $"Kota Tangerang, {DateTime.Today.ToString("dd MMMM yyyy")}";
                    report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                    report.xrPrintTime.Text = DateTime.Now.ToString("HH:mm:ss");

                    report.DisplayName = this.Text;
                    report.PrinterName = this.Text;
                    report.Name = this.Text;

                    string path = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + $"{this.Text}.pdf";
                    _DocumentViewer.DocumentSource = report;
                    _DocumentViewer.InitiateDocumentCreation();

                    //_DocumentViewer.PrintingSystem.ExportOptions.PrintPreview.ShowOptionsBeforeExport = true;
                }
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

        private void InitialLoads(List<Student> students)
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                this.Text = $"Buku Kontrol Murid";
                // set report destination
                rptEPaymentBook report = new rptEPaymentBook();
                report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                DataTable dt = new DataTable();
                dt.Columns.Add("StudentCode", typeof(string));
                dt.Columns.Add("StudentName", typeof(string));
                dt.Columns.Add("MajorCode", typeof(string));
                dt.Columns.Add("Index", typeof(string));
                dt.Columns.Add("ClassName", typeof(string));
                dt.Columns.Add("Balance", typeof(string));
                foreach (var student in students)
                {
                    DataRow r = dt.NewRow();
                    r["StudentCode"] = student.Code;
                    r["StudentName"] = student.Name;
                    r["MajorCode"] = student.Major.Code;
                    r["Index"] = 1;//student.Index
                    r["ClassName"] = student.Class.Name;
                    r["Balance"] = student.Balance;

                    dt.Rows.Add(r);

                    //var company = student.Company;
                    //var kelas = student.Class;


                    //if (company != null && kelas != null && student != null)
                    //{

                        //foreach (var studentEducationPayment in student.StudentEducationPayments.OrderBy(s => s.Year).ThenBy(s => s.Month).ToList())
                        //{
                        //    DataRow r = dt.NewRow();
                        //    r["StudentCode"] = studentEducationPayment.Class.Name;
                        //    r["ClassName"] = studentEducationPayment.Class.Name;
                        //    r["ClassName"] = studentEducationPayment.Class.Name;
                        //    r["ClassName"] = studentEducationPayment.Class.Name;
                        //    r["ClassName"] = studentEducationPayment.Class.Name;
                        //    r["ClassName"] = studentEducationPayment.Class.Name;
                        //    r["Note"] = $"Bulan {HelperConvert.MonthText(studentEducationPayment.Month)} Tahun {studentEducationPayment.Year}";
                        //    r["StatusName"] = EnumHelper.EnumPaymentStatusToString(studentEducationPayment.PaymentStatus);
                        //    r["Amount"] = studentEducationPayment.TotalAmount;

                        //    dt.Rows.Add(r);
                        //}

                    //}
                }


                report.DataSource = dt;

                // Buat instance GroupField dan tambahkan ke band Header Grup.
                GroupField groupField = new GroupField("StudentCode");
                report.GroupHeader.GroupFields.Add(groupField);


                //if (company.Logo != null)
                //    report.companyLogo.ImageSource = HelperConvert.UrlToImageSource($"{HelperConvert.URL_AZURE_STORAGE}{company.Logo}");


                //report.xrCompanyAddressHeader.Text = company.Address;
                //report.xrCompanyAddressHeader2.Text = $"Telepon {company.PhoneNumber} | Web {company.Website} ";


                //Detail
                report.xrStudentNISHeader.ExpressionBindings.Add(new ExpressionBinding("Text", "[StudentCode]"));
                report.xrStudentNameHeader.ExpressionBindings.Add(new ExpressionBinding("Text", "[StudentName]"));
                report.xrClassHeader.ExpressionBindings.Add(new ExpressionBinding("Text", "[ClassName] + ' ' + [MajorCode] + ' ' + [Index]"));

                report.xrUsername.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                report.xrDate.Text = $"Kota Tangerang, {DateTime.Today.ToString("dd MMMM yyyy")}";
                report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                report.xrPrintTime.Text = DateTime.Now.ToString("HH:mm:ss");

                report.DisplayName = this.Text;
                report.PrinterName = this.Text;
                report.Name = this.Text;

                string path = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + $"{this.Text}.pdf";
                _DocumentViewer.DocumentSource = report;
                _DocumentViewer.InitiateDocumentCreation();

                //_DocumentViewer.PrintingSystem.ExportOptions.PrintPreview.ShowOptionsBeforeExport = true;
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

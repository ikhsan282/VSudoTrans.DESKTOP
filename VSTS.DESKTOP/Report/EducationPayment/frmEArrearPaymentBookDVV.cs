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
    public partial class frmEArrearPaymentBookDVV : frmBaseDVV
    {
        public frmEArrearPaymentBookDVV(Student student)
        {
            InitializeComponent();

            this.Text = "Buku Kontrol Murid";

            InitialLoad(student);
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
                    int currentYear = DateTime.Today.Year;
                    int currentMonth = DateTime.Today.Month;

                    var studentEducationPayments = student.StudentEducationPayments
                        .Where(s => s.PaymentStatus == Domain.EnumPaymentStatus.Unpaid || s.PaymentStatus == Domain.EnumPaymentStatus.PartiallyPaid)
                        .Where(s => s.Year < currentYear ||
                                    (s.Year == currentYear && s.Month < currentMonth)).ToList();
                    this.Text = $"Buku Kontrol Tunggakan Murid ({student.Code} - {student.Name})";
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

                    report.xrTableHeader.Text = "BUKU KONTROL TUNGGAKAN MURID";

                    DataTable dt = new DataTable();
                    dt.Columns.Add("ClassName", typeof(string));
                    dt.Columns.Add("Note", typeof(string));
                    dt.Columns.Add("StatusName", typeof(string));
                    dt.Columns.Add("Amount", typeof(decimal));
                    dt.Columns.Add("TotalAmount", typeof(decimal));

                    foreach (var studentEducationPayment in studentEducationPayments.OrderBy(s => s.Year).ThenBy(s => s.Month).ToList())
                    {
                        DataRow r = dt.NewRow();
                        r["ClassName"] = studentEducationPayment.Class.Name;
                        r["Note"] = $"Bulan {HelperConvert.MonthText(studentEducationPayment.Month)} Tahun {studentEducationPayment.Year}";
                        r["StatusName"] = EnumHelper.EnumPaymentStatusToString(studentEducationPayment.PaymentStatus);
                        r["Amount"] = studentEducationPayment.TotalAmount - studentEducationPayment.TotalAmountPaid;
                        r["TotalAmount"] = studentEducationPayments.Sum(s => s.TotalAmount) - studentEducationPayments.Sum(s => s.TotalAmountPaid);

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
    }
}

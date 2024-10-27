using DevExpress.XtraReports.UI;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using Domain.Entities.Organization;
using System;
using System.Data;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.EducationPayment
{
    public partial class frmEPaymentInvoiceDVV : frmBaseDVV
    {
        public frmEPaymentInvoiceDVV(StudentEducationPaymentHistory studentEducationPaymentHistory)
        {
            InitializeComponent();

            this.Text = "Bukti Penerimaan Pembayaran";

            InitialLoad(studentEducationPaymentHistory);
        }

        private void InitialLoad(StudentEducationPaymentHistory studentEducationPaymentHistory)
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                var company = studentEducationPaymentHistory.Company;
                var kelas = studentEducationPaymentHistory.Class;
                var student = studentEducationPaymentHistory.Student;


                if (company != null && kelas != null && student != null)
                {
                    this.Text = $"Bukti Penerimaan Pembayaran [{studentEducationPaymentHistory.OrderId}] ({kelas.Name} - {student.Code} - {student.Name})";
                    // set report destination
                    rptEPaymentInvoice report = new rptEPaymentInvoice();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                    //if (studentEducationPaymentHistory.TransactionStatus == "success")
                    //{
                    //    if (company.WatermarkPaid != null)
                    //        SetPictureWatermark(report, HelperConvert.UrlToImageSource($"{HelperConvert.URL_AZURE_STORAGE}{company.WatermarkPaid}"));
                    //}
                    //else if (studentEducationPaymentHistory.TransactionStatus == "pending")
                    //{
                    //    if (company.WatermarkUnpaid != null)
                    //        SetPictureWatermark(report, HelperConvert.UrlToImageSource($"{HelperConvert.URL_AZURE_STORAGE}{company.WatermarkUnpaid}"));
                    //}
                    //else
                    //{
                    //    if (company.Watermark != null)
                    //        SetPictureWatermark(report, HelperConvert.UrlToImageSource($"{HelperConvert.URL_AZURE_STORAGE}{company.Watermark}"));
                    //}

                    if (company.Logo != null)
                        report.companyLogo.ImageSource = HelperConvert.UrlToImageSource(company.LogoUrl);

                    report.xrFooterNote.Text =
"Catatan :\r\n" +
"- Harap disimpan sebagai bukti pembayaran yang SAH.\r\n" +
"- Uang yang sudah dibayarkan tidak dapat diminta kembali.\r\n";

                    if (!string.IsNullOrEmpty(studentEducationPaymentHistory.NoteArrear))
                    {
                        report.xrFooterNote.Text += $"{studentEducationPaymentHistory.NoteArrear}";
                    }

                    report.xrOrderId.Text = studentEducationPaymentHistory.OrderId.ToString();
                    if (studentEducationPaymentHistory.PaymentMethod == Domain.EnumPaymentMethod.Cash)
                        report.xrPaymentMethod.Text = $"{EnumHelper.EnumPaymentMethodToString(studentEducationPaymentHistory.PaymentMethod)} (Bank BTN 00043.01.30.000215.0)";
                    else
                        report.xrPaymentMethod.Text = EnumHelper.EnumPaymentMethodToString(studentEducationPaymentHistory.PaymentMethod);
                    report.xrExpiredTimeFooter.Text = studentEducationPaymentHistory.ExpiryTime;
                    switch (studentEducationPaymentHistory.PaymentMethod)
                    {
                        case Domain.EnumPaymentMethod.QRISShopeePay:
                        case Domain.EnumPaymentMethod.QRISGopay:
                            report.paymentPicture.ImageSource = HelperConvert.UrlToImageSource(studentEducationPaymentHistory.ActionUrl);
                            break;
                        case Domain.EnumPaymentMethod.BCA:
                        case Domain.EnumPaymentMethod.BRI:
                        case Domain.EnumPaymentMethod.BNI:
                        case Domain.EnumPaymentMethod.CIMB:
                        case Domain.EnumPaymentMethod.Permata:
                            report.xrCaptionVANumberFooter.Visible = true;
                            report.xrVANumberFooter.Visible = true;
                            report.xrVANumberFooter.Text = studentEducationPaymentHistory.VANumber;

                            if (studentEducationPaymentHistory.PaymentMethod == Domain.EnumPaymentMethod.BCA)
                                report.paymentPicture.ImageSource = HelperConvert.UrlToImageSource("https://simulator.sandbox.midtrans.com/assets/images/payment_partners/bank_transfer/bca_va.png");
                            else if (studentEducationPaymentHistory.PaymentMethod == Domain.EnumPaymentMethod.BRI)
                                report.paymentPicture.ImageSource = HelperConvert.UrlToImageSource("https://simulator.sandbox.midtrans.com/assets/images/payment_partners/bank_transfer/bri_va.png");
                            else if (studentEducationPaymentHistory.PaymentMethod == Domain.EnumPaymentMethod.BNI)
                                report.paymentPicture.ImageSource = HelperConvert.UrlToImageSource("https://simulator.sandbox.midtrans.com/assets/images/payment_partners/bank_transfer/bni_va.png");
                            else if (studentEducationPaymentHistory.PaymentMethod == Domain.EnumPaymentMethod.CIMB)
                                report.paymentPicture.ImageSource = HelperConvert.UrlToImageSource("https://simulator.sandbox.midtrans.com/assets/images/payment_partners/bank_transfer/cimb_va.png");
                            else if (studentEducationPaymentHistory.PaymentMethod == Domain.EnumPaymentMethod.Permata)
                                report.paymentPicture.ImageSource = HelperConvert.UrlToImageSource("https://simulator.sandbox.midtrans.com/assets/images/payment_partners/bank_transfer/permata_va.png");

                            break;
                        case Domain.EnumPaymentMethod.Mandiri:
                            report.paymentPicture.ImageSource = HelperConvert.UrlToImageSource("https://simulator.sandbox.midtrans.com/assets/images/payment_partners/bank_transfer/mandiri_bill.png");
                            report.xrCaptionVANumberFooter.Visible = true;
                            report.xrVANumberFooter.Visible = true;
                            report.xrCaptionVANumberFooter.Text = "BILL KEY";
                            report.xrVANumberFooter.Text = studentEducationPaymentHistory.BillKey;

                            report.xrCaptionBillerCodeFooter.Visible = true;
                            report.xrBillerCodeFooter.Visible = true;
                            report.xrBillerCodeFooter.Text = studentEducationPaymentHistory.BillerCode;
                            break;
                        case Domain.EnumPaymentMethod.Cash:
                            report.xrCaptionExpiredTimeFooter.Visible = false;
                            report.xrExpiredTimeFooter.Visible = false;
                            report.paymentPicture.Visible = false;
                            break;
                        default:
                            break;
                    }

                    //report.xrCompanyNameHeader.Text = company.Name;
                    report.xrCompanyAddressHeader.Text = company.Address;
                    report.xrCompanyAddressHeader2.Text = $"Telepon {company.PhoneNumber} | Web {company.Website} ";

                    report.xrClassHeader.Text = $"{kelas.Name} {student.Major.Code} {student.Rombel.Name}";
                    //report.xrMajorHeader.Text = $"{student.Major.Name}";
                    report.xrStudentNISHeader.Text = $"{student.Code}";
                    report.xrStudentNameHeader.Text = $"{student.Name}";
                    report.xrTerbilangHeader.Text = $"{HelperConvert.Terbilang(Convert.ToInt64(studentEducationPaymentHistory.GrossAmount))} Rupiah";
                    //report.xrPaymentHeader.Text = $"{HelperConvert.MonthText(studentEducationPaymentHistory.Month)} {studentEducationPaymentHistory.Year}";
                    //report.xrDateHeader.Text = studentEducationPaymentComponentDetails.FirstOrDefault().Date.ToString("dd MMMM yyyy");

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Note", typeof(string));
                    dt.Columns.Add("Amount", typeof(decimal));

                    foreach (var studentEducationPaymentHistoryDetail in studentEducationPaymentHistory.StudentEducationPaymentHistoryDetails)
                    {
                        DataRow r = dt.NewRow();
                        r["Note"] = studentEducationPaymentHistoryDetail.Note;
                        r["Amount"] = studentEducationPaymentHistoryDetail.Amount;

                        dt.Rows.Add(r);
                    }

                    report.DataSource = dt;

                    //Detail
                    report.xrNote.ExpressionBindings.Add(new ExpressionBinding("Text", "[Note]"));
                    report.xrAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[Amount]"));

                    report.xrUsername.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDate.Text = $"Kota Tangerang, {DateTime.Today.ToString("dd MMMM yyyy")}";
                    report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                    report.xrPrintTime.Text = DateTime.Now.ToString("HH:mm:ss");
                    report.xrActualDate.Text = studentEducationPaymentHistory.ActualDate.ToString("dd MMMM yyyy");

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

using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Model;
using Domain.Entities.Finance;
using Domain.Entities.Organization;
using Domain.Entities.Rental;
using Domain.Entities.SQLView.EducationPayment;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Finance
{
    public partial class frmProfitLossWeeklyDVV : frmBaseFilterDVV
    {
        public frmProfitLossWeeklyDVV()
        {
            InitializeComponent();

            this.EndPoint = "/BudgetTransactions";
            this.FormTitle = "Keuangan Mingguan (Dokumen)";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            FilterDate2.EditValue = new DateTime(DateTime.Today.Year, 12, 31);

            InitializeComponentAfter<RentalCarBooking>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
        }

        protected override void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter1.Text = "Tanggal Mulai";
            HelperConvert.FormatDateEdit(FilterDate1);

            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter2.Text = "Tanggal Selesai";
            HelperConvert.FormatDateEdit(FilterDate2);

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate1, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate2, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        public class WeekNum
        {
            public int Number { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        protected override void ActionRefresh()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            MessageHelper.WaitFormShow(this);
            try
            {
                Company company = FilterPopUp3.EditValue as Company;
                DateTime startDate = HelperConvert.Date(FilterDate1.EditValue);
                DateTime endDate = HelperConvert.Date(FilterDate2.EditValue);
                int iStartDate = HelperConvert.Int(HelperConvert.Date(FilterDate1.EditValue).ToString("yyyyMMdd"));
                int iEndDate = HelperConvert.Int(HelperConvert.Date(FilterDate2.EditValue).ToString("yyyyMMdd"));
                if (company != null && iStartDate > 0 && iEndDate > 0)
                {
                    this.OdataFilter = $"CompanyId eq {company.Id} ";

                    if (FilterDate1.EditValue != null && FilterDate1.EditValue != null)
                        OdataFilter += $" and IDate ge {iStartDate} and IDate le {iEndDate} ";

                    string select = "Id,CategoryId,Indicator,Amount,Date";
                    string expand = "Category($select=Id,Code,Name)";

                    var budgetTransactions = HelperRestSharp.GetListOdata<BudgetTransaction>("/BudgetTransactions", fSelect: select, fExpand: expand, OdataFilter, fOrder: "Id");

                    if (budgetTransactions.Any())
                    {
                        // set report destination
                        rptProfitLossWeekly report = new rptProfitLossWeekly();
                        report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                        if (company.WatermarkUrl != null)
                            SetPictureWatermark(report, HelperConvert.UrlToImageSource(company.WatermarkUrl));

                        DataTable dt = new DataTable();
                        dt.TableName = "Table1";
                        dt.Columns.Add("DetailNo", typeof(string));
                        dt.Columns.Add("DetailWeekName", typeof(string));

                        dt.Columns.Add("DetailKredit", typeof(decimal));
                        dt.Columns.Add("DetailDebit", typeof(decimal));

                        dt.Columns.Add("DetailTotal", typeof(decimal));

                        CultureInfo cul = new CultureInfo("id-ID");
                        List<WeekNum> weekNumbers = new List<WeekNum>();

                        for (var day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
                        {
                            int weekNum = cul.Calendar.GetWeekOfYear(day, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

                            var weekNumber = weekNumbers.Where(s => s.Number == weekNum).FirstOrDefault();
                            if (weekNumber != null)
                            {
                                if (day < weekNumber.StartDate)
                                    weekNumber.StartDate = day;

                                if (day > weekNumber.EndDate)
                                    weekNumber.EndDate = day;
                            }
                            else
                            {
                                weekNumber = new WeekNum()
                                {
                                    Number = weekNum,
                                    StartDate = day,
                                    EndDate = day,
                                };

                                weekNumbers.Add(weekNumber);
                            }
                        }

                        int loop = 0;
                        foreach (var weekNumber in weekNumbers)
                        {
                            DataRow totalRow = dt.NewRow();
                            totalRow["DetailNo"] = $"{loop++}.";

                            totalRow["DetailWeekName"] = $"{weekNumber.Number} ({weekNumber.StartDate.ToString("dd-MMM-yyyy")} - {weekNumber.EndDate.ToString("dd-MMM-yyyy")})";

                            var kredit = budgetTransactions.Where(s => s.Date.Date >= weekNumber.StartDate.Date && s.Date.Date <= weekNumber.EndDate.Date && s.Indicator == Domain.EnumTransactionIndicator.Kredit).Sum(s => s.Amount);
                            totalRow["DetailKredit"] = kredit;

                            var debit = budgetTransactions.Where(s => s.Date.Date >= weekNumber.StartDate.Date && s.Date.Date <= weekNumber.EndDate.Date && s.Indicator == Domain.EnumTransactionIndicator.Debit).Sum(s => s.Amount);
                            totalRow["DetailDebit"] = debit;

                            totalRow["DetailTotal"] = kredit - debit;

                            dt.Rows.Add(totalRow);
                        }

                        report.DataSource = dt;

                        //Detail
                        report.xrDetailWeekName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailWeekName]"));

                        report.xrDetailKredit.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailKredit]"));
                        report.xrDetailDebit.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDebit]"));

                        report.xrDetailTotal.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotal]"));

                        report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
                        report.xrPeriodeDate.Text = $"{HelperConvert.Date(FilterDate1.EditValue).ToString("dd MMMM yyyy")} - {HelperConvert.Date(FilterDate2.EditValue).ToString("dd MMMM yyyy")}";

                        report.xrUsernameFooter.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                        report.xrDateFooter.Text = $"Kota Tangerang, {DateTime.Today.ToString("dd MMMM yyyy")}";

                        report.Name = $"DetailRentalKendaraan_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
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
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex.Message);
            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh();
        }
    }
}

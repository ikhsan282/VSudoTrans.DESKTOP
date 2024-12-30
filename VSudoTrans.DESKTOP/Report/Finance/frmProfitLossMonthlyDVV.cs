using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Domain.Entities.Finance;
using Domain.Entities.Organization;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Finance
{
    public partial class frmProfitLossMonthlyDVV : frmBaseFilterDVV
    {
        public frmProfitLossMonthlyDVV()
        {
            InitializeComponent();

            this.EndPoint = "/BudgetTransactions";
            this.FormTitle = "Keuangan Bulanan (Dokumen)";

            HelperConvert.FormatDateTextEdit(YearTextEdit, "yyyy");

            YearTextEdit.EditValue = new DateTime(DateTime.Today.Year, 1, 1);

            InitializeComponentAfter<BudgetTransaction>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
        }

        protected override void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.YearTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        public class MonthNum
        {
            public int Number { get; set; }
            public string Name { get; set; }
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
                int year = HelperConvert.Date(YearTextEdit.EditValue).Year;
                if (company != null && year > 0)
                {
                    this.OdataFilter = $"CompanyId eq {company.Id} ";
                    this.OdataFilter += $" and Year eq {year} ";

                    string select = "Id,CategoryId,Indicator,Amount,Date";
                    string expand = "";

                    var budgetTransactions = HelperRestSharp.GetListOdata<BudgetTransaction>("/BudgetTransactions", fSelect: select, fExpand: expand, OdataFilter, fOrder: "Id");

                    if (budgetTransactions.Any())
                    {
                        // set report destination
                        rptProfitLossMonthly report = new rptProfitLossMonthly();
                        report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                        if (company.WatermarkUrl != null)
                            SetPictureWatermark(report, HelperConvert.UrlToImageSource(company.WatermarkUrl));

                        DataTable dt = new DataTable();
                        dt.TableName = "Table1";
                        dt.Columns.Add("DetailNo", typeof(string));
                        dt.Columns.Add("DetailMonthName", typeof(string));

                        dt.Columns.Add("DetailKredit", typeof(decimal));
                        dt.Columns.Add("DetailDebit", typeof(decimal));

                        dt.Columns.Add("DetailTotal", typeof(decimal));

                        CultureInfo cul = new CultureInfo("id-ID");
                        List<MonthNum> monthNumbers = new List<MonthNum>();

                        for (int month = 1; month <= 12; month++)
                        {
                            string monthName = new DateTime(year, month, 1).ToString("MMMM", cul);

                            DateTime startDate = new DateTime(year, month, 1);

                            int daysInMonth = DateTime.DaysInMonth(year, month);
                            DateTime endDate = new DateTime(year, month, daysInMonth);

                            monthNumbers.Add(new MonthNum
                            {
                                Number = month,
                                Name = monthName,
                                StartDate = startDate,
                                EndDate = endDate
                            });
                        }

                        int loop = 0;
                        foreach (var monthNumber in monthNumbers)
                        {
                            DataRow totalRow = dt.NewRow();
                            totalRow["DetailNo"] = $"{loop++}.";

                            totalRow["DetailMonthName"] = $"{monthNumber.Name} ({monthNumber.StartDate.ToString("dd-MMM-yyyy")} - {monthNumber.EndDate.ToString("dd-MMM-yyyy")})";

                            var kredit = budgetTransactions.Where(s => s.Date.Date >= monthNumber.StartDate.Date && s.Date.Date <= monthNumber.EndDate.Date && s.Indicator == Domain.EnumTransactionIndicator.Kredit).Sum(s => s.Amount);
                            totalRow["DetailKredit"] = kredit;

                            var debit = budgetTransactions.Where(s => s.Date.Date >= monthNumber.StartDate.Date && s.Date.Date <= monthNumber.EndDate.Date && s.Indicator == Domain.EnumTransactionIndicator.Debit).Sum(s => s.Amount);
                            totalRow["DetailDebit"] = debit;

                            totalRow["DetailTotal"] = kredit - debit;

                            dt.Rows.Add(totalRow);
                        }

                        report.DataSource = dt;

                        //Detail
                        report.xrDetailMonthName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailMonthName]"));

                        report.xrDetailKredit.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailKredit]"));
                        report.xrDetailDebit.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDebit]"));

                        report.xrDetailTotal.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotal]"));

                        report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
                        report.xrPeriodeDate.Text = $"{new DateTime(year, 1, 1).ToString("dd MMMM yyyy")} - {new DateTime(year, 12, 31).ToString("dd MMMM yyyy")}";

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

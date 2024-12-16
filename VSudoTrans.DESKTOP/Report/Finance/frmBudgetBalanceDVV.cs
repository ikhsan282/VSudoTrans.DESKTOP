using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Domain.Entities.Finance;
using Domain.Entities.Organization;
using Domain.Entities.SQLView.EducationPayment;
using PopUpUtils;
using System;
using System.Data;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Finance
{
    public partial class frmBudgetBalanceDVV : frmBaseFilterDVV
    {
        public frmBudgetBalanceDVV()
        {
            InitializeComponent();

            this.EndPoint = "/BudgetTransactions";
            this.FormTitle = "Buku KAS (Dokumen)";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = new DateTime(DateTime.Today.Year, 7, 1);
            FilterDate2.EditValue = new DateTime(DateTime.Today.AddYears(1).Year, 6, 30);

            InitializeComponentAfter<StudentPaymentControlBookView>();

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

        protected override void ActionRefresh()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            MessageHelper.WaitFormShow(this);
            try
            {
                var company = FilterPopUp3.EditValue as Company;
                this.OdataFilter = $"CompanyId eq {company.Id} ";

                if (FilterDate1.EditValue != null && FilterDate1.EditValue != null)
                    OdataFilter += $" and Date ge {HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-ddTHH:mm:ssZ")} and Date le {HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-ddTHH:mm:ssZ")} ";

                string expand = "";

                var budgetTransactions = HelperRestSharp.GetListOdata<BudgetTransaction>("/BudgetTransactions", "*", fExpand: expand, OdataFilter, fOrder: "Id");

                if (budgetTransactions.Any())
                {
                    // set report destination
                    rptBudgetBalance report = new rptBudgetBalance();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                    DataTable dt = new DataTable();
                    dt.TableName = "Table1";
                    dt.Columns.Add("DetailNo", typeof(string));
                    dt.Columns.Add("DetailDate", typeof(string));
                    dt.Columns.Add("DetailNote", typeof(string));
                    dt.Columns.Add("DetailPenerimaan", typeof(decimal));
                    dt.Columns.Add("DetailPengeluaran", typeof(decimal));
                    dt.Columns.Add("DetailSaldo", typeof(decimal));

                    OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";
                    OdataFilter += $" and Date lt {HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-ddTHH:mm:ssZ")} ";
                    var prevBudgetTransactions = HelperRestSharp.GetListOdata<BudgetTransaction>("/BudgetTransactions", "Id,Month,Year,Indicator,Amount", fExpand: expand, OdataFilter, fOrder: "Id");

                    // Set initial balance
                    decimal saldoAwal = prevBudgetTransactions.Where(s => s.Indicator == Domain.EnumTransactionIndicator.Kredit).Sum(s => s.Amount) - prevBudgetTransactions.Where(s => s.Indicator == Domain.EnumTransactionIndicator.Debit).Sum(s => s.Amount);

                    int loop = 0;
                    // Add initial balance row
                    DataRow initialRow = dt.NewRow();
                    initialRow["DetailNo"] = $"{loop++}.";
                    initialRow["DetailDate"] = HelperConvert.Date(FilterDate1.EditValue).AddDays(-1).ToString("dd-MMM-yyyy");
                    initialRow["DetailNote"] = "SALDO AWAL";
                    initialRow["DetailPenerimaan"] = DBNull.Value;
                    initialRow["DetailPengeluaran"] = DBNull.Value;
                    initialRow["DetailSaldo"] = saldoAwal;
                    dt.Rows.Add(initialRow);

                    foreach (var budgetTransaction in budgetTransactions.GroupBy(s => s.Date).OrderBy(s => s.Key).ToList())
                    {
                        decimal penerimaan = budgetTransaction
                            .Where(s => s.Indicator == Domain.EnumTransactionIndicator.Kredit).Sum(s => s.Amount);
                        decimal pengeluaran = budgetTransaction
                            .Where(s => s.Indicator == Domain.EnumTransactionIndicator.Debit).Sum(s => s.Amount);

                        if (penerimaan > 0)
                        {
                            saldoAwal += penerimaan;
                            DataRow totalRow = dt.NewRow();
                            totalRow["DetailNo"] = $"{loop++}.";
                            totalRow["DetailDate"] = budgetTransaction.Key.ToString("dd-MMM-yyyy");
                            totalRow["DetailNote"] = "PEMASUKAN KAS";
                            totalRow["DetailPenerimaan"] = penerimaan;
                            totalRow["DetailPengeluaran"] = DBNull.Value;
                            totalRow["DetailSaldo"] = saldoAwal;
                            dt.Rows.Add(totalRow);
                        }

                        if (pengeluaran > 0)
                        {
                            saldoAwal -= pengeluaran;
                            DataRow finalRow = dt.NewRow();
                            finalRow["DetailNo"] = $"{loop++}.";
                            finalRow["DetailDate"] = budgetTransaction.Key.ToString("dd-MMM-yyyy");
                            finalRow["DetailNote"] = "PENGELUARAN KAS";
                            finalRow["DetailPenerimaan"] = DBNull.Value;
                            finalRow["DetailPengeluaran"] = pengeluaran;
                            finalRow["DetailSaldo"] = saldoAwal;
                            dt.Rows.Add(finalRow);
                        }
                    }

                    report.DataSource = dt;

                    //Detail
                    report.xrCompanyName.Text = company.Name;
                    report.xrTrDate.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDate]"));
                    report.xrCategory.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailNote]"));

                    report.xrPenerimaan.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPenerimaan]"));
                    report.xrPengeluaran.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailPengeluaran]"));
                    report.xrSaldo.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailSaldo]"));

                    report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                    report.xrPrintTime.Text = DateTime.Now.ToString("HH:mm:ss");

                    report.xrHeader1.Text = $"BUKU KAS";
                    report.xrHeader2.Text = $"UNTUK PERIODE {HelperConvert.Date(FilterDate1.EditValue).ToString("dd-MMM-yyyy").ToUpper()} - {HelperConvert.Date(FilterDate2.EditValue).ToString("dd-MMM-yyyy").ToUpper()}";

                    report.Name = $"BukuKAS_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
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

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh();
        }
    }
}

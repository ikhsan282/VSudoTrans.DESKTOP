using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using Domain;
using Domain.Entities.EducationPayment;
using Domain.Entities.EducationResource;
using Domain.Entities.Organization;
using Domain.Entities.SQLProc;
using Domain.Entities.SQLView.EducationPayment;
using Microsoft.Graph.Models;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Finance
{
    public partial class frmComparationBudgetRealizationBalanceDVV : frmBaseFilterDVV
    {
        public frmComparationBudgetRealizationBalanceDVV()
        {
            InitializeComponent();

            this.EndPoint = "/Students";
            this.FormTitle = "Keuangan (Dokumen)";

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
            _LayoutControlItemFilter3.Text = "Sekolah";
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
                var indicatorPenerimaan = EnumTransactionIndicator.Kredit;
                var indicatorPengeluaran = EnumTransactionIndicator.Debit;
                var company = FilterPopUp3.EditValue as Company;
                var comparationBudgetRealizationPenerimaans = HelperRestSharp.GetListOdata<ComparationBudgetRealizationResult>($"/SQLProcedures/ComparationBudgetRealizationResults(Indicator={(int)indicatorPenerimaan}, CompanyId={company.Id}, FromDate={HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-dd")}, ToDate={HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-dd")})", "");
                var comparationBudgetRealizationPengeluarans = HelperRestSharp.GetListOdata<ComparationBudgetRealizationResult>($"/SQLProcedures/ComparationBudgetRealizationResults(Indicator={(int)indicatorPengeluaran}, CompanyId={company.Id}, FromDate={HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-dd")}, ToDate={HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-dd")})", "");

                if (comparationBudgetRealizationPenerimaans.Any() || comparationBudgetRealizationPengeluarans.Any())
                {
                    // set report destination
                    rptComparationBudgetRealizationBalance report = new rptComparationBudgetRealizationBalance();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                    DataTable dt = new DataTable();
                    dt.TableName = "Table1";
                    dt.Columns.Add("DetailNo", typeof(string));
                    dt.Columns.Add("DetailEducationComponentCodePenerimaan", typeof(string));
                    dt.Columns.Add("DetailEducationComponentNamePenerimaan", typeof(string));
                    dt.Columns.Add("DetailTotalBudgetAmountPenerimaan", typeof(decimal));
                    dt.Columns.Add("DetailTotalRealizedAmountPenerimaan", typeof(decimal));
                    dt.Columns.Add("DetailAmountVariancePenerimaan", typeof(decimal));
                    dt.Columns.Add("DetailRealizationPercentagePenerimaan", typeof(decimal));

                    dt.Columns.Add("DetailEducationComponentCodePengeluaran", typeof(string));
                    dt.Columns.Add("DetailEducationComponentNamePengeluaran", typeof(string));
                    dt.Columns.Add("DetailTotalBudgetAmountPengeluaran", typeof(decimal));
                    dt.Columns.Add("DetailTotalRealizedAmountPengeluaran", typeof(decimal));
                    dt.Columns.Add("DetailAmountVariancePengeluaran", typeof(decimal));
                    dt.Columns.Add("DetailRealizationPercentagePengeluaran", typeof(decimal));

                    dt.Columns.Add("DetailBalance", typeof(decimal));
                    int count = comparationBudgetRealizationPenerimaans.Count > comparationBudgetRealizationPengeluarans.Count ? comparationBudgetRealizationPenerimaans.Count : comparationBudgetRealizationPengeluarans.Count;
                    int loop = 0;

                    foreach (var comparationBudgetRealizationPenerimaan in comparationBudgetRealizationPenerimaans)
                    {
                        DataRow r = dt.NewRow();
                        loop++;
                        r["DetailNo"] = $"{loop}.";

                        if (comparationBudgetRealizationPenerimaan != null)
                        {
                            r["DetailEducationComponentCodePenerimaan"] = comparationBudgetRealizationPenerimaan.EducationComponentCode;
                            r["DetailEducationComponentNamePenerimaan"] = comparationBudgetRealizationPenerimaan.EducationComponentName;

                            r["DetailTotalBudgetAmountPenerimaan"] = comparationBudgetRealizationPenerimaan.TotalBudgetAmount;
                            r["DetailTotalRealizedAmountPenerimaan"] = comparationBudgetRealizationPenerimaan.TotalRealizedAmount;
                            r["DetailAmountVariancePenerimaan"] = comparationBudgetRealizationPenerimaan.AmountVariance;
                            r["DetailRealizationPercentagePenerimaan"] = comparationBudgetRealizationPenerimaan.RealizationPercentage;
                        }

                        var comparationBudgetRealizationPengeluaran = comparationBudgetRealizationPengeluarans.Where(s => s.EducationComponentCode.Substring(1, 2) == comparationBudgetRealizationPenerimaan.EducationComponentCode.Substring(1, 2)).FirstOrDefault();

                        if (comparationBudgetRealizationPenerimaan != null && comparationBudgetRealizationPengeluaran != null)
                        {
                            r["DetailEducationComponentCodePengeluaran"] = comparationBudgetRealizationPengeluaran.EducationComponentCode;
                            r["DetailEducationComponentNamePengeluaran"] = comparationBudgetRealizationPengeluaran.EducationComponentName;

                            r["DetailTotalBudgetAmountPengeluaran"] = comparationBudgetRealizationPengeluaran.TotalBudgetAmount;
                            r["DetailTotalRealizedAmountPengeluaran"] = comparationBudgetRealizationPengeluaran.TotalRealizedAmount;
                            r["DetailAmountVariancePengeluaran"] = comparationBudgetRealizationPengeluaran.AmountVariance;
                            r["DetailRealizationPercentagePengeluaran"] = comparationBudgetRealizationPengeluaran.RealizationPercentage;
                        }

                        if (comparationBudgetRealizationPenerimaan != null && comparationBudgetRealizationPengeluaran != null)
                        {
                            r["DetailBalance"] = comparationBudgetRealizationPenerimaan.TotalRealizedAmount - comparationBudgetRealizationPengeluaran.TotalRealizedAmount;
                        }
                        else if (comparationBudgetRealizationPenerimaan != null && comparationBudgetRealizationPengeluaran == null)
                        {
                            r["DetailBalance"] = comparationBudgetRealizationPenerimaan.TotalRealizedAmount;
                        }
                        else if (comparationBudgetRealizationPenerimaan == null && comparationBudgetRealizationPengeluaran != null)
                        {
                            r["DetailBalance"] = comparationBudgetRealizationPengeluaran.TotalRealizedAmount;
                        }

                        dt.Rows.Add(r);
                    }

                    //for (int i = 0; i < count; i++)
                    //{
                    //    DataRow r = dt.NewRow();
                    //    loop++;
                    //    r["DetailNo"] = $"{loop}.";

                    //    var comparationBudgetRealizationPenerimaan = (i < comparationBudgetRealizationPenerimaans.Count) ? comparationBudgetRealizationPenerimaans[i] : null;

                    //    if (comparationBudgetRealizationPenerimaan != null)
                    //    {
                    //        r["DetailEducationComponentCodePenerimaan"] = comparationBudgetRealizationPenerimaan.EducationComponentCode;
                    //        r["DetailEducationComponentNamePenerimaan"] = comparationBudgetRealizationPenerimaan.EducationComponentName;

                    //        r["DetailTotalBudgetAmountPenerimaan"] = comparationBudgetRealizationPenerimaan.TotalBudgetAmount;
                    //        r["DetailTotalRealizedAmountPenerimaan"] = comparationBudgetRealizationPenerimaan.TotalRealizedAmount;
                    //        r["DetailAmountVariancePenerimaan"] = comparationBudgetRealizationPenerimaan.AmountVariance;
                    //        r["DetailRealizationPercentagePenerimaan"] = comparationBudgetRealizationPenerimaan.RealizationPercentage;
                    //    }

                    //    var comparationBudgetRealizationPengeluaran = (i < comparationBudgetRealizationPengeluarans.Count) ? comparationBudgetRealizationPengeluarans[i] : null;

                    //    if (comparationBudgetRealizationPenerimaan != null && comparationBudgetRealizationPengeluaran != null)
                    //    {
                    //        if (comparationBudgetRealizationPenerimaan.EducationComponentCode.Substring(1, 2) == comparationBudgetRealizationPengeluaran.EducationComponentCode.Substring(1, 2))
                    //        {
                    //            r["DetailEducationComponentCodePengeluaran"] = comparationBudgetRealizationPengeluaran.EducationComponentCode;
                    //            r["DetailEducationComponentNamePengeluaran"] = comparationBudgetRealizationPengeluaran.EducationComponentName;

                    //            r["DetailTotalBudgetAmountPengeluaran"] = comparationBudgetRealizationPengeluaran.TotalBudgetAmount;
                    //            r["DetailTotalRealizedAmountPengeluaran"] = comparationBudgetRealizationPengeluaran.TotalRealizedAmount;
                    //            r["DetailAmountVariancePengeluaran"] = comparationBudgetRealizationPengeluaran.AmountVariance;
                    //            r["DetailRealizationPercentagePengeluaran"] = comparationBudgetRealizationPengeluaran.RealizationPercentage;
                    //        }
                    //    }

                    //    if (comparationBudgetRealizationPenerimaan != null && comparationBudgetRealizationPengeluaran != null)
                    //    {
                    //        if (comparationBudgetRealizationPenerimaan.EducationComponentCode.Substring(1, 2) == comparationBudgetRealizationPengeluaran.EducationComponentCode.Substring(1, 2))
                    //            r["DetailBalance"] = comparationBudgetRealizationPenerimaan.TotalRealizedAmount - comparationBudgetRealizationPengeluaran.TotalRealizedAmount;
                    //    }
                    //    else if (comparationBudgetRealizationPenerimaan != null && comparationBudgetRealizationPengeluaran == null)
                    //    {
                    //        r["DetailBalance"] = comparationBudgetRealizationPenerimaan.TotalRealizedAmount;
                    //    }
                    //    else if (comparationBudgetRealizationPenerimaan == null && comparationBudgetRealizationPengeluaran != null)
                    //    {
                    //        r["DetailBalance"] = comparationBudgetRealizationPengeluaran.TotalRealizedAmount;
                    //    }

                    //    dt.Rows.Add(r);
                    //}

                    report.DataSource = dt;

                    //Detail
                    report.xrEducationComponentCodePenerimaan.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailEducationComponentCodePenerimaan]"));
                    report.xrEducationComponentNamePenerimaan.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailEducationComponentNamePenerimaan]"));

                    report.xrTotalBudgetAmountPenerimaan.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalBudgetAmountPenerimaan]"));
                    report.xrTotalRealizedAmountPenerimaan.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalRealizedAmountPenerimaan]"));
                    report.xrAmountVariancePenerimaan.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailAmountVariancePenerimaan]"));
                    report.xrRealizationPercentagePenerimaan.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailRealizationPercentagePenerimaan]"));
                    
                    report.xrEducationComponentCodePengeluaran.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailEducationComponentCodePengeluaran]"));
                    report.xrEducationComponentNamePengeluaran.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailEducationComponentNamePengeluaran]"));

                    report.xrTotalBudgetAmountPengeluaran.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalBudgetAmountPengeluaran]"));
                    report.xrTotalRealizedAmountPengeluaran.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalRealizedAmountPengeluaran]"));
                    report.xrAmountVariancePengeluaran.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailAmountVariancePengeluaran]"));
                    report.xrRealizationPercentagePengeluaran.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailRealizationPercentagePengeluaran]"));



                    report.xrBalance.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailBalance]"));


                    report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                    report.xrPrintTime.Text = DateTime.Now.ToString("HH:mm:ss");

                    report.xrHeader1.Text = $"LAPORAN KEUANGAN";
                    report.xrHeader2.Text = $"UNTUK TAHUN YANG BERAKHIR {HelperConvert.Date(FilterDate2.EditValue).ToString("dd-MMM-yyyy").ToUpper()}";

                    report.Name = $"LaporanKeuangan_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
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

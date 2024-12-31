using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Domain;
using Domain.Entities.Organization;
using Domain.Entities.SQLProc;
using Domain.Entities.SQLView.EducationPayment;
using PopUpUtils;
using System;
using System.Data;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Finance
{
    public partial class frmComparationBudgetRealizationDVV : frmBaseFilterDVV
    {
        public frmComparationBudgetRealizationDVV()
        {
            InitializeComponent();

            this.EndPoint = "/ComparationBudgetRealizationResults";
            this.FormTitle = "Perbandingan Anggaran Dan Realisasi (Dokumen)";

            HelperConvert.FormatDateTextEdit(YearTextEdit, "yyyy");
            YearTextEdit.EditValue = new DateTime(DateTime.Today.Year, 1, 1);

            InitializeComponentAfter<StudentPaymentControlBookView>();

            IndicatorSearchLookUpEdit.EditValue = EnumTransactionIndicator.Kredit;

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
        }

        protected override void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);

            _LayoutControlItemFilter4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter4.Text = "Indikator";
            SLUHelper.SetEnumDataSource<EnumTransactionIndicator>(IndicatorSearchLookUpEdit, EnumHelper.EnumTransactionIndicatorToString);
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.YearTextEdit, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.IndicatorSearchLookUpEdit, ConditionOperator.IsNotBlank);
        }

        protected override void ActionRefresh()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            MessageHelper.WaitFormShow(this);
            try
            {
                var indicator = (EnumTransactionIndicator)IndicatorSearchLookUpEdit.EditValue;
                var company = FilterPopUp3.EditValue as Company;
                int year = HelperConvert.Date(YearTextEdit.EditValue).Year;
                if (company != null && year > 0)
                {
                    var comparationBudgetRealizations = HelperRestSharp.GetListOdata<ComparationBudgetRealizationResult>($"/SQLProcedures/ComparationBudgetRealizationResults(CompanyId={company.Id}, Indicator={(int)indicator}, Year={year})", "");

                    if (comparationBudgetRealizations.Any())
                    {
                        // set report destination
                        rptComparationBudgetRealization report = new rptComparationBudgetRealization();
                        report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                        if (company.WatermarkUrl != null)
                            SetPictureWatermark(report, HelperConvert.UrlToImageSource(company.WatermarkUrl));

                        DataTable dt = new DataTable();
                        dt.TableName = "Table1";
                        dt.Columns.Add("DetailNo", typeof(string));
                        dt.Columns.Add("DetailCategoryCode", typeof(string));
                        dt.Columns.Add("DetailCategoryName", typeof(string));
                        dt.Columns.Add("DetailTotalBudgetAmount", typeof(decimal));
                        dt.Columns.Add("DetailTotalRealizedAmount", typeof(decimal));
                        dt.Columns.Add("DetailAmountVariance", typeof(decimal));
                        dt.Columns.Add("DetailRealizationPercentage", typeof(decimal));

                        int loop = 0;
                        foreach (var comparationBudgetRealization in comparationBudgetRealizations)
                        {
                            DataRow r = dt.NewRow();
                            loop++;
                            //var totalAmountPaid = studentEducationPayments.Sum(s => s.TotalAmountPaid);
                            r["DetailNo"] = $"{loop}.";
                            r["DetailCategoryCode"] = comparationBudgetRealization.CategoryCode;
                            r["DetailCategoryName"] = comparationBudgetRealization.CategoryName;

                            r["DetailTotalBudgetAmount"] = comparationBudgetRealization.TotalBudgetAmount;
                            r["DetailTotalRealizedAmount"] = comparationBudgetRealization.TotalRealizedAmount;
                            r["DetailAmountVariance"] = comparationBudgetRealization.AmountVariance;
                            r["DetailRealizationPercentage"] = comparationBudgetRealization.RealizationPercentage;

                            dt.Rows.Add(r);
                        }

                        report.DataSource = dt;

                        //Detail
                        report.xrCategoryCode.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailCategoryCode]"));
                        report.xrCategoryName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailCategoryName]"));

                        report.xrTotalBudgetAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalBudgetAmount]"));
                        report.xrTotalRealizedAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailTotalRealizedAmount]"));
                        report.xrAmountVariance.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailAmountVariance]"));
                        report.xrRealizationPercentage.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailRealizationPercentage]"));

                        report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
                        report.xrPeriodeDate.Text = $"{new DateTime(year, 1, 1).ToString("dd MMMM yyyy")} - {new DateTime(year, 12, 31).ToString("dd MMMM yyyy")}";

                        report.Name = $"PerbandinganAnggaranDanRealisasi_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
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

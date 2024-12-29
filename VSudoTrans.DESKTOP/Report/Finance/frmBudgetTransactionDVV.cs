using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Domain;
using Domain.Entities.Finance;
using Domain.Entities.SQLView.Finance;
using PopUpUtils;
using System;
using System.Data;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Finance
{
    public partial class frmBudgetTransactionDVV : frmBaseFilterDVV
    {
        public frmBudgetTransactionDVV()
        {
            InitializeComponent();

            EndPoint = "/SQLViews/BudgetTransactionViews";
            FormTitle = "Keuangan (Dokumen)";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            HelperConvert.FormatDateTextEdit(YearTextEdit, "yyyy");
            HelperConvert.FormatDateTextEdit(MonthTextEdit, "MMMM");

            FilterDate1.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            FilterDate2.EditValue = new DateTime(DateTime.Today.Year, 12, 31);

            InitializeComponentAfter<BudgetTransactionView>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
        }

        protected override void InitializeParameter()
        {
            base.InitializeParameter();

            _LayoutControlItemFilter4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter4.Text = "Indikator";
            SLUHelper.SetEnumDataSource<EnumTransactionIndicator>(FilterPopUp4, EnumHelper.EnumTransactionIndicatorToString);

            _LayoutControlItemFilter5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter5.Text = "Kategori";
            PopupEditHelper.General<Category>(fEndPoint: "/Categorys", fTitle: "Kategory", fControl: FilterPopUp5, fCascade: FilterPopUp3, fCascadeMember: "CompanyId", fDisplaycolumn: "Code;Name", fCaptionColumn: "Kode;Nama", fWidthColumn: "250;100;400", fDisplayText: "Code;Name");

            _LayoutControlItemFilter6.Text = "Tahun";
            _LayoutControlItemFilter7.Text = "Bulan";
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void ActionRefresh()
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            MessageHelper.WaitFormShow(this);
            try
            {
                OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

                if (FilterPopUp4.EditValue != null)
                    OdataFilter += $"and Indicator eq '{FilterPopUp4.EditValue}' ";

                if (FilterPopUp5.EditValue != null)
                    OdataFilter += $"and CategoryId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp5.EditValue, "Id"))} ";

                if (YearTextEdit.EditValue != null)
                    OdataFilter += $"and Year eq {HelperConvert.Date(YearTextEdit.EditValue).Year} ";

                if (MonthTextEdit.EditValue != null)
                    OdataFilter += $"and Month eq {HelperConvert.Date(MonthTextEdit.EditValue).Month} ";

                var datas = HelperRestSharp.GetListOdata<BudgetTransactionView>("/SQLViews/BudgetTransactionViews", "*", "", OdataFilter, fOrder: "Id");
                if (datas.Any())
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Indicator", typeof(string));
                    dt.Columns.Add("CategoryName", typeof(string));
                    dt.Columns.Add("Year", typeof(int));
                    dt.Columns.Add("Month", typeof(int));
                    dt.Columns.Add("Date", typeof(string));
                    dt.Columns.Add("Amount", typeof(decimal));
                    dt.Columns.Add("TotalAmountKredit", typeof(decimal));
                    dt.Columns.Add("TotalAmountDebit", typeof(decimal));

                    foreach (var data in datas)
                    {
                        DataRow r = dt.NewRow();
                        r["Indicator"] = EnumHelper.EnumTransactionIndicatorToString(data.Indicator);
                        r["CategoryName"] = data.CategoryName;
                        r["Year"] = data.Year;
                        r["Month"] = data.Month;
                        r["Date"] = data.Date.ToString("dd-MMM-yyyy");
                        r["Amount"] = data.Amount;
                        r["TotalAmountKredit"] = datas.Where(s => s.Indicator == EnumTransactionIndicator.Kredit).Sum(s => s.Amount);
                        r["TotalAmountDebit"] = datas.Where(s => s.Indicator == EnumTransactionIndicator.Debit).Sum(s => s.Amount);

                        dt.Rows.Add(r);
                    }
                    rptBudgetTransaction report = new rptBudgetTransaction
                    {
                        DataSource = dt
                    };

                    //Detail
                    report.xrIndicator.ExpressionBindings.Add(new ExpressionBinding("Text", "[Indicator]"));
                    report.xrCategoryName.ExpressionBindings.Add(new ExpressionBinding("Text", "[CategoryName]"));
                    report.xrYear.ExpressionBindings.Add(new ExpressionBinding("Text", "[Year]"));
                    report.xrMonth.ExpressionBindings.Add(new ExpressionBinding("Text", "[Month]"));
                    report.xrDate.ExpressionBindings.Add(new ExpressionBinding("Text", "[Date]"));
                    report.xrAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[Amount]"));
                    report.xrTotalAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[Amount]"));
                    report.xrKredit.ExpressionBindings.Add(new ExpressionBinding("Text", "[TotalAmountKredit]"));
                    report.xrDebit.ExpressionBindings.Add(new ExpressionBinding("Text", "[TotalAmountDebit]"));
                    report.xrGrandTotal.ExpressionBindings.Add(new ExpressionBinding("Text", "[Amount]"));

                    report.xrUsername.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDate.Text = DateTime.Today.ToString("dd MMMM yyyy");

                    report.Name = $"Keuangan_{HelperConvert.String(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Code"))}_{DateTime.Now:yyyyMMddHHmmss}";
                    string path = Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + $"{report.Name}.pdf";
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
            catch { }
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

using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Domain;
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
    public partial class frmBudgetTransactionDVV : frmBaseFilterDVV
    {
        public frmBudgetTransactionDVV()
        {
            InitializeComponent();

            this.EndPoint = "/BudgetTransactions";
            this.FormTitle = "Keuangan (Dokumen)";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            FilterDate2.EditValue = new DateTime(DateTime.Today.Year, 12, 31);

            IndicatorSearchLookUpEdit.EditValue = EnumTransactionIndicator.Kredit;

            InitializeComponentAfter<BudgetTransaction>();

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

            _LayoutControlItemFilter4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter4.Text = "Indikator";
            SLUHelper.SetEnumDataSource<EnumTransactionIndicator>(IndicatorSearchLookUpEdit, EnumHelper.EnumTransactionIndicatorToString);

            _LayoutControlItemFilter5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter5.Text = "Kategori";
            PopupEditHelper.General<Category>(fEndPoint: "/Categorys", fTitle: "Kategori", fControl: FilterPopUp4, fCascade: FilterPopUp3, fCascadeMember: "CompanyId");
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate1, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate2, ConditionOperator.IsNotBlank);
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
                var company = FilterPopUp3.EditValue as Company;
                DateTime startDate = HelperConvert.Date(FilterDate1.EditValue);
                DateTime endDate = HelperConvert.Date(FilterDate2.EditValue);
                var indicator = (EnumTransactionIndicator)IndicatorSearchLookUpEdit.EditValue;
                var category = FilterPopUp4.EditValue as Category;

                this.OdataFilter = $"CompanyId eq {company.Id} ";
                this.OdataFilter += $" and IDate ge {startDate.ToString("yyyyMMdd")} and IDate le {endDate.ToString("yyyyMMdd")} ";
                this.OdataFilter += $" and Indicator eq '{indicator.ToString()}' ";
                
                if (category != null)
                    this.OdataFilter = $"CategoryId eq {category.Id} ";

                string expand = "Category($select=Id,Code,Name)";
                var budgetTransactions = HelperRestSharp.GetListOdata<BudgetTransaction>("/BudgetTransactions", "*", fExpand: expand, OdataFilter, fOrder: "Id");

                if (budgetTransactions.Any())
                {
                    // set report destination
                    rptBudgetTransaction report = new rptBudgetTransaction();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                    DataTable dt = new DataTable();
                    dt.TableName = "Table1";
                    dt.Columns.Add("DetailNo", typeof(string));
                    dt.Columns.Add("DetailDate", typeof(string));
                    dt.Columns.Add("DetailCategoryCode", typeof(string));
                    dt.Columns.Add("DetailCategoryName", typeof(string));
                    dt.Columns.Add("DetailAmount", typeof(decimal));

                    int loop = 0;
                    foreach (var budgetTransaction in budgetTransactions.OrderBy(s => s.Date).GroupBy(s => new { s.Date.Date, s.Category.Code, s.Category.Name }).ToList())
                    {
                        loop++;
                        DataRow totalRow = dt.NewRow();
                        totalRow["DetailNo"] = $"{loop}.";
                        totalRow["DetailDate"] = budgetTransaction.Key.Date.ToString("dd-MMM-yyyy");
                        totalRow["DetailCategoryCode"] = budgetTransaction.Key.Code;
                        totalRow["DetailCategoryName"] = budgetTransaction.Key.Name;
                        totalRow["DetailAmount"] = budgetTransaction.Sum(s => s.Amount);
                        dt.Rows.Add(totalRow);
                    }

                    report.DataSource = dt;

                    //Detail
                    report.xrDetailDate.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDate]"));
                    report.xrDetailCategoryCode.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailCategoryCode]"));
                    report.xrDetailCategoryName.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailCategoryName]"));
                    report.xrDetailAmount.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailAmount]"));


                    report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
                    report.xrPeriodeDate.Text = $"{startDate.ToString("dd MMMM yyyy")} - {endDate.ToString("dd MMMM yyyy")}";

                    report.xrUsernameFooter.Text = $"{ApplicationSettings.Instance.ApplicationUser.FirstName} {ApplicationSettings.Instance.ApplicationUser.LastName}";
                    report.xrDateFooter.Text = $"Kota Tangerang, {DateTime.Today.ToString("dd MMMM yyyy")}";

                    report.Name = $"Keuangan_{company.Code}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
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

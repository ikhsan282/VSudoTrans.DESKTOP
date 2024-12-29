﻿using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Domain;
using Domain.Entities.Finance;
using Domain.Entities.SQLView.EducationPayment;
using PopUpUtils;
using System;
using System.Data;
using System.Linq;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Finance
{
    public partial class frmBudgetTransactionCategoryDVV : frmBaseFilterDVV
    {
        public frmBudgetTransactionCategoryDVV()
        {
            InitializeComponent();

            this.EndPoint = "/BudgetTransactions";
            this.FormTitle = "Buku KAS Pembantu (Dokumen)";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            FilterDate2.EditValue = new DateTime(DateTime.Today.Year, 12, 31);
            IndicatorSearchLookUpEdit.EditValue = EnumTransactionIndicator.Kredit;

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
                this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

                if (FilterDate1.EditValue != null && FilterDate1.EditValue != null)
                    OdataFilter += $" and Date ge {HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-ddTHH:mm:ssZ")} and Date le {HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-ddTHH:mm:ssZ")} ";
                
                if (IndicatorSearchLookUpEdit.EditValue != null)
                    OdataFilter += $" and Indicator eq '{indicator.ToString()}' ";
                
                if (FilterPopUp4.EditValue != null)
                    OdataFilter = $"CategoryId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp4.EditValue, "Id"))} ";

                string expand = "Category";

                var budgetTransactions = HelperRestSharp.GetListOdata<BudgetTransaction>("/BudgetTransactions", "*", fExpand: expand, OdataFilter, fOrder: "Id");

                if (budgetTransactions.Any())
                {
                    // set report destination
                    rptBudgetTransactionCategory report = new rptBudgetTransactionCategory();
                    report.PrintingSystem.Document.AutoFitToPagesWidth = 1;

                    DataTable dt = new DataTable();
                    dt.TableName = "Table1";
                    dt.Columns.Add("DetailNo", typeof(string));
                    dt.Columns.Add("DetailDate", typeof(string));
                    dt.Columns.Add("DetailNote", typeof(string));
                    dt.Columns.Add("DetailAmount", typeof(decimal));
                    dt.Columns.Add("HeaderCategoryCode", typeof(string));
                    dt.Columns.Add("HeaderCategoryName", typeof(string));

                    int loop = 0;
                    foreach (var budgetTransaction in budgetTransactions)
                    {
                        loop++;
                        DataRow totalRow = dt.NewRow();
                        totalRow["DetailNo"] = $"{loop}.";
                        totalRow["DetailDate"] = budgetTransaction.Date.ToString("dd-MMM-yyyy");
                        totalRow["DetailNote"] = budgetTransaction.Note;
                        totalRow["DetailAmount"] = budgetTransaction.Amount;
                        totalRow["HeaderCategoryCode"] = budgetTransaction.Category.Code;
                        totalRow["HeaderCategoryName"] = budgetTransaction.Category.Name;
                        dt.Rows.Add(totalRow);
                    }

                    report.DataSource = dt;

                    // Buat instance GroupField dan tambahkan ke band Header Grup.
                    GroupField groupField = new GroupField("HeaderCategoryCode");
                    report.GroupHeader.GroupFields.Add(groupField);

                    //Detail
                    report.xrDate.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailDate]"));
                    report.xrCategory.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailNote]"));

                    report.xrJumlah.ExpressionBindings.Add(new ExpressionBinding("Text", "[DetailAmount]"));

                    report.xrCategoryCode.ExpressionBindings.Add(new ExpressionBinding("Text", "[HeaderCategoryCode]"));
                    report.xrCategoryName.ExpressionBindings.Add(new ExpressionBinding("Text", "[HeaderCategoryName]"));

                    report.xrPrintDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
                    report.xrPrintTime.Text = DateTime.Now.ToString("HH:mm:ss");

                    report.xrHeader1.Text = $"AKUN {EnumHelper.EnumTransactionIndicatorToString(indicator).ToUpper()}";
                    report.xrHeader2.Text = $"UNTUK SELAMA TAHUN YANG BERAKHIR {HelperConvert.Date(FilterDate2.EditValue).ToString("dd-MMM-yyyy").ToUpper()}";

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

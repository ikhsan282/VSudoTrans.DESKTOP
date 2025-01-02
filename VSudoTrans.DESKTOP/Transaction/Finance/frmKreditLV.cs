using Contract.Finance;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain;
using Domain.Entities.Finance;
using Newtonsoft.Json;
using PopUpUtils;
using System;
using System.IO;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Transaction.Finance
{
    public partial class frmKreditLV : frmBaseFilterLV
    {
        public frmKreditLV()
        {
            InitializeComponent();

            EndPoint = "/BudgetTransactions";
            FormTitle = "Penerimaan";

            OdataSelect = "Id,Quantity,Amount,Date,Note";
            OdataExpand = "Company($select=name)";
            OdataExpand += ",Category($select=name)";
            OdataExpand += ",UnitMeasure($select=name)";

            InitializeComponentAfter<BudgetTransaction>();

            InitializeSearchLookup();

            FilterDate1.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            FilterDate2.EditValue = new DateTime(DateTime.Today.Year, 12, 31);

            _GridView.OptionsView.ShowFooter = true;
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colQuantity, typeof(decimal), "n2", fTotal: true);

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiTemplateImport.ItemClick += BbiTemplateImport_ItemClick;
            bbiImportData.ItemClick += BbiImportData_ItemClick;
        }
        private void BbiImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string url = "/BudgetTransactions/Import/ValidateFile";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageHelper.WaitFormShow(this);
                    ImportSummaryBudgetTransactionModel result = null;
                    try
                    {
                        result = HelperRestSharp.UploadFileImport<ImportSummaryBudgetTransactionModel>(File.ReadAllBytes(openFileDialog.FileName), openFileDialog.FileName, url);
                    }
                    catch (Exception ex)
                    {
                        MessageHelper.ShowMessageError(this, ex.Message);
                    }
                    finally
                    {
                        MessageHelper.WaitFormClose();
                    }

                    if (result != null)
                    {
                        using (var form = new frmImportBudgetTransactionWV())
                        {
                            if (result.TotalFailed > 0)
                                form.btnOK.Enabled = false;

                            form._BindingSource.DataSource = result.Data;
                            form.SetSummary(result.Total, result.TotalSuccess, result.TotalFailed);
                            var resultDialog = form.ShowDialog();
                            if (resultDialog == System.Windows.Forms.DialogResult.OK)
                            {
                                var jsonString = JsonConvert.SerializeObject(result.Data);
                                var response = HelperRestSharp.Post("/BudgetTransactions/Import", jsonString);

                                if (!string.IsNullOrEmpty(response))
                                {
                                    var res = JsonConvert.DeserializeObject<bool>(response);
                                    if (res)
                                    {
                                        MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);
                                        ActionRefresh<BudgetTransaction>();
                                    }
                                }
                            }
                            else if (resultDialog == System.Windows.Forms.DialogResult.Cancel)
                            {

                            }
                        }
                    }
                }
            }
        }

        private void BbiTemplateImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileExcel = HelperRestSharp.DownloadFile("vsudotrans", "import/Import Budget Transaction.xlsx");
            HelperRestSharp.SaveFileDialog(fileExcel, "File Template Import Budget Transaction");
        }


        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate1, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate2, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            _LayoutControlItemFilter5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

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
            _LayoutControlItemFilter4.Text = "Kategori";
            PopupEditHelper.General<Category>(fEndPoint: "/Categorys", fFilter: $"", fTitle: "Kategori", fControl: FilterPopUp4, fCascade: FilterPopUp3, fCascadeMember: "CompanyId");
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            //Validasi searchLookup
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            OdataFilter = $"Indicator eq '{EnumTransactionIndicator.Kredit}' and CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))}";

            if (FilterPopUp4.EditValue != null)
                OdataFilter += $" and CategoryId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp4.EditValue, "Id"))} ";

            if (FilterDate1.EditValue != null && FilterDate1.EditValue != null)
                OdataFilter += $" and Date ge {HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-ddTHH:mm:ssZ")} and Date le {HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-ddTHH:mm:ssZ")} ";

            base.ActionRefresh<T>(endPoint);
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<BudgetTransaction>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<BudgetTransaction>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmKreditDV(EntityId, EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

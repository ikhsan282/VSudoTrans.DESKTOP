using VSudoTrans.DESKTOP.BaseForm;
using Domain.Entities.HumanResource;
using VSudoTrans.DESKTOP.Utils;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;
using System;
using Contract.HumanResource;

namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    public partial class frmJobGradeLV : frmBaseFilterLV
    {
        public frmJobGradeLV()
        {
            InitializeComponent();

            this.EndPoint = "/JobGrades";
            this.FormTitle = "Golongan";

            this.OdataSelect = "Id,Code,Name,FromAmount,MidAmount,ToAmount";
            this.OdataExpand = "Company($select=name)";

            InitializeComponentAfter<JobGrade>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiTemplateImport.ItemClick += BbiTemplateImport_ItemClick;
            bbiImportData.ItemClick += BbiImportData_ItemClick;

            GridHelper.GridColumnInitializeLayout(colFromAmount, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colMidAmount, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colToAmount, typeof(decimal), "n0");
        }

        private void BbiImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string url = "/JobGrades/Import/ValidateFile";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageHelper.WaitFormShow(this);
                    ImportSummaryJobGradeModel result = null;
                    try
                    {
                        result = HelperRestSharp.UploadFileImport<ImportSummaryJobGradeModel>(File.ReadAllBytes(openFileDialog.FileName), openFileDialog.FileName, url);
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
                        using (var form = new frmImportJobGradeWV())
                        {
                            if (result.TotalFailed > 0)
                                form.btnOK.Enabled = false;

                            form._BindingSource.DataSource = result.Data;
                            form.SetSummary(result.Total, result.TotalSuccess, result.TotalFailed);
                            var resultDialog = form.ShowDialog();
                            if (resultDialog == System.Windows.Forms.DialogResult.OK)
                            {
                                var jsonString = JsonConvert.SerializeObject(result.Data);
                                var response = HelperRestSharp.Post("/JobGrades/Import", jsonString);

                                if (!string.IsNullOrEmpty(response))
                                {
                                    var res = JsonConvert.DeserializeObject<bool>(response);
                                    if (res)
                                    {
                                        MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);
                                        ActionRefresh<JobGrade>();
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
            var fileExcel = HelperRestSharp.DownloadFile("VSudoTrans", "import/Import JobGrade.xlsx");
            HelperRestSharp.SaveFileDialog(fileExcel, "File Template Import JobGrade");
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<JobGrade>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<JobGrade>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmJobGradeDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            this.OdataFilter = $"CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>(endPoint);
        }
    }
}

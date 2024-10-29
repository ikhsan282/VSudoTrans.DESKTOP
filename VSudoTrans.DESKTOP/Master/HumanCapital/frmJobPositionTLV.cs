using Contract.HumanResource;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.HumanResource;
using Newtonsoft.Json;
using PopUpUtils;
using System;
using System.IO;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Master.Organization;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    public partial class frmJobPositionTLV : frmBaseFilterTLV
    {
        public frmJobPositionTLV()
        {
            InitializeComponent();

            this.EndPoint = "/JobPositions";
            this.FormTitle = "Posisi";

            this.OdataSelect = "Id,ParentId,Code,Name,Level";
            this.OdataExpand = "JobTitle($select=name), ";
            this.OdataExpand += "Company($select=name)";

            InitializeComponentAfter<JobPosition>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiTemplateImport.ItemClick += BbiTemplateImport_ItemClick;
            bbiImportData.ItemClick += BbiImportData_ItemClick;

            _TreeList.HierarchyColumn = colCode;
            _TreeList.HierarchyFieldName = "Code";
            _TreeList.KeyFieldName = "Id";
            _TreeList.ParentFieldName = "ParentId";
            _TreeList.OptionsBehavior.PopulateServiceColumns = true;

            colId.Visible = false;
            colParentId.Visible = false;
            colId.OptionsColumn.AllowEdit = false;
            colParentId.OptionsColumn.AllowEdit = false;
            colCode.OptionsColumn.AllowEdit = false;
            colName.OptionsColumn.AllowEdit = false;
            colJobTitle.OptionsColumn.AllowEdit = false;
            colCompanyName.OptionsColumn.AllowEdit = false;
            colLevel.OptionsColumn.AllowEdit = false;
        }

        private void BbiImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string url = "/JobPositions/Import/ValidateFile";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageHelper.WaitFormShow(this);
                    ImportSummaryJobPositionModel result = null;
                    try
                    {
                        result = HelperRestSharp.UploadFileImport<ImportSummaryJobPositionModel>(File.ReadAllBytes(openFileDialog.FileName), openFileDialog.FileName, url);
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
                        using (var form = new frmImportJobPositionWV())
                        {
                            if (result.TotalFailed > 0)
                                form.btnOK.Enabled = false;

                            form._BindingSource.DataSource = result.Data;
                            form.SetSummary(result.Total, result.TotalSuccess, result.TotalFailed);
                            var resultDialog = form.ShowDialog();
                            if (resultDialog == System.Windows.Forms.DialogResult.OK)
                            {
                                var jsonString = JsonConvert.SerializeObject(result.Data);
                                var response = HelperRestSharp.Post("/JobPositions/Import", jsonString);

                                if (!string.IsNullOrEmpty(response))
                                {
                                    var res = JsonConvert.DeserializeObject<bool>(response);
                                    if (res)
                                    {
                                        MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);
                                        ActionRefresh<JobPosition>();
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
            var fileExcel = HelperRestSharp.DownloadFile("vsudotrans", "import/Import JobPosition.xlsx");
            HelperRestSharp.SaveFileDialog(fileExcel, "File Template Import JobPosition");
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<JobPosition>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<JobPosition>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmJobPositionDV(this.EntityId, this.EndPoint, fCopy);
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

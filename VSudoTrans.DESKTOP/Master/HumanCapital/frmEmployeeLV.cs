using VSudoTrans.DESKTOP.BaseForm;
using Domain.Entities.HumanResource;
using VSudoTrans.DESKTOP.Utils;
using System;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;
using Newtonsoft.Json;
using System.Windows.Forms;
using Contract.HumanResource;
using System.IO;

namespace VSudoTrans.DESKTOP.Master.HumanCapital
{
    public partial class frmEmployeeLV : frmBaseFilterLV
    {
        public frmEmployeeLV()
        {
            InitializeComponent();

            this.EndPoint = "/Employees";
            this.FormTitle = "Karyawan";

            this.OdataSelect = "Id,Code,Name,JoinDate,ResignationDate,PhoneNumber";
            this.OdataExpand = "Company($select=name)";

            InitializeComponentAfter<Employee>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiTemplateImport.ItemClick += BbiTemplateImport_ItemClick;
            bbiImportData.ItemClick += BbiImportData_ItemClick;

            GridHelper.GridColumnInitializeLayout(colJoinDate, typeof(DateTime));
            GridHelper.GridColumnInitializeLayout(colResignationDate, typeof(DateTime));
        }

        private void BbiImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string url = "/Employees/Import/ValidateFile";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageHelper.WaitFormShow(this);
                    ImportSummaryEmployeeModel result = null;
                    try
                    {
                        result = HelperRestSharp.UploadFileImport<ImportSummaryEmployeeModel>(File.ReadAllBytes(openFileDialog.FileName), openFileDialog.FileName, url);
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
                        using (var form = new frmImportEmployeeWV())
                        {
                            if (result.TotalFailed > 0)
                                form.btnOK.Enabled = false;

                            form._BindingSource.DataSource = result.Data;
                            form.SetSummary(result.Total, result.TotalSuccess, result.TotalFailed);
                            var resultDialog = form.ShowDialog();
                            if (resultDialog == System.Windows.Forms.DialogResult.OK)
                            {
                                var jsonString = JsonConvert.SerializeObject(result.Data);
                                var response = HelperRestSharp.Post("/Employees/Import", jsonString);

                                if (!string.IsNullOrEmpty(response))
                                {
                                    var res = JsonConvert.DeserializeObject<bool>(response);
                                    if (res)
                                    {
                                        MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);
                                        ActionRefresh<Employee>();
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
            var fileExcel = HelperRestSharp.DownloadFile("vsudotrans", "import/Import Employee.xlsx");
            HelperRestSharp.SaveFileDialog(fileExcel, "File Template Import Employee");
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<Employee>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<Employee>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmEmployeeDV(this.EntityId, this.EndPoint, fCopy);
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

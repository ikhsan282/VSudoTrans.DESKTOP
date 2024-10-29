using Contract.Shared;
using Domain.Entities.Shared;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Shared
{
    public partial class frmUnitMeasureLV : frmBaseLV
    {
        public frmUnitMeasureLV()
        {
            InitializeComponent();

            EndPoint = "/UnitMeasures";
            FormTitle = "Satuan Ukuran";

            OdataSelect = "Id,Format,Code,Name";

            InitializeComponentAfter<UnitMeasure>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiTemplateImport.ItemClick += BbiTemplateImport_ItemClick;
            bbiImportData.ItemClick += BbiImportData_ItemClick;

            var roleNames = ApplicationSettings.Instance.UserRoles.Select(s => s.Name);
            if (roleNames.FirstOrDefault(s => s == "Super Administrator") == null)
            {
                bbiNew.Enabled = false;
                bbiEdit.Enabled = false;
                bbiDelete.Enabled = false;
                bbiImportData.Enabled = false;
            }
        }

        private void BbiImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string url = "/UnitMeasures/Import/ValidateFile";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageHelper.WaitFormShow(this);
                    ImportSummaryUnitMeasureModel result = null;
                    try
                    {
                        result = HelperRestSharp.UploadFileImport<ImportSummaryUnitMeasureModel>(File.ReadAllBytes(openFileDialog.FileName), openFileDialog.FileName, url);
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
                        using (var form = new frmImportUnitMeasureWV())
                        {
                            if (result.TotalFailed > 0)
                                form.btnOK.Enabled = false;

                            form._BindingSource.DataSource = result.Data;
                            form.SetSummary(result.Total, result.TotalSuccess, result.TotalFailed);
                            var resultDialog = form.ShowDialog();
                            if (resultDialog == DialogResult.OK)
                            {
                                var jsonString = JsonConvert.SerializeObject(result.Data);
                                var response = HelperRestSharp.Post("/UnitMeasures/Import", jsonString);

                                if (!string.IsNullOrEmpty(response))
                                {
                                    var res = JsonConvert.DeserializeObject<bool>(response);
                                    if (res)
                                    {
                                        MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);
                                        ActionRefresh<UnitMeasure>();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void BbiTemplateImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var fileExcel = HelperRestSharp.DownloadFile("vsudotrans", "import/Import Satuan Ukuran.xlsx");
            HelperRestSharp.SaveFileDialog(fileExcel, "File Template Import Satuan Ukuran");
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<UnitMeasure>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<UnitMeasure>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmUnitMeasureDV(EntityId, EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

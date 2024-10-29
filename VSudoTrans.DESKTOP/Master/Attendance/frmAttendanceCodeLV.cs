using Contract.Attendance;
using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Attendance;
using Newtonsoft.Json;
using PopUpUtils;
using System;
using System.IO;
using System.Windows.Forms;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Master.Attendance
{
    public partial class frmAttendanceCodeLV : frmBaseFilterLV
    {
        public frmAttendanceCodeLV()
        {
            InitializeComponent();

            this.EndPoint = "/AttendanceCodes";
            this.FormTitle = "Kode Kehadiran";

            this.OdataSelect = "Id,Code,Name,GroupType,AssignmentType";
            this.OdataExpand = "Company($select=name)";

            InitializeComponentAfter<AttendanceCode>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;
            bbiTemplateImport.ItemClick += BbiTemplateImport_ItemClick;
            bbiImportData.ItemClick += BbiImportData_ItemClick;
        }
        private void BbiImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string url = "/AttendanceCodes/Import/ValidateFile";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageHelper.WaitFormShow(this);
                    ImportSummaryAttendanceCodeModel result = null;
                    try
                    {
                        result = HelperRestSharp.UploadFileImport<ImportSummaryAttendanceCodeModel>(File.ReadAllBytes(openFileDialog.FileName), openFileDialog.FileName, url);
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
                        using (var form = new frmImportAttendanceCodeWV())
                        {
                            if (result.TotalFailed > 0)
                                form.btnOK.Enabled = false;

                            form._BindingSource.DataSource = result.Data;
                            form.SetSummary(result.Total, result.TotalSuccess, result.TotalFailed);
                            var resultDialog = form.ShowDialog();
                            if (resultDialog == System.Windows.Forms.DialogResult.OK)
                            {
                                var jsonString = JsonConvert.SerializeObject(result.Data);
                                var response = HelperRestSharp.Post("/AttendanceCodes/Import", jsonString);

                                if (!string.IsNullOrEmpty(response))
                                {
                                    var res = JsonConvert.DeserializeObject<bool>(response);
                                    if (res)
                                    {
                                        MessageHelper.ShowMessageInformation(this, MessageHelper.MessageSaveSuccessfully);
                                        ActionRefresh<AttendanceCode>();
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
            var fileExcel = HelperRestSharp.DownloadFile("vsudotrans", "import/Import AttendanceCode.xlsx");
            HelperRestSharp.SaveFileDialog(fileExcel, "File Template Import AttendanceCode");
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<AttendanceCode>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<AttendanceCode>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmAttendanceCodeDV(this.EntityId, this.EndPoint, fCopy);
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

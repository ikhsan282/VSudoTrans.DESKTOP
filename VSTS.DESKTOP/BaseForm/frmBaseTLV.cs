using VSTS.DESKTOP.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using DevExpress.Data.ODataLinq;
using Microsoft.OData.Client;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using Domain.Entities.Organization;
using DevExpress.XtraTreeList;

namespace VSTS.DESKTOP.BaseForm
{
    public partial class frmBaseTLV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected object OdataEntity { get; set; }
        protected object ObjectBaseClass { get; set; }
        protected object EntityId { get; set; }
        protected string EndPoint { get; set; }
        protected string OdataSelect { get; set; }
        protected string OdataFilter { get; set; }
        protected string OdataExpand { get; set; }
        protected CriteriaOperator OdataFixedCriteria { get; set; }
        protected GridControlDataSource GridControlDataSourceType = GridControlDataSource.VirtualMode;
        protected HelperHttpClient _HttpClient;
        protected XtraForm FormDetail { get; set; }
        protected string FormTitle { get; set; }
        protected enum ExportType
        {
            Csv,
            Pdf,
            Html,
            Xls,
            Xlsx,
            Doc,
            Docx
        }
        protected enum GridControlDataSource
        {
            OdataInstantFeedback,
            VirtualMode
        }

        protected virtual void ActionShowFormDetail(object fCopy = null)
        {
            try
            {
                if (FormDetail != null)
                {
                    //FormDetail.Text = FormTitle;
                    FormDetail.MdiParent = MdiParent;
                    FormDetail.Show();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
        }

        public frmBaseTLV()
        {
            InitializeComponent();
            SearchControlHelper.InitializeSearchControl(_SearchControl);
            _TreeList.ExpandAll();
            _TreeList.DoubleClick += _GridView_DoubleClick;
        }

        private void _GridView_DoubleClick(object sender, EventArgs e)
        {
            var ea = e as DevExpress.Utils.DXMouseEventArgs;
            var view = sender as TreeList;
            var info = view.CalcHitInfo(ea.Location);
            if (info.InRow) ActionEdit();
        }

        protected virtual async Task<object> CreateEntity<T>()
        {
            object operationResponse = null;
            try
            {
                var jsonString = JsonConvert.SerializeObject(this.OdataEntity);
                var result = await _HttpClient.PostAsync(this.EndPoint, jsonString);
                if (result != null)
                    operationResponse = JsonConvert.DeserializeObject<T>(result.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return operationResponse;
        }

        protected List<object> GetListDataRowSelected(GridView gridView)
        {
            List<object> result = new List<object>();
            try
            {
                var selectedRows = gridView.GetSelectedRows();

                foreach (var selectedRow in selectedRows)
                {
                    result.Add(gridView.GetRow(selectedRow));
                    //if (gridView.GetRow(selectedRow).GetType().FullName != "DevExpress.Data.NotLoadedObject")
                    //    result.Add(((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)gridView.GetRow(selectedRow)).OriginalRow);
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, "Gagal untuk mendapatkan data yang dipilih dengan detail error " + ex.Message);
                return null;
            }
        }

        protected virtual object GetDataRowSelected()
        {
            object result;
            try
            {
                var selectedRows = _TreeList.GetFocusedRow();

                if (_TreeList.GetFocusedRow() != null)
                    return _TreeList.GetFocusedRow();
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, "Gagal untuk mendapatkan data yang dipilih dengan detail error " + ex.Message);
                return null;
            }
        }

        protected object GetIdOfDataRowSelected()
        {
            object result;
            try
            {
                var selected = GetDataRowSelected();
                if (selected == null) return null;
                result = AssemblyHelper.GetValueProperty(selected, "Id");

                if (result.GetType().Equals(typeof(int)))
                {
                    if (Convert.ToInt32(result) <= 0) return null;
                }
                else
                {
                    if (result.GetType().Equals(typeof(Guid)))
                    {
                        Guid temp = (Guid)result;
                        if (temp == Guid.Empty) return null;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, "Gagal untuk mendapatkan Id Object dengan detail error " + ex.Message);
                return null;
            }
        }

        protected virtual void ActionNew()
        {
            EntityId = 0;
            ActionShowFormDetail();
        }

        protected virtual void ActionEdit()
        {
            EntityId = GetIdOfDataRowSelected();
            if (EntityId == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }
            ActionShowFormDetail();
        }

        protected virtual void ActionDelete<T>()
        {
            var delete = GetDataRowSelected();
            if (delete == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }
            if (MessageHelper.ShowMessageQuestion(MessageHelper.MessageDelete) == System.Windows.Forms.DialogResult.No) return;

            HelperRestSharp.Delete(AssemblyHelper.GetValueProperty(delete, "Id"), this.EndPoint);

            //notif 
            MessageHelper.ShowMessageInformation(this, $"Data Berhasil Di Delete ");

            ActionRefresh<T>();
        }

        protected virtual void ActionRefresh<T>(string endPoint = "")
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                _BindingSource.DataSource = HelperRestSharp.GetListOdata<T>(EndPoint, OdataSelect, OdataExpand);
                _TreeList.ExpandAll();
            }
            catch (Exception)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        protected virtual void InitializeComponentAfter<T>()
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                this.Text = "Daftar " + this.FormTitle;
                this.ObjectBaseClass = new BaseClass<T>(this.EndPoint);
                ActionRefresh<T>();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ActionRefresh();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionNew();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionEdit();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ActionDelete();
        }

        private void bbiCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ActionCopy();
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionPrintPreview();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiExportCsv_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionExport(ExportType.Csv);
        }

        private void bbiExportPdf_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionExport(ExportType.Pdf);
        }

        private void bbiExportHtml_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionExport(ExportType.Html);
        }

        private void bbiExportXls_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionExport(ExportType.Xls);
        }

        private void bbiExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionExport(ExportType.Xlsx);
        }

        private void bbiExportDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionExport(ExportType.Doc);
        }

        private void bbiExportDocX_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionExport(ExportType.Docx);
        }
        protected virtual void ActionExport(ExportType exportType)
        {

            string name = this.FormTitle + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string path = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + $"{name}." + exportType;
            switch (exportType)
            {
                case ExportType.Csv:
                    _TreeList.ExportToCsv(path);
                    break;
                case ExportType.Pdf:
                    _TreeList.ExportToPdf(path);
                    break;
                case ExportType.Html:
                    _TreeList.ExportToHtml(path);
                    break;
                case ExportType.Xls:
                    _TreeList.ExportToXls(path);
                    break;
                case ExportType.Xlsx:
                    _TreeList.ExportToXlsx(path);
                    break;
                case ExportType.Doc:
                    _TreeList.ExportToDocx(path);
                    break;
                case ExportType.Docx:
                    _TreeList.ExportToDocx(path);
                    break;
                default:
                    break;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });

        }

        protected virtual void ActionPrintPreview()
        {
            _TreeList.ShowRibbonPrintPreview();
        }
    }
}
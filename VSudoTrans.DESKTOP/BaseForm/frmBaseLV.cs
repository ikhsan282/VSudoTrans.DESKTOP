using VSudoTrans.DESKTOP.Utils;
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
using DevExpress.XtraTreeList;

namespace VSudoTrans.DESKTOP.BaseForm
{
    public partial class frmBaseLV : DevExpress.XtraBars.Ribbon.RibbonForm
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

        public frmBaseLV()
        {
            InitializeComponent();
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControl, fNextPage: true, fNext: true, fPrev: true, fPrevPage: true);
            SearchControlHelper.InitializeSearchControl(_SearchControl);
            _GridView.DoubleClick += _GridView_DoubleClick;
        }

        private void _GridView_DoubleClick(object sender, EventArgs e)
        {
            var ea = e as DevExpress.Utils.DXMouseEventArgs;
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var info = view.CalcHitInfo(ea.Location);
            if (info.InDataRow) ActionEdit();
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
                var selectedRows = _GridView.GetFocusedRow();

                //result = selectedRows;
                if (_GridControl.DataSource.GetType().ToString() == "DevExpress.Data.VirtualServerModeSource")
                {
                    if (_GridView.GetFocusedRow() == null)
                    {
                        MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                        return null;
                    }
                    result = _GridView.GetFocusedRow();
                }
                else
                {
                    // code dibawah bila menggunakan bawaan OdataInstantSource nya si devexpress
                    if (_GridView.GetFocusedRow().GetType().FullName == "DevExpress.Data.NotLoadedObject")
                    {
                        MessageHelper.ShowMessageError(this, MessageHelper.MessageWaitLoadingData);
                        return null;
                    }
                    result = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)_GridView.GetFocusedRow()).OriginalRow;
                }
                return result;
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
                if (GridControlDataSourceType == GridControlDataSource.OdataInstantFeedback)
                    ActionRefresh_OdataInstantFeedbackSource<T>();
                else
                    ActionRefresh_InfiniteScroll<T>();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        protected virtual void ActionRefresh_InfiniteScroll<T>()
        {
            try
            {
                var source =(this.ObjectBaseClass as BaseClass<T>).GetEntities(OdataSelect, OdataFilter, OdataExpand, null);
                _GridControl.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
        }

        protected virtual void ActionRefresh_OdataInstantFeedbackSource<T>()
        {
            try
            {
                var source = (this.ObjectBaseClass as BaseClass<T>).GetOdataInstantFeedbackSource(EndPoint, OdataExpand, OdataSelect, OdataFilter, OdataFixedCriteria);
                _GridControl.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);

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
                GridHelper.GridViewInitializeLayout(this._GridView);
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
                    _GridControl.ExportToCsv(path);
                    break;
                case ExportType.Pdf:
                    _GridControl.ExportToPdf(path);
                    break;
                case ExportType.Html:
                    _GridControl.ExportToHtml(path);
                    break;
                case ExportType.Xls:
                    _GridControl.ExportToXls(path);
                    break;
                case ExportType.Xlsx:
                    _GridControl.ExportToXlsx(path);
                    break;
                case ExportType.Doc:
                    _GridControl.ExportToDocx(path);
                    break;
                case ExportType.Docx:
                    _GridControl.ExportToDocx(path);
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
            _GridControl.ShowRibbonPrintPreview();
        }
    }

    public class BaseClass<T>
    {
        public BaseClass(string endpoint) //, string select, string filter, string expand, string sort
        {
            this._uri = ApplicationSettings.Instance.UriHelper.UrlApiDefault;
            this.EndPoint = endpoint;

            this._OdataServiceContext = new DataServiceContext(new Uri(_uri));
        }

        public BaseClass(string uri, string endpoint) //, string select, string filter, string expand, string sort
        {
            this._uri = uri;
            this.EndPoint = endpoint;

            this._OdataServiceContext = new DataServiceContext(new Uri(_uri));
        }

        private int _CurrentCount;
        private const int _BatchCount = 20;

        private readonly string _uri;
        public string EndPoint { get; }

        private string _select { get; set; }
        private string _expand { get; set; }
        // this one is filter from constructor
        private string _filter { get; set; }
        // this one is sort from constructor
        private string _sort { get; set; }

        private readonly DataServiceContext _OdataServiceContext;
        public DataServiceContext ODataServiceContext
        {
            get
            {
                return _OdataServiceContext;
            }
        }

        public ODataInstantFeedbackSource GetOdataInstantFeedbackSource
        (
            string fEndpoint,
            string fExpand = null,
            string fSelect = null,
            string fFilter = null,
            CriteriaOperator fCriteriaOperator = null
        )
        {
            var source = new ODataInstantFeedbackSource();

            if (!ReferenceEquals(fCriteriaOperator, null))
            {
                source.FixedFilterCriteria = fCriteriaOperator;
            }

            var context = _OdataServiceContext;
            var query = context.CreateQuery<T>(fEndpoint);

            if (string.IsNullOrEmpty(fSelect) == true)
            {
                fSelect = "id,code,name";
            }
            query = query.AddQueryOption("$select", fSelect);
            if (string.IsNullOrEmpty(fExpand) == false)
            {
                query = query.AddQueryOption("$expand", fExpand);
            }

            if (string.IsNullOrEmpty(fFilter) == false)
            {
                query = query.AddQueryOption("$filter", fFilter);
            }

            // add event
            source.GetSource += (d, e) =>
            {
                e.KeyExpressions = new string[] { "Id" };
                e.Query = query;
                e.Tag = context;
            };
            source.GetSource += (d, e) =>
            {
                DataServiceContext container = (DataServiceContext)e.Tag;
            };

            return source;
        }

        public VirtualServerModeSource GetEntities(string select, string filter, string expand, string sort)
        {
            var source = new VirtualServerModeSource();
            source.RowType = typeof(T);

            source.MoreRows += SourceOnMoreRows;
            source.ConfigurationChanged += SourceOnConfigurationChanged;

            this._select = select;
            this._filter = filter;
            this._expand = expand;
            this._sort = sort;

            return source;
        }

        private void SourceOnConfigurationChanged(object sender, VirtualServerModeRowsEventArgs e)
        {
            _CurrentCount = 0;
        }

        private void SourceOnMoreRows(object sender, VirtualServerModeRowsEventArgs e)
           => e.RowsTask = Task.Factory.StartNew((Func<VirtualServerModeRowsTaskResult>)(() =>
           {
               var list = HelperRestSharp.LoadMoreDatas<T>(e.ConfigurationInfo, this.EndPoint, this._select, this._expand, this._filter, this._sort, _BatchCount, _CurrentCount).ToArray();

               var currentBatchCount = list.Length;
               var moreRows = currentBatchCount >= _BatchCount;
               _CurrentCount += currentBatchCount;

               return new VirtualServerModeRowsTaskResult(list, moreRows);

           }), e.CancellationToken);
    }
}
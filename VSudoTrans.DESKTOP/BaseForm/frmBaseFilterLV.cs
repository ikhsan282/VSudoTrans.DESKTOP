using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using VSudoTrans.DESKTOP.Utils;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Threading;
using System.Drawing;

namespace VSudoTrans.DESKTOP.BaseForm
{
    public partial class frmBaseFilterLV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected OverlayTextPainterTwoLevelEx overlayLabelTitle;
        protected OverlayTextPainterTwoLevelEx overlayLabelPercentage;
        protected CancellationTokenSource cancellationTokenSource;
        public frmBaseFilterLV()
        {
            InitializeComponent();
            GridHelper.GridControlInitializeEmbeddedNavigator(_GridControl, fNextPage: true, fNext: true, fPrev: true, fPrevPage: true);
            SearchControlHelper.InitializeSearchControl(_SearchControl);

            _GridView.DoubleClick += _GridView_DoubleClick;

            this.overlayLabelTitle = new OverlayTextPainterTwoLevelEx(OverlayTextPainterTwoLevelTextPosition.Title);
            this.overlayLabelTitle.Text = "Harap menunggu ...";
            this.overlayLabelTitle.Font = new Font(this.Appearance.Font.OriginalFontName, 10, FontStyle.Bold);

            this.overlayLabelPercentage = new OverlayTextPainterTwoLevelEx(OverlayTextPainterTwoLevelTextPosition.Percentage);
            this.overlayLabelPercentage.Font = this.Appearance.Font;
        }

        private void _GridView_DoubleClick(object sender, EventArgs e)
        {
            var ea = e as DevExpress.Utils.DXMouseEventArgs;
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var info = view.CalcHitInfo(ea.Location);
            if (info.InDataRow) ActionEdit();
        }

        protected object OdataEntity { get; set; }
        protected object ObjectBaseClass { get; set; }
        protected object EntityId { get; set; }
        protected string EndPoint { get; set; }
        protected string OdataSelect { get; set; }
        protected string OdataFilter { get; set; }
        protected string OdataExpand { get; set; }
        protected CriteriaOperator OdataFixedCriteria { get; set; }
        protected GridControlDataSource GridControlDataSourceType = GridControlDataSource.VirtualMode;
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

        protected virtual bool ActionValidate()
        {
            bool result = false;
            bool resultAddition = false;

            _BindingSource.EndEdit();

            // validate default validation
            result = _DxValidationProvider.Validate();

            foreach (var control in _DxValidationProvider.GetInvalidControls())
            {
                var validationRuleBase = _DxValidationProvider.GetValidationRule(control);
                if (validationRuleBase.ErrorType == ErrorType.Critical)
                {
                    MessageHelper.ShowMessageError(this, "Terdapat inputan data yang tidak valid");
                    return result;
                }
            }

            resultAddition = InitializeAdditionalValidation();

            foreach (var control in _DxValidationProvider.GetInvalidControls())
            {
                var validationRuleBase = _DxValidationProvider.GetValidationRule(control);
                if (validationRuleBase.ErrorType == ErrorType.Critical)
                {
                    MessageHelper.ShowMessageError(this, "Terdapat inputan data yang tidak valid");
                    return resultAddition;
                }
            }

            //Cek validate
            if (result && resultAddition)
                return true;
            else
                return false;
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

        protected object GetDataRowSelected()
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
                    var row = _GridView.GetFocusedRow();
                    if (row != null)
                    {
                        // code dibawah bila menggunakan bawaan OdataInstantSource nya si devexpress
                        if (_GridView.GetFocusedRow().GetType().FullName == "DevExpress.Data.NotLoadedObject")
                        {
                            MessageHelper.ShowMessageError(this, MessageHelper.MessageWaitLoadingData);
                            return null;
                        }
                        result = ((DevExpress.Data.Async.Helpers.ReadonlyThreadSafeProxyForObjectFromAnotherThread)_GridView.GetFocusedRow()).OriginalRow;
                    }
                    else
                        return null;
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

            try
            {
                HelperRestSharp.Delete(AssemblyHelper.GetValueProperty(delete, "Id"), this.EndPoint);

                //notif 
                MessageHelper.ShowMessageInformation(this, $"Data berhasil di hapus!");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex.Message);
            }

            ActionRefresh<T>();
        }

        protected virtual void InitializeComponentAfter<T>()
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                this.Text = "Daftar " + this.FormTitle;
                this.ObjectBaseClass = new BaseClass<T>(this.EndPoint);
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
                var source = (this.ObjectBaseClass as BaseClass<T>).GetEntities(OdataSelect, OdataFilter, OdataExpand, null);
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


        protected virtual void ActionShowFormDetail(object fCopy = null)
        {
            try
            {
                if (FormDetail != null)
                {
                    if (string.IsNullOrEmpty(FormDetail.Text))
                        FormDetail.Text = FormTitle;
                    FormDetail.MdiParent = MdiParent;
                    FormDetail.Show();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
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
            Process.Start(path);
        }

        protected virtual void ActionPrintPreview()
        {
            _GridControl.ShowRibbonPrintPreview();
        }
        protected virtual void InitializeSearchLookup()
        {

        }

        protected virtual void InitializeDefaultValidation()
        {

        }

        protected virtual bool InitializeAdditionalValidation()
        {
            return true;
        }
    }
}
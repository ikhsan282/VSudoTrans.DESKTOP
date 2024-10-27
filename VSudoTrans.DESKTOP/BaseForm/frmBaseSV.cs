using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using VSudoTrans.DESKTOP.Utils;
using DevExpress.Data.Filtering;
using PopUpUtils;
using System.IO;
using DevExpress.XtraPivotGrid;

namespace VSudoTrans.DESKTOP.BaseForm
{
    public partial class frmBaseSV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmBaseSV()
        {
            InitializeComponent();
        }
        protected object OdataEntity { get; set; }
        protected object ObjectBaseClass { get; set; }
        protected object EntityId { get; set; }
        protected string EndPoint { get; set; }
        protected string OdataSelect { get; set; }
        protected string OdataFilter { get; set; }
        protected string OdataExpand { get; set; }
        protected object DataSource { get; set; }
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

        protected virtual void InitializeComponentAfter<T>()
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                this.Text = "Daftar " + this.FormTitle;
                this.ObjectBaseClass = new BaseClass<T>(this.EndPoint);
                //ActionRefresh<T>();

                InitializeParameter();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        protected virtual void ActionRefresh<T>()
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                var source = HelperRestSharp.GetListOdata<T>(EndPoint, OdataSelect, OdataExpand, OdataFilter);
                this.DataSource = source;

                _spreadsheetControl.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.Default);
                _spreadsheetControl.ActiveWorksheet.Clear(_spreadsheetControl.ActiveWorksheet.GetDataRange());

                WoorkbookConfiguration();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        protected virtual void WoorkbookConfiguration()
        {

        }

        protected virtual void ActionPrintPreview()
        {
            _spreadsheetControl.ShowRibbonPrintPreview();
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

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            ActionPrintPreview();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        protected virtual void InitializeParameter()
        {
            _LayoutControlItemFilter1.Text = "Tanggal Mulai";
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            _LayoutControlItemFilter2.Text = "Tanggal Selesai";
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);
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
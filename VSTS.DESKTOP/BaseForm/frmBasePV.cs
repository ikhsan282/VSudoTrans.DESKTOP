using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using VSTS.DESKTOP.Utils;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using PopUpUtils;
using System.IO;
using DevExpress.XtraPivotGrid;
using Domain.Entities.Identity;
using DevExpress.XtraEditors.DXErrorProvider;

namespace VSTS.DESKTOP.BaseForm
{
    public partial class frmBasePV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmBasePV()
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
                this.Text = "Laporan " + this.FormTitle;
                this.ObjectBaseClass = new BaseClass<T>(this.EndPoint);
                //ActionRefresh<T>();

                InitializeCustomGrid();
                InitializeParameter();
                Loadlayout();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
            }
        }

        protected virtual void InitializeCustomGrid()
        {
            _pivotGridControl.BestFit();

        }
        private void Loadlayout()
        {
            var user = ApplicationSettings.Instance.ApplicationUser.UserName;
            var basenameFile = EndPoint + this.Name.Substring(3, 3) + ".xml";
            var path = ApplicationSettings.Instance.PathMyDocument + "\\VSTS" + "\\LAYOUT" + $"\\{user}" + $"\\{basenameFile}";

            if (File.Exists(path))
            {
                _pivotGridControl.RestoreLayoutFromXml(path);
            }
        }
        private void bbiResetLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            var confirm = MessageHelper.ShowMessageQuestion(this, "Reset layout");
            if (confirm != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            var user = ApplicationSettings.Instance.ApplicationUser.UserName;
            var basenameFile = EndPoint + this.Name.Substring(3, 3) + ".xml";
            var path = ApplicationSettings.Instance.PathMyDocument + "\\VSTS" + "\\LAYOUT" + $"\\{user}" + $"\\{basenameFile}";
            if (File.Exists(path))
            {
                File.Delete(path);

                //bbiRefresh.PerformClick();


            }
        }

        protected virtual void ActionRefresh<T>()
        {
            MessageHelper.WaitFormShow(this);
            try
            {
                var source = HelperRestSharp.GetListOdata<T>(EndPoint, OdataSelect, OdataExpand, OdataFilter);
                _pivotGridControl.DataSource = source;
                _pivotGridControl.BestFit();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageHelper.WaitFormClose(this);
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
                    _pivotGridControl.OptionsPrint.MergeRowFieldValues = false;
                    _pivotGridControl.ExportToCsv(path);
                    break;
                case ExportType.Pdf:
                    _pivotGridControl.ExportToPdf(path);
                    break;
                case ExportType.Html:
                    _pivotGridControl.ExportToHtml(path);
                    break;
                case ExportType.Xls:
                    PivotXlsExportOptions optionsXls = new DevExpress.XtraPivotGrid.PivotXlsExportOptions();
                    optionsXls.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    _pivotGridControl.OptionsPrint.MergeRowFieldValues = false;
                    _pivotGridControl.ExportToXls(path, optionsXls);
                    break;
                case ExportType.Xlsx:
                    PivotXlsxExportOptions optionsXlsx = new DevExpress.XtraPivotGrid.PivotXlsxExportOptions();
                    optionsXlsx.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    _pivotGridControl.OptionsPrint.MergeRowFieldValues = false;
                    _pivotGridControl.ExportToXlsx(path, optionsXlsx);
                    break;
                case ExportType.Doc:
                    _pivotGridControl.ExportToDocx(path);
                    break;
                case ExportType.Docx:
                    _pivotGridControl.ExportToDocx(path);
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
            _pivotGridControl.ShowRibbonPrintPreview();
        }

        protected virtual void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);
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

        protected virtual void InitializeDefaultValidation()
        {

        }

        protected virtual bool InitializeAdditionalValidation()
        {
            return true;
        }
    }
}
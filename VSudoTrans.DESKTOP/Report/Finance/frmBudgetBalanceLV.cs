using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraSplashScreen;
using Domain.Entities.Organization;
using Domain.Entities.SQLProc;
using PopUpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;

namespace VSudoTrans.DESKTOP.Report.Finance
{
    public partial class frmBudgetBalanceLV : frmBaseFilterLV
    {
        public frmBudgetBalanceLV()
        {
            InitializeComponent();

            EndPoint = "/SQLProcedures/BudgetTransactionResults";
            FormTitle = "Buku KAS";

            OdataSelect = "";
            OdataExpand = "";

            InitializeComponentAfter<BudgetTransactionResult>();

            InitializeSearchLookup();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;

            FilterDate1.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            FilterDate2.EditValue = new DateTime(DateTime.Today.Year, 12, 31);

            GridHelper.GridColumnInitializeLayout(colDate, typeof(DateTime), "dd-MMM-yyyy");
            GridHelper.GridColumnInitializeLayout(colPenerimaan, typeof(decimal), "n0", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colPengeluaran, typeof(decimal), "n0", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colSaldo, typeof(decimal), "n0");

            DisableAllButton();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<BudgetTransactionResult>();
        }

        protected override void ActionEdit()
        {

        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate1, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate2, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeSearchLookup()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter1.Text = "Tanggal Mulai";
            HelperConvert.FormatDateEdit(FilterDate1);

            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter2.Text = "Tanggal Selesai";
            HelperConvert.FormatDateEdit(FilterDate2);

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            var company = FilterPopUp3.EditValue as Company;

            _BindingSource.DataSource = null;
            _GridControl.DataSource = null;
            _GridControl.DataSource = HelperRestSharp.GetListOdata<BudgetTransactionResult>($"/SQLProcedures/BudgetTransactionResults(CompanyId={company.Id}, FromDate={HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-dd")}, ToDate={HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-dd")})", "");


            //_GridControl.DataSource = null;
            //List<BudgetTransactionResult> results = new List<BudgetTransactionResult>();

            //string taskResult = "";
            //cancellationTokenSource = new CancellationTokenSource();

            //IOverlaySplashScreenHandle overlayHandle = SplashScreenManager.ShowOverlayForm(this, customPainter: new OverlayWindowCompositePainter(overlayLabelTitle, overlayLabelPercentage));
            //try
            //{
            //    await Task.Run(() =>
            //    {
            //        try
            //        {
            //            results = HelperRestSharp.GetListOdata<BudgetTransactionResult>($"/SQLProcedures/BudgetTransactionResults(CompanyId={company.Id}, FromDate={HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-dd")}, ToDate={HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-dd")})", "");
            //        }
            //        catch (Exception ex)
            //        {
            //            taskResult = ex.Message;
            //            if (ex.InnerException != null)
            //            {
            //                taskResult = taskResult + ";" + ex.InnerException.Message;
            //            }
            //            cancellationTokenSource.Cancel();
            //            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            //        }

            //    }, cancellationTokenSource.Token);
            //}
            //catch (OperationCanceledException)
            //{
            //    taskResult = "Operation is Cancelled; " + taskResult;
            //}
            //finally
            //{
            //    SplashScreenManager.CloseOverlayForm(overlayHandle);
            //}

            //if (taskResult != "") MessageHelper.ShowMessageError(this, taskResult);

            //if (taskResult != "")
            //    MessageHelper.ShowMessageError(this, taskResult);
            //else
            //{
            //    if (results.Any())
            //    {
            //        _BindingSource.DataSource = results;
            //        _GridControl.DataSource = results;
            //    }
            //    else
            //    {
            //        _BindingSource.DataSource = null;
            //        _GridControl.DataSource = null;
            //        MessageHelper.ShowMessageError(this, "Data tidak ditemukan.");
            //    }
            //}
        }

        private void DisableAllButton()
        {
            this.bbiNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiNew.Enabled = false;
            this.bbiEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiEdit.Enabled = false;
            this.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiDelete.Enabled = false;
            this.bbiCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiCopy.Enabled = false;

            bbiRefresh.Enabled = true;
        }
    }
}

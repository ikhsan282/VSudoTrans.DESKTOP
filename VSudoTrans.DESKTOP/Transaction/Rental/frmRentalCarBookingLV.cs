using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using Domain;
using Domain.Entities.Rental;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System;
using System.Drawing;
using VSudoTrans.DESKTOP.Report.Rental;
using Domain.Entities.Organization;

namespace VSudoTrans.DESKTOP.Transaction.Rental
{
    public partial class frmRentalCarBookingLV : frmBaseFilterLV
    {
        public frmRentalCarBookingLV()
        {
            InitializeComponent();

            this.EndPoint = "/RentalCarBookings";
            this.FormTitle = "Pemesanan Sewa Kendaraan";

            this.OdataSelect = "Id,Date,Time,TotalPrice,BBM,TotalOperationalCost,TotalPayment";
            this.OdataExpand = "Company($select=name)";
            this.OdataExpand += ",PickupPointCity($select=name),DeliveryPointCity($select=name)";
            this.OdataExpand += ",Passenger($select=Name,PhoneNumber)";
            this.OdataExpand += ",Vehicle($select=VehicleNumber)";
            this.OdataExpand += ",RentalCarBookingEmployees($select=EmployeeId,Amount;$expand=Employee($select=Code,Name))";
            this.OdataExpand += ",RentalCarBookingPayments($select=PaymentMethod,Date,Amount)";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<RentalCarBooking>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;

            GridHelper.GridColumnInitializeLayout(colDate, typeof(DateTime));
            GridHelper.GridColumnInitializeLayout(colTime, typeof(TimeSpan), "hh:mm");
            GridHelper.GridColumnInitializeLayout(colBBM, typeof(decimal), "n0", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colTotalOperationalCost, typeof(decimal), "n0", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colTotalPayment, typeof(decimal), "n0", fTotal: true);
            GridHelper.GridColumnInitializeLayout(colTotalPrice, typeof(decimal), "n0", fTotal: true);
            _GridView.OptionsView.ShowFooter = true;
            _GridView.OptionsView.ColumnAutoWidth = false;


            GridHelper.GridViewInitializeLayout(_GridViewEmployee);
            _GridViewEmployee.OptionsView.ShowFooter = true;
            _GridViewEmployee.ViewCaption = "Sopir/Kernet/Montir";
            GridHelper.GridColumnInitializeLayout(colAmount, typeof(decimal), "n2", fTotal: true);

            GridHelper.GridViewInitializeLayout(_GridViewPayment);
            _GridViewPayment.OptionsView.ShowFooter = true;
            _GridViewPayment.ViewCaption = "Pembayaran";
            GridHelper.GridColumnInitializeLayout(colDatePayment, typeof(DateTime));
            GridHelper.GridColumnInitializeLayout(colAmountPayment, typeof(decimal), "n2", fTotal: true);

            _GridView.CustomDrawCell += _GridView_CustomDrawCell;
            _GridView.RowCellStyle += _GridView_RowCellStyle;

            bbiPrintInvoice.ItemClick += BbiPrintInvoice_ItemClick;

            InitializeSearchLookup();
        }

        private void BbiPrintInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EntityId = GetIdOfDataRowSelected();
            if (EntityId == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }

            var formDetail = new frmRentalCarBookingInvoiceLV(HelperConvert.Int(this.EntityId));

            try
            {
                if (formDetail != null)
                {
                    formDetail.MdiParent = MdiParent;
                    formDetail.Show();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageError(this, ex);
            }
        }

        private void _GridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var totalPrice = HelperConvert.Decimal(_GridView.GetRowCellValue(e.RowHandle, colTotalPrice));
            var totalPayment = HelperConvert.Decimal(_GridView.GetRowCellValue(e.RowHandle, colTotalPayment));
            if (totalPayment >= totalPrice)
                e.Appearance.BackColor = Color.LightGreen;
            else if (totalPayment < totalPrice && totalPayment != 0)
                e.Appearance.BackColor = Color.LightYellow;
            else
                e.Appearance.BackColor = Color.LightPink;
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

            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter2.Text = "Tanggal Akhir";

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Perusahaan";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            InitializeDefaultValidation();
            if (!ActionValidate())
                return;

            Company company = FilterPopUp3.EditValue as Company;
            int iStartDate = HelperConvert.Int(HelperConvert.Date(FilterDate1.EditValue).ToString("yyyyMMdd"));
            int iEndDate = HelperConvert.Int(HelperConvert.Date(FilterDate2.EditValue).ToString("yyyyMMdd"));

            if (company != null && iStartDate > 0 && iEndDate > 0)
            {
                this.OdataFilter = $"CompanyId eq {company.Id} ";
                this.OdataFilter += $"and IDate ge {iStartDate} and IDate le {iEndDate}";
            }

            base.ActionRefresh<T>(endPoint);
        }

        private void _GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue != DBNull.Value && e.CellValue != null)
            {
                if (e.Column.FieldName.Contains("Time"))
                    e.DisplayText = ((TimeSpan)e.CellValue).ToString(@"hh\:mm");
            }
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<RentalCarBooking>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<RentalCarBooking>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmRentalCarBookingDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

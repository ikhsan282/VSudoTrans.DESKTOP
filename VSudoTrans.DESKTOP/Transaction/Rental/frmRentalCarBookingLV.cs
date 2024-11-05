using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using Domain;
using Domain.Entities.Rental;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using PopUpUtils;
using System;

namespace VSudoTrans.DESKTOP.Transaction.Rental
{
    public partial class frmRentalCarBookingLV : frmBaseFilterLV
    {
        public frmRentalCarBookingLV()
        {
            InitializeComponent();

            this.EndPoint = "/RentalCarBookings";
            this.FormTitle = "Pemesanan Sewa Mobil";

            this.OdataSelect = "Id,Date,Time,Status,TotalPrice";
            this.OdataExpand = "Company($select=name)";
            this.OdataExpand += ",PickupPointCity($select=name),DeliveryPointCity($select=name)";
            this.OdataExpand += ",Passenger($select=Name,PhoneNumber)";
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
            GridHelper.GridColumnInitializeLayout(colTotalPrice, typeof(decimal), "n0");

            _GridView.CustomDrawCell += _GridView_CustomDrawCell;

            //bbiPrintETicket.ItemClick += BbiPrintETicket_ItemClick;

            InitializeSearchLookup();
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
            this.OdataFilter = $"Date ge {HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-dd")} and Date le {HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-dd")}";

            if (FilterPopUp3.EditValue != null)
                OdataFilter += $" and CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>(endPoint);
        }

        private void BbiPrintETicket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EntityId = GetIdOfDataRowSelected();
            if (EntityId == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }

            //var formDetail = new frmETicketRentalCarBookingLV(HelperConvert.Int(this.EntityId));

            //try
            //{
            //    if (formDetail != null)
            //    {
            //        formDetail.MdiParent = MdiParent;
            //        formDetail.Show();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageHelper.ShowMessageError(this, ex);
            //}
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

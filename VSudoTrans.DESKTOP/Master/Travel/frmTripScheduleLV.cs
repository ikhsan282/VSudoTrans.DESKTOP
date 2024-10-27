using DevExpress.XtraGrid.Views.Base;
using Domain.Entities.Travel;
using VSudoTrans.DESKTOP.BaseForm;
using VSudoTrans.DESKTOP.Utils;
using System;
using System.Linq;
using VSudoTrans.DESKTOP.Report.Travel;
using DevExpress.XtraEditors.DXErrorProvider;
using PopUpUtils;

namespace VSudoTrans.DESKTOP.Master.Travel
{
    public partial class frmTripScheduleLV : frmBaseFilterLV
    {
        public frmTripScheduleLV()
        {
            InitializeComponent();

            this.EndPoint = "/TripSchedules";
            this.FormTitle = "Surat Perintah Jalan";

            this.OdataSelect = "Id,Date,StartTime,EndTime";
            this.OdataExpand = "Company($select=name)";
            this.OdataExpand += ",Employee($select=name)";
            this.OdataExpand += ",PickupPointCity($select=Name)";
            this.OdataExpand += ",DeliveryPointCity($select=Name)";
            this.OdataExpand += ",TripScheduleDetails($select=LineNumberPickup,LineNumberDelivery;$expand=TravelTicketBooking($select=Time,PickupAddress,PickupPointCityId,DeliveryPointCityId,DeliveryAddress,Status,PaymentType,TotalTicket,TotalPrice))";
            this.OdataExpand += ",Vehicle($select=VehicleNumber;$expand=Brand($select=name),ModelUnit($select=name))";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<TripSchedule>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
            bbiDelete.ItemClick += BbiDelete_ItemClick;

            GridHelper.GridViewInitializeLayout(_GridViewDetail);
            _GridViewDetail.ViewCaption = "Detail Penumpang";

            GridHelper.GridColumnInitializeLayout(colDate, typeof(DateTime));
            GridHelper.GridColumnInitializeLayout(colStartTime, typeof(TimeSpan), "hh:mm");
            GridHelper.GridColumnInitializeLayout(colEndTime, typeof(TimeSpan), "hh:mm");
            GridHelper.GridColumnInitializeLayout(colTravelTicketBookingTime, typeof(TimeSpan), "hh:mm");
            GridHelper.GridColumnInitializeLayout(colTravelTicketBookingTotalPrice, typeof(decimal), "n0");
            GridHelper.GridColumnInitializeLayout(colTravelTicketBookingTotalTicket, typeof(decimal), "n0");

            HelperConvert.FormatTimeEdit(TravelTicketBookingTimeDateEdit, "HH:mm");

            _GridView.CustomDrawCell += _GridView_CustomDrawCell;
            _GridViewDetail.CustomDrawCell += _GridViewDetail_CustomDrawCell;

            bbiPrintESPJ.ItemClick += BbiPrintESPJ_ItemClick;

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
            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>(string endPoint = "")
        {
            this.OdataFilter = $"Date ge {HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-dd")} and Date le {HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-dd")}";

            if (FilterPopUp3.EditValue != null)
                OdataFilter += $" and CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>(endPoint);
        }

        private void BbiPrintESPJ_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EntityId = GetIdOfDataRowSelected();
            if (EntityId == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }

            var formDetail = new frmESPJTripScheduleLV(HelperConvert.Int(this.EntityId));

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

        private void BbiPrintETicket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EntityId = GetIdOfDataRowSelected();
            if (EntityId == null)
            {
                MessageHelper.ShowMessageError(this, MessageHelper.MessagePleaseSelect);
                return;
            }

            //var formDetail = new frmETicketTripScheduleLV(HelperConvert.Int(this.EntityId));

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

        private void _GridViewDetail_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue != DBNull.Value && e.CellValue != null)
            {
                //if (e.Column.FieldName.Contains("Time"))
                //    e.DisplayText = ((TimeSpan)e.CellValue).ToString(@"hh\:mm");

                if (e.Column.FieldName.Contains("TravelTicketBooking.PickupPointCityId") || e.Column.FieldName.Contains("TravelTicketBooking.DeliveryPointCityId"))
                {
                    //var city = ApplicationSettings.Instance.Citys.Where(s => s.Id == HelperConvert.Int(e.CellValue)).FirstOrDefault();
                    //if (city != null)
                    //    e.DisplayText = city.Name;
                }
            }
        }

        private void _GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue != DBNull.Value && e.CellValue != null)
            {
                if (e.Column.FieldName.Contains("StartTime"))
                    e.DisplayText = ((TimeSpan)e.CellValue).ToString(@"hh\:mm");

                if (e.Column.FieldName.Contains("EndTime"))
                    e.DisplayText = ((TimeSpan)e.CellValue).ToString(@"hh\:mm");
            }
        }

        private void BbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionDelete<TripSchedule>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<TripSchedule>();
        }

        protected override void ActionShowFormDetail(object fCopy = null)
        {
            FormDetail = new frmTripScheduleDV(this.EntityId, this.EndPoint, fCopy);
            base.ActionShowFormDetail();
        }
    }
}

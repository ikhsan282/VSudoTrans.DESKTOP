using DevExpress.XtraEditors.DXErrorProvider;
using Domain.Entities.Travel;
using VSTS.DESKTOP.BaseForm;
using VSTS.DESKTOP.Utils;
using PopUpUtils;
using System;

namespace VSTS.DESKTOP.Report.Travel
{
    public partial class frmTravelTicketBookingPV : frmBasePV
    {
        public frmTravelTicketBookingPV()
        {
            InitializeComponent();

            this.EndPoint = "/TravelTicketBookings";
            this.FormTitle = "Laporan Data Pemesanan Tiket Perjalanan";

            this.OdataSelect = "Id,Date,Time,PaymentType,Status,TotalTicket,TotalPrice";
            this.OdataExpand = "Company($select=name)";
            this.OdataExpand += ",PickupPointCity($select=name),DeliveryPointCity($select=name)";
            //this.OdataExpand += ",TravelTicketBookingDetails($select=PassengerType,Price;$expand=Passenger($select=name,PhoneNumber))";

            HelperConvert.FormatDateEdit(FilterDate1);
            HelperConvert.FormatDateEdit(FilterDate2);

            FilterDate1.EditValue = DateTime.Today.AddMonths(-1);
            FilterDate2.EditValue = DateTime.Today;

            InitializeComponentAfter<TravelTicketBooking>();

            bbiRefresh.ItemClick += BbiRefresh_ItemClick;
        }

        protected override void InitializeDefaultValidation()
        {
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate1, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterDate2, ConditionOperator.IsNotBlank);
            MyValidationHelper.SetValidation(_DxValidationProvider, this.FilterPopUp3, ConditionOperator.IsNotBlank);
        }

        protected override void InitializeParameter()
        {
            _LayoutControlItemFilter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter1.Text = "Tanggal Mulai";

            _LayoutControlItemFilter2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter2.Text = "Tanggal Akhir";

            _LayoutControlItemFilter3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            _LayoutControlItemFilter3.Text = "Sekolah";
            PopupEditHelper.Company(FilterPopUp3);
        }

        protected override void ActionRefresh<T>()
        {
            this.OdataFilter = $"Date ge {HelperConvert.Date(FilterDate1.EditValue).ToString("yyyy-MM-dd")} and Date le {HelperConvert.Date(FilterDate2.EditValue).ToString("yyyy-MM-dd")}";

            if (FilterPopUp3.EditValue != null)
                OdataFilter += $" and CompanyId eq {HelperConvert.Int(AssemblyHelper.GetValueProperty(FilterPopUp3.EditValue, "Id"))} ";

            base.ActionRefresh<T>();
        }

        private void BbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActionRefresh<TravelTicketBooking>();
        }
    }
}
